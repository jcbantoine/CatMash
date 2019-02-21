using CatMash.Web.Mapping;
using CatMash.Web.Models;
using EntityMash.Services.Interop;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CatMash.Web.Controllers
{
    public class CatController : Controller
    {
        private readonly IEntityMashService entityMashService_;

        public CatController(IEntityMashService entityMashService)
        {
            entityMashService_ = entityMashService;
        }

        public IActionResult AddVote(string identifier)
        {
            entityMashService_.AddVote(identifier);
            return View("Vote", GetVersus());
        }

        public IActionResult Vote()
        {
            var catViewModels = GetVersus();
            return View(catViewModels);
        }

        public IActionResult Ranking()
        {

            return View(entityMashService_.GetRanking().Select(i => i.ToViewModel()));
        }

        private Tuple<CatViewModel, CatViewModel> GetVersus()
        {
            var models = entityMashService_.GetVersus();
            var catViewModels =
                new Tuple<CatViewModel, CatViewModel>(models.Item1.ToViewModel(), models.Item2.ToViewModel());
            return catViewModels;
        }
    }
}
