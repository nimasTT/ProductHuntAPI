using System;

namespace ProductHuntAPI.Queries
{
    public class PostQuery : BaseQuery,IQuery
    {
        private int? vFeaturedYear;
        private int? vFeaturedMonth;
        private int? vFeaturedDay;

        public PostQuery()
        {
            SelectType = SelectionType.All;
        }
        
        public int? Topic { get; set; }
        public string Category { get; set; }
        public Uri Url { get; set; }
        public int? FeaturedYear { get { return vFeaturedYear; } set {
                if (value == null)
                    throw new ArgumentNullException(nameof(FeaturedYear));
                if (value < 1990)
                    throw new ArgumentOutOfRangeException(nameof(FeaturedYear));
                vFeaturedYear = value;
            } }
        public int? FeaturedMonth { get { return vFeaturedMonth; } set {
                if (value == null)
                    throw new ArgumentNullException(nameof(FeaturedMonth));
                if (!(value>=1 && value<=12))
                    throw new ArgumentOutOfRangeException(nameof(FeaturedMonth));
                vFeaturedMonth = value;
            } }
        public int? FeaturedDay
        {
            get { return vFeaturedDay; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(FeaturedDay));
                if (!(value >= 1 && value <= 31))
                    throw new ArgumentOutOfRangeException(nameof(FeaturedDay));
                vFeaturedDay = value;
            }
        }

        public new string ToHttpQuery()
        {
            var httpQuery = base.ToHttpQuery();
            if (Topic != null)
                httpQuery += AddSearchPropertyToQuery("topic", Topic.Value.ToString());
            if (FeaturedYear != null)
                httpQuery += AddSearchPropertyToQuery("featured_year", FeaturedYear.Value.ToString());
            if (FeaturedMonth != null)
                httpQuery += AddSearchPropertyToQuery("featured_month", FeaturedMonth.Value.ToString());
            if (FeaturedDay != null)
                httpQuery += AddSearchPropertyToQuery("featured_day", FeaturedDay.Value.ToString());
            if (Url != null)
                httpQuery += AddSearchPropertyToQuery("url", Url.ToString());
            if (Category != null)
                httpQuery += AddSearchPropertyToQuery("category", Category);
            return httpQuery;
        }
    }
}
