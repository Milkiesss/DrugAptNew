using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugStoreCommands;
/// <summary>
/// команда на обмновление обьекта сущности DrugStore
/// </summary>
/// <param name="Id">идентификатор</param>
/// <param name="DrugNetWork">сеть аптек</param>
/// <param name="Number">номер аптеки</param>
/// <param name="Address">адрес аптеки</param>
/// <param name="PhoneNumber">номер телефона</param>
public record UpdateDrugStoreCommand(
    Guid Id,
    string DrugNetWork,
    int Number, 
    Address Address,
    string PhoneNumber
) : IRequest<DrugStore>;