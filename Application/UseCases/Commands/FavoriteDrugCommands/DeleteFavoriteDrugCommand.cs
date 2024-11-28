using MediatR;

namespace DrugsApt.Application.UseCases.Commands.FavoriteDrugCommands;
/// <summary>
/// команда на удаление обьекта сущности FavoriteDrug
/// </summary>
/// <param name="Id">идентификатор</param>
public record DeleteFavoriteDrugCommand(Guid Id) : IRequest<bool>;