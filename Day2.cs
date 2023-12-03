
record struct CubeSample(int r, int g, int b);
record struct Game(int id, List<CubeSample> samples);

class Day2 {

    delegate void VisitSpan(ReadOnlySpan<char> str);

    static void SpanSplit(ReadOnlySpan<char> str, string sep, VisitSpan func) {
        while (!str.IsEmpty) {
            int i = str.IndexOf(sep);
            if(i == -1) {
                func(str);
                break;
            }
            else {
                func(str[0..i]);
                str = str[(i + sep.Length)..];
            }
        }
    }

    public static Game ReadGame(ReadOnlySpan<char> game) {
        game = game["Game ".Length..];
        int colonPos = game.IndexOf(':');
        int id = int.Parse(game[0..colonPos]);
        game = game[(colonPos + 1)..].TrimStart();
        List<CubeSample> samples = new();
        SpanSplit(game, "; ", sample => {
            int r = 0, g = 0, b = 0;
            SpanSplit(sample, ", ", cc => {
                int space = cc.IndexOf(" ");
                int count = int.Parse(cc[0..space]);
                var colour = cc[(space + 1)..];
                if (colour.StartsWith("red")) r += count;
                else if (colour.StartsWith("green")) g += count;
                else if (colour.StartsWith("blue")) b += count;
            });
            samples.Add(new(r, g, b));
        });
        return new(id, samples);
    }

    public static int SumPossibleGames(string[] games) =>
        games.Select(s => ReadGame(s))
            .Where(g => !g.samples.Any(s => s.r > 12 || s.b > 13 || s.g > 14))
            .Sum(g => g.id);

    public static int SumOfPowers(string[] games) {
        return games.Select(s => ReadGame(s)).Sum(game => {
            var gs = game.samples;
            return gs.Max(s => s.r) * gs.Max(s => s.g) * gs.Max(s => s.b);
        });
    }
}