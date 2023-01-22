namespace Cars.Entity.Entities
{
    public class Brand : BaseWithId<int>
    {
        public string Name { get; set; }

        public IEnumerable<Model> Models { get; set; }
    }
}
