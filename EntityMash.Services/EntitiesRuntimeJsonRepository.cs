using EntityMash.Models;
using EntityMash.Models.Import;
using EntityMash.Services.Interop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EntityMash.Services
{
    /// <summary>
    /// This class represent a runtime entities repository.
    /// Implementation of <see cref="IEntitiesRepository"/>
    /// </summary>
    public class EntitiesRuntimeJsonRepository : IEntitiesRepository
    {
        /// <summary>
        /// The runtime list of entities
        /// </summary>
        private IList<Entity> entities_ = null;

        public EntitiesRuntimeJsonRepository(string jsonPath)
        {
            entities_ = new List<Entity>();
            InitAsync(jsonPath).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Implementation of <see cref="IEntitiesRepository.Entities"/>
        /// </summary>
        public IEnumerable<Entity> Entities { get => entities_; }

        /// <summary>
        /// Implementation of <see cref="IEntitiesRepository.Update(Entity)"/>
        /// </summary>
        public void Update(Entity entity)
        {
            if (entities_.SingleOrDefault(c => c.Identifier == entity.Identifier) != null)
            {
                var index = entities_.IndexOf(entity);
                entities_[index] = entity;
            }
        }

        /// <summary>
        /// This private method retrieve all entities in order to initialize 
        /// the runtime repository representing by <see cref="entities_"/>
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        private async Task InitAsync(string jsonPath)
        {
            using (var fileStream = File.OpenRead(jsonPath))
            using (var streamReader = new StreamReader(fileStream))
            {
                var content = await streamReader.ReadToEndAsync();
                var entitiesImport = JsonConvert.DeserializeObject<EntitiesImport>(content);

                foreach (var import in entitiesImport.Images)
                {
                    entities_.Add(new Entity(import.Id)
                    {
                        ImageUrl = new Uri(import.Url),
                        Votes = 0
                    });
                }
            }
        }
    }
}
