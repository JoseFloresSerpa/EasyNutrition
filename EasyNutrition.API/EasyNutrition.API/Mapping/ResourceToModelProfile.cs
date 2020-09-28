using AutoMapper;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveRoleResource, Role>();
            CreateMap<SaveUserResource, User>();
        }


    }
}
