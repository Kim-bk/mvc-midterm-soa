using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Service
{
    public interface INewService
    {
        List<New> SearchNew(string searchingString);
        List<New> GetNewByType(string typeNew);
        List<New> GetNews();
        New? GetNewById(int id);

        void CreateNew(New New);

        void UpdateNew(New New);

        void DeleteNew(int id);

        List<TypeNew> GetTypeNew();
    }
}