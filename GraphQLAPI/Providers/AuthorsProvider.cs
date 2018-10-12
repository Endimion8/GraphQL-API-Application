using AutoMapper;
using GraphQLAPI.Library.Lib;
using GraphQLAPI.Library.Lib.Response;
using GraphQLAPI.Providers.Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.Providers
{
    public class AuthorsProvider: IAuthorsProvider
    {
        private readonly IMapper _mapper;
        private readonly ILibraryService _libraryService;

        AuthorsProvider(ILibraryService libraryService, IMapper mapper)
        {
            _mapper = mapper;
            _libraryService = libraryService;
        }
        public async Task<IEnumerable<Library.Models.Response.AuthorResponse>> GetAuthorsAsync()
        {
            var authors = await _libraryService.GetAuthorsAsync();
            return _mapper.Map<IReadOnlyList<Library.Models.Response.AuthorResponse>>(authors);

        }

        public async Task<Library.Models.Response.AuthorResponse> GetAuthorByIdAsync(int authorId)
        {
            var author = await _libraryService.GetAuthorByIdAsync(authorId);
            return _mapper.Map<Library.Models.Response.AuthorResponse>(author);
        }

        public async Task<Library.Models.Response.AuthorResponse> CreateAuthorAsync(Library.Models.Response.AuthorResponse author)
        {
            var addedAuthor = await _libraryService.CreateAuthorAsync(_mapper.Map<GraphQLAPI.Library.Lib.Response.AuthorResponse>(author));
            return _mapper.Map<Library.Models.Response.AuthorResponse>(addedAuthor);
        }

        public AuthorResponse UpdateAuthor(int id, Library.Models.Response.AuthorResponse author)
        {
            author.AuthorId = id;
            var updatedAuthor = _libraryService.UpdateAuthor(_mapper.Map<GraphQLAPI.Library.Lib.Response.AuthorResponse>(author));
            return _mapper.Map<Library.Models.Response.AuthorResponse>(updatedAuthor);
        }

        public async Task<Library.Models.Response.AuthorResponse> DeleteAuthorAsync(int authorId)
        {
            var deletedAuthor = await _libraryService.DeleteAuthorAsync(authorId);
            return _mapper.Map<Library.Models.Response.AuthorResponse>(deletedAuthor);

        }

        public async Task<Library.Models.Response.AuthorResponse> DeleteAuthorByNameAsync(string authorName)
        {
            var deletedAuthor = await _libraryService.DeleteAuthorByNameAsync(authorName);
            return _mapper.Map<Library.Models.Response.AuthorResponse>(deletedAuthor);
        }
    }
}
