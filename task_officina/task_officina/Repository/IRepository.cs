namespace task_officina.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? GetbyId(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
