using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidbit.Dtos;
using Vidbit.Models;

namespace Vidbit.App_Start
{
    public class MappingProfile : Profile
    {
        // maping profile will have our wanted maps for automapper
        // for it to work wen need to initialize those maps in global.asax.cs by adding them to Mapper profiles
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}