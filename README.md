# Escolaridade
Aplicação de estudo que simula um sistema de gestão escolar
Temos a implementação em Web Api
Essa aplicação segue o roteiro do curso de C# Avaçado do Professor [Eduardo Pires](https://github.com/EduardoPires).

### Desafio:
- Adicionar segurança no projeto API/REST:
	- HTTPS
		- Setgurança de criptografia
	- IDentity
		- Utilizando o tutorial da microsoft [clique aqui](https://docs.microsoft.com/pt-br/aspnet/web-api/overview/security/individual-accounts-in-web-api)
	- CORS (Implementado no projeto)
		- Cross Origin Request -> 
		- Segindo o tutorial [clique aqui](https://docs.microsoft.com/pt-br/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api)

Site do curso: [desenvolvedor.io](https://desenvolvedor.io/)

### Frameworks
- Asp.Net MVC5
- _ORM_ EntityFramework 6
- AutoMapper [AutoMapper 8.0.0](https://automapper.org/)
    -Comando: PM> _Install-Package AutoMapper_
- Dapper [Dapper 2.0.35](https://github.com/StackExchange/Dapper)
    -Comando: PM> _Install-Package Dapper_ *(**Pega a versão mais recente**) ou no Nuget
- Bootstrap 3.4.1 [Bootstrap 3.4.1](https://getbootstrap.com/docs/3.4/)
- Simple Injector [Simpleinjector.MVC3 4.9.2](https://www.nuget.org/packages/SimpleInjector.MVC3/4.9.2)
    -Mecanismo de injeção de dependência na camada de apresentação
- Simple Injector [Simpleinjector 4.9.2](https://www.nuget.org/packages/SimpleInjector.MVC3/4.9.2)
    -Mecanismo somente de injeção de dependência, para uma camada respsável somente pra isso
- DomainValidation [DomainValidation 1.0.0](https://www.nuget.org/packages/DomainValidation/)
    -O padrão de especificação é uma ótima maneira de validar regras de negócios complexas no domínio.
    -Utiliza o padrão de Fluente Validation
    -Comando: PM> _Install-Package DomainValidation -Version 1.0.0_
- SimpleInjector Integration WebApi [SimpleInjector.Integration.WebApi.WebHost.QuickStart 4.9.2](https://www.nuget.org/packages/SimpleInjector.Integration.WebApi.WebHost.QuickStart)
	- integração do projeto de web API com a injeção de dependência
- CORS [Microsoft.AspNet.WebApi.Cors.5.2.7](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Cors)
	- Habilitar CORS

### Descrição da aplicação
- Arquitetura: DDD (Domain Driven Domain)
- OS modelos são POCO
- Code First
- Utilizando o padrão FLUENT API
