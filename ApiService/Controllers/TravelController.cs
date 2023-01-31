using DriverService.Contract;
using FactorService.Contract;
using FactorService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TravelService.Contract;
using TravelService.Model;
using TravelService.Model.DTO;

namespace ApiService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelRepo tr;
        private readonly IFactorRepo fr;
        private readonly IDriverRepo dr;

        public TravelController(ITravelRepo tr, IFactorRepo fr, IDriverRepo dr)
        {
            this.tr = tr;
            this.fr = fr;
            this.dr = dr;
        }

        [HttpPost]
        public IActionResult Create(AddTravelDto dto)
        {
            int OfferPrice = dto.OfferCode.IsNullOrEmpty() ? 0 : fr.GetOffer(dto.OfferCode);
            (int distance, int price) = fr.CalculatePrice(dto.Start, dto.End);
            var factor = new Factor(dto.TravelerId, dto.DriverId, price, OfferPrice);
            if(fr.Create(factor))
            {
                var travel = new Travel(dto.Start, dto.End, distance,dto.DriverId, dto.OfferCode, State.Start, factor.TravelCode,dto.TravelerId);
                if(tr.Create(travel))
                    return StatusCode(200, new StandardResult<Guid>()
                    {
                        Success = true,
                        Message = "Travel Created .",
                        Result = travel.TravelCode
                    });

                return StatusCode(500, new StandardResult()
                {
                    Success = false,
                    Message = "internal server Error !"
                });
            }
            else
            {
                return StatusCode(500, new StandardResult()
                {
                    Success = false,
                    Message = "Can't create Factor ."
                });
            }
        }

        [HttpPatch]
        public IActionResult EndTravel(int id)
        {
            if (tr.EndTravel(id))
            {
                dr.AddScore(tr.GetDriverId(id), 10);
                return StatusCode(200, new StandardResult<Guid>()
                {
                    Success = true,
                    Message = "Travel Ended ."
                });
            }

            return StatusCode(500, new StandardResult()
            {
                Success = false,
                Message = "internal server Error !"
            });
        }

        [HttpPatch]
        public IActionResult CancelTravel(int id)
        {
            if (tr.CancelTravel(id))
            {
                return StatusCode(200, new StandardResult<Guid>()
                {
                    Success = true,
                    Message = "Travel Canceled ."
                });
            }

            return StatusCode(500, new StandardResult()
            {
                Success = false,
                Message = "internal server Error !"
            });
        }


    }
}
