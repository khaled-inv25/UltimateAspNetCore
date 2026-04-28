using CompanyEmployees.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public CompanyController(IRepositoryManager repository)
        {
            _repository = repository;
        }

    }
}
