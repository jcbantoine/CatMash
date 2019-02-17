using EntityMash.Models;
using EntityMash.Services.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace EntityMash.Services.Tests
{

    [TestClass]
    public class EntitiesMashServiceTests
    {
        [TestMethod]
        public void EntitiesMashService_GetRanking()
        {
            //init
            var entities = new[] { new Entity("") { Votes = 2 }, new Entity("") { Votes = 0 }, new Entity("") { Votes = 5 } };

            var entitiesRepositoryMoq = new Mock<IEntitiesRepository>();
            entitiesRepositoryMoq
                .Setup(i => i.Entities)
                .Returns(entities);

            //system-under-test
            var entitiesMashService = new EntityMashService(entitiesRepositoryMoq.Object);
            var entitiesRanking = entitiesMashService.GetRanking();

            //assert
            Assert.AreEqual(5, entitiesRanking.ElementAt(0).Votes);
            Assert.AreEqual(2, entitiesRanking.ElementAt(1).Votes);
            Assert.AreEqual(0, entitiesRanking.ElementAt(2).Votes);

        }

        [TestMethod]
        public void EntitiesMashService_AddVote()
        {
            //init
            var entityToUpdate = new Entity("") { Votes = 2 };
            var entities = new[] { entityToUpdate, new Entity("") { Votes = 0 }, new Entity("") { Votes = 5 } };

            var entitiesRepositoryMoq = new Mock<IEntitiesRepository>();
            entitiesRepositoryMoq
                .Setup(i => i.Update(It.IsAny<Entity>()))
                .Callback((Entity entity) => { entities[0] = entity; });

            //system-under-test
            var entitiesMashService = new EntityMashService(entitiesRepositoryMoq.Object);
            entitiesMashService.AddVote(entityToUpdate);

            //assert
            entitiesRepositoryMoq.VerifyAll();
            Assert.AreEqual(3, entities[0].Votes);
        }

        [TestMethod]
        public void EntitiesMashService_GetVersus()
        {
            //init
            var entity1 = new Entity("1") { Votes = 2 };
            var entity2 = new Entity("2") { Votes = 2 };
            var entity3 = new Entity("3") { Votes = 2 };
            var entities = new[] { entity1, entity2, entity3 };

            var entitiesRepositoryMoq = new Mock<IEntitiesRepository>();
            entitiesRepositoryMoq
                .Setup(i => i.Entities)
                .Returns(entities);

            //system-under-test
            var entitiesMashService = new EntityMashService(entitiesRepositoryMoq.Object);
            var versusTuple = entitiesMashService.GetVersus();

            //assert
            entitiesRepositoryMoq.VerifyAll();
            Assert.AreNotEqual(versusTuple.Item1.Identifier, versusTuple.Item2.Identifier);
        }

        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void EntitiesMashService_GetVersus_NotPossibleIfOneEntity()
        {
            //init
            var entity1 = new Entity("1") { Votes = 2 };
            var entities = new[] { entity1 };

            var entitiesRepositoryMoq = new Mock<IEntitiesRepository>();
            entitiesRepositoryMoq
                .Setup(i => i.Entities)
                .Returns(entities);

            //system-under-test
            var entitiesMashService = new EntityMashService(entitiesRepositoryMoq.Object);
            var versusTuple = entitiesMashService.GetVersus();
        }
    }
}
