using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccess.Contracts
{
    public interface IGenericRepository<Entity> where Entity:class
    {
        int Add(Entity entity);
        int Adit(Entity entity);
        int Remove(int id_user);
        IEnumerable<Entity> GetALL();
        DataTable Encontrar();
    }
}
