using ProductHuntAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductHuntAPI
{
    public class BaseRepository<T> : IRepository<T> where T: IBaseEntity
    {
        private readonly IAsyncHttpClient vHttpClient;
        private readonly string vEndpoint;
        
        public BaseRepository(IAsyncHttpClient authorizedHttpClient,string endpoint)
        {
            vHttpClient = authorizedHttpClient ?? throw new ArgumentNullException(nameof(authorizedHttpClient));
            vEndpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }
        public T FindById(int id)
        {
            var uri = vHttpClient.CreateRequestUri(vEndpoint+"/"+id.ToString());
            return vHttpClient.GetAsync<IRootWithInstance<T>>(uri).Result.Instance;
        }
        public T[] Select(IQuery query)
        {

            List<T> allData = new List<T>();
            switch (query.SelectType)
            {
                case SelectionType.Top:
                    {
                        allData.AddRange(ExecuteQuery(query.ToHttpQuery()));
                        break;
                    };
                case SelectionType.All:
                    {
                        //Fetch first round
                        var httpQueryString = query.ToHttpQuery();
                        var queryResult = ExecuteQuery(httpQueryString, 0);
                        allData.AddRange(queryResult);
                        int lastId;

                        //Now fetch all others
                        while (queryResult.Length == vHttpClient.ResultsPerPage)
                        {
                            lastId = queryResult.Select(x => x.Id).Max();
                            queryResult = ExecuteQuery(httpQueryString, lastId);
                            allData.AddRange(queryResult);
                        }
                        break;
                    };
                case SelectionType.Count:
                    {
                        if ((query.Count == null) || (query.Count==0))
                            throw new ArgumentNullException(nameof(query.Count));
                        //Fetch first round
                        var httpQueryString = query.ToHttpQuery();
                        var queryResult = ExecuteQuery(httpQueryString, 0);
                        allData.AddRange(queryResult);
                        int lastId;

                        //Now fetch all others
                        while (allData.Count <query.Count)
                        {
                            lastId = queryResult.Select(x => x.Id).Max();
                            queryResult = ExecuteQuery(httpQueryString, lastId);
                            allData.AddRange(queryResult);
                        }
                        break;
                    }; 
                    default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(query.SelectType));
                    };
            };
            return allData.ToArray();
        }
        private T[] ExecuteQuery(string query,int? lastId=null)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            if (lastId != null)
                query = query + "&newer=" + lastId;
            var uri = vHttpClient.CreateRequestUri(vEndpoint,query);
            return vHttpClient.GetAsync<IRootWithInstances<T>>(uri).Result.Instances;
        }
    }
}
