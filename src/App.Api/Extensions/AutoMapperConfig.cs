using App.Api.ViewModels;
using App.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace App.Api.Extensions
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            // TODO Fazer um Assembly que faz isso automaticamente pelo base ou interface
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Documento, DocumentoViewModel>().ReverseMap();
            CreateMap<DocumentoBaixa, DocumentoBaixaViewModel>().ReverseMap();
        }
    }
}