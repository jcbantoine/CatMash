using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace EntityMash.Services.Tests
{
    [TestClass]
    public class EntitiesRuntimeJsonRepositoryTests
    {
        [TestMethod]
        public void EntitiesRuntimeJsonRepository_Entities()
        {
            //init

            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data/cats.json");

            //system-under-test

            var entitiesRepository = new EntitiesRuntimeJsonRepository(jsonPath);

            //assert
            Assert.AreEqual(100, entitiesRepository.Entities.Count());
            Assert.AreEqual("MTgwODA3MA", entitiesRepository.Entities.First().Identifier);
            Assert.AreEqual(new Uri("http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg"), entitiesRepository.Entities.First().ImageUrl);
            Assert.AreEqual(0, entitiesRepository.Entities.First().Votes);
        }

        [TestMethod]
        public void EntitiesRuntimeJsonRepository_Update()
        {
            //init

            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data/cats.json");
            var newUri = new Uri("http://mynewimage.png");
            var newVotes = 3;

            //system-under-test

            var entitiesRepository = new EntitiesRuntimeJsonRepository(jsonPath);
            var entityToUpdate = entitiesRepository.Entities.First();
            entityToUpdate.ImageUrl = newUri;
            entityToUpdate.Votes = newVotes;

            //assert
            Assert.AreEqual(100, entitiesRepository.Entities.Count());
            Assert.AreNotEqual(new Uri("http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg"), entitiesRepository.Entities.First().ImageUrl);
            Assert.AreNotEqual(0, entitiesRepository.Entities.First().Votes);
            Assert.AreEqual("MTgwODA3MA", entitiesRepository.Entities.First().Identifier);
            Assert.AreEqual(newUri, entitiesRepository.Entities.First().ImageUrl);
            Assert.AreEqual(newVotes, entitiesRepository.Entities.First().Votes);
        }
    }
}
