using System.Linq;

namespace Lab1.Interfaces
{
    public interface ISortUtils<T>
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
    }
}