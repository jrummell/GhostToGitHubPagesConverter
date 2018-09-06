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
                    var directory = new DirectoryInfo(db.meta.exported_on.ToString());
                    if (!directory.Exists)
                    {
                        directory.Create();
                    }

                    foreach (Post post in db.data.posts)
                    {
                        string postFile = Path.Combine(directory.FullName, post.slug + ".md");

                        var tagIds = db.data.posts_tags.Where(x => x.post_id == post.id)
                                       .Select(x => x.tag_id)
                                       .ToArray();

                        var tags = db.data.tags.Where(t => tagIds.Contains(t.id))
                                     .Select(t => t.name)
                                     .ToArray();

                        // see https://help.github.com/articles/configuring-jekyll/#front-matter-is-required and https://jekyllrb.com/docs/front-matter/
                        string frontMatter = $@"---
permalink: /{post.slug}
title: {post.title}
date: {post.created_at}
published: {post.status == "published" && post.visibility == "public"}
tags: {string.Join(" ", tags)}
---";

                        string postContent = frontMatter + Environment.NewLine + Environment.NewLine + post.markdown;

                        File.WriteAllText(postFile, postContent);
                    }
                }
            }
            else
            {
                Console.WriteLine("Missing file argument");
                Environment.Exit(1);
            }
        }
    }
}
