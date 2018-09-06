namespace GhostToGitHubPagesConverter.Ghost
{
    public class Posts_Tags
    {
        public int id { get; set; }
        public int post_id { get; set; }
        public int tag_id { get; set; }
        public int sort_order { get; set; }
    }
}