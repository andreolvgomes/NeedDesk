using AutoMapper;
using NeedDesk.Application.Dtos.Users;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Mapping
{
    public class ModelToDtoMapping : Profile
    {
        public ModelToDtoMapping()
        {
            CreateMap<User, LoginDto>().ReverseMap();
        }
    }
}
