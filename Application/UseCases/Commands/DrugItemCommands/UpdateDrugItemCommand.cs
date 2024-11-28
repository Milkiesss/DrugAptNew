using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugItemCommands;
/// <summary>
/// команда на обновление обьекта сущности DrugIyem 
/// </summary>
/// <param name="Id">идентификатор</param>
/// <param name="DrugId">иентификатор препарата</param>
/// <param name="Drug">препарат</param>
/// <param name="DrugStoreId">идентифиактор аптеки</param>
/// <param name="DrugStore">аптека</param>
/// <param name="Price">цена</param>
/// <param name="Amount">кол-ва</param>
public record UpdateDrugItemCommands(
    Guid Id,
    Guid DrugId,
    Drug Drug,
    Guid DrugStoreId,
    DrugStore DrugStore,
    decimal Price,
    double Amount
) : IRequest<DrugItem>;
