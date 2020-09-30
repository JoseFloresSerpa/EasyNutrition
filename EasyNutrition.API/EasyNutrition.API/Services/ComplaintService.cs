using EasyNutrition.API.Controllers;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Repositories;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ComplaintService(IComplaintRepository complaintRepository, IUnitOfWork unitOfWork)
        {
            _complaintRepository = complaintRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<Complaint>> ListAsync()
        {
            return await _complaintRepository.ListAsync();
        }

        public async Task<ComplaintResponse> SaveAsync(Complaint complaint)
        {
            try
            {
                await _complaintRepository.AddAsync(complaint);
                await _unitOfWork.CompleteAsync();

                return new ComplaintResponse(complaint);
            }
            catch (Exception ex)
            {
                return new ComplaintResponse($"An error ocurred while saving user: {ex.Message}");
            }
        }


    }


}
