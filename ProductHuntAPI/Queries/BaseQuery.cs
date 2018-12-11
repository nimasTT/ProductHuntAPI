using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI.Queries
{
    public class BaseQuery : IQuery
    {
        private int? vCount;
        private readonly Dictionary<Order, string> OrderValueToQuery = new Dictionary<Order, string>
        {
            { Order.Ascending,"asc"},
            {Order.Descending,"desc" }
        };
        private readonly Dictionary<SortBy, string> SortByEnumValueToQuery = new Dictionary<SortBy, string>
        {
            { SortBy.Id,"id"},
            { SortBy.CreatedAt,"created_at"},
            { SortBy.UpdatedAt,"updated_at"}
        };

        public SelectionType SelectType { get; set; }
        public int? Count { get { return vCount; } set
            {
                if (SelectType != SelectionType.Count)
                    throw new ArgumentException(nameof(Count) + $" could be set only for " + nameof(SelectType) + $" equal to 'Count'");
                if (value == 0)
                    throw new ArgumentOutOfRangeException(nameof(Count) + $"can not be zero");
                vCount = value;
            } }
        public Order? ResultOrder { get; set ; }
        public SortBy? Sort { get ; set ; }

        public BaseQuery()
        {
            SelectType = SelectionType.Top;
        }

        public string ToHttpQuery()
        {
            string httpQuery = "";
            if (ResultOrder != null)
                httpQuery += "&order=" + OrderValueToQuery[ResultOrder.Value];
            if (Sort != null)
                httpQuery += "&sort_by=" + SortByEnumValueToQuery[Sort.Value];
            return httpQuery;
        }

        protected string AddSearchPropertyToQuery(string property, string value)
        {
            return "&search[" + property + "]=" + value;
        }
    }
}
