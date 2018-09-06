namespace GhostToGitHubPagesConverter.Ghost
{
    public class Data
    {
        public Post[] posts { get; set; }
        public User[] users { get; set; }
        public Role[] roles { get; set; }
        public Roles_Users[] roles_users { get; set; }
        public Permission[] permissions { get; set; }
        public object[] permissions_users { get; set; }
        public Permissions_Roles[] permissions_roles { get; set; }
        public object[] permissions_apps { get; set; }
        public Setting[] settings { get; set; }
        public Tag[] tags { get; set; }
        public Posts_Tags[] posts_tags { get; set; }
        public object[] apps { get; set; }
        public object[] app_settings { get; set; }
        public object[] app_fields { get; set; }
        public object[] subscribers { get; set; }
    }
}