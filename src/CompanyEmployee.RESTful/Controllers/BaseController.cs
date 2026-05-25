using CompanyEmployee.RESTful.ActionFilters;
using CompanyEmployees.Application.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployee.RESTful.Controllers
{
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class BaseController : ControllerBase
    {
        #region fields
        protected readonly IServiceManager _serviceManager;
        #endregion

        #region ctor
        public BaseController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        #endregion
    }
}
