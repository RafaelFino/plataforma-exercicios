using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Storage
{
    public enum StorageType
    {
        InMemory,
        SQLite
    }
    public class ClientStorageFactory
    {
        public static Interfaces.IClientStorage Create(StorageType type)
        {
            switch (type)
            {
                case StorageType.InMemory:
                    return new InMemory.ClientStorage();
                case StorageType.SQLite:
                    return new SQLite.ClientStorage();
                default:
                    throw new ArgumentException("Invalid storage type");
            }
        }   
    }
}