namespace ViaGio_task.Repositories
{
    public interface IRepoLettura<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
    }
}
