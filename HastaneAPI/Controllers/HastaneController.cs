using HastaneAPI.Context;
using HastaneAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaneController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public HastaneController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAllHospitals")]
        public IEnumerable<Hospital> GetHospitals()
        {
            var HospitalList= dbContext.Hospitals.ToList<Hospital>();

            return HospitalList;
        }

        [HttpGet]
        [Route("GetHospitalByID")]
        public IActionResult GetHospitalByID(int ID)
        {
            Hospital hospital = dbContext.Hospitals.FirstOrDefault<Hospital>(x => x.ID == ID);

            if (hospital != null)
                return Ok(hospital);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("CreateHospital")]
        public IActionResult CreateHospital(Hospital hospital)
        {
            dbContext.Hospitals.Add(hospital);
            dbContext.SaveChanges();
            return Ok(hospital.ID);

        }

        [HttpPut]
        [Route("CreateHospital")]
        public IActionResult UpdateHospital(int ID,Hospital hospital)
        {
            Hospital updatedhospital = dbContext.Hospitals.FirstOrDefault<Hospital>(x => x.ID == ID);

            if (updatedhospital != null)
            {
                updatedhospital.HospitalName = hospital.HospitalName;
                updatedhospital.Address = hospital.Address;
                updatedhospital.Hastalar = hospital.Hastalar;
                dbContext.Hospitals.Add(updatedhospital);
                dbContext.SaveChanges();
                return Ok(updatedhospital.ID);
            }
            else
                return NotFound();

        }

        [HttpDelete]
        [Route("DeleteHospital")]
        public IActionResult DeleteHospital(int ID)
        {
            Hospital hospital = dbContext.Hospitals.FirstOrDefault<Hospital>(x => x.ID == ID);
            if (hospital != null)
            {
                dbContext.Hospitals.Remove(hospital);
                return Ok(hospital.ID);
            }
            else
                return NotFound();
        }


    }
}
