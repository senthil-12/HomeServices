using HomeServices.API.CustomFilters;
using HomeServices.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using HomeServices.Data.Models;

namespace HomeServices.API.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class HomeServiceController : ControllerBase
    {
        #region " Private Variables"
        private readonly IRequestService _requestService;
        #endregion

        #region "Public Constructor"
        public HomeServiceController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        #endregion

        #region "API Methods"
        /// <summary>
        /// Get all the service details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _requestService.Get();
                if (result != null && result.Count > 0)
                    return Ok(result);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            return BadRequest();
        }

        [HttpGet, Route("CategoryLookup")]
        /// <summary>
        /// Get all the get category lookup
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategoryLookup()
        {
            try
            {
                var result = await _requestService.GetCategoryDetails();
                if (result != null && result.Count > 0)
                    return Ok(result);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            return BadRequest();
        }

        /// <summary>
        /// save service details
        /// </summary>
        /// <returns></returns>
        [ServiceFilter(typeof(CustomActionFilter))]
        [HttpPost]
        public async Task<IActionResult> Post(Services service)
        {
            try
            {
                var result = await _requestService.Save(service);
                if (result)
                    return Ok("Saved Successfully");
                else
                    return BadRequest("Error in saving");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            return BadRequest();
        }

        /// <summary>
        /// update service details
        /// </summary>
        /// <returns></returns>
        [ServiceFilter(typeof(CustomActionFilter))]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Services service)
        {
            try
            {
                var result = await _requestService.Update(service);
                if (result)
                    return Ok("Updated Successfully");
                else
                    return BadRequest("Error in saving");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            return BadRequest();
        }
        #endregion
    }
}
