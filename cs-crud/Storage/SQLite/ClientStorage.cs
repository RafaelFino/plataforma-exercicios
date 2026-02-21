using Microsoft.Data.Sqlite;
using CRUD.Commons;
using System;

namespace CRUD.Storage.SQLite
{
    public class ClientStorage : Interfaces.IClientStorage
    {
        private readonly Microsoft.Data.Sqlite.SqliteConnection _connection = new Microsoft.Data.Sqlite.SqliteConnection("Data Source=clients.sqlite3");

        public ClientStorage()
        {
            _connection.Open();
            var command = _connection.CreateCommand();
            command.CommandText =
            @"
                CREATE TABLE IF NOT EXISTS Clients (
                    Id TEXT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    BirthDate TEXT NOT NULL,
                    IsActive INTEGER NOT NULL,
                    CreatedAt TEXT DEFAULT CURRENT_TIMESTAMP,
                    UpdatedAt TEXT DEFAULT CURRENT_TIMESTAMP
                );
            ";
            command.ExecuteNonQuery();
        }

        public bool Create(Domain.Client client)
        {
            try
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Creating client with ID: {client.Id}");
                var command = _connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO Clients (Id, Name, Email, BirthDate, IsActive) VALUES (@Id, @Name, @Email, @BirthDate, @IsActive);
                ";
                command.Parameters.AddWithValue("@Id", client.Id);
                command.Parameters.AddWithValue("@Name", client.Name);
                command.Parameters.AddWithValue("@Email", client.Email);
                command.Parameters.AddWithValue("@BirthDate", client.BirthDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@IsActive", client.IsActive ? 1 : 0);
                var ret = command.ExecuteNonQuery();                

                if (ret > 0)
                {
                    Logger.GetInstance().Log($"[SQLiteClientStorage] Client with ID {client.Id} created successfully.");
                    return true;
                }
                
                Logger.GetInstance().Log($"[SQLiteClientStorage] Failed to create client with ID {client.Id}.");
                return false;
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Error creating client: {ex.Message}");
                throw;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Deleting client with ID: {id}");
                var command = _connection.CreateCommand();
                command.CommandText = @"
                    UPDATE Clients SET IsActive = 0, UpdatedAt = CURRENT_TIMESTAMP WHERE Id = @Id;
                ";
                command.Parameters.AddWithValue("@Id", id);
                var ret = command.ExecuteNonQuery();

                if (ret == 0)             {
                    Logger.GetInstance().Log($"[SQLiteClientStorage] Client with ID {id} not found for deletion.");
                    return false;
                }                                

                return true;
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Error deleting client: {ex.Message}");
                throw;
            }
        }

        public bool Update(Domain.Client client)
        {
            try
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Updating client with ID: {client.Id}");
                var command = _connection.CreateCommand();
                command.CommandText = @"
                    UPDATE Clients SET Name = @Name, Email = @Email, IsActive = @IsActive, UpdatedAt = CURRENT_TIMESTAMP WHERE Id = @Id;
                ";
                command.Parameters.AddWithValue("@Id", client.Id);
                command.Parameters.AddWithValue("@Name", client.Name);
                command.Parameters.AddWithValue("@Email", client.Email);
                command.Parameters.AddWithValue("@IsActive", client.IsActive ? 1 : 0);
                var ret = command.ExecuteNonQuery();

                if (ret == 0)
                {
                    Logger.GetInstance().Log($"[SQLiteClientStorage] Client with ID {client.Id} not found for update.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Error updating client: {ex.Message}");
                throw;
            }            
        }        

        public IEnumerable<Domain.Client> GetAll(bool includeInactive = false)
        {
            try
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Fetching all clients (includeInactive={includeInactive})");
                var command = _connection.CreateCommand();
                command.CommandText = @"
                    SELECT Id, Name, Email, BirthDate, CreatedAt, UpdatedAt, IsActive FROM Clients" + (includeInactive ? "" : " WHERE IsActive = 1") + ";";
                
                var result = command.ExecuteReader();
                var clients = new List<Domain.Client>();

                while (result.Read())
                {
                    clients.Add(new Domain.Client(
                        result.GetString(0),
                        result.GetString(1),
                        result.GetString(2),
                        result.GetDateTime(3),
                        result.GetDateTime(3),
                        result.GetDateTime(5),
                        result.GetInt32(6) == 1
                    ));
                }

                return clients;
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Error fetching clients: {ex.Message}");
                throw;
            }
        }

