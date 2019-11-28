using System.Collections.Generic;
using FakeUberEat.Models;

namespace FakeUberEat.Repository
{
    public interface IPlatRepository{
        List<Plat> All();
        Plat getById(int id);
        void Save(Plat plat);
    }
}