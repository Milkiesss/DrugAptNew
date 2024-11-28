using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.FavoriteDrugCommands;
/// <summary>
/// команда на обновление FavoriteDrug
/// </summary>
/// <param name="Id">идентификатор</param>
/// <param name="ProfileId">Telegram Id</param>
/// <param name="Profile">профиль</param>
/// <param name="DrugId">идентификаор препарата</param>
/// <param name="Drug">препарат</param>
/// <param name="DrugStoreId">идентификатор аптеки</param>
/// <param name="DrugStore">аптека</param>
public record UpdateFavoriteDrugCommands(
    Guid Id,
    Guid ProfileId,
    Profile Profile,
    Guid DrugId,
    Drug Drug,
    Guid? DrugStoreId,
    DrugStore DrugStore
) : IRequest<FavoriteDrug>;
