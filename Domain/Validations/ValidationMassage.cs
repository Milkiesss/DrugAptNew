namespace DrugsApt.Domain.Validations;

public static class ValidationMassage
{
    public static string NotNull = "{PropertyName} cannot be null";
    public static string NotEmpty = "{PropertyName} cannot be empty";
    public static string ErrorLenght = "{PropertyName} must be greater than {min} and less than {max}";
    public static string OnlyLettersAndSpaces = "{PropertyName} must contain only letters and spaces";
    public static string OnlyCapitalLatinLetters = "{PropertyName} must contain only capital latin letters";
    public static string NoSpecialCharacters = "{PropertyName} cant contain sapcial characters";
    public static string OnlyLettersSpacesAndHyphens = "{PropertyName} must contain only letters, spaces and hyphens";
    public static string PositiveNumber = "{PropertyName} must be a positive number";
    public static string DecimalNumber = "{PropertyName} should not contain 2 numbers after the decimal point";
    public static string MinimumNumber = "{PropertyName} must be greater ";
    public static string MaximumNumber = "{PropertyName} must be less";
    public static string WrongEmailSyntax = "Email must contain the '@' symbol.";
}
