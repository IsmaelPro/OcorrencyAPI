using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entites
{
    public class Ocorrencia
    {
        [Key]
        public int IdOcorrencia { get; set; }
        public int IndFinalizadora { get; set; }
        public string TipoOcorrencia { get; set; }
        public DateTime HoraOcorrencia { get; set; }
    }
}
