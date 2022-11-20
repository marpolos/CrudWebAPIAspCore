# CrudWebAPIAPIAspCore

Tutorial Macoratti.net

Parte 1: https://www.macoratti.net/17/12/aspcore_crudapi1.htm
Parte 2: https://www.macoratti.net/17/12/aspcore_crudapi2.htm
Projeto está com um problema: 

An unhandled exception occurred while processing the request.

InvalidOperationException: Unable to resolve service for type 'CrudWebAPIAspCore.Service.IFilmeService' while attempting to activate 'CrudWebAPIAspCore.Controllers.FilmesController'.

Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, bool isDefaultParameterRequired)

Injection: https://pt.stackoverflow.com/questions/334870/inje%C3%A7%C3%A3o-de-depend%C3%AAncia-error-invalidoperationexception-unable-to-resolve-ser

Os serviços ASP.NET podem ser configurados com as seguintes vidas úteis:

Transient

Objetos Transient são sempre diferentes; uma nova instância é fornecida para todos os controladores e todos os serviços.

Scoped

Objetos com Scoped são os mesmos em uma solicitação, mas diferentes entre solicitações diferentes

Singleton

Objetos singleton são os mesmos para cada objeto e cada solicitação (independentemente de uma instância ser fornecida ConfigureServices)

Configure service: https://hassantariqblog.wordpress.com/2017/02/20/asp-net-core-error-invalidoperationexception-unable-to-resolve-service-for-type-foo-while-attempting-to-activate-bar/

-> O problema foi resolvido com injeção de dependência e escolhi singleton porque quero que todos os retornos sejam iguais para todas as chamadas, já que aqui os valores são fixos.