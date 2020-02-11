using HomeServices.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeServices.Business.Interfaces
{
    /// <summary>
    /// Define the methods which needs to be implemented in the RequestService class
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Get all Service Request
        /// </summary>
        /// <returns>Services Object</returns>
        Task<List<Services>> Get();

        /// <summary>
        /// Get all Service Category Details
        /// </summary>
        /// <returns>Lookup Object</returns>
        Task<List<CommonLookup>> GetCategoryDetails();

        /// <summary>
        /// Save Request details
        /// </summary>
        /// <param name="Services"></param>
        /// <returns>Boolean</returns>
        Task<bool> Save(Services service);

        /// <summary>
        /// Update Request details
        /// </summary>
        /// <param name="Services"></param>
        /// <returns>Boolean</returns>
        Task<bool> Update(Services service);
    }
}
