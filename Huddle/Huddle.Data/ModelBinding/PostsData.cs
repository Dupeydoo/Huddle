﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huddle.Data.Entities;
using ObjectPost = Huddle.Objects.Post;

namespace Huddle.Data.ModelBinding
{
    public class PostsData
    {
        public IEnumerable<ObjectPost> GetPostsFromDB(int threadId, int postsSelected)
        {
            List<Post> postSelect = new List<Post>();
            List<ObjectPost> output = new List<ObjectPost>();

            using (HuddleEntities entities = new HuddleEntities())
            {
                postSelect =
                       (from posts in entities.Posts
                        where posts.ThreadId == threadId
                        orderby posts.DateCreated
                        select posts).Skip(postsSelected).Take(10).ToList();
            }

            // Parse the posts into non-ef wrapped objects
            this.ParsePostSelect(postSelect, output);

            return output;
        }

        private void ParsePostSelect(List<Post> posts, List<ObjectPost> output)
        {
            for(int p = 0; p < posts.Count; p++)
            {
                Post post = posts[p];
                output.Add
                (
                    new ObjectPost
                    {
                        Id = post.Id,
                        CreatedBy = post.CreatedBy,
                        DateCreated = post.DateCreated,
                        DateModified = post.DateModified,
                        PostMessage = post.PostMessage,
                        ThreadId = post.ThreadId
                    }
                );
            }
        }
    }
}
