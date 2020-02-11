using HomeServices.Business.Interfaces;
using HomeServices.Data.Interfaces;
using HomeServices.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace HomeServices.Business.Implementation
{
    /// <summary>
    /// Implement ILibraryService interface methods
    /// </summary>
    public class RequestService : IRequestService
    {
        #region "Private Variables"
        private readonly IHomeServicesRepository _repository;
        private List<Services> _service = new List<Services>();
        private List<CommonLookup> _lookup = new List<CommonLookup>();
        #endregion

        #region "Public Constructor"
        public RequestService(IHomeServicesRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region "Public Methods"
        /// <summary>
        /// Get all the service details
        /// </summary>
        /// <returns>Book Object</returns>
        public async Task<List<Services>> Get()
        {
            GetServiceDetails(await _repository.Get(), ref _service);
            return _service;
        }

        /// <summary>
        /// Get all the catagory details
        /// </summary>
        /// <returns>Book Object</returns>
        public async Task<List<CommonLookup>> GetCategoryDetails()
        {
            GetCategoryDetails(await _repository.GetCategoryDetails(), ref _lookup);
            return _lookup;
        }

        /// <summary>
        /// Save Request Details
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Boolean</returns>
        public async Task<bool> Save(Services service)
        {
            return await _repository.Save(new Services()
            {
                ServiceName = service.ServiceName,
                CategoryLkpId = service.CategoryLkpId,
                CategoryLkpName = service.CategoryLkpName,
                ServiceType = service.ServiceType,
                Timing = service.Timing,
                CreatedBy = "SYS-Created",
                CreatedDate = DateTime.Now,
                ModifiedBy = "SYS-Modified",
                ModifiedDate = DateTime.Now,
            });
        }

        /// <summary>
        /// Update Request Details
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Boolean</returns>
        public async Task<bool> Update(Services service)
        {
            return await _repository.Update(new Services()
            {
                ServiceName = service.ServiceName,
                CategoryLkpId = service.CategoryLkpId,
                ServiceType = service.ServiceType,
                Timing = service.Timing,
                ModifiedBy = "SYS-Modified",
                ModifiedDate = DateTime.Now,
            });
        }
        #endregion

        #region "Private Methods"
        /// <summary>
        /// Get Service Details
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private void GetServiceDetails(List<Services> result, ref List<Services> books)
        {
            if (result != null && result.Count > 0)
            {
                books.AddRange( result.Select(x => new Services()
                {
                    ServiceId = x.ServiceId,
                    ServiceName = x.ServiceName,
                    CategoryLkpId = x.CategoryLkpId,
                    CategoryLkpName = x.CategoryLkpName,
                    ServiceType = x.ServiceType,
                    Timing = x.Timing
                }).ToList());
            }
        }

        /// <summary>
        /// Get Service Category Details
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private void GetCategoryDetails(List<CommonLookup> result, ref List<CommonLookup> lookup)
        {
            if (result != null && result.Count > 0)
            {
                lookup.AddRange(result.Select(x => new CommonLookup()
                {
                    CommonLkpId = x.CommonLkpId,
                    CommonLkpName = x.CommonLkpName,
                    CommonLkpType = x.CommonLkpType
                }).ToList());
            }
        }
        #endregion
    }
}
