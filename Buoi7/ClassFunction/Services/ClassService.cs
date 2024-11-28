using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassFunction.DTOs;
using ClassFunction.Models;
using ClassFunction.Respositories;

namespace ClassFunction.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository classRepository;
        private readonly IMapper mapper;
        public ClassService(IClassRepository classRepository, IMapper mapper)
        {
            this.classRepository = classRepository;
            this.mapper = mapper;
        }
        public void AddClass(AddClassDTO classDto)
        {
            try
            {
                Class _class = mapper.Map<Class>(classDto);
                this.classRepository.AddClass(_class);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public List<Class> GetClasses()
        {
            return this.classRepository.GetClasses();
        }
    }
}