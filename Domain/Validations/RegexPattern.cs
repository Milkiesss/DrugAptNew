using System.Text.RegularExpressions;

namespace DrugsApt.Domain.Validations;

public static class RegexPattern
{
    public static readonly Regex OnlyLettersAndSpacesPattern = new (@"^[a-zA-Zа-яА-ЯёЁ\s]+$");
    public static readonly Regex NoSpecialCharactersPattern = new("^[a-zA-Z0-9]+$");
    public static readonly Regex OnlyLettersSpacesAndHyphensPattern = new("^[a-zA-Zа-яА-ЯёЁ\\s-]+$");
    public static readonly Regex OnlyCapitalLatinLettersPattern = new("^[A-Z]+$");
}