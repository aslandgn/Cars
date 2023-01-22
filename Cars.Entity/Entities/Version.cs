namespace Cars.Entity.Entities
{
    public class Version : BaseWithId<int>
    {
        public string Name { get; set; }
        public int ModelId { get; set; }
        public short TransmissionTypeId { get; set; }

        public Model Model { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public IEnumerable<VersionSpesification> VersionSpesifications { get; set; }
    }
}
