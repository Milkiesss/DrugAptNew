using DrugsApt.Application.Interfaces.Repositories.CountryRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.CountryCommands;
/// <summary>
/// Обработчик команды на создание нового обьекта сущности Country
/// </summary>
/// <param name="countryWriteRepository">репозиторий Country Для записи</param>
public class CreateCountryCommandHandler(ICountryWriteRepository countryWriteRepository) : IRequestHandler<CreateCountryCommand,Country>
{
    public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country(request.Name, request.Code);
        await countryWriteRepository.AddAsync(country,cancellationToken);
        return country;
    }
}