using AutoMapper;
using DR.Escolaridade.Application.ViewModels;
using DR.Escolaridade.Domain.Models;

namespace DR.Escolaridade.Application.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
        }
    }
}