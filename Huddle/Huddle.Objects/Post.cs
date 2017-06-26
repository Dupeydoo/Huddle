using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huddle.Objects
{
    public class Post
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string PostMessage { get; set; }

        public virtual Thread Thread { get; set; }
    }
}
