using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI
{
    public interface IConnectionManager
    {
        string Token { get; }
        void Connect();
    }
}
