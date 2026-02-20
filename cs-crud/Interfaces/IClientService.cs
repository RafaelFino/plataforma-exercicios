namespace CRUD.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Domain.Client> GetAll(bool includeInactive = false);

        IEnumerable<Domain.Client> GetFiltered(IDictionary<string, string> filters);
        
        Domain.Client? GetByID(string id);

        string Create(string name, string email, DateTime birthDate);

        bool Update(Domain.Client client);

        bool Delete(string id);
    }
}