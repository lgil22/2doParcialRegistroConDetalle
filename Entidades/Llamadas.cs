using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2doParcial.Entidades
{
    public class Llamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("id")]

        public virtual List<LlamadasDetalle> Detalles { get; set; } = new List<LlamadasDetalle>();
        public Llamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;
            Detalles = new List<LlamadasDetalle>();
        }
    }
}
