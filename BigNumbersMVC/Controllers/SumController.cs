using System;
using System.Web.Mvc;
using BigNumbersMVC.Helpers;
using BigNumbersMVC.Models;
using NLog;

namespace BigNumbersMVC.Controllers
{
    public class SumController : Controller
    {
        private ILogger logger;

        public SumController(ILogger logger)
        {
            this.logger = logger;
        }
        public ActionResult Sum()
        {
            return View(new BigNumbersSumViewModel());
        }

        [HttpPost]
        public ActionResult Sum(BigNumbersSumViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = BigNumbersHelper.Sum(model.Number1, model.Number2);
                logger.Log(LogLevel.Info, $"{model.Number1}, {model.Number2}, {model.Result}");
            }

            return View(model);
        }
    }
}