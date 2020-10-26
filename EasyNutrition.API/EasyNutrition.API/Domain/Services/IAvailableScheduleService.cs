<<<<<<< HEAD
﻿using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface IAvailableScheduleService
    {

        Task<IEnumerable<AvailableSchedule>> ListByUserIdAsync(int userId);

        Task<AvailableScheduleResponse> GetByIdAsync(int id);
        Task<AvailableScheduleResponse> SaveAsync(AvailableSchedule availableSchedule);
        Task<AvailableScheduleResponse> UpdateAsync(int id, AvailableSchedule availableSchedule);
    }
}
=======
﻿using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface IAvailableScheduleService
    {

        Task<IEnumerable<AvailableSchedule>> ListByUserIdAsync(int userId);

        Task<AvailableScheduleResponse> GetByIdAsync(int id);
        Task<AvailableScheduleResponse> SaveAsync(AvailableSchedule availableSchedule);
        Task<AvailableScheduleResponse> UpdateAsync(int id, AvailableSchedule availableSchedule);
    }
}
>>>>>>> develop
