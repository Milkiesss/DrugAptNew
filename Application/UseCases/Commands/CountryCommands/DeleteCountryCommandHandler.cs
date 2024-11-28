using DrugsApt.Application.Interfaces.Repositories.CountryRepositories;
using DrugsApt.Application.UseCases.Commands.DrugCommands;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.CountryCommands;
/// <summary>
/// обработчик команды DeleteDrugCommand
/// </summary>
/// <param name="countryWriteRepository">репозиторий Country для чтения </param>
public class DeleteCountryCommandHandler(ICountryWriteRepository countryWriteRepository)
    : IRequestHandler<DeleteCountryCommand, bool>
{
    public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        await countryWriteRepository.DeleteAsync(request.Id,cancellationToken);
            
        return true;
    }
}