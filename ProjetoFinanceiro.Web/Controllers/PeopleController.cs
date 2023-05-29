using Microsoft.AspNetCore.Mvc;
using ProjectFinance.Web.Models.DTO;

namespace ProjectFinance.Web.Controllers
{
    public class PeopleController : Controller
    {
        #region Props

        private static List<DtoPeople> _people = null;

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
            _people = new List<DtoPeople>();

            DtoPeople pessoa1 = new DtoPeople
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Lucas Ribeirao Preto",
                Email = "lucas@gmail.com"
            };
            _people.Add(pessoa1);

            DtoPeople pessoa2 = new DtoPeople
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Grindwald Harry Potter",
                Email = "hp@hotmail.com"
            };
            _people.Add(pessoa2);

            DtoPeople pessoa3 = new DtoPeople
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Woldemort Harry Potter",
                Email = "whp@outlook.com"
            };
            _people.Add(pessoa3);
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
        public IActionResult Create([Bind("Name, Email")] DtoPeople people)
        {
            try
            {
                people.Id = Guid.NewGuid().ToString();
                _people.Add(people);

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
        public IActionResult Edit([Bind("Id, Name, Email")] DtoPeople pessoa)
        {
            DtoPeople pessoaPesquisa = _people.FirstOrDefault(p => p.Id.Equals(pessoa.Id));
            if (pessoaPesquisa != null)
            {
                _people.Remove(pessoaPesquisa);
                _people.Add(pessoa);
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region DETAILS

        [HttpGet]
        public IActionResult Details(string id)
        {
            DtoPeople people = _people.FirstOrDefault(p => p.Id.Equals(id));
            return View(people);
        }

        #endregion
    }
}
