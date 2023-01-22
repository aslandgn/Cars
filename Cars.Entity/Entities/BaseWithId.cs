namespace Cars.Entity.Entities
{
    public abstract class BaseWithId<N> : Base
    {
        public N Id { get; set; }
    }
}
