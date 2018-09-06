namespace GhostToGitHubPagesConverter.Ghost
{
    public class Role
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string created_at { get; set; }
        public int created_by { get; set; }
        public string updated_at { get; set; }
        public int updated_by { get; set; }
    }
}