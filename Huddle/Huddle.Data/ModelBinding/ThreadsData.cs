using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Huddle.Data.Entities;
using ObjectThread = Huddle.Objects.Thread;

namespace Huddle.Data.ModelBinding
{
    /*
     * The data class for threads. Using entity framework with modelbinding the data is
     * displayed to the user.
     * 
     * @author   James
     * @version  1.3.4
    */
    public class ThreadsData
    {
        /*
         * Default constructor for use in a facade style to call data methods. 
        */
        public ThreadsData() { }

        /*
         * The central data method for selecting threads from the database.
         * 
         * @param    id  Category id for the threads
         * @see      Huddle.Data.Entities.Thread
         * @returns  A list of ef thread objects
         * @author   James
         * @version  1.0.0
        */
        public List<Thread> GetCategoryThreadsFromDB(int id)
        {
            using (HuddleEntities entities = new HuddleEntities())
            {
                return (from threads in entities.Threads
                        where threads.CategoryId == id
                        orderby threads.DateModified descending
                        select threads).Take(10).ToList();
            }
        }

        /*
         * The filter data method for selecting threads from the database.
         * Using a bool it can be called to select sticky or non sticky threads.
         * 
         * @param    id         Category id to select threads
         * @param    isSticky   if true return sticky threads
         * @see      Huddle.Objects.Thread
         * @returns  An IEnumerable of non ef wrapped thread objects
         * @author   James
         * @version  2.2.1
        */
        public IEnumerable<ObjectThread> GetCategoryThreadsFromDB(int id, bool isSticky)
        {
            List<Thread> threads = GetCategoryThreadsFromDB(id);
            //Parse threads to custom lightweight ef wrapper free objects
            List<ObjectThread> output = ParseThreadSelect(threads);

            if (isSticky)
            {
                return output.Where(thread => thread.IsSticky == true);
            }
            return output.Where(thread => thread.IsSticky == false);
        }

        /*
         * A helper method which deals with translating ef wrapped objects into non ef wrapped objects.
         * The result is lightweight objects to be passed around.
         * 
         * @param    threads   A list of ef threads
         * @see      Huddle.Objects.Thread
         * @author   James
         * @version  2.0.0
        */
        private List<ObjectThread> ParseThreadSelect(List<Thread> threads)
        {
            List<ObjectThread> output = new List<ObjectThread>();

            for(int t = 0 ; t < threads.Count() ; t++)
            {
                Thread thread = threads.ElementAt(t);

                output.Add(
                    new ObjectThread
                    {
                        CategoryId = thread.CategoryId,
                        CreatedBy = thread.CreatedBy,
                        DateCreated = thread.DateCreated,
                        DateModified = thread.DateModified,
                        Id = thread.Id,
                        IsSticky = thread.IsSticky,
                        ModifiedBy = thread.ModifiedBy,
                        Title = thread.Title,
                        Views = thread.Views,
                        Replies = thread.PostCount
                    }
                );
            }

            return output;
        }

        /*
         * Selects a thread title based on its id
         * 
         * @param    id  The thread id
         * @author   James
         * @version  1.0.0
        */
        public string GetThreadTitleFromDB(int id)
        {
            using (HuddleEntities entities = new HuddleEntities())
            {
                return (from threads in entities.Threads
                        where threads.Id == id
                        select threads.Title).SingleOrDefault();
            }
        }
    }
}
