using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassFunction.Models;

namespace ClassFunction.Respositories
{
    public interface IClassRepository
    {
        List<Class> GetClasses();
        void AddClass(Class _class);
    }
}