using System.Text.RegularExpressions;
using Humanizer;

namespace Shared.Extensions;

public static partial class StringExtensions
{
    public static string ToKebabCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return KebabCaseRegex().Replace(value, "-$1")
            .Trim()
            .ToLower();
    }

    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
    
    
    
    public static string ToSnakeCase(this string value)
    {
        return new string(Convert(value.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;

            yield return char.ToLower(e.Current);

            while (e.MoveNext())
            {
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
            }
        }
    }

    public static string ToPlural(this string value)
    {
        return value.Pluralize(inputIsKnownToBeSingular: false);
    }
}