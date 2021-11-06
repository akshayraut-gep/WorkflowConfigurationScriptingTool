﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;
using CC = WorkflowConfigurationScriptingTool.Constants.ConsolidationConstants;

namespace WorkflowConfigurationScriptingTool.Events
{
    public class BaseQueryJsonEvent : BaseJsonEvent
    {
        [JsonProperty(CC.QueryId)]
        [JsonPropertyName(CC.QueryId)]
        public string QueryId { get; set; }

        [JsonProperty(CC.QuerySequence)]
        [JsonPropertyName(CC.QuerySequence)]
        public string QuerySequence { get; set; }

        [JsonProperty(CC.QueryName)]
        [JsonPropertyName(CC.QueryName)]
        public string QueryName { get; set; }
    }
}
