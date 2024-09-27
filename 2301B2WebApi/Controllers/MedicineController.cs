using _2301B2WebApi.Data;
using _2301B2WebApi.Models;
using _2301B2WebApi.Models.DTOs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2301B2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private readonly PharmacyContext _context;
        public MedicineController(PharmacyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMedicines()
        {

            var AvailableMedicines = _context.Medicines.Include(x => x.Company).ToList();
            return Ok(AvailableMedicines);
        }


        ////Pagination API
        //[HttpGet("{pageNo}/{pageSize}")]
        //public IActionResult GetMedicines(int pageNo, int pageSize)
        //{

        //    var AvailableMedicines = _context.Medicines.Include(x => x.Company).Skip((pageNo -1)*pageSize).Take(pageSize)
        //       .ToList();
        //    return Ok(AvailableMedicines);
        //}




        [HttpGet ("{PageNo}/{PageSize}")]
        public IActionResult GetMedicines(int PageNo, int PageSize)

        { 
        int pageNumber = PageNo; //2
        int pageSize = PageSize; //5

            if (PageNo < 1) { pageNumber = 1; }
            if (PageSize < 1) { pageSize = 1; }
            
            var medicines = _context.Medicines.Skip((pageNumber -1) * pageSize).Take(pageSize).ToList();// (2-1)*5=>1*5=>5

            //  (1-1)*5=> 0*5 => 0


            return Ok(medicines);
        }


        [HttpGet("{q}")]
        public IActionResult SearchMedicines(string q)
        {
            //var company = _context.Medicines.Include(x=> x.Company).Where(x=>x.Name==q  ||  x.Company.Name==q || x.Power==q).ToList();//Exact Match
          //  var abc = q.GetType();
          //if ( )
          //  {

          //  }

            var company = 
                _context.Medicines.Include(x => x.Company)
                .Where(x => x.Name.Contains(q) || x.Company.Name.Contains(q) || x.Power.Contains(q) )
                .ToList();//Partial Match

            if (company == null)
            {

                return NotFound();
            }
            else
            {

                return Ok(company);
            }
        }



        [HttpPost]
        public IActionResult AddMedicine(MedicineDTO medicine)
        {
            if(medicine != null)
            {
                Medicine addMed = new Medicine()
                {
                    Name=medicine.Name,
                    Description=medicine.Description,
                    Price=medicine.Price,
                    Power=medicine.Power,
                    Formula=medicine.Formula,
                    Expiry=medicine.Expiry,
                    CompanyId=medicine.CompanyId

                };
                var addedmedicine=_context.Medicines.Add(addMed);
                _context.SaveChanges();
                return Ok(addedmedicine.Entity);
            }
            else
            {
                return BadRequest();

            }
           
        }






    }
}
