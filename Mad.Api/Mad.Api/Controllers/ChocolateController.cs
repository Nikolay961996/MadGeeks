using Mad.Bl.Services.Chocolate;
using Mad.Data.Entities.Chocolate;
using Microsoft.AspNetCore.Mvc;

namespace Mad.Api.Controllers
{
    [ApiController]
    [Route("chocolate")]
    public class ChocolateController : ControllerBase
    {
        private readonly ChocolateService serviceEntity = new();

        [HttpPut("create-company")]
        public IActionResult CreateCompany(string companyName) 
        {
            return Ok(serviceEntity.NewCompany(companyName));
        }
        [HttpGet("list-of-companies")]
        public IActionResult GetCompanies() 
        {
            return Ok(serviceEntity.GetCompanies());
        }
        [HttpGet("search-company")]
        public IActionResult SearchCompany(string companyName)
        {
            return Ok(serviceEntity.SearchCompany(companyName));
        }
        [HttpPut("create-brand")]
        public IActionResult CreateBrand(string brandName)
        {
            return Ok(serviceEntity.NewBrand(brandName));
        }
        [HttpGet("list-of-brands")]
        public IActionResult GetBrands()
        {
            return Ok(serviceEntity.GetBrands());
        }
        [HttpGet("search-brand")]
        public IActionResult SearchBrand(string brandName)
        {
            return Ok(serviceEntity.SearchBrand(brandName));
        }
    }
}
