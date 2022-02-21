using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2MR.Models
{
    [Table("V_LIBRO_INDIVIDUAL")]
    public class VistaLibros
    {
        [Key]
        [Column("IdLibro")]
        public int IdLibro { get; set; }
        [Column("Titulo")]
        public string Titulo { get; set; }
        [Column("Autor")]
        public string Autor { get; set; }
        
        [Column("Portada")]
        public string Portada { get; set; }
        [Column("POSICION")]
        public int Posicion { get; set; }

    }
}
