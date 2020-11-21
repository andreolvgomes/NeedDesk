using AutoMapper;
using NeedDesk.Application.DTO.Categoria;
using NeedDesk.Application.DTO.Classificacao;
using NeedDesk.Application.DTO.Cliente;
using NeedDesk.Application.DTO.Colaborador;
using NeedDesk.Application.DTO.Departamento;
using NeedDesk.Application.DTO.Prioridade;
using NeedDesk.Application.DTO.Status;
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
            CreateMap<User, LogIn>().ReverseMap();
            CreateMap<User, UserResult>().ReverseMap();
            CreateMap<User, UserCreate>().ReverseMap();
            CreateMap<User, UserUpdate>().ReverseMap();

            CreateMap<Categoria, CategoriaCreate>().ReverseMap();
            CreateMap<Categoria, CategoriaResult>().ReverseMap();
            CreateMap<Categoria, CategoriaUpdate>().ReverseMap();
            CreateMap<Categoria, CategoriaStatus>().ReverseMap();

            CreateMap<Classificacao, ClassificacaoCreate>().ReverseMap();
            CreateMap<Classificacao, ClassificacaoResult>().ReverseMap();
            CreateMap<Classificacao, ClassificacaoUpdate>().ReverseMap();
            CreateMap<Classificacao, ClassificacaoStatus>().ReverseMap();

            CreateMap<Prioridade, PrioridadeCreate>().ReverseMap();
            CreateMap<Prioridade, PrioridadeResult>().ReverseMap();
            CreateMap<Prioridade, PrioridadeUpdate>().ReverseMap();
            CreateMap<Prioridade, PrioridadeStatus>().ReverseMap();

            CreateMap<Status, StatusCreate>().ReverseMap();
            CreateMap<Status, StatusResult>().ReverseMap();
            CreateMap<Status, StatusUpdate>().ReverseMap();
            CreateMap<Status, StatusStatus>().ReverseMap();

            CreateMap<Departamento, DepartamentoCreate>().ReverseMap();
            CreateMap<Departamento, DepartamentoResult>().ReverseMap();
            CreateMap<Departamento, DepartamentoUpdate>().ReverseMap();
            CreateMap<Departamento, DepartamentoStatus>().ReverseMap();

            CreateMap<Colaborador, ColaboradorCreate>().ReverseMap();
            CreateMap<Colaborador, ColaboradorResult>().ReverseMap();
            CreateMap<Colaborador, ColaboradorUpdate>().ReverseMap();
            CreateMap<Colaborador, ColaboradorStatus>().ReverseMap();

            CreateMap<Cliente, ClienteCreate>().ReverseMap();
            CreateMap<Cliente, ClienteResult>().ReverseMap();
            CreateMap<Cliente, ClienteUpdate>().ReverseMap();
            CreateMap<Cliente, ClienteStatus>().ReverseMap();
        }
    }
}