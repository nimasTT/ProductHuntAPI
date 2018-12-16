using System;

namespace ProductHuntAPI
{
   public interface IRepository<T> where T: IBaseEntity
    {
        T FindById(int id);
        T[] Select(IQuery query);
    }
}
