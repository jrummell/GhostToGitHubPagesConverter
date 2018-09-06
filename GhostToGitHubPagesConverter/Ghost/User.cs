namespace GhostToGitHubPagesConverter.Ghost
{
    public class User
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public object cover { get; set; }
        public string bio { get; set; }
        public object website { get; set; }
        public object location { get; set; }
        public object facebook { get; set; }
        public object twitter { get; set; }
        public object accessibility { get; set; }
        public string status { get; set; }
        public string language { get; set; }
        public string visibility { get; set; }
        public object meta_title { get; set; }
        public object meta_description { get; set; }
        public object tour { get; set; }
        public string last_login { get; set; }
        public string created_at { get; set; }
        public int created_by { get; set; }
        public string updated_at { get; set; }
        public int updated_by { get; set; }
    }
}