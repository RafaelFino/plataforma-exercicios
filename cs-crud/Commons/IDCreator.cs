using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Commons
{
    public class IDCreator
    {
        public static string NewId()
        {
            return Ulid.NewUlid().ToString();
        }   
    }
}