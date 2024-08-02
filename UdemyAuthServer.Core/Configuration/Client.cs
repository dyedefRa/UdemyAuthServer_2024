using System.Collections.Generic;

namespace UdemyAuthServer.Core.Configuration
{
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public List<string> Audience { get; set; }
    }
}
