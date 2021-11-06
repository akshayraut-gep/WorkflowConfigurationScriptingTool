namespace WorkflowConfigurationScriptingTool
{
    internal class QueryType
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public int StageId { get; set; }
        public bool AllowMultiple { get; set; }
        public string DisplayName { get; set; }

        public QueryType(int stageId, int eventId, string name, bool allowMultiple = false)
        {
            this.EventId = eventId;
            this.Name = name;
            this.StageId = stageId;
            this.AllowMultiple = allowMultiple;
            this.DisplayName = name + " (" + eventId.ToString() +")";
        }
    }
}