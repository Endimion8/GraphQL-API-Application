using GraphQLAPI.Providers.Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLAPI.Providers
{
    public interface IAuthorsProvider
    {
        Task<IEnumerable<AuthorResponse>> GetAuthorsAsync();
        Task<AuthorResponse> GetAuthorByIdAsync(int autorId);
        Task<AuthorResponse> CreateAuthorAsync(AuthorResponse author);
        AuthorResponse UpdateAuthor(int id, AuthorResponse author);
        Task<AuthorResponse> DeleteAuthorAsync(int autorId);
        Task<AuthorResponse> DeleteAuthorByNameAsync(string authorName);
    }
}
