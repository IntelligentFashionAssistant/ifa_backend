namespace ifa_front.Helper
{
    public class HelperApi
    {

        public HttpClient Intial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7297");

            return client;
        }
    }
}
