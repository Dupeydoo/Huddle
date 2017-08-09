using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Huddle.Data.Entities;

namespace Huddle.Data.Misc
{
    /*
     * A class providing miscallaneous data functionality to the 
     * components of Huddle
     * 
     * @author   James
     * @version  1.0.0
    */
    public class MiscData
    {
        /*
         * A method to retrieve the count of categories from the db.
         * 
         * @see      Huddle.Data.Entities
         * @returns  The count of categories
         * @author   James
         * @version  1.0.0
        */
        public int GetCategoryCount()
        {
            using (HuddleEntities entities = new HuddleEntities())
            {
                return (from categories in entities.Categories
                        select categories).Count();
            }
        }
    }
}
