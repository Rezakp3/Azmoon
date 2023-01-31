using Microsoft.AspNetCore.Mvc;
using TravelService.Model.DTO;
using TravelService.Model;
using TravelService.Contract;

namespace ApiService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TravelerController : ControllerBase
    {
        private readonly ITravelerRepo tr;

        public TravelerController(ITravelerRepo tr)
        {
            this.tr = tr;
        }

        [HttpPost]
        public IActionResult Create(AddTravelerDto travelerDto)
        {
            var traveler = new Traveler(travelerDto.Name, travelerDto.Family, travelerDto.NationalCode, travelerDto.Number);
            if (tr.Create(traveler))
                return StatusCode(200, new StandardResult<Traveler>()
                {
                    Success = true,
                    Message = "Traveler Created .",
                    Result = traveler
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
            var traveler = tr.FindBy(id);
            if (traveler is not null)
                return StatusCode(302, new StandardResult<Traveler>()
                {
                    Success = true,
                    Message = "Traveler Founded .",
                    Result = traveler
                });

            return StatusCode(404, new StandardResult()
            {
                Success = true,
                Message = "can't found traveler .",
            });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var traveler = tr.GetAll();
            if (traveler is not null)
                return StatusCode(302, new StandardResult<IEnumerable<Traveler>>()
                {
                    Success = true,
                    Message = "Travelers Founded .",
                    Result = traveler
                });

            return StatusCode(404, new StandardResult()
            {
                Success = true,
                Message = "can't found travelers .",
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Traveler traveler)
        {
            if (id != traveler.Id)
                return StatusCode(400, new StandardResult()
                {
                    Success = false,
                    Message = "wrong id !"
                });

            if (tr.Update(id, traveler))
                return StatusCode(200, new StandardResult<Traveler>()
                {
                    Success = true,
                    Message = "Traveler Updated .",
                    Result = traveler
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
            if (tr.Remove(id))
                return StatusCode(200, new StandardResult()
                {
                    Success = true,
                    Message = "Traveler Removed .",
                });

            return StatusCode(500, new StandardResult()
            {
                Success = false,
                Message = "internal server Error !"
            });
        }
    }
}
