using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Repositories
{
    public interface IComplaintRepository
    {
        Task<IEnumerable<Complaint>> ListAsync();

        Task AddAsync(Complaint complaint);

    }


}
