using Altamira.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altamira.Bussiness.Mapper
{
    public class AutoMapperInit : Profile
    {
        public AutoMapperInit()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<Address, Address>();
            CreateMap<Company, Company>();
            CreateMap<Geo, Geo>();
        }
    }
}
