namespace DriverService.Model
{
    public class Driver
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Number { get; private set; }
        public string NationalCode { get; private set; }
        public string CarBrand { get; private set; }
        public string CarModel { get; private set; }
        public string CarTag { get; private set; }
        public int Score { get; private set; }
        public bool IsActive { get; private set; }
        public Driver(string name, string family, string number, string carBrand, string carModel, string carTag, string nationalCode)
        {
            Id = Guid.NewGuid();
            IsActive = true;
            Name = name;
            Family = family;
            Number = number;
            CarBrand = carBrand;
            CarModel = carModel;
            CarTag = carTag;
            NationalCode = nationalCode;
        }

        public void Update(string name, string family, string number, string carBrand, string carModel, string carTag, string nationalCode)
        {
            Name = name;
            Family = family;
            Number = number;
            CarBrand = carBrand;
            CarModel = carModel;
            CarTag = carTag;
            NationalCode = nationalCode;
        }
        public void ChangeScore(int score) => Score += score;
        public void SetActiveState(bool state) => IsActive = state;
    }
}
