namespace Finale.Services
{
    public interface IServicesLett<T>
    {
        IEnumerable<T> List();
        T? Details(int id);
    }
}
