namespace TaskFinale.Services
{
    public interface IServiceLettura<T>
    {
        IEnumerable<T> List();
        T? Details(int id);
    }
}
