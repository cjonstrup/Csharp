using Nancy;
using Nancy.Security;

namespace WebServer.Routes.Protected
{
    public class StatusModule : NancyModule
    {
        public StatusModule()
        {
            this.RequiresAuthentication();
            this.RequiresClaims(new[] { "Admin" });

            Get["/v1/status"] = parameters =>
            {
                var feeds = new string[] { "ok1", "ok2" };
                return Response.AsJson(feeds);
            };

        }
    }
}
