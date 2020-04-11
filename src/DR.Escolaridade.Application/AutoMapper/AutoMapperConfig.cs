using AutoMapper;
using DR.Escolaridade.Application.ViewModels;
using DR.Escolaridade.Domain.Models;

namespace DR.Escolaridade.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomainToViewModel>();
                i.AddProfile<ViewModelToDomain>();
            });
        }
    }
}
