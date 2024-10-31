namespace TaskFinale.Repos
{
    public interface IReposScrittura<T>
    {
        bool Create(T entity);
        bool Delete(int id);
        bool Update(T entity);
    }
}
