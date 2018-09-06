namespace GhostToGitHubPagesConverter.Ghost
{
    public class Setting
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string key { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public string created_at { get; set; }
        public int created_by { get; set; }
        public string updated_at { get; set; }
        public int updated_by { get; set; }
    }
}