using System;

namespace CreataceousPark.Models
{
  public class Headline
  {
    public int HeadlineId { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public Headline(string title, string summary)
    {
      Title = title;
      Summary = summary;
    }
  }
}

// static void Main()
//         {
//             var apiCallTask = ApiHelper.ApiCall("a8N9RYvKvHtG8rQCQlv2jCJCqNvEbptD");
//             var result = apiCallTask.Result;
//             JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
//             List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());

//             foreach (Article article in articleList)
//             {
//                 Console.WriteLine($"Section: {article.Section}");
//                 Console.WriteLine($"Title: {article.Title}");
//                 Console.WriteLine($"Abstract: {article.Abstract}");
//                 Console.WriteLine($"Url: {article.Url}");
//                 Console.WriteLine($"Byline: {article.Byline}");
//             }
//         }