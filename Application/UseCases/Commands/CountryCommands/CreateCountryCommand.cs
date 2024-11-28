using System.Windows.Input;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.CountryCommands;
/// <summary>
/// команда на создание нового обьекта сущности Country 
/// </summary>
/// <param name="Name">название</param>
/// <param name="Code">код страны</param>
public record CreateCountryCommand(string Name, string Code) : IRequest<Country>;
