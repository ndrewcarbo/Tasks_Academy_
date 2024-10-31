namespace TaskFinale.Repos
{
    public interface IReposLettura<T>
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
    }
}
