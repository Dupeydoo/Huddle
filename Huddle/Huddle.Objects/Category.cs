using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huddle.Objects
{
    /*
     * A non ef wrapped equivalent of Huddle.Data.Entities.Category
     * 
     * @author   James
     * @version  1.0.0
    */
    public class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.Threads = new HashSet<Thread>();
        }

        public int Id { get; set; }                          // Every category has a unique id
        public string Title { get; set; }                    // Every category has a title
        public System.DateTime DateCreated { get; set; }     // Every category is created at a certain timestamp
        public System.DateTime DateModified { get; set; }    // A category's modified date is denoted by when the latest thread was modified
        public string CreatedBy { get; set; }                // The user ressponsible, in a category's case this will be an admin or higher
        public string ModifiedBy { get; set; }               // Denoted by the most recent user to modify a child thread
        public string Description { get; set; }              // A description of the category

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thread> Threads { get; set; }
    }
}
