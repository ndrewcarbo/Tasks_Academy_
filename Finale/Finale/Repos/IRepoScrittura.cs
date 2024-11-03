namespace Finale.Repos
{
    public interface IRepoScrittura<T>
    {
        bool Create(T t);
        bool Update(T t);
        bool Delete(int id);
    }
}
