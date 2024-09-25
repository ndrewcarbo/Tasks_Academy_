using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edicola_25sett.Models.DAL
{
   
        internal interface IDaoScrittura<T>
        {
            bool Insert(T t);
            bool Update(T t);
            bool Delete(int id);
        }

}
