using CRUD.Commons;

namespace CRUD.Storage.InMemory
{
    public class ClientStorage : Interfaces.IClientStorage
    {
        private IDictionary<string, Domain.Client> _clients = new Dictionary<string, Domain.Client>();   
        private readonly object _lock = new object();     

        public bool Create(Domain.Client client)
        {
            if (client == null)
            {
                Logger.GetInstance().Log("[InMemoryClientStorage] Attempted to create a null client.");
                throw new ArgumentNullException(nameof(client));
            }

            if (_clients.ContainsKey(client.Id))
            {
                Logger.GetInstance().Log($"[InMemoryClientStorage] Client with ID {client.Id} already exists.");
                return false;
            }

            Logger.GetInstance().Log($"[InMemoryClientStorage] Creating client with ID: {client.Id}");  
            lock(_lock)
            {                
                _clients.Add(client.Id, client);
            }

            return true;
        }

        public bool Delete(string id)
        {
            bool ret = false;
            lock(_lock)
            {
                if (_clients.ContainsKey(id))
                {
                    Logger.GetInstance().Log($"[InMemoryClientStorage] Deleting client with ID: {id}");                  
                    ret = _clients.Remove(id);                
                }
                else
                {
                    Logger.GetInstance().Log($"[InMemoryClientStorage] Client with ID {id} not found for deletion.");
                }
            }

            return ret;
        }

        public bool Update(string id, Domain.UpdateClientRequest client)
        {
            bool ret = false;
            try
            {
                lock(_lock)
                {
                    if (_clients.ContainsKey(id))
                    {
                        Logger.GetInstance().Log($"[InMemoryClientStorage] Updating client with ID: {id}");                        
                        var c = _clients[id];
                        c.Name = client.Name;
                        c.Email = client.Email;
                        c.BirthDate = client.BirthDate;
                        c.UpdatedAt = DateTime.Now;
                        _clients[id] = c;
                        ret = true;                    
                    }
                    else 
                    {
                        Logger.GetInstance().Log($"[InMemoryClientStorage] Client with ID {id} not found for update.");
                    }                
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log($"[InMemoryClientStorage] Error updating client: {ex.Message}");
                throw;
            }

            return ret;
        }        

        public Domain.Client? GetByID(string id) 
        { 
            Domain.Client? ret;
            if (!_clients.TryGetValue(id, out ret))
            {
                Logger.GetInstance().Log($"[InMemoryClientStorage] Client with ID {id} not found.");    
            }            
            
            return ret;
        }
        public Domain.Client? GetByName(string name) 
        { 
            var client = _clients.Values.FirstOrDefault(c => 
                        !string.IsNullOrWhiteSpace(c.Name) 
                        && c.Name.Trim().Equals(name, StringComparison.OrdinalIgnoreCase)
                    );
            if (client == null)
            {
                Logger.GetInstance().Log($"[InMemoryClientStorage] Client with name {name} not found.");
            }
            return client;
        }

        public IEnumerable<Domain.Client> GetAll(bool includeInactive = false)
        {
            return _clients.Values.Where(c => includeInactive || c.IsActive);
        }

        public IEnumerable<Domain.Client> GetFiltered(IDictionary<string, string> filters)
        {
            var result = new List<Domain.Client>();

            foreach(var c in _clients.Values)
            {
                foreach (var filter in filters)
                {                
                    switch (filter.Key.ToLower())
                    {
                        case "name":
                            if(filter.Value.Trim().Equals(c.Name))
                                result.Add(c);
                            break;
                        case "email":
                            if(filter.Value.Trim().Equals(c.Email))
                                result.Add(c);  
                            break;
                        case "birthdate":
                            if (DateTime.TryParse(filter.Value, out var birthDate))
                            {
                                if (c.BirthDate.Date == birthDate.Date)
                                    result.Add(c);
                            }                            
                            break;
                        case "isactive":
                            if (bool.TryParse(filter.Value, out var isActive))
                            {
                                if (c.IsActive == isActive)
                                    result.Add(c);
                            }
                            break;
                    }
                }
            }

            Logger.GetInstance().Log($"[InMemoryClientStorage] GetFiltered with {filters.Count} filters returned {result.Count()} clients.");   
            return result;
        }
    }
}