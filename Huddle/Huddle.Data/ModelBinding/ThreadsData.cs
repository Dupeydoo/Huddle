﻿using System;
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
                return  (from threads in entities.Threads
                        where threads.CategoryId == id
                        orderby threads.DateModified descending
                        select threads);
            }
        }

        public IQueryable<ObjectThread> GetCategoryThreadsFromDB(int id, bool isSticky)
        {
            IQueryable<Thread> threads = GetCategoryThreadsFromDB(id);
            //Parse threads to custom lightweight ef wrapper free objects
            IQueryable<ObjectThread> output = ParseThreadSelect(threads);

            if (isSticky)
            {
                return output.Where(thread => thread.IsSticky == true);
            }
            return output.Where(thread => thread.IsSticky == false);
        }

        private IQueryable<ObjectThread> ParseThreadSelect(IQueryable<Thread> threads)
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
                        Views = thread.Views
                    }
                );
            }

            return output.AsQueryable();
        }
    }
}
