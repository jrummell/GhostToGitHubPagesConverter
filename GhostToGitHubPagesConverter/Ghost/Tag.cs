namespace GhostToGitHubPagesConverter.Ghost
{
    public class Tag
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public object image { get; set; }
        public object parent_id { get; set; }
        public string visibility { get; set; }
        public object meta_title { get; set; }
        public object meta_description { get; set; }
        public string created_at { get; set; }
        public int created_by { get; set; }
        public string updated_at { get; set; }
        public int updated_by { get; set; }
    }
}