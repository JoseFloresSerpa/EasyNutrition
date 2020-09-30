using AutoMapper;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {   
        public ModelToResourceProfile()
        {
            CreateMap<Role, RoleResource>();

            CreateMap<User, UserResource>();

            CreateMap<Subscription, SubscriptionResource>();


        }
    }
}
