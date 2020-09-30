using AutoMapper;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Extensions;
using EasyNutrition.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SubscriptionsController : ControllerBase
    {

        private readonly ISubscriptionService _subscriptionService;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISubscriptionService subscriptionService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all subscriptions",
            Description = "List of Subscriptions",
            OperationId = "ListAllSubscriptions",
            Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "List of Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IEnumerable<SubscriptionResource>> GetAllAsync()
        {
            var subscriptions = await _subscriptionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(subscriptions);
            return resources;
        }

        /*
        [SwaggerOperation(
          Summary = "List subscriptions ID",
          Description = "List of Subscriptions by ID",
          OperationId = "ListSubscriptionsByID",
          Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "List of Subscriptions by ID", typeof(IEnumerable<SubscriptionResource>))]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IEnumerable<SubscriptionResource>> GetByIdAsync(int id)
        {
            var subscriptions = await _subscriptionService.GetByIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(subscriptions);
            return resources;
        }
        */



        [SwaggerOperation(
            Summary = "Add subscription",
            Description = "Add new subscription",
            OperationId = "AddSubscription",
            Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "Add Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.SaveAsync(subscription);

            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }


        [SwaggerOperation(
            Summary = "Update subscription",
            Description = "Update a subscription",
            OperationId = "UpdateSubscription",
            Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "Update Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSubscriptionResource resource)
        {
            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.UpdateAsync(id, subscription);

            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }


        [SwaggerOperation(
        Summary = "Delete subscription",
        Description = "Delete a subscription",
        OperationId = "DeleteSubscription",
        Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "Delete Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _subscriptionService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);

        }
    }
}
