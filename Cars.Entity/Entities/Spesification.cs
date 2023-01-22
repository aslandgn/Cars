namespace Cars.Entity.Entities
{
    public class Spesification : BaseWithId<int>
    {
        public string Name { get; set; }
        public IEnumerable<VersionSpesification> VersionSpesifications { get; set; }
    }
}
