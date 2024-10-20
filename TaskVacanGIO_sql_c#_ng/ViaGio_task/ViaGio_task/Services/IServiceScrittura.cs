namespace ViaGio_task.Services
{
    public interface IServiceScrittura<T>
    {
        bool Inserisci(T entity);
        bool Aggiorna(T entity);
        bool Elimina(string codice);
    }
}
