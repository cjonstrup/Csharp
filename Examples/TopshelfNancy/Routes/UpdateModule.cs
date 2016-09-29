using Nancy;

namespace WebServer.Routes
{
    public class UpdateModule : NancyModule
    {
        public UpdateModule()
        {
            Get["/v1/feeds"] = parameters =>
            {
                var feeds = new string[] { "x1", "x2" };
                return Response.AsJson(feeds);
            };
        }

    }
}
