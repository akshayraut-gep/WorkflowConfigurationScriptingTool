using WorkflowConfigurationScriptingTool.Events;

namespace WorkflowConfigurationScriptingTool.Interfaces
{
    public interface IWorkflowEventJsonValidator
    {
        BaseJsonEvent GetJsonEvent(string queryName, string query, int sequenceId);
    }
}
