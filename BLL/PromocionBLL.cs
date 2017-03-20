using DAL.Modelo;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PromocionBLL
    {
        Context ctx;

        public void PostPromocion(byte[] imageData, string titulo, string mensaje)
        {
            using (ctx = new Context())
            {
                Promocion p = new Promocion()
                {
                    ImagePromocion = imageData,
                    Titulo = titulo,
                    NombreImagen = titulo,
                    Mensaje = mensaje
                };
                ctx.Promocion.Add(p);
                ctx.SaveChanges();
            }
        }

        public List<PromocionDto> GetPromiciones()
        {
            using (ctx = new Context())
            {
                List<PromocionDto> lst = new List<PromocionDto>();
                using (ctx = new Context())
                {
                    List<Promocion> plst = ctx.Promocion.OrderByDescending(x => x.PromocionId).ToList();
                    int cont = 0;
                    foreach (Promocion p in plst)
                    {
                        if (cont == 5)
                        {
                            return lst;
                        }
                        lst.Add(new PromocionDto()
                        {
                            PromocionId = p.PromocionId,
                            ImagePromocion = "data:image/jpeg;base64," + Convert.ToBase64String(p.ImagePromocion),
                            Mensaje = p.Mensaje,
                            Titulo = p.Titulo,
                            NombreImagen = p.NombreImagen
                        });
                    }
                    return lst;
                }
            }
        }
    }
}
