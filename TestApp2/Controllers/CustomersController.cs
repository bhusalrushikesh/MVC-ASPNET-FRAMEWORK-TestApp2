using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TestApp2.Models;
using TestApp2.ViewModels;

namespace TestApp2.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;


        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
            {

                return View(customers);
            }
            return View("ReadOnlyList", customers);

        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer); // Pass a single Customer object to the Details view
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes

            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };

                return View("New", viewmodel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var custInDB = _context.Customers.Single(c => c.Id == customer.Id);
                custInDB.Name = customer.Name;
                custInDB.BirthDay = customer.BirthDay;
                custInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                custInDB.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes
            };

            return View("New", viewModel);
        }


        public ActionResult Delete(int id)
        {
            var custInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (custInDb == null)
                return HttpNotFound();

            _context.Customers.Remove(custInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}