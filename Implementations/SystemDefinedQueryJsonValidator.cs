using WorkflowConfigurationScriptingTool.Events;
using WorkflowConfigurationScriptingTool.Interfaces;

namespace WorkflowConfigurationScriptingTool.Implementations
{
    public class SystemDefinedQueryJsonValidator : IWorkflowEventJsonValidator
    {
        public BaseJsonEvent GetJsonEvent(string queryName, string query, int sequenceId)
        {
            var jsonEvent = new CleansingAtSourceJsonEvent();
            jsonEvent.QueryName = queryName;
            jsonEvent.Query = query.Replace("'", "''");
            jsonEvent.SortOrder = sequenceId.ToString();
            return jsonEvent;
        }
    }
}
