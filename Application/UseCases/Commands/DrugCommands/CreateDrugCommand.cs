using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugCommands;
/// <summary>
/// команда на создание нового обьекта сущности Drug
/// </summary>
/// <param name="Name">наименование</param>
/// <param name="Manufacturer">производитель</param>
/// <param name="CountryCodeId">код страны</param>
/// <param name="Country">страна</param>
public record CreateDrugCommand(
    string Name,
    string Manufacturer,
    string CountryCodeId,
    Country Country
) : IRequest<Drug>;