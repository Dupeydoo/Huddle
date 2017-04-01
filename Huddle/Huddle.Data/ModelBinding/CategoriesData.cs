using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huddle.Data.Entities;

namespace Huddle.Data.ModelBinding
{
    public class CategoriesData
    {
        public CategoriesData() { }

        public IEnumerable<Category> GetCategoriesFromDB()
        {
            using(HuddleEntities entities = new HuddleEntities())
            {
                return (from categories in entities.Categories
                       orderby categories.Id
                       select categories).ToList();
            }
        }
    }
}
