using System;
using CatMash.Web.Mapping;
using CatMash.Web.Models;
using EntityMash.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatMash.Web.Tests
{
    [TestClass]
    public class MapperExtensionsTests
    {
        [TestMethod]
        public void MapperExtensions_ToModel()
        {
            //init

            var viewModel = new CatViewModel()
            {
                Identifier = "identifier",
                ImageUrl = new Uri("http://myimg.com"),
                Votes = 15
            };

            //system-under-test

            var model = viewModel.ToModel();

            //assert
            AssertModelEqualViewModel(model, viewModel);
        }

        
        [TestMethod]
        public void MapperExtensions_ToViewModel()
        {
            //init

            var model = new Entity("identifier")
            {
                ImageUrl = new Uri("http://myimg.com"),
                Votes = 15
            };

            //system-under-test

            var viewModel = model.ToViewModel();

            //assert

            AssertModelEqualViewModel(model, viewModel);
        }

        private void AssertModelEqualViewModel(Entity model, CatViewModel viewModel)
        {
            Assert.AreEqual(viewModel.Identifier, model.Identifier);
            Assert.AreEqual(viewModel.ImageUrl, model.ImageUrl);
            Assert.AreEqual(viewModel.Votes, model.Votes);
        }

    }
}
