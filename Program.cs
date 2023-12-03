
void RunDay1() {
    string[] testInputs1 = [
        "1abc2",
        "pqr3stu8vwx",
        "a1b2c3d4e5f",
        "treb7uchet"
    ];
    string[] testInputs2 = [
        "two1nine",
        "eightwothree",
        "abcone2threexyz",
        "xtwone3four",
        "4nineeightseven2",
        "zoneight234",
        "7pqrstsixteen"
    ];

    string[] calibInputs = File.ReadAllLines("../../../day1.txt");

    Console.WriteLine($"Day 1, Part 1 test output: {Day1.Sum1(testInputs1)}");
    Console.WriteLine($"Day 1, Part 1 real output: {Day1.Sum1(calibInputs)}");

    Console.WriteLine($"Day 1, Part 2 test output: {Day1.Sum2(testInputs2)}");
    Console.WriteLine($"Day 1, Part 2 real output: {Day1.Sum2(calibInputs)}");
}

void RunDay2() {
    string[] testInputs = [
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
    ];
    string[] gameInputs = File.ReadAllLines("../../../day2.txt");

    Console.WriteLine($"Day 2, Part 1 test output: {Day2.SumPossibleGames(testInputs)}");
    Console.WriteLine($"Day 2, Part 1 real output: {Day2.SumPossibleGames(gameInputs)}");

    Console.WriteLine($"Day 2, Part 2 test output: {Day2.SumOfPowers(testInputs)}");
    Console.WriteLine($"Day 2, Part 2 real output: {Day2.SumOfPowers(gameInputs)}");
}

void RunDay3() {
    string[] testSchematic = [
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598..",
    ];
    string[] fullSchematic = File.ReadAllLines("../../../day3.txt");
    Console.WriteLine($"Day 3, Part 1 test output: {Day3.SumPartNumbers(testSchematic)}");
    Console.WriteLine($"Day 3, Part 1 real output: {Day3.SumPartNumbers(fullSchematic)}");

    Console.WriteLine($"Day 3, Part 2 test output: {Day3.SumGearRatio(testSchematic)}");
    Console.WriteLine($"Day 3, Part 2 real output: {Day3.SumGearRatio(fullSchematic)}");
}

RunDay1();
RunDay2();
RunDay3();