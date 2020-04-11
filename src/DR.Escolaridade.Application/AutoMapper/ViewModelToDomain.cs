using AutoMapper;
using DR.Escolaridade.Application.ViewModels;
using DR.Escolaridade.Domain.Models;

namespace DR.Escolaridade.Application.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}