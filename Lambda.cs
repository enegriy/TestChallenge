using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp9
{
    class Lambda
    {
        public void Show()
        {
            var source = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var result = source.Where(x => x > 2 && x < 6);

            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            source[3] = 0;
            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            var actions = new List<Func<int>>();

            var start = 0;
            var finish = 5;
            while (start < finish)
            {
                actions.Add(() => start * 2);
                start++;
            }

            foreach (var act in actions)
            {
                Console.Write(act.Invoke());
            }
        }
    }
}
