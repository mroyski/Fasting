using Fasting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fasting.Repositories
{
    public interface IRhythmRepository
    {
        IEnumerable<Rhythm> GetAll();
        Rhythm GetById(int id);
        void Delete(Rhythm rhythm);
        void AddRhythm(Rhythm rhythm);
        void Edit(Rhythm rhythm);
    }
}
