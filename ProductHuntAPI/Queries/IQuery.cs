using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI
{
    public interface IQuery
    {
        SelectionType SelectType { get; set; }
        int? Count { get; set; }
        Order? ResultOrder { get; set; }
        SortBy? Sort { get; set; }
        string ToHttpQuery();
    }

    public enum SelectionType
    {
        All=0,  //Select all data
        Count=1,//Select specified number of data from begining of time 
        Top =2  //Select maximun number of newest data
    }
    public enum Order
    {
        Ascending=0,
        Descending=1
    }
    public enum SortBy
    {
        Id=0,
        CreatedAt=1,
        UpdatedAt=2
    }
}
