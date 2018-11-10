using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace actividadcomplementaria.Models
{
    public class area
    {
        [Key]
        public string ID_area { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del area debe tener 3 a 20")]
        public string Nombre_area { get; set; }


    }
}
