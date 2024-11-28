using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.ProfileCommands;
/// <summary>
/// команда на создание новой сущности Profile
/// </summary>
/// <param name="ExternalId">Telegram Id</param>
/// <param name="Email">Email адрес</param>
public record CreateProfileCommand(
    string ExternalId,
    EmailAddress Email
    ) : IRequest<Profile>;

