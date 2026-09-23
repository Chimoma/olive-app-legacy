using System.Linq;
using System.Web.Mvc;
using OliveApp.Legacy.Data;

namespace OliveApp.Legacy.Controllers
{
    // Synchronous controller over a classic EF6 DbContext - representative
    // of the pre-modernization data-access pattern targeted for transformation.
    public class CustomersController : Controller
    {
        private readonly OliveLegacyDbContext db = new OliveLegacyDbContext();

        // GET: /Customers
        public ActionResult Index()
        {
            var customers = db.Customers.OrderBy(c => c.Id).ToList();
            return View(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
