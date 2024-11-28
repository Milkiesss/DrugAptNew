using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugStoreCommands;
/// <summary>
/// команда на созданиие нового обьекта сущности DrugStore
/// </summary>
/// <param name="DrugNetWork">сеть аптек</param>
/// <param name="Number">номер аптеки</param>
/// <param name="Address">адрес аптеки</param>
/// <param name="PhoneNumber">номер телефона</param>
public record CreateDrugStoreCommand(
    string DrugNetWork,
    int Number, 
    Address Address,
    string PhoneNumber
    ) : IRequest<DrugStore>;