namespace Cars.Entity.Entities
{
    public class Model : BaseWithId<int>
    {
        public int BrandId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short StartDate { get; set; }
        public short EndDate { get; set; }

        public Brand Brand { get; set; }
        public IEnumerable<Version> Versions { get; set; }
    }
}