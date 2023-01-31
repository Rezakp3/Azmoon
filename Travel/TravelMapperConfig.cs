using AutoMapper;
using TravelService.Model;
using TravelService.Model.DTO;

namespace TravelService
{
    public class TravelMapperConfig : Profile
    {
        public TravelMapperConfig()
        {
            CreateMap<AddTravelerDto, Traveler>();
        }
    }
}