        public Domain.Client? GetByID(string id) 
        { 
            try
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Fetching client by ID: {id}");
                var command = _connection.CreateCommand();
                command.CommandText = @"
                    SELECT Id, Name, Email, BirthDate, CreatedAt, UpdatedAt, IsActive FROM Clients WHERE Id = @Id AND IsActive = 1;";
                command.Parameters.AddWithValue("@Id", id);
                
                var result = command.ExecuteReader();

                if (result.Read())
                {
                    return new Domain.Client(
                        result.GetString(0),
                        result.GetString(1),
                        result.GetString(2),
                        result.GetDateTime(3),
                        result.GetDateTime(3),
                        result.GetDateTime(5),
                        result.GetInt32(6) == 1
                    );
                }
                else
                {
                    Logger.GetInstance().Log($"[SQLiteClientStorage] Client with ID {id} not found.");                    
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Error fetching client by ID: {ex.Message}");
                throw;
            }

            return null;
        }
        public Domain.Client? GetByName(string name) 
        { 
            try
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Fetching client by name: {name}");
                var command = _connection.CreateCommand();
                command.CommandText = @"
                    SELECT Id, Name, Email, BirthDate, CreatedAt, UpdatedAt, IsActive FROM Clients WHERE Name = @Name AND IsActive = 1;";
                command.Parameters.AddWithValue("@Name", name);
                
                var result = command.ExecuteReader();

                if (result.Read())
                {
                    return new Domain.Client(
                        result.GetString(0),
                        result.GetString(1),
                        result.GetString(2),
                        result.GetDateTime(3),
                        result.GetDateTime(3),
                        result.GetDateTime(5),
                        result.GetInt32(6) == 1
                    );
                }
                else
                {
                    Logger.GetInstance().Log($"[SQLiteClientStorage] Client with name {name} not found.");                    
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Error fetching client by name: {ex.Message}");
                throw;
            }

            return null;
        }

        public IEnumerable<Domain.Client> GetFiltered(IDictionary<string, string> filters)
        {
            try
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Fetching filtered clients with filters: {string.Join(", ", filters.Select(f => $"{f.Key}={f.Value}"))}");
                var command = _connection.CreateCommand();
                var whereClauses = new List<string>();

                foreach (var filter in filters)
                {
                    switch (filter.Key.ToLower())
                    {
                        case "name":
                            whereClauses.Add("Name = @Name");
                            command.Parameters.AddWithValue("@Name", filter.Value);
                            break;
                        case "email":
                            whereClauses.Add("Email = @Email");
                            command.Parameters.AddWithValue("@Email", filter.Value);
                            break;
                        case "birthdate":
                            if (DateTime.TryParse(filter.Value, out var birthDate))
                            {
                                whereClauses.Add("DATE(BirthDate) = DATE(@BirthDate)");
                                command.Parameters.AddWithValue("@BirthDate", birthDate.ToString("yyyy-MM-dd"));    
                            }
                            break;
                        case "active":
                            if (bool.TryParse(filter.Value, out var isActive))
                            {
                                whereClauses.Add("IsActive = @IsActive");
                                command.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);    
                            }
                            break;
                        
                    }
                }

                command.CommandText = @"
                    SELECT Id, Name, Email, BirthDate, CreatedAt, UpdatedAt, IsActive FROM Clients" + 
                    (whereClauses.Count > 0 ? " WHERE " + string.Join(" AND ", whereClauses) : "") + ";";
                
                var result = command.ExecuteReader();
                var clients = new List<Domain.Client>();

                while (result.Read())
                {
                    clients.Add(new Domain.Client(
                        result.GetString(0),
                        result.GetString(1),
                        result.GetString(2),
                        result.GetDateTime(3),
                        result.GetDateTime(3),
                        result.GetDateTime(5),
                        result.GetInt32(6) == 1
                    ));
                }

                return clients;
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log($"[SQLiteClientStorage] Error fetching filtered clients: {ex.Message}");
                throw;
            }
        }        
    }
}