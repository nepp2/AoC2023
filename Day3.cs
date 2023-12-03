
using System.Drawing;

ref struct SpanStream<T>(ReadOnlySpan<T> s) {
    public ReadOnlySpan<T> Data { get; } = s;
    public int Pos { get; private set; } = 0;
    public bool IsEmpty => Pos >= Data.Length;

    public void Skip(int len) => Pos += len;
    public void SkipUntil(Func<T, bool> cond) {
        for (; Pos < Data.Length; ++Pos)
            if (cond(Data[Pos])) break;
    }

    public ReadOnlySpan<T> ReadUntil(Func<T, bool> cond) {
        int start = Pos;
        SkipUntil(cond);
        return Data[start..Pos];
    }
}

record struct NumCollider(int Num, Rectangle Collider);

class Day3 {
    record struct SymbolGrid(int W, int H) {
        bool[] Grid = new bool[W * H];
        public Span<bool> Row(int row) => Grid.AsSpan()[(row * W)..][0..W];
        public bool CheckRect(in Rectangle r) {
            var (left, right) = (Math.Max(0, r.Left), Math.Min(W, r.Right));
            var (top, bottom) = (Math.Max(0, r.Top), Math.Min(H, r.Bottom));
            for (int i = top; i < bottom; ++i)
                foreach (bool b in Row(i)[left..right])
                    if (b) return true;
            return false;
        }
    }

    static void ParseNumbers(List<NumCollider> partNums, SymbolGrid symbols, int y, SpanStream<char> cs) {
        cs.SkipUntil(char.IsDigit);
        while(!cs.IsEmpty) {
            int start = cs.Pos;
            var intSpan = cs.ReadUntil(c => !char.IsDigit(c));
            var collider = new Rectangle(start - 1, y - 1, intSpan.Length + 2, 3);
            if(symbols.CheckRect(collider))
                partNums.Add(new(int.Parse(intSpan), collider));
            cs.SkipUntil(char.IsDigit);
        }
    }

    static List<NumCollider> FindPartNumbers(string[] lines) {
        void markSymbols(Span<bool> rowFlags, ReadOnlySpan<char> rowChars) {
            for (int x = 0; x < rowChars.Length; ++x) {
                char c = rowChars[x];
                rowFlags[x] = c != '.' && !char.IsLetterOrDigit(c);
            }
        }
        if (lines.Length == 0) return [];
        var symbols = new SymbolGrid(lines[0].Length, lines.Length);
        List<NumCollider> partNumbers = new();
        for (int y = 0; y < lines.Length; ++y)
            markSymbols(symbols.Row(y), lines[y]);
        for (int i = 0; i < lines.Length; ++i)
            ParseNumbers(partNumbers, symbols, i, new(lines[i]));
        return partNumbers;
    }

    public static int SumPartNumbers(string[] lines) =>
        FindPartNumbers(lines).Sum(pn => pn.Num);

    static List<Point> ParseGears(string[] lines) {
        List<Point> gears = new();
        for (int y = 0; y < lines.Length; ++y) {
            var cs = lines[y].AsSpan();
            for (int x = 0; x < cs.Length; ++x)
                if (cs[x] == '*')
                    gears.Add(new (x, y));
        }
        return gears;
    }

    public static int SumGearRatio(string[] lines) {
        List<Point> gears = ParseGears(lines);
        var partNumbers = FindPartNumbers(lines);
        return gears
            .Select(gear => partNumbers
                .Where(pn => pn.Collider.Contains(gear))
                .Select(pn => pn.Num)
                .ToArray())
            .Where(adj => adj.Length == 2)
            .Sum(adj => adj[0] * adj[1]);
    }
}