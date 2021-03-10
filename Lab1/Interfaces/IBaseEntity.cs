namespace Lab1.Interfaces
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}