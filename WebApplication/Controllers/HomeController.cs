using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [HttpPost]
        public IActionResult DoLogin()
        {
            return Redirect(Constants.AUTH0_AUTH_URL);
        }

        [HttpPost]
        public IActionResult DoLogout()
        {
            return Redirect(Constants.AUTH0_LOGOUT_URL);
        }

        [HttpPost]
        public async Task<IActionResult> DoAction(IndexViewModel model)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Constants.EXECUTE_URL);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", model.AccessToken);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                model.TestData = result;
            }
            else
            {
                model.TestData = $"Error code: {response.StatusCode}";
            }

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
