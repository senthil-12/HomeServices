using HomeServices.Data.Context;
using HomeServices.Data.Interfaces;
using HomeServices.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeServices.Data.Repository
{
    /// <summary>
    /// Implement ILibraryService interface methods
    /// </summary>
    public class HomeServicesRepository : IHomeServicesRepository
    {
        #region "Private Variables"
        private readonly HomeServicesDatabaseContext _context;
        #endregion

        #region "Public Constructor"
        public HomeServicesRepository(HomeServicesDatabaseContext context)
        {
            _context = context;
        }

        public HomeServicesRepository()
        {
        }
        #endregion

        #region "Public Methods"
        /// <summary>
        /// Get all the Service Details
        /// </summary>
        /// <returns>Services Object</returns>
        public async Task<List<Services>> Get()
        {
            return await Task.FromResult(_context.Services.ToList());
        }

        /// <summary>
        /// Get all the Service Category Details
        /// </summary>
        /// <returns>Services Object</returns>
        public async Task<List<CommonLookup>> GetCategoryDetails()
        {
            return await Task.FromResult(_context.Lookup.ToList());
        }

        /// <summary>
        /// Save Request details
        /// </summary>
        /// <param name="Services"></param>
        /// <returns>Boolean</returns>
        public async Task<bool> Save(Services service)
        {
            try
            {
                await Task.FromResult(_context.Add(service));
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// Update book details
        /// </summary>
        /// <param name="Services"></param>
        /// <returns>Boolean</returns>
        public async Task<bool> Update(Services service)
        {
            try
            {
                var existBookObject = await Task.FromResult(_context.Services.FirstOrDefault(x => x.ServiceId == service.ServiceId));
                if (existBookObject != null)
                {
                    existBookObject.ServiceName = service.ServiceName;
                    existBookObject.CategoryLkpId = service.CategoryLkpId;
                    existBookObject.ServiceType = service.ServiceType;
                    existBookObject.Timing = service.Timing;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
        #endregion
    }
}
