using System;

namespace ConsoleApp9
{
    class RefVal
    {
        public void Show()
        {
            string val = "Привет";

            HelloBehevior(val);
            Console.WriteLine(val);

            HelloBehevior((object)val);
            Console.WriteLine(val);

            HelloBehevior(ref val);
            Console.WriteLine(val);

            HelloBeheviorOut(out val);
            Console.WriteLine(val);
        }

        private void HelloBehevior(string val)
        {
            val = val + " мир";
        }

        private void HelloBehevior(object val)
        {
            val = val + "!";
        }

        private void HelloBehevior(ref string val)
        {
            val = val + " земля";
        }

        private void HelloBeheviorOut(out string val)
        {
            val = String.Empty;
        }

    }
}
