using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Huddle.Data.Entities;
using ObjectThread = Huddle.Objects.Thread;

namespace Huddle.Data.ModelBinding
{
    public class ThreadsData
    {
        public ThreadsData() { }

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
