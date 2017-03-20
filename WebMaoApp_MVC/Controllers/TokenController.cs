using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebMaoApp_MVC.Controllers
{
    [RoutePrefix("api/Token")]
    public class TokenController : ApiController
    {
        [Route("")]
        public List<UsuarioDto> GetUsuario()
        {
            UsuarioBLL o = new UsuarioBLL();
            return o.GetUsaurios();
        }
        [Route("")]
        public string PostUsuario(UsuarioDto u)
        {
            UsuarioBLL o = new UsuarioBLL();
            return o.PostUsuario(u);
        }
    }
}
