using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkflowConfigurationScriptingTool
{
    public partial class NewQuery : Form
    {
        Form1 parentForm;
        public NewQuery(Form1 form1)
        {
            InitializeComponent();
            parentForm = form1;
        }

        private void NewQuery_Load(object sender, EventArgs e)
        {
            tbQuery.Multiline = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbQueryName.Text == null || tbQueryName.Text.Trim() == "")
                MessageBox.Show("Query Name is mandatory");

            if (tbQuery.Text == null || tbQuery.Text.Trim() == "")
                MessageBox.Show("Query Name is mandatory");

            var result = parentForm.OnQuerySave(tbQueryName.Text, tbQuery.Text);
            if (result)
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
