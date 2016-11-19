namespace SuperheroesUniverse.Data.Common
{
    using System.Linq;

    public interface IRepository<T>
        where T : class
    {
        //IEnumerable<T> GetAll();

        //IEnumerable<T1> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> selectExpression);

        // For queryable collections
        IQueryable<T> GetAll { get; }

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}