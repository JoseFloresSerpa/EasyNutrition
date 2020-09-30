using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface IExperienceService
    {
        Task<IEnumerable<Experience>> ListAsync();

    }

}
