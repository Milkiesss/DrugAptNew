using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.CountryCommands;
/// <summary>
/// команда на обнолвние обьекта сущности Country 
/// </summary>
/// <param name="id">идентификатор</param>
/// <param name="Name">название</param>
/// <param name="Code">код страны</param>
public record UpdateCountryCommand(Guid id,string Name, string Code) : IRequest<Country>;