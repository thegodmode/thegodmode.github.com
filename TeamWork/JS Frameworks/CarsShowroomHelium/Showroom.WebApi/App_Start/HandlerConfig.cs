using System.Collections.ObjectModel;
using System.Net.Http;
using Showroom.MessageHandlers;

namespace Showroom.WebApi.App_Start
{
    public class HandlerConfig
    {
        public static void RegisterHandlers(Collection<DelegatingHandler> handlers)
        {
            handlers.Add(new CorsMessageHandler());
        }
    }
}