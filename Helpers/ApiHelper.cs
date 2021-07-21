using System.Threading.Tasks;
using RestSharp;

namespace CreataceousPark.Helpers
{
  public class ApiHelper
  {
    public static async Task<string> NytApiCall(string apiKey)
    {
      RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
      RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}
