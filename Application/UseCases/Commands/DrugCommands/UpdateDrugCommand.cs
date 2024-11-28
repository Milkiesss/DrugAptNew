using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugCommands;
/// <summary>
/// команда на обновление обьекта сущности Drug
/// </summary>
/// <param name="Id">идентификатор</param>
/// <param name="Name">наименование</param>
/// <param name="Manufacturer">производитель</param>
/// <param name="CountryCodeId">код страны</param>
/// <param name="Country">страна</param>
public record UpdateDrugCommand(
    Guid Id,
    string Name,
    string Manufacturer,
    string CountryCodeId,
    Country Country
) : IRequest<Drug>;
