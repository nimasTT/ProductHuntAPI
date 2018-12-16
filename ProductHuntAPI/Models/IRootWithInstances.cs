using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI.Models
{
    internal interface IRootWithInstances<T>
    {
        T[] Instances { get; set; }
    }
}
