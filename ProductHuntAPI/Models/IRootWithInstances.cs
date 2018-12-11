using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI.Models
{
    public interface IRootWithInstances<T>
    {
        T[] Instances { get; set; }
    }
}
