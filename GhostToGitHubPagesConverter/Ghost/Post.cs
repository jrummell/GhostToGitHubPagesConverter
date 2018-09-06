namespace GhostToGitHubPagesConverter.Ghost
{
    public class Post
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string markdown { get; set; }
        public object mobiledoc { get; set; }
        public string html { get; set; }
        public string image { get; set; }
        public int featured { get; set; }
        public int page { get; set; }
        public string status { get; set; }
        public string language { get; set; }
        public string visibility { get; set; }
        public object meta_title { get; set; }
        public object meta_description { get; set; }
        public int author_id { get; set; }
        public string created_at { get; set; }
        public int created_by { get; set; }
        public string updated_at { get; set; }
        public int updated_by { get; set; }
        public string published_at { get; set; }
        public int? published_by { get; set; }
        public object amp { get; set; }
    }
}