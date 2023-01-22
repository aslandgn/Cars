namespace Cars.Entity.Entities
{
    public class TransmissionType: BaseWithId<short>
    {
        public string Name { get; set; }

        public IEnumerable<Version> Versions { get; set; }
    }
}
