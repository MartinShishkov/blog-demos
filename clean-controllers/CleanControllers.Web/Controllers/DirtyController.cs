using System;
using System.Linq;
using System.Net;
using CleanControllers.Web.Models.Business;
using CleanControllers.Web.Models.Web;
using Microsoft.AspNetCore.Mvc;

namespace CleanControllers.Web.Controllers
{
    public class DirtyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoStuff(SimpleFormPostModel model)
        {
            if (model.Consent == null || model.Consent.Contains("yes") == false)
            {
                // This is business logic right here
                // we could have created a custom ValidationAttribute.
                // Although this is going to be slightly better - 
                // the issue still remains. Furthermore, we are going 
                // to have some trouble if we want to use localization for
                // our errors if we rely on [ValidationAttribute]s
                ModelState.AddModelError(
                    nameof(SimpleFormPostModel.Consent), 
                    "You have to give your consent"
                );
            }

            if (ModelState.IsValid == false)
                return new JsonResult(new
                {
                    // even getting the error messages is an abomination
                    errors = ModelState.Values.SelectMany(e => e.Errors.Select(err => err.ErrorMessage))
                }) {StatusCode = (int)HttpStatusCode.BadRequest};

            try
            {
                var person = new Person(model.FirstName, model.LastName, model.Age);

                if(model.ShouldCauseServerError)
                    throw new InvalidOperationException("Something happened with our Person because our validation logic is all over the place! It was not in valid state to begin with!");

                // ...execute operations with 'person'...

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
