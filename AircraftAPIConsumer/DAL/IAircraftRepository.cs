using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AircraftAPIConsumer.Models;
using AircraftAPIConsumer.DAL;


namespace AircraftAPIConsumer.DAL
{
    public interface IAircraftRepository
    {
        IEnumerable<Aircraft> GetAll();
        Aircraft Get(int id);
        void Add(Aircraft ac);
        void Delete(int id);
        void Change(Aircraft ac);
    }
}
