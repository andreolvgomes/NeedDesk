using AutoMapper;
using NeedDesk.Application.ViewModels;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.CrossCutting.AutoMapper.Mapping
{
    public class ModelToViewModelMapping : Profile
    {
        public ModelToViewModelMapping()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}