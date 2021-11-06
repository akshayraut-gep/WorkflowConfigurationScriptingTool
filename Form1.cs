using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkflowConfigurationScriptingTool.Implementations;
using WorkflowConfigurationScriptingTool.Interfaces;

namespace WorkflowConfigurationScriptingTool
{
    public partial class Form1 : Form
    {
        DataTable _queriesTable;
        string sqlQueryTemplateForStep = "DECLARE @JobId INT = {JobId}, @StageId INT = {StageId}, @EventId INT = {EventId};\n";
        string sqlQueryTemplateForStepInsert = "INSERT INTO SSDL.WorkflowEventSetting(JobId, ActivityId, StageId, EventId, SettingName, SettingValue, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn)\n"
                                        + "VALUES(@JobId, 2200, @StageId, null, '{StepName}', '{StepSettingJson}', 1, GETDATE(), 1, GETDATE());\n";
        string sqlQueryTemplateForUpdateExistingStep = "UPDATE SSDL.WorkflowEventSetting"
                                        + "SET\n"
                                        + "\tSettingValue='{StepSettingJson}'\n"
                                        + "WHERE JobId = {JobId} AND StageId = {StageId} AND SettingName = '{StepName}' AND EventId IS NULL AND ParentId IS NULL;\n";
        string sqlQueryTemplateForParentId = "\nDECLARE @ParentId BIGINT;\n"
                                        + "SELECT @ParentId = Id FROM SSDL.WorkflowEventSetting WHERE JobId = @JobId AND StageId = @StageId AND SettingName = '{StepName}';\n";
        string sqlQueryTemplateForTaskInsert = "INSERT INTO SSDL.WorkflowEventSetting(JobId, ActivityId, StageId, EventId, SettingName, SettingValue, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, ParentId)\n"
                                        + "VALUES (@JobId, 2200, @StageId, @EventID, '{TaskName}', '{TaskSettingJson}', 1, GETDATE(), 1, GETDATE(), @ParentId);\n";
        List<QueryType> _queryTypes;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this._queryTypes = new List<QueryType>();
            this._queryTypes.Add(new QueryType(2210, 2211, "Cleanse Data in Source Table"));
            this._queryTypes.Add(new QueryType(2300, 2301, "System Defined Step", true));

            this.cbQueryTypes.DataSource = _queryTypes;
            this.cbQueryTypes.ValueMember = "EventId";
            this.cbQueryTypes.DisplayMember = "DisplayName";
            this.cbQueryTypes.SelectedIndex = -1;
            this.cbQueryTypes.Text = "Select query type";

            this._queriesTable = new DataTable();
            this._queriesTable.Columns.Add("SequenceNo");
            this._queriesTable.Columns["SequenceNo"].DataType = typeof(int);
            this._queriesTable.Columns.Add("QueryName");
            this._queriesTable.Columns.Add("Query");
            this._queriesTable.PrimaryKey = new DataColumn[] { _queriesTable.Columns["QueryName"] };
            this.dgvQueries.DataSource = _queriesTable;

