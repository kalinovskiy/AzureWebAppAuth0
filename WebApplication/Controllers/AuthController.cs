using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Dto;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Callback(string code)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Constants.AUTH0_TOKEN_URL)
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"grant_type", "authorization_code"},
                    {"client_id", Constants.AUTH0_CLIENT_ID},
                    {"client_secret", Constants.AUTH0_CLIENT_SECRET},
                    {"code", code},
                    {"redirect_uri", Constants.CALLBACK_URL}
                })
            };

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            var model = new IndexViewModel();

            if (response.IsSuccessStatusCode)
            {
                var tokensInfo = await response.Content.ReadAsAsync<DtoTokensInfo>();
                model.AccessToken = tokensInfo.AccessToken;
            }

            return View("~/Views/Home/Index.cshtml", model);
        }
    }
}