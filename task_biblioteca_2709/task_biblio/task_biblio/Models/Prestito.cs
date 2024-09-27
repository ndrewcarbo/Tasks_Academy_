using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_biblio.Models
{
    internal abstract class Prestito
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string? Data_st { get; set; } = null!;
        public string? Data_ret { get; set; } 

    }
}
