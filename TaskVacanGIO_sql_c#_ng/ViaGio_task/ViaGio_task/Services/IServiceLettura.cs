namespace ViaGio_task.Services
{
    public interface IServiceLettura<T>
    {
        IEnumerable<T> CercaTutti();

        T? CercaPerCodice(string varCod);
    }
}
