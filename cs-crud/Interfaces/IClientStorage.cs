namespace CRUD.Interfaces
{
    public interface IClientStorage
    {
        bool Create(Domain.Client client);
        bool Update(string id, Domain.UpdateClientRequest client);
        bool Delete(string id);
        Domain.Client? GetByID(string id);        
        Domain.Client? GetByName(string name);
        IEnumerable<Domain.Client> GetAll(bool includeInactive = false);
        IEnumerable<Domain.Client> GetFiltered(IDictionary<string, string> filters);      
    }
}