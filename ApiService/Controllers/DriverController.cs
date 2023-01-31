using DriverService.Contract;
using DriverService.Model;
using Microsoft.AspNetCore.Mvc;
using TravelService.Model.DTO;
using TravelService.Model;

namespace ApiService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DriverController : Controller
    {
        private readonly IDriverRepo dr;

        public DriverController(IDriverRepo dr)
        {
            this.dr = dr;
        }


        [HttpPost]
        public IActionResult Create(AddDriverDto dto)
        {
            var driver = new Driver(dto.Name, dto.Family, dto.Number, dto.CarBrand, dto.CarModel, dto.CarTag, dto.NationalCode);
            if (dr.Create(driver))
                return StatusCode(200, new StandardResult<Driver>()
                {
                    Success = true,
                    Message = "Traveler Created .",
                    Result = driver
                });

            return StatusCode(500, new StandardResult()
            {
                Success = false,
                Message = "internal server Error !"
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetBy(Guid id)
        {
            var driver = dr.FindBy(id);
            if (driver is not null)
                return StatusCode(302, new StandardResult<Driver>()
                {
                    Success = true,
                    Message = "driver Founded .",
                    Result = driver
                });

            return StatusCode(404, new StandardResult()
            {
                Success = true,
                Message = "can't found driver .",
            });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var driver = dr.GetAll();
            if (driver is not null)
                return StatusCode(302, new StandardResult<IEnumerable<Driver>>()
                {
                    Success = true,
                    Message = "drivers Founded .",
                    Result = driver
                });

            return StatusCode(404, new StandardResult()
            {
                Success = true,
                Message = "can't found drivers .",
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Driver driver)
        {
            if (id != driver.Id)
                return StatusCode(400, new StandardResult()
                {
                    Success = false,
                    Message = "wrong id !"
                });

            if (dr.Update(id, driver))
                return StatusCode(200, new StandardResult<Driver>()
                {
                    Success = true,
                    Message = "driver Updated .",
                    Result = driver
                });

            return StatusCode(500, new StandardResult()
            {
                Success = false,
                Message = "internal server Error !"
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (dr.Remove(id))
                return StatusCode(200, new StandardResult()
                {
                    Success = true,
                    Message = "driver Removed .",
                });

            return StatusCode(500, new StandardResult()
            {
                Success = false,
                Message = "internal server Error !"
            });
        }

        [HttpPatch]
        public IActionResult ActiveDriverBy(Guid id)
        {
            if (dr.Active(id))
                return StatusCode(200, new StandardResult()
                {
                    Success = true,
                    Message = "Driver is active now"
                });
            else
                return StatusCode(500, new StandardResult()
                {
                    Success = false,
                    Message = "internal server Error !"
                });
        }

        [HttpPatch]
        public IActionResult DeactiveDriverBy(Guid id)
        {
            if (dr.Deactive(id))
                return StatusCode(200, new StandardResult()
                {
                    Success = true,
                    Message = "Driver is deactive now"
                });
            else
                return StatusCode(500, new StandardResult()
                {
                    Success = false,
                    Message = "internal server Error !"
                });
        }

        [HttpPatch]
        public IActionResult AddScore(Guid id , int score)
        {
            int? newScore = dr.AddScore(id, score);
            if (newScore is not null)
                return StatusCode(200, new StandardResult<int>()
                {
                    Success = true,
                    Message = "Score Changed .",
                    Result = newScore.Value
                });
            else
                return StatusCode(500, new StandardResult()
                {
                    Success = false,
                    Message = "internal server Error !"
                });
        }
    }
}
