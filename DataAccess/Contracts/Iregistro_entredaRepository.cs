using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Data;

namespace DataAccess.Contracts
{
    public interface Iregistro_entredaRepository:IGenericRepository<registro_entrada>
    {
        DataTable todoLosRegistros();
    }
}
