using Microsoft.Owin;
using Owin;
using System.Text;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            

        }

        private class JwtBearerOptions
        {
            public bool AutomaticAuthenticate { get; set; }
            public bool AutomaticChallenge { get; set; }
            public object TokenValidationParameters { get; set; }
        }

        private class TokenValidationParameters
        {
            public object IssuerSigningKey { get; set; }
            public object ValidAudience { get; set; }
            public bool ValidateIssuerSigningKey { get; set; }
            public bool ValidateLifetime { get; set; }
            public object ValidIssuer { get; set; }
        }

        private class SymmetricSecurityKey
        {
            private object p;

            public SymmetricSecurityKey(object p)
            {
                this.p = p;
            }
        }
    }
}
