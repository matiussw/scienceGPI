using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace scienceGPI.shared.Entities
{
    public class Project
	{
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]

        public String Name { get; set; } = null!;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinalizacion { get; set; }

        [Display(Name = "Nombre Lider de Proyecto")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]

        public String LiderName { get; set; } = null!;

        [Display(Name = "Descripcion Proyecto")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(200, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]

        public String Descripcion { get; set; } = null!;

        [Display(Name = "Area Proyecto")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de un {1} Caracteres")]

        public String Area { get; set; } = null!;

    }
}

