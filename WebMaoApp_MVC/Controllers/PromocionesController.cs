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
    [RoutePrefix("api/Promociones")]
    public class PromocionesController : ApiController
    {
        [Route("")]
        public List<PromocionDto> GetPromociones()
        {
            PromocionBLL p = new PromocionBLL();
            return p.GetPromiciones();
        }
    }
}
