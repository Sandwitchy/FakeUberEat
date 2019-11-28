using System;
using System.Collections.Generic;
using FakeUberEat.Models;

namespace FakeUberEat.Repository
{
    public interface IRepository{
        List<Object> All();
        Object getById(int id);
        void Save(Object ObjectToSave);
    }
}