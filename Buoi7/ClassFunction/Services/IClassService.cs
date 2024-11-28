using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassFunction.Models;
using ClassFunction.DTOs;

namespace ClassFunction.Services
{
    public interface IClassService
    {
        List<Class> GetClasses();
        void AddClass(AddClassDTO classDto);
    }
}