using System;
using GraphQL;
using GraphQL.Types;

namespace GraphQLAPI
{
    public class LibrarySchema : Schema
    {
        public LibrarySchema(IDependencyResolver resolver, ILibraryQuery query, ILibraryMutation mutation) : base(resolver)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
