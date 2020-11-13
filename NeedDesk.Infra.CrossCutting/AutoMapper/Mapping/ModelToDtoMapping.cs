using AutoMapper;
using NeedDesk.Application.DTO.Categoria;
using NeedDesk.Application.DTO.Classificacao;
using NeedDesk.Application.DTO.User;
using NeedDesk.Application.DTO.Users;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.CrossCutting.AutoMapper.Mapping
{
    public class ModelToDtoMapping : Profile
    {
        public ModelToDtoMapping()
        {
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();

            CreateMap<Categoria, CategoriaCreate>().ReverseMap();
            CreateMap<Categoria, CategoriaResult>().ReverseMap();
            CreateMap<Categoria, CategoriaUpdate>().ReverseMap();
            CreateMap<Categoria, CategoriaStatus>().ReverseMap();

            CreateMap<Classificacao, ClassificacaoCreate>().ReverseMap();
            CreateMap<Classificacao, ClassificacaoResult>().ReverseMap();
            CreateMap<Classificacao, ClassificacaoUpdate>().ReverseMap();
            CreateMap<Classificacao, ClassificacaoStatus>().ReverseMap();
        }
    }
}