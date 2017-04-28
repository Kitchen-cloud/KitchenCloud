using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenCloudEntitiesHandler.Common
{
    interface IFunctionsHandler<T>
    {
        void Add(T t);
        List<T> GetAll();

        T GetById(int id);
        void DeleteById(int id);
        void DeleteAll();

        void Update(T t);

    }
}
