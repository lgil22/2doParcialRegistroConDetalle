using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _2doParcial.Entidades
{
    public class LlamadasDetalle
    {
        [Key]
        public int id { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadasDetalle()
        {
            id = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }
    }
}
