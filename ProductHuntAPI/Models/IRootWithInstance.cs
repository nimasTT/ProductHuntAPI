using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI.Models
{
    public interface IRootWithInstance<T>
    {
        T Instance { get; set; }
    }
}
