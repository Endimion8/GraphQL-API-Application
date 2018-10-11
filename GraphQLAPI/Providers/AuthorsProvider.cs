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
        public async Task<IEnumerable<AuthorResponse>> GetAuthorsAsync()
        {
            var authors = await _libraryService.GetAuthorsAsync();
            return _mapper.Map<IReadOnlyList<AuthorResponse>>(authors);

        }

        public async Task<AuthorResponse> GetAuthorByIdAsync(int authorId)
        {
            var author = await _libraryService.GetAuthorByIdAsync(authorId);
            return _mapper.Map<AuthorResponse>(author);
        }

        public async Task<AuthorResponse> CreateAuthorAsync(AuthorResponse author)
        {
            var addedAuthor = await _libraryService.CreateAuthorAsync(_mapper.Map<AuthorResponseLib>(author));
            return _mapper.Map<AuthorResponse>(addedAuthor);
        }

        public AuthorResponse UpdateAuthor(int id, AuthorResponse author)
        {
            author.AuthorId = id;
            var updatedAuthor = _libraryService.UpdateAuthor(_mapper.Map<AuthorResponseLib>(author));
            return _mapper.Map<AuthorResponse>(updatedAuthor);
        }

        public async Task<AuthorResponse> DeleteAuthorAsync(int authorId)
        {
            var deletedAuthor = await _libraryService.DeleteAuthorAsync(authorId);
            return _mapper.Map<AuthorResponse>(deletedAuthor);

        }

        public async Task<AuthorResponse> DeleteAuthorByNameAsync(string authorName)
        {
            var deletedAuthor = await _libraryService.DeleteAuthorByNameAsync(authorName);
            return _mapper.Map<AuthorResponse>(deletedAuthor);
        }
    }
}
