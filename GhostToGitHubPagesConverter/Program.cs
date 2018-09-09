using System;
using System.IO;
using System.Linq;
using GhostToGitHubPagesConverter.Ghost;
using Newtonsoft.Json;

namespace GhostToGitHubPagesConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                var ghostBackupFile = args[0];

                var content = File.ReadAllText(ghostBackupFile);

                var export = JsonConvert.DeserializeObject<GhostExport>(content);

                foreach (Db db in export.db)
                {
                    var dbDirectory = new DirectoryInfo(db.meta.exported_on.ToString());
                    if (!dbDirectory.Exists)
                    {
                        dbDirectory.Create();
                    }

                    var postsPath = Path.Combine(dbDirectory.FullName, "_posts");
                    var postDirectory = new DirectoryInfo(postsPath);
                    if (!postDirectory.Exists)
                    {
                        postDirectory.Create();
                    }

                    var posts = db.data.posts.Where(p => p.page == 0)
                                  .ToArray();

                    foreach (Post post in posts)
                    {
                        string[] tags = GetTags(db, post);
                        string frontMatter = GetFrontMatter(post, tags);
                        string postContent = GetContent(post, frontMatter);

                        string fileName = (post.published_at ?? post.created_at).Split(" ")
                                                                                .First() + "-" + post.slug + ".md";
                        string fullPath = Path.Combine(postDirectory.FullName, fileName);
                        File.WriteAllText(fullPath, postContent);
                    }

                    var pages = db.data.posts.Where(e => e.page == 1)
                                  .ToArray();

                    foreach (Post post in pages)
                    {
                        string[] tags = GetTags(db, post);
                        string frontMatter = GetFrontMatter(post, tags);
                        string postContent = GetContent(post, frontMatter);

                        string fileName = post.slug + ".md";
                        string fullPath = Path.Combine(dbDirectory.FullName, fileName);
                        File.WriteAllText(fullPath, postContent);
                    }
                }
            }
            else
            {
                Console.WriteLine("Missing file argument");
                Environment.Exit(1);
            }
        }

        private static string GetContent(Post post, string frontMatter)
        {
            return frontMatter + Environment.NewLine + Environment.NewLine + post.markdown;
        }

        private static string GetFrontMatter(Post post, string[] tags)
        {
            var layout = post.page == 0 ? "post" : "default";
            var published = post.status == "published" && post.visibility == "public";

            // see https://help.github.com/articles/configuring-jekyll/#front-matter-is-required and https://jekyllrb.com/docs/front-matter/
            string frontMatter = $@"---
layout: {layout}
title: {post.title?.Replace(":", " -")}
permalink: /{post.slug}
date: {post.published_at ?? post.created_at}
published: {published.ToString().ToLower()}
tags: [{string.Join(", ", tags)}]
---";
            return frontMatter;
        }

        private static string[] GetTags(Db db, Post post)
        {
            var tagIds = db.data.posts_tags.Where(x => x.post_id == post.id)
                           .Select(x => x.tag_id)
                           .ToArray();

            var tags = db.data.tags.Where(t => tagIds.Contains(t.id))
                         .Select(t => t.name)
                         .ToArray();
            return tags;
        }
    }
}