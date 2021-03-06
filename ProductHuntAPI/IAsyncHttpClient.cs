﻿using System;
using System.Threading.Tasks;

namespace ProductHuntAPI
{
    internal interface IAsyncHttpClient
    {
        bool IsAuthorized { get; }
        int ResultsPerPage { get; }
        int RequestLimit { get; }

        void AddBearerAuthorization(string token);
        Uri CreateRequestUri(string relativePath, string queryString = "");
        Task<T> GetAsync<T>(Uri requestUrl);
        Task<TR> PostAsync<T, TR>(Uri requestUrl, T content);
    }
}