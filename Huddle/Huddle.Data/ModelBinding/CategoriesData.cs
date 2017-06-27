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
            this.ParseCategorySelect(categorySelect, output);

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

        private void ParseCategorySelect(List<Category> categories, List<ObjectCat> output)
        {
            for (int c = 0; c < categories.Count; c++)
            {
                Category category = categories[c];
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
        }
    }
}
