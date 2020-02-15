using System;
using System.Net;
using CleanControllers.Web.Models.Business;
using Microsoft.AspNetCore.Mvc;

namespace CleanControllers.Web.Controllers
{
    public class CleanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoStuff(Person.Builder builder)
        {
            var buildResult = builder.Build();
            if(buildResult.IsValid == false)
                return new JsonResult(new
                {
                    errorCodes = buildResult.ErrorCodes
                }) {StatusCode = (int)HttpStatusCode.BadRequest};

            try
            {
                // we have a valid person at this point for sure
                var person = buildResult.Value;

                // ...execute operations with 'person'...
                if(builder.ShouldCauseServerError)
                    throw new InvalidOperationException("Something happened but this time we can be sure that our Person was valid which means something else failed in our services.");

                return new JsonResult(new
                {
                    message = "Everything went smooth"
                }) {StatusCode = (int)HttpStatusCode.OK};
            }
            catch (Exception e)
            {
                return new JsonResult(new
                {
                    errors = new string[]{e.Message}
                }){ StatusCode = (int)HttpStatusCode.InternalServerError};
            }
        }
    }
}