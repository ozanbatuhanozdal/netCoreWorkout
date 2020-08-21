using System;
using GraphQL.Types;

namespace netcoregraphql.Data.Types
{
    public class EasyStoreSchema : Schema
    {
      public EasyStoreSchema(Func<Type, GraphType> resolveType)
            :base(resolveType)
        {
            Query = (EasyStoreQuery)resolveType(typeof(EasyStoreQuery));
        }
    }
}