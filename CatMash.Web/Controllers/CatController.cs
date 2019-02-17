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
            var catViewModel = new CatViewModel() { Identifier = identifier };
            var entity = Mapper.ToModel(catViewModel);
            entityMashService_.AddVote(entity);
            return View("Vote");
        }

        public IActionResult Vote()
        {
            var models = entityMashService_.GetVersus();
            var catViewModels = new Tuple<CatViewModel, CatViewModel>(Mapper.ToViewModel(models.Item1), Mapper.ToViewModel(models.Item2));
            return View(catViewModels);
        }

        public IActionResult Ranking()
        {

            return View(entityMashService_.GetRanking().Select(i => Mapper.ToViewModel(i)));
        }

    }
}
