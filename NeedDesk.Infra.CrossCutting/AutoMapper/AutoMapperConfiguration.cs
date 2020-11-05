using AutoMapper;
using NeedDesk.Infra.CrossCutting.AutoMapper.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.CrossCutting.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToViewModelMapping());
                cfg.AddProfile(new ModelToDtoMapping());
            });
        }
    }
}