﻿using AutoMapper;
using Mongo.Database.Models;
using Mongo.DTOs;

namespace Mongo.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookCreateDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();
            CreateMap<PublisherDTO, Publisher>();
        }
    }
}
