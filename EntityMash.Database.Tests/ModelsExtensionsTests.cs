using System;
using EntityMash.Database.Mapping;
using EntityMash.Database.Models;
using EntityMash.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityMash.Database.Tests
{
    [TestClass]
    public class ModelsExtensionsTests
    {
        [TestMethod]
        public void ModelsExtensions_ToDBModel()
        {
            //init

            var model = new Entity("identifier")
            {
                ImageUrl = new Uri("http://myimg.com"),
                Votes = 15
            };

            //system-under-test

            var dbModel = model.ToDBModel();

            //assert

            AssertModelEqualDBModel(model, dbModel);
        }

        [TestMethod]
        public void ModelsExtensions_ToModel()
        {
            //init

            var dbModel = new DBEntity()
            {
                Identifier = "identifier",
                ImageUrl = "http://myimg.com",
                Votes = 15
            };

            //system-under-test

            var model = dbModel.ToModel();

            //assert

            AssertModelEqualDBModel(model, dbModel);
        }

        private void AssertModelEqualDBModel(Entity model, DBEntity dbModel)
        {
            Assert.AreEqual(model.Identifier, dbModel.Identifier);
            Assert.AreEqual(model.ImageUrl, dbModel.ImageUrl);
            Assert.AreEqual(model.Votes, dbModel.Votes);
        }
    }
}