            this.cbQueryTypes.SelectedIndexChanged += this.cbQueryTypes_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbQueryTypes.SelectedIndex < 0)
            {
                MessageBox.Show("Select a query type first");
                return;
            }
            _queriesTable.Rows.Add(_queriesTable.Rows.Count + 1, "", "");
            //NewQuery newQuery = new NewQuery(this);
            //newQuery.ShowDialog();
        }

        public bool OnQuerySave(string name, string query)
        {
            var matchingDataRow = _queriesTable.Rows.Find(name);
            if (matchingDataRow != null)
            {
                MessageBox.Show("A query with same name already exists");
                return false;
            }
            _queriesTable.Rows.Add(_queriesTable.Rows.Count + 1, cbQueryTypes.SelectedValue, name, query);
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_queriesTable == null || _queriesTable.Rows.Count == 0)
            {
                MessageBox.Show("Queries are missing");
                return;
            }

            foreach (DataRow dataRow in _queriesTable.Rows)
            {
                if (dataRow["QueryName"] == null || dataRow["QueryName"] == DBNull.Value || dataRow["QueryName"].ToString().Trim() == "")
                {
                    MessageBox.Show("Query name is missing for one of the queries");
                    return;
                }

                if (dataRow["SequenceNo"] == null || dataRow["SequenceNo"] == DBNull.Value || dataRow["SequenceNo"].ToString().Trim() == "" || (int)dataRow["SequenceNo"] < 1)
                {
                    MessageBox.Show("Sequence number is either missing or invalid for one of the queries");
                    return;
                }
            }

            var diaglogResult = MessageBox.Show("This SQL query will use " + nudSequence.Value.ToString() + " as the position of the Step. If this is correct then click OK otherwise Cancel.", "Confirm", MessageBoxButtons.OKCancel);
            if (diaglogResult == DialogResult.Cancel)
                return;

            var matchingQueryType = _queryTypes.FirstOrDefault(a => a.EventId == (int)cbQueryTypes.SelectedValue);

            StringBuilder sbQueries = new StringBuilder(sqlQueryTemplateForStep);

            if (cbExistingStep.Checked)
                sbQueries.Append(sqlQueryTemplateForUpdateExistingStep);
            else
                sbQueries.Append(sqlQueryTemplateForStepInsert);

            sbQueries.Append(sqlQueryTemplateForParentId);

            sbQueries.Replace("{JobId}", tbJobID.Text);
            sbQueries.Replace("{StageId}", matchingQueryType.StageId.ToString());
            sbQueries.Replace("{EventId}", matchingQueryType.EventId.ToString());
            sbQueries.Replace("{StepName}", tbStepName.Text);

            var stepSetting = new StepTaskJson();
            stepSetting.ChildEventUIDetail = new List<ChildEventUIDetail>();

            foreach (DataRow dataRow in _queriesTable.Rows)
            {
                var childEventUIDetail = new ChildEventUIDetail();
                childEventUIDetail.Name = dataRow["QueryName"].ToString();
                childEventUIDetail.EventId = matchingQueryType.EventId;
                childEventUIDetail.SequenceId = (int)dataRow["SequenceNo"];
                stepSetting.ChildEventUIDetail.Add(childEventUIDetail);


                var jsonValidator = GetJsonEventValidatorByEventId(matchingQueryType.EventId);
                var jsonEvent = jsonValidator.GetJsonEvent(childEventUIDetail.Name, dataRow["Query"].ToString(), childEventUIDetail.SequenceId);
                if (jsonEvent != null)
                {
                    var taskSetting = new StepTaskJson();
                    taskSetting.EventUIDetail = new List<object>();
                    taskSetting.SequenceId = childEventUIDetail.SequenceId;
                    taskSetting.EventUIDetail.Add(jsonEvent);

                    sbQueries.Append(sqlQueryTemplateForTaskInsert);
                    sbQueries.Replace("{TaskName}", childEventUIDetail.Name);
                    var taskSettingJson = JsonConvert.SerializeObject(taskSetting);
                    sbQueries.Replace("{TaskSettingJson}", taskSettingJson);
                }
            }
            stepSetting.SequenceId = (int)nudSequence.Value;
            var stepSettingJson = JsonConvert.SerializeObject(stepSetting);
            sbQueries.Replace("{StepSettingJson}", stepSettingJson);

            tbQueries.Text = sbQueries.ToString();
        }

        private IWorkflowEventJsonValidator GetJsonEventValidatorByEventId(int eventId)
        {
            if (eventId == 2211)
                return new CleansingAtSourceJsonValidator();

            if (eventId == 2301)
                return new SystemDefinedQueryJsonValidator();

            return null;
        }

        private void cbQueryTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQueryTypes.SelectedItem != null)
            {
                var matchingQueryType = _queryTypes.FirstOrDefault(a => a.EventId == (cbQueryTypes.SelectedItem as QueryType).EventId);
                if (matchingQueryType.AllowMultiple)
                {
                    tbStepName.Text = "";
                    tbStepName.ReadOnly = false;
                }
                else
                {
                    tbStepName.ReadOnly = true;
                    tbStepName.Text = matchingQueryType.Name;
                }
            }
        }
    }
}
