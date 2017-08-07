using System.Collections.Generic;
using System.Linq;
using Huddle.Data.Entities;
using ObjectCat = Huddle.Objects.Category;

namespace Huddle.Data.ModelBinding
{
    /*
     * The data class for categories. Using entity framework with modelbinding the data is
     * displayed to the user.
     * 
     * @author   James
     * @version  2.3.4
    */
    public class CategoriesData
    {
        /*
         * Default constructor for use in a facade style to call data methods. 
        */
        public CategoriesData() { }

        /*
         * The central data method for selecting categories from the database.
         * 
         * @see      Huddle.Objects.Category
         * @returns  An IEnumerable of non ef wrapped category objects
         * @author   James
         * @version  1.2.0
        */
        public IEnumerable<ObjectCat> GetCategoriesFromDB()
        {
            // Input and output lists
            List<Category> categorySelect = new List<Category>();
            List<ObjectCat> output = new List<ObjectCat>();

            // EF selection
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

        /*
         * Selects a category title based on its id
         * 
         * @param    id  The category id
         * @author   James
         * @version  1.0.0
        */
        public string GetCategoryTitleFromDB(int id)
        {
            using (HuddleEntities entities = new HuddleEntities())
            {
                return (from categories in entities.Categories
                        where categories.Id == id
                        select categories.Title).SingleOrDefault(); 
            }
        }

        /*
         * A helper method which deals with translating ef wrapped objects into non ef wrapped objects.
         * The result is lightweight objects to be passed around.
         * 
         * @param    categories  A list of ef categories
         * @param    output      A list of huddle categories
         * @see      Huddle.Objects.Category
         * @author   James
         * @version  1.0.0
        */
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
