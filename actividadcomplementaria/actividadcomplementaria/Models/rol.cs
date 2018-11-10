using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace actividadcomplementaria.Models
{
    public class rol
    {
        [Key]
        public int ID_rol { get; set; }

        public string nombre_rol { get; set; }
        public string descripcion { get; set; }
    }
}
