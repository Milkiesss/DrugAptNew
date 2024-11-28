using DrugsApt.Application.Interfaces.Repositories.CountryRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.CountryCommands;
/// <summary>
/// обработчик команды UpdateCountryCommand 
/// </summary>
/// <param name="countryWriteRepository">репозиторий Country для записи</param>
/// <param name="countryReadRepository">репозиторий Country для чтений</param>
public class UpdateCountryCommandHandler(
    ICountryWriteRepository countryWriteRepository,
    ICountryReadRepository countryReadRepository)
    : IRequestHandler<UpdateCountryCommand, Country>
{

    public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var countryExist = await countryReadRepository.GetByIdAsync(request.id,cancellationToken);
        if (countryExist is null)
            throw new NullReferenceException();
        
        var country = new Country(request.Name, request.Code)
        {
            Id = Guid.NewGuid()
        };
        
        await countryWriteRepository.AddAsync(country,cancellationToken);
        return country;
    }
}