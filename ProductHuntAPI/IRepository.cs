using System;

namespace ProductHuntAPI
{
    public interface IRepository<T>
    {
        T FindById(int id);
        T[] Select(string query);
    }
}
