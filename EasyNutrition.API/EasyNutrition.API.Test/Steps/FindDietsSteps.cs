using EasyNutrition.API.Domain.Models;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using EasyNutrition.API.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using EasyNutrition.API.Services;
using EasyNutrition.API.Domain.Services.Communication;

namespace EasyNutrition.API.Test.Steps
{
    [Binding]
    public class FindDietsSteps
    {
        [Given(@"the id of the user")]
        public void GivenTheIdOfTheUser()
        {
        }
        
        [When(@"the id is (.*)")]
        public void WhenTheIdIs(int id)
        {
            id.Should().Be(5);
        }

        [Then(@"the result should be a empty list")]
        public async void ThenTheResultShouldBeAEmptyList()
        {
            var mockDietRepository = GetDefaultIDietRepositoryInstance();
            mockDietRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Diet>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new DietService(
                mockDietRepository.Object,
                mockUnitOfWork.Object);
            List<Diet> result = (List<Diet>)await service.ListAsync();
            int dietsCount = result.Count;
            dietsCount.Should().Equals(0);
        }
        private Mock<IDietRepository> GetDefaultIDietRepositoryInstance()
        {
            return new Mock<IDietRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
