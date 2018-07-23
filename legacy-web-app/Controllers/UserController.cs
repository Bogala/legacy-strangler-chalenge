using legacy_business_logic.Services;

using System.Web.Mvc;

using legacy_business_logic.Entities;

namespace legacy_web_app.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController() 
            : this(new UserService())
        {
        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            var model = _userService.GetAll();
            return View(model);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var model = _userService.GetEnrichedUserById(id);
            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new User();
            TryUpdateModel(model, collection);
            _userService.AddUser(model);
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _userService.GetUserById(id);
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = _userService.GetUserById(id);
            TryUpdateModel(model, collection);
            _userService.UpdateUser(model);
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
