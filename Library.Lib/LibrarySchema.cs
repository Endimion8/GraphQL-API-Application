using System;
using GraphQL;
using GraphQL.Types;

namespace GraphQLAPI.Library.Lib
{
    public class LibrarySchema : Schema
    {
		public LibrarySchema(IDependencyResolver resolver) : base(resolver)
        {
			Query = resolver.Resolve<LibraryQuery>();
			Mutation = resolver.Resolve<LibraryMutation>();
        }
    }
}
