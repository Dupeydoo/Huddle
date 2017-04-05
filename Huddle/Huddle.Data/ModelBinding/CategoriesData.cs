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

        public string GetCategoryTitleFromDB(int id)
        {
            using (HuddleEntities entities = new HuddleEntities())
            {
                return (from categories in entities.Categories
                        where categories.Id == id
                        select categories.Title).SingleOrDefault(); 
            }
        }

        public IQueryable<Thread> GetCategoryThreadsFromDB(int id)
        {
            using(HuddleEntities entities = new HuddleEntities())
            {
                return (from threads in entities.Threads
                        where threads.CategoryId == id
                        orderby threads.DateModified descending
                        select threads);
            }
        }

        public IQueryable<Thread> GetCategoryThreadsFromDB(int id, bool isSticky)
        {
            IQueryable<Thread> threads = GetCategoryThreadsFromDB(id);

            if (isSticky)
            {
                return threads.Where(thread => thread.IsSticky == true);
            }
            return threads.Where(thread => thread.IsSticky == false);
        }
    }
}
