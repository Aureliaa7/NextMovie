﻿using System.Reflection;

namespace NextMovie.Application.Helpers
{
    static class QueryParamsHelper
    {
        public static IDictionary<string, string> GetQueryParams<T>(T queryParamsModel)
        {
            var queryParams = new Dictionary<string, string>();

            foreach (PropertyInfo prop in queryParamsModel.GetType().GetProperties())
            {
                if (prop.GetValue(queryParamsModel) != null)
                {
                    queryParams.Add(prop.Name, prop.GetValue(queryParamsModel).ToString());
                }
            }

            return queryParams;
        }
    }
}
