using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBlue.Data;
using ZooBlue.Models.ZooModels;

namespace ZooBlue.Services
{
    public class ZooServices
    {
        private readonly Guid _userId;

        public ZooServices(Guid userId)
        {
            _userId = userId;
        }

        // POST - CREATE
        public bool CreateZoo(ZooCreate model)
        {
            var entity =
                new Zoo
                {
                    ZooName = model.ZooName,
                    Location = model.Location,
                    ZooSize = model.ZooSize,
                    AZAAccredited = model.AZAAccredited,
                    Admission = model.Admission
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Zoos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET ALL - READ 
        public IEnumerable<ZooListItems> GetZoos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var zooQuery =
                    ctx
                        .Zoos.ToList()
                        .Select(
                        e => new ZooListItems
                        {
                            ZooId = e.ZooId,
                            ZooName = e.ZooName,
                            ZooSize = e.ZooSize,
                            Location = e.Location,
                            AZAAccredited = e.AZAAccredited,
                            Admission = e.Admission,
                            AverageRating = e.AverageRating,
                            Attractions = e.Attractions.ToList(),
                            AllZooReviews = e.AllZooReviews.ToList()
                        });
                return zooQuery.ToArray();
            }
        } 

        // GET BY ID - READ
        public ZooListItems GetZooById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Zoos
                        .SingleOrDefault(e => e.ZooId == id);

                return
                    new ZooListItems
                    {
                        ZooName = entity.ZooName,
                        Location = entity.Location,
                        ZooSize = entity.ZooSize,
                        AZAAccredited = entity.AZAAccredited,
                        Admission = entity.Admission,
                        AverageRating = entity.AverageRating,
                        Attractions = entity.Attractions.ToList(),
                        AllZooReviews = entity.AllZooReviews.ToList()
                    };
            }
        }

        // UPDATE - PUT
        public bool UpdateZoo(ZooEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Zoos
                        .SingleOrDefault(e => e.ZooId == model.ZooId);

                entity.ZooName = model.ZooName;
                entity.Location = model.Location;
                entity.ZooSize = model.ZooSize;
                entity.AZAAccredited = model.AZAAccredited;
                entity.Admission = model.Admission;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteZoo(int zooId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Zoos
                        .SingleOrDefault(e => e.ZooId == zooId);

                ctx.Zoos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
