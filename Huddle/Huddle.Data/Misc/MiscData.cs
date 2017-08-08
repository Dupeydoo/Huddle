using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Huddle.Data.Entities;

namespace Huddle.Data.Misc
{
    public class MiscData
    {
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
