using System.Web.Mvc;
using BigNumbersMVC.Model;

namespace BigNumbersMVC.Controllers
{
    public class LogsController : Controller
    {
        // provided by Unity
        private ILogReader reader;

        public LogsController(ILogReader reader)
        {
            this.reader = reader;
        }

        // TODO paging
        public ActionResult Logs()
        {
            return View(reader.ReadAll());
        }
    }
}