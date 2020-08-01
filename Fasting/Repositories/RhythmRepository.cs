using Fasting.Data;
using Fasting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fasting.Repositories
{
    public class RhythmRepository : IRhythmRepository
    {
        ApplicationDbContext _db;
        public RhythmRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddRhythm(Rhythm rhythm)
        {
            _db.Rhythm.Add(rhythm);
            _db.SaveChanges();
        }

        public void Delete(Rhythm rhythm)
        {
            _db.Remove(rhythm);
            _db.SaveChanges();
        }

        public void Edit(Rhythm rhythm)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rhythm> GetAll()
        {
            return _db.Rhythm.ToList();
        }

        public Rhythm GetById(int id)
        {
            return _db.Rhythm.Single(r => r.Id == id);
        }
    }
}
