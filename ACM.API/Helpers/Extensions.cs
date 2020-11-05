using Microsoft.AspNetCore.Http;

namespace ACM.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            // add a new header called application Error
            response.Headers.Add("Application-Error", message);
            // Allow these to be displayed
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");

        }
    }
}