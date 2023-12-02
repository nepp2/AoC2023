
string[] testInputs1 = [
    "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"
];
string[] testInputs2 = [
    "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four",
    "4nineeightseven2", "zoneight234", "7pqrstsixteen"
];

string[] calibInputs = File.ReadAllLines("../../../day1.txt");

Console.WriteLine($"Day 1, Part 1 test output: {Day1.Sum1(testInputs1)}");
Console.WriteLine($"Day 1, Part 1 real output: {Day1.Sum1(calibInputs)}");

Console.WriteLine($"Day 1, Part 2 test output: {Day1.Sum2(testInputs2)}");
Console.WriteLine($"Day 1, Part 2 real output: {Day1.Sum2(calibInputs)}");

class Day1 {
    public static int Sum1(string[] inputs) => inputs.Sum(str => {
        var digits = str.Where(char.IsDigit);
        return (digits.First() - '0') * 10 + (digits.Last() - '0');
    });

    static string[] numbers = [
        "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
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
