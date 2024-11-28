using MediatR;

namespace DrugsApt.Application.UseCases.Commands.CountryCommands;
/// <summary>
/// команда на удаление сущности Country 
/// </summary>
/// <param name="id">идентификатор</param>
public record DeleteCountryCommand(Guid Id) : IRequest<bool>;