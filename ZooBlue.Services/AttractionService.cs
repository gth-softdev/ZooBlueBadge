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
        //private readonly int _zooId;
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public AttractionService(Guid userId)
        {
            _userId = userId;

        }
        public List<AttractionListItems> GetAttractions()
        {

            var attractionEntities = _context.Attractions.ToList();
            var attractionList = attractionEntities.Select(e => new AttractionListItems
            {
                AttId = e.AttId,
                Animals = e.Animals,
                Experiences = e.Experiences,
                HasAquaticExhibit = e.HasAquaticExhibit,
                HasGarden = e.HasGarden,
                SeasonalAttractions = e.SeasonalAttractions
            }
            ).ToList();
            return attractionList;
        }
        //public IEnumerable<AttractionListItems> GetAttractions()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var attQuery =
        //            ctx
        //            .Attractions.ToList()
        //            .Select(
        //            e => new AttractionListItems
        //            {
        //                AttId = e.AttId,
        //                Animals = e.Animals,
        //                Experiences = e.Experiences,
        //                HasAquaticExhibit = e.HasAquaticExhibit,
        //                HasGarden = e.HasGarden,
        //                SeasonalAttractions = e.SeasonalAttractions
        //            });
        //        return attQuery.ToArray();
        //    }
        //}

        public bool CreateAttraction(AttractionCreate model)
        {
            var entity =
                new Attraction
                {
                    ZooId = model.ZooId,
                    Animals = model.Animals,
                    Experiences = model.Experiences,
                    HasAquaticExhibit = model.HasAquaticExhibit,
                    HasGarden = model.HasGarden,
                    SeasonalAttractions = model.SeasonalAttractions
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attractions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AttractionDetail> GetAttractionById(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Attractions
                    .Where(e => e.AttId == id)// Throws exception 
                    .Select(e =>

                    new AttractionDetail
                    {
                        AttId = e.AttId,
                        Animals = e.Animals,
                        Experiences = e.Experiences,
                        HasAquaticExhibit = e.HasAquaticExhibit,
                        HasGarden = e.HasGarden,
                        SeasonalAttractions = e.SeasonalAttractions,
                        ZooId = e.ZooId,
                        ZooName = e.Zoo.ZooName
                    });

                return entity.ToArray();
            }
        }
        public bool UpdateAttraction(AttractionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Attractions.ToList()
                        .SingleOrDefault(e => e.AttId == model.AttId); // Just doesn't work... Don'
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
                        .SingleOrDefault(e => e.AttId == AttId);

                ctx.Attractions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
