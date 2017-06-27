using System.Collections.Generic;
using System.Linq;
using Huddle.Data.Entities;
using ObjectCat = Huddle.Objects.Category;

namespace Huddle.Data.ModelBinding
{
    public class CategoriesData
    {
        public CategoriesData() { }

        public IEnumerable<ObjectCat> GetCategoriesFromDB()
        {
            List<Category> categorySelect = new List<Category>();
            List<ObjectCat> output = new List<ObjectCat>();

            using(HuddleEntities entities = new HuddleEntities())
            {
                categorySelect =
                       (from categories in entities.Categories
                       orderby categories.Id
                       select categories).ToList();
            }

            // Parse the categories into non-ef wrapped objects
            for(int c = 0; c < categorySelect.Count; c++)
            {
                Category category = categorySelect[c];
                output.Add(
                    new ObjectCat
                    {
                        Id = category.Id,
                        CreatedBy = category.CreatedBy,
                        DateCreated = category.DateCreated,
                        DateModified = category.DateModified,
                        Description = category.Description,
                        ModifiedBy = category.ModifiedBy,
                        Title = category.Title
                    }
                );
            }

            return output;
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
