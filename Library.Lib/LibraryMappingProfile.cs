using AutoMapper;
using GraphQLAPI.Library.Dal.Models;
using GraphQLAPI.Library.Lib.Request;
using Library.Dal.Models;
using Library.Lib.Request;
using Library.Lib.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Lib
{
    class LibraryMappingProfile: Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<AuthorCreateRequest, Author>()
                .ForMember(dest => dest.AuthorId, opt => opt.Ignore());

            CreateMap<AuthorUpdateRequest, Author>()
                .ForMember(dest => dest.AuthorId, opt => opt.Ignore());

            CreateMap<BookCreateRequest, Book>()
                .ForMember(dest => dest.BookId, opt => opt.Ignore());

            CreateMap<BookUpdateRequest, Book>()
                .ForMember(dest => dest.BookId, opt => opt.Ignore());

            CreateMap<AuthorBook, AuthorBookResponse>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorAuthorId))
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookBookId))
                .ForSourceMember(src => src.Author, opt => opt.Ignore())
                .ForSourceMember(src => src.Book, opt => opt.Ignore());

            CreateMap<AuthorBookCreateRequest, AuthorBook>()
                .ForMember(dest => dest.AuthorAuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.BookBookId, opt => opt.MapFrom(src => src.BookId))
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Book, opt => opt.Ignore());
        }
    }
}
