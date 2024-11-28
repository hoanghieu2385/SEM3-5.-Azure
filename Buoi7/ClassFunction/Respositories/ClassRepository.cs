using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassFunction.Models;
using ClassFunction.Presentations;

namespace ClassFunction.Respositories
{
    public class ClassRepository : IClassRepository
{
        public readonly EduDbContext dbContext;

        public ClassRepository(EduDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddClass(Class _class)
        {
            try
            {
                this.dbContext.Add(_class);
                this.dbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public List<Class> GetClasses()
        {
            try
            {
                return this.dbContext.Classes.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}