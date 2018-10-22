using AutoMapper;
using GraphQLAPI.Library.Dal.Models;
using GraphQLAPI.Library.Lib.Request;
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
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => 0));

            CreateMap<AuthorUpdateRequest, Author>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => 0));

            CreateMap<BookCreateRequest, Book>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => 0));

            CreateMap<BookUpdateRequest, Book>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => 0));
        }
    }
}
