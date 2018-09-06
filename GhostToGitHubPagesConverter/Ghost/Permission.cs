namespace GhostToGitHubPagesConverter.Ghost
{
    public class Permission
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string object_type { get; set; }
        public string action_type { get; set; }
        public object object_id { get; set; }
        public string created_at { get; set; }
        public int created_by { get; set; }
        public string updated_at { get; set; }
        public int updated_by { get; set; }
    }
}