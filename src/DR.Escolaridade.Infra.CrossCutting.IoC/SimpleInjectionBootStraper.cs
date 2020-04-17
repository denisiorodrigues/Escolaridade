using DR.Escolaridade.Application.Interfaces;
using DR.Escolaridade.Application.Services;
using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Services;
using DR.Escolaridade.Infra.Data.Repository;
using SimpleInjector;

namespace DR.Escolaridade.Infra.CrossCutting.IoC
{
    public class SimpleInjectionBootStraper
    {
        //Lifestyle.Trasient => Uma instância para cada solicitação; Se não setar vai como padrão // * Cuidado
        //Lifestyle.Singleton => Uma instância unica para a classe (para o servidor)
        //Lifestyle.Scoped => Uma instência única para o request

        public static void Register(Container container)
        {
            //Por padrão é "Transient"
            //APP
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            //DOMAIN
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            //INFRA
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
        }
    }
}