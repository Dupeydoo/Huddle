using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huddle.Objects
{
    /*
     * A non ef wrapped equivalent of Huddle.Data.Entities.Thread
     * 
     * @author   James
     * @version  1.0.1
    */
    public class Thread
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thread()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }                                 // A thread has a unique id
        public string Title { get; set; }                           // A thread has a title
        public System.DateTime DateCreated { get; set; }            // A thread is created at a certain timestamp with a first post
        public System.DateTime DateModified { get; set; }           // A thread is modified when a new post is added to it
        public string CreatedBy { get; set; }                       // A thread is created by a user
        public string ModifiedBy { get; set; }                      // A user modified a thread
        public int Views { get; set; }                              // How many views does the thread have
        public bool IsSticky { get; set; }                          // Is it a sticky thread or not? Sticky threads are displayed at the top regardless of page
        public int CategoryId { get; set; }                         // A thread is related to a category
        public int? Replies { get; set; }                           // How many posts does the thread have

        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
