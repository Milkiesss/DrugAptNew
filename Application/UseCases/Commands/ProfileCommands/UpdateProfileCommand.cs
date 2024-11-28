using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.ProfileCommands;
/// <summary>
/// команда на обновление сущности Profile
/// </summary>
/// <param name="Id">идентификатор</param>
/// <param name="ExternalId">Telegram Id</param>
/// <param name="Email">Email Aдрес</param>
public record UpdateProfileCommand(
    Guid Id,
    string ExternalId,
    EmailAddress Email
) : IRequest<Profile>;