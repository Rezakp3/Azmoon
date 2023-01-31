using System.ComponentModel.DataAnnotations;

namespace TravelService.Model
{
    public class Traveler
    {
        [Key]
        public Guid Id { get; init; }
        [MaxLength(20)]
        public string Name { get; private set; }
        [MaxLength(30)]
        public string Family { get; private set; }
        [MaxLength(11)]
        public string NationalCode { get; private set; }
        [MaxLength(13)]
        public string Number { get; private set; }

        public List<Travel> Travels { get; set; }

        public Traveler(string name, string family, string nationalCode, string number)
        {
            Id = Guid.NewGuid();
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            Number = number;
        }
        
        public void Update(string name, string family, string nationalCode, string number)
        {
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            Number = number;
        }
    }
}
