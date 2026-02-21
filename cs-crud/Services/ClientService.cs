using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Interfaces;
using CRUD.Domain;
using CRUD.Commons;

namespace CRUD.Services
{
    public class ClientService : Interfaces.IClientService
    {
        private Interfaces.IClientStorage _storage;

        public ClientService(Interfaces.IClientStorage storage)
        {
            _storage = storage;
        }

        public IEnumerable<Domain.Client> GetAll(bool includeInactive = false)
        {
            try
            {  
                Logger.GetInstance().Log("[ClientService] Fetching all clients");              
                return _storage.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClientService] Error in GetAll: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Domain.Client> GetFiltered(IDictionary<string, string> filters)
        {
            try
            {
                Logger.GetInstance().Log("[ClientService] Fetching filtered clients");
                return _storage.GetFiltered(filters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClientService] Error in GetFiltered: {ex.Message}");
                throw;
            }
        }

        
        public Domain.Client? GetByID(string id)
        {
            try
            {
                Logger.GetInstance().Log($"[ClientService] Fetching client by ID: {id}");
                return _storage.GetByID(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClientService] Error in GetByID: {ex.Message}");
                throw;
            }
        }

        public string Create(string name, string email, DateTime birthDate)
        {
            try
            {
                var client = new Domain.Client(
                    IDCreator.NewId(), 
                    name, 
                    email, 
                    birthDate, 
                    DateTime.Now, 
                    DateTime.Now, 
                    true);

                Logger.GetInstance().Log($"[ClientService] Creating client: {client.Name} with ID: {client.Id}");
                var result = _storage.Create(client);

                if (!result)
                {
                    Logger.GetInstance().Log($"[ClientService] Failed to create client: {client.Name} with ID: {client.Id}");
                    return string.Empty;
                }   

                Logger.GetInstance().Log($"[ClientService] Client created successfully: {client.Name} with ID: {client.Id}");   
                return client.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClientService] Error in Create: {ex.Message}");
                throw;
            }
        }

        public bool Update(string id, Domain.UpdateClientRequest client)
        {
            try
            {
                Logger.GetInstance().Log($"[ClientService] Updating client: {client.Name}");
                return _storage.Update(id, client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClientService] Error in Update: {ex.Message}");
                throw;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                Logger.GetInstance().Log($"[ClientService] Deleting client with ID: {id}");
                return _storage.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClientService] Error in Delete: {ex.Message}");
                throw;
            }
        }   
    }
}