﻿using System;
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

        public AttractionService() { }
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
                ZooId = e.ZooId,
                Animals = e.Animals,
                Experiences = e.Experiences,
                HasAquaticExhibit = e.HasAquaticExhibit,
                HasGarden = e.HasGarden,
                SeasonalAttractions = e.SeasonalAttractions
            }
            ).ToList();
            return attractionList;
        }
       

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
        public AttractionDetail GetAttractionById(int id)
        {
            var entity = _context.Attractions.Find(id);
            if (entity == null)
                return null;
            var detail = new AttractionDetail
            {
                AttId = entity.AttId,
                Animals = entity.Animals,
                Experiences = entity.Experiences,
                HasAquaticExhibit = entity.HasAquaticExhibit,
                HasGarden = entity.HasGarden,
                SeasonalAttractions = entity.SeasonalAttractions,
                ZooId = entity.ZooId,
            };
            return detail;
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

