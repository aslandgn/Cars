namespace Cars.Entity.Entities
{
    public class VersionSpesification : Base
    {
        public int VersionId { get; set; }
        public int SpesificationId { get; set; }

        public Version Version { get; set; }
        public Spesification Spesification { get; set; }
    }
}
