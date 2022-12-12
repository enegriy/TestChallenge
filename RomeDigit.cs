using System;

namespace ConsoleApp9
{
    internal class RomeDigit
    {
        struct Pair
        {
            public int Current { get; set; }
            public int Next { get; set; }

            public Pair(int current, int next)
            {
                Current = current;
                Next = next;
            }
        }

        public int ConvertToInt(string source)
        {
            if (source.Length == 1)
            {
                return ParseSymbol(source);
            }
            else if (source.Length > 1)
            {
                return ParseMultiSymbol(source);
            }
            return 0;
        }

        private int CompositePair(Pair pair)
        {
            if (pair.Current >= pair.Next)
                return pair.Current + pair.Next;
            else
                return pair.Next - pair.Current;
        }

        private Pair GetPair(int startIndex, string source)
        {
            var cur = 0;
            var next = 0;

            if (source.Length > startIndex)
                cur = ParseSymbol(source[startIndex].ToString());

            if (source.Length > startIndex + 1)
                next = ParseSymbol(source[startIndex + 1].ToString());

            return new Pair(cur, next);
        }

        private int ParseMultiSymbol(string symbols)
        {
            var result = 0;
            var startIndex = 0;

            while (startIndex < symbols.Length)
            {
                var pair = GetPair(startIndex, symbols);
                result += CompositePair(pair);

                startIndex += 2;
            }

            return result;
        }

        private int ParseSymbol(string symbol)
        {
            switch (symbol)
            {
                case "I": return 1;
                case "V": return 5;
                case "X": return 10;
            }
            throw new InvalidOperationException("Не удалось распознать символ");
        }
    }
}
