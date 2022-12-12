using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    class Fruit
    {
        public virtual void ShowName()
        {
            Console.WriteLine("Fruit");
        }
    }

    class Apple : Fruit
    {
        public override void ShowName()
        {
            Console.WriteLine("Apple");
        }
    }

    class Peach : Fruit
    {
        public void ShowName()
        {
            Console.WriteLine("Peach");
        }
    }

    class Melon : Fruit
    {
        public new void ShowName()
        {
            Console.WriteLine("Melon");
        }
    }

    class Basket
    {
        public void Contents()
        {
            // 1
            List<Fruit> fruits = new List<Fruit>();
            fruits.Add(new Apple());
            fruits.Add(new Peach());
            fruits.Add(new Melon());
            foreach(var fruit in fruits)
            {
                fruit.ShowName();
            }

            // 2
            var apple = new Apple();
            apple.ShowName();

            var peach = new Peach();
            peach.ShowName();

            var melon = new Melon();
            melon.ShowName();

            // 3
            Fruit theMelon = new Melon();
            theMelon.ShowName();

            ((Melon)theMelon).ShowName();
            ((Apple)theMelon).ShowName();
            
        }
    }
}
