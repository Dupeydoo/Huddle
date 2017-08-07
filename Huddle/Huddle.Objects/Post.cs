using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huddle.Objects
{
    /*
     * A non ef wrapped equivalent of Huddle.Data.Entities.Post
     * 
     * @author   James
     * @version  1.0.0
    */
    public class Post
    {
        public int Id { get; set; }                               // Each post has a unique Id
        public int ThreadId { get; set; }                         // Each post is related to a thread
        public System.DateTime DateCreated { get; set; }          // A post is created at a a certain timestamp
        public System.DateTime DateModified { get; set; }         // A post may be edited by the privileged user
        public string CreatedBy { get; set; }                     // A post is created by a user
        public string PostMessage { get; set; }                   // A post has a message

        public virtual Thread Thread { get; set; }
    }
}
