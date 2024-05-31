using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ODataBookStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class PressController : Controller
{
    private readonly HttpClient client = null;
    private string ProductApiUrl = "";

    public PressController()
    {
        client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
        ProductApiUrl = "https://localhost:5001/odata/Presses";
    }

    // GET: PressController
    public async Task<IActionResult> Index()
    {
        HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
        string strData = await response.Content.ReadAsStringAsync();

        dynamic temp = JObject.Parse(strData);
        var lst = temp.value;
        List<Press> items = ((JArray)temp.value).Select(x => new Press
        {
            Id = (int)x["Id"],
            Name = (string)x["Name"]
        }).ToList();

        return View(items);
    }
}
