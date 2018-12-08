using System;

namespace ProductHuntAPI
{
    public interface IRepository<T>
    {
        T FindById(string id);
    }
}
