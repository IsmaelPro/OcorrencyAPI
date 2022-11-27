using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entites
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public int NumeroPedido { get; set; }
        public List<Ocorrencia> Ocorrencias { get; set; }
        public DateTime HoraPedido { get; set; }
        public bool IndCancelado { get; set; }
        public bool IndConcluido { get; set; }
    }
}
