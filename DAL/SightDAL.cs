using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SightDAL
    {
        public List<Sight> GetAllSights()
        {
            var db = new SightseeingdbContext();
            return db.Sights.ToList();
        }

        public Sight GetSightById(int id)
        {
            var db = new SightseeingdbContext();
            Sight p = new Sight();

            p = db.Sights.FirstOrDefault(x => x.SightId == id);

            return p;
        }


        public void postSight(Sight person)
        {
            var db = new SightseeingdbContext();
            db.Add(person);
            db.SaveChanges();
        }
    }
}
