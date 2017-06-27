using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huddle.Data.Entities;
using ObjectThread = Huddle.Objects.Thread;

namespace Huddle.Data.ModelBinding
{
    public class ThreadsData
    {
        public ThreadsData() { }

        public IQueryable<Thread> GetCategoryThreadsFromDB(int id)
        {
            using (HuddleEntities entities = new HuddleEntities())
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
