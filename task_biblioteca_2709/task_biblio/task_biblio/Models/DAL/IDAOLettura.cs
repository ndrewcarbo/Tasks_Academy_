using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_biblio.Models.DAL
{
    internal interface IDAOLettura<T>
    {
        List<T> GetAll();               
        T GetById(int id);              
        T GetByCodice(string cod);
    }
}
