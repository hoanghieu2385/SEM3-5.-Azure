using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassFunction.DTOs;
using ClassFunction.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;

namespace ClassFunction.Presentations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddClassDTO, Class>().ReverseMap();
        }
    }
}