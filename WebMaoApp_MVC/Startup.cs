using System;
using Microsoft.Owin;
using Owin;
using WebMaoApp_MVC.Security;

[assembly: OwinStartupAttribute(typeof(WebMaoApp_MVC.Startup))]
namespace WebMaoApp_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GenerarUsuario();
        }

        private void GenerarUsuario()
        {
            Role_Usuario ru = new Role_Usuario();
            ru.SetUsuarioRol();
        }
    }
}
