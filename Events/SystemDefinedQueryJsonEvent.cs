using Newtonsoft.Json;
using System.Text.Json.Serialization;
using CC = WorkflowConfigurationScriptingTool.Constants.ConsolidationConstants;

namespace WorkflowConfigurationScriptingTool.Events
{
    public class SystemDefinedQueryJsonEvent : BaseQueryJsonEvent
    {
        [JsonProperty(CC.SystemDefinedQuery)]
        [JsonPropertyName(CC.SystemDefinedQuery)]
        public string SystemDefinedQuery { get; set; }
    }
}
