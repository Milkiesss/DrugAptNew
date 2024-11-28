using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Application.Interfaces.Repositories.DrugStoreRepositories;
using DrugsApt.Application.Interfaces.Repositories.FavoriteDrugRepositories;
using DrugsApt.Application.Interfaces.Repositories.ProfileRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.FavoriteDrugCommands;

/// <summary>
/// обработчик команды UpdateFavoriteDrugCommands
/// </summary>
/// <param name="favoriteDrugWriteRepository">репозиторий FavoriteDrug для записи</param>
/// <param name="favoriteDrugReadRepository">репозиторий FavoriteDrug для чтения</param>
/// <param name="drugStoreReadRepository">репозиторий DrugStoreдля чтения</param>
/// <param name="drugReadRepository">репозиторий Drug для чтения</param>
/// <param name="profileReadRepository">репозиторий Profile для чтения</param>
public class UpdateFavoriteDrugCommandHandler(
    IFavoriteDrugWriteRepository favoriteDrugWriteRepository,
    IFavoriteDrugReadRepositories favoriteDrugReadRepository,
    IDrugStoreReadRepository drugStoreReadRepository,
    IDrugReadRepository drugReadRepository,
    IProfileReadRepository profileReadRepository)
    : IRequestHandler<UpdateFavoriteDrugCommands, FavoriteDrug>
{
   public async Task<FavoriteDrug> Handle(UpdateFavoriteDrugCommands request, CancellationToken cancellationToken)
    {
        var FavoriteDrugExist = await favoriteDrugReadRepository.GetByIdAsync(request.Id);
        if(FavoriteDrugExist is null)
            throw new NullReferenceException("FavoriteDrug not found");
            
        var ProfileExist = await profileReadRepository.GetByIdAsync(request.ProfileId,cancellationToken);
        if (ProfileExist is null)
            throw new NullReferenceException("Profile not found");
        
        var drugExist = await drugReadRepository.GetByIdAsync(request.DrugId,cancellationToken);
        if(drugExist is null)
            throw new NullReferenceException("Drug not found");
        
        var drugStoreExist = await drugStoreReadRepository.GetByIdAsync(request.DrugStoreId,cancellationToken);


        var favoriteDrug = new FavoriteDrug(
            ProfileExist.Id, 
            ProfileExist, 
            drugExist.Id, 
            drugStoreExist.Id,
            drugExist,
            drugStoreExist)
        {
            Id = request.Id,
        };
        await favoriteDrugWriteRepository.UpdateAsync(favoriteDrug);
        return favoriteDrug;
    }
}