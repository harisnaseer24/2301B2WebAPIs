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

        [HttpGet("{id}")]
        public IActionResult GetCompanyDetails(int id)
        {
            var company = db.Companies.FirstOrDefault(x => x.Id == id);
            if (company == null) {

                return NotFound();
            }
            else
            {

            return Ok(company);
            }
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

        [HttpPut]
		
		public IActionResult EditCompany(int id,CompanyDTO companydata)
		{

			if (companydata != null && id!=null)
			{
				var company = db.Companies.Find(id);

                company.Name = companydata.Name;
				company.Address = companydata.Address;

				

				var newaddedcompany = db.Companies.Update(company);
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
