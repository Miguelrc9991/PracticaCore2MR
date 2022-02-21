using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2MR.Models
{
    [Table("PEDIDOS")]
    public class Pedido
    {
        [Key]
        [Column("IDPEDIDO")]
        public int IDPEDIDO { get; set; }
        [Column("IDFACTURA")]
        public int IDFACTURA { get; set; }
        [Column("FECHA")]
        public string FECHA { get; set; }
        [Column("IDLIBRO")]
        public int IDLIBRO { get; set; }
        [Column("IDUSUARIO")] 
        public int IDUSUARIO { get; set; }
        [Column("CANTIDAD")] 
        public int CANTIDAD { get; set; }
       
    }
}
