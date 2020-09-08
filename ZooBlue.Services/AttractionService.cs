using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBlue.Data;
using ZooBlue.Models;
using ZooBlue.Models.AttractionModels;

namespace ZooBlue.Services
{
    public class AttractionService
    {
        private readonly int _zooId;
        public AttractionService(int zooId)
        {
            _zooId = zooId;
        }

        public IEnumerable<AttractionListItems> GetAttractions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var attQuery =
                    ctx
                    .Attractions
                    .Where(e => e.ZooId == _zooId)
                    .Select(
                    e => new AttractionListItems
                    {
                        AttId = e.AttId,
                        Animals = e.Animals,
                        Experiences = e.Experiences,
                        HasAquaticExhibit = e.HasAquaticExhibit,
                        HasGarden = e.HasGarden,
                        SeasonalAttractions = e.SeasonalAttractions
                    }) ;
                return attQuery.ToArray();
            }
        }

        public bool CreateAttraction(AttractionCreate model)
        {
            var entity =
                new Attraction
                {
                    ZooId = _zooId,
                    Animals = model.Animals,
                    Experiences = model.Experiences,
                    HasAquaticExhibit = model.HasAquaticExhibit,
                    HasGarden = model.HasGarden,
                    SeasonalAttractions = model.SeasonalAttractions
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attractions.Add(entity);
                return ctx.SaveChanges() == 0;
            }
        }

        public AttractionDetail GetAttractionByZoo(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Attractions
                    .SingleOrDefault(e => e.AttId == id && e.ZooId == _zooId);

                return
                    new AttractionDetail
                    {
                        Attid = entity.AttId,
                        Animals = entity.Animals,
                        Experiences = entity.Experiences,
                        HassAquaticExhibit = entity.HasAquaticExhibit,
                        HasGarden = entity.HasGarden,
                        SeasonalAttractions = entity.SeasonalAttractions,
                        ZooId = entity.ZooId,
                        ZooName = entity.Zoo.ZooName
                    };
            }
        }
        public bool UpdateNote(AttractionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Attractions
                        .SingleOrDefault(e => e.AttId == model.AttId && e.ZooId == _zooId);

                entity.ZooId = model.ZooId;
                entity.Animals = model.Animals;
                entity.Experiences = model.Experiences;
                entity.HasAquaticExhibit = model.HasAquaticExhibit;
                entity.HasGarden = model.HasGarden;
                entity.SeasonalAttractions = model.SeasonalAttractions;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAttraction(int AttId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Attractions
                        .SingleOrDefault(e => e.AttId == AttId && e.ZooId == _zooId);

                ctx.Attractions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
