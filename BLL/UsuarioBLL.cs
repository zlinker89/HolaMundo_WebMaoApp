using DAL.Modelo;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        Context ctx;

        public List<UsuarioDto> GetUsaurios()
        {
            using (ctx = new Context())
            {
                return ctx.Usuario.Select(x => new UsuarioDto()
                {
                    Token = x.Token,
                    UsuarioId = x.UsuarioId
                }).ToList();
            }
        }


        public string PostUsuario(UsuarioDto u)
        {
            using (ctx = new Context())
            {
                if (ctx.Usuario.Where(x => x.Token == u.Token).Count() > 0)
                {
                    return "Ya existe";
                }
                ctx.Usuario.Add(new Usuario() {
                    UsuarioId = 0,
                    Token = u.Token
                });
                ctx.SaveChanges();
                return "Guardado";
            }
        }
    }
}
