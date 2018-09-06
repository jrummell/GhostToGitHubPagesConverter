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
                    var postsPath = Path.Combine(db.meta.exported_on.ToString(), "_posts");
                    var directory = new DirectoryInfo(postsPath);
                    if (!directory.Exists)
                    {
                        directory.Create();
                    }

                    foreach (Post post in db.data.posts)
                    {
                        var tagIds = db.data.posts_tags.Where(x => x.post_id == post.id)
                                       .Select(x => x.tag_id)
                                       .ToArray();

                        var tags = db.data.tags.Where(t => tagIds.Contains(t.id))
                                     .Select(t => t.name)
                                     .ToArray();

                        var published = post.status == "published" && post.visibility == "public";

                        // see https://help.github.com/articles/configuring-jekyll/#front-matter-is-required and https://jekyllrb.com/docs/front-matter/
                        string frontMatter = $@"---
layout: post
title: {post.title?.Replace(":", " -")}
permalink: /{post.slug}
date: {post.published_at ?? post.created_at}
published: {published.ToString().ToLower()}
tags: {string.Join(" ", tags)}
---";

                        string postContent = frontMatter + Environment.NewLine + Environment.NewLine + post.markdown;

                        string fileName = (post.published_at ?? post.created_at).Split(" ").First() + "-" + post.slug + ".md";
                        string fullPath = Path.Combine(directory.FullName, fileName);
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
    }
}
