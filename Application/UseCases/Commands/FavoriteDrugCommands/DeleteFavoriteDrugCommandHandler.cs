using DrugsApt.Application.Interfaces.Repositories.FavoriteDrugRepositories;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.FavoriteDrugCommands;
/// <summary>
/// обработчки команды DeleteFavoriteDrugCommand
/// </summary>
/// <param name="favoriteDrugWriteRepository">репозиторий FavoriteDrug для записи</param>
public class DeleteFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugWriteRepository)
    : IRequestHandler<DeleteFavoriteDrugCommand, bool>
{
    public async Task<bool> Handle(DeleteFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        await favoriteDrugWriteRepository.DeleteAsync(request.Id);
        return true;
    }
}