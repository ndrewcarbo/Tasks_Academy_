namespace Finale.Repos
{
    public interface IRepoLett<T>
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
    }
}
