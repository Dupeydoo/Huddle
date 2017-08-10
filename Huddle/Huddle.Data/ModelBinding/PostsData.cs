using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huddle.Data.Entities;
using ObjectPost = Huddle.Objects.Post;

namespace Huddle.Data.ModelBinding
{
    /*
     * The data class for posts. Using entity framework with modelbinding the data is
     * displayed to the user.
     * 
     * @author   James
     * @version  2.0.0
    */
    public class PostsData
    {
        /*
         * Default constructor for use in a facade style to call data methods. 
        */
        public PostsData() { }

        /*
         * The central data method for selecting posts from the database.
         * 
         * @see      Huddle.Objects.Post
         * @returns  An IEnumerable of non ef wrapped post objects
         * @author   James
         * @version  1.0.0
        */
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

        /*
         * A helper method which deals with translating ef wrapped objects into non ef wrapped objects.
         * The result is lightweight objects to be passed around.
         * 
         * @param    posts   A list of ef posts
         * @param    output  A list of huddle posts
         * @see      Huddle.Objects.Post
         * @author   James
         * @version  1.0.0
        */
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
