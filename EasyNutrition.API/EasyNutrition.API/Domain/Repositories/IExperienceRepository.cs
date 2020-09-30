using EasyNutrition.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyNutrition.API
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> ListAsync();

    }


}