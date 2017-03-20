using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelo
{
    public class Promocion
    {
        public int PromocionId { get; set; }
        public byte[] ImagePromocion { get; set; }
        public string NombreImagen { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
    }
}
