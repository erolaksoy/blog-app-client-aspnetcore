using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using WorksBlogProjectClient.Extensions;
using WorksBlogProjectClient.Models;

namespace WorksBlogProjectClient.Filters
{
    public class JwtAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("Token");
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new RedirectToActionResult("SignIn", "Account",new{@area=""});
            }
            else
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = httpClient.GetAsync("http://localhost:57240/api/Auth/ActiveUser").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var activeUser = JsonConvert.DeserializeObject<AppUserViewModel>(responseMessage.Content.ReadAsStringAsync().Result);
                    context.HttpContext.Session.SetObject(activeUser, "ActiveUser");
                }
                else
                {
                    context.Result = new RedirectToActionResult("SignIn", "Account", new {@area=""});
                }
            }
        }
    }
}