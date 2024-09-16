using _2301B2WebApi.Data;
using _2301B2WebApi.Models;
using _2301B2WebApi.Models.DTOs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2301B2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly PharmacyContext db;
        public CompanyController(PharmacyContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            return Ok(db.Companies.ToList());
        }

        [HttpPost]
         public IActionResult AddCompany(CompanyDTO companydata)
		{
          
            if (companydata != null) {
				var company = new Company()
				{
					Name = companydata.Name,
					Address = companydata.Address,

				};

              var newaddedcompany =  db.Companies.Add(company);
                db.SaveChanges();
                return Ok(newaddedcompany.Entity);

            }
            else
            {
                return BadRequest();
            }

		}
	}
}
