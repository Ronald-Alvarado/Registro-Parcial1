using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Parcial1Proyecto.Entidades
{
    public class Articulos
    {
        [Key]
        public int ProductoId { get; set; }
        public String Descripcion { get; set; }
        public int Existencia { get; set; }
        public int Costo { get; set; }
        public int ValorInventario { get; set; }

        public Articulos()
        {
            ProductoId = 0;
            Descripcion = String.Empty;
            Existencia = 0;
            Costo = 0;
            ValorInventario = 0;
        }

    }
}
