using Microsoft.AspNetCore.Mvc;
using ProjectFinance.Web.Models.DTO;

namespace ProjectFinance.Web.Controllers
{
    public class PeopleController : Controller
    {
        #region Props

        private static List<DtoPeople> _people;

        #endregion

        #region Constructor

        public PeopleController()
        {
            if (_people == null)
            {
                SeedingPeople();
            }
        }

        #endregion

        #region HELPERS/POPULATION
        private void SeedingPeople()
        {
            _people = new List<DtoPeople>
            {
                    new DtoPeople
                    {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lucas Ribeirao Preto",
                    Email = "lucas@gmail.com"
                },
                new DtoPeople
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Grindwald Harry Potter",
                    Email = "hp@hotmail.com"
                },
                new DtoPeople
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Woldemort Harry Potter",
                    Email = "whp@outlook.com"
                }
            };
        }
        #endregion

        #region INDEX
        public IActionResult Index()
        {
            return View(_people);
        }

        #endregion

        #region CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, Email")] DtoPeople person)
        {
            try
            {
                person.Id = Guid.NewGuid().ToString();
                _people.Add(person);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region DELETE

        [HttpGet]
        public IActionResult DeletePage(string id)
        {
            DtoPeople people = _people.FirstOrDefault(p => p.Id.Equals(id));

            return View(people);
        }

        [HttpPost]
        public IActionResult DeleteReal(string Id)
        {
            DtoPeople people = _people.FirstOrDefault(p => p.Id.Equals(Id));

            if (people != null) _people.Remove(people);

            return RedirectToAction("Index");
        }

        #endregion

        #region EDIT

        [HttpGet]
        public IActionResult Edit(string id)
        {
            DtoPeople pessoa = _people.FirstOrDefault(p => p.Id.Equals(id));
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Name, Email")] DtoPeople person)
        {
            DtoPeople pessoaPesquisa = _people.FirstOrDefault(p => p.Id.Equals(person.Id));
            if (pessoaPesquisa != null)
            {
                _people.Remove(pessoaPesquisa);
                _people.Add(person);
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region DETAILS

        [HttpGet]
        public IActionResult Details(string id)
        {
            DtoPeople person = _people.FirstOrDefault(p => p.Id.Equals(id));
            return View(person);
        }

        #endregion
    }
}
