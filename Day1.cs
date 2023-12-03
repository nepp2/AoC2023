
class Day1 {

    public static int Sum1(string[] inputs) => inputs.Sum(str => {
        var digits = str.Where(char.IsDigit);
        return (digits.First() - '0') * 10 + (digits.Last() - '0');
    });

    static string[] numbers = [
        "zero",
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine"
    ];
    static bool IsDigitChar(char c, int num) => c == (char)('0' + num);

    public static int Sum2(string[] inputs) {
        int FirstDigit(ReadOnlySpan<char> str) {
            for (int i = 0; i < str.Length; ++i)
                for (int num = 0; num < 10; ++num)
                    if (IsDigitChar(str[i], num) || str[i..].StartsWith(numbers[num]))
                        return num;
            throw new();
        }
        int SecondDigit(ReadOnlySpan<char> str) {
            for (int i = str.Length; i > 0; --i)
                for (int num = 0; num < 10; ++num)
                    if (IsDigitChar(str[i - 1], num) || str[0..i].EndsWith(numbers[num]))
                        return num;
            throw new();
        }
        return inputs.Sum(str => FirstDigit(str) * 10 + SecondDigit(str));
    }
}
