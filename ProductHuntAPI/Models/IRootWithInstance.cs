using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI.Models
{
    internal interface IRootWithInstance<T>
    {
        T Instance { get; set; }
    }
}
