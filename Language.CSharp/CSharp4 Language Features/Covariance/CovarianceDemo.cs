using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp4Demo.Covariance
{
    class CovarianceDemo
    {
        public static void DemoUnsafeArray()
        {
            string[] strings = new string[3];
            object[] objects = strings;           // 陣列本來就支援 covariance

            // 可是，透過型別比較「大」的變數來操作同一家族中型別比較「小」的物件，是不安全的
            // 因為你可能會這樣做...
            objects[0] = DateTime.Now;
            string s = (string) objects[0];

            Console.WriteLine(strings[0]);            
        }

        public static void DemoGenericList()
        {
            List<string> stringList = new List<string>() { "Vivid", "Adams" };
            //List<object> objectList = stringList; // 即使 C# 4.0 也不能這樣寫。            

            IEnumerable<object> objectEnums = stringList;  // C# 4.0 OK! 但 C# 2/3 不能這樣寫。

            // 即使將 IEnumerable<T> 轉換成串列，也不會動到原始的串列內容。
            List<object> objectList = objectEnums.ToList();
            objectList[0] = "John";
            Console.WriteLine(stringList[0]);
        }

        public static void FactoryDemo()
        {
            
        }

        public static void Run()
        {
            // 一盒蘋果
            List<Apple> apples = new List<Apple>();
            apples.Add(new Apple());
            apples.Add(new Apple());

            // 一盒水蜜桃
            List<Peach> peaches = new List<Peach>();
            peaches.Add(new Peach());
            peaches.Add(new Peach());

            // 綜合
            List<Fruit> mixedFruits = new List<Fruit>();
            mixedFruits.Add(new Apple());
            mixedFruits.Add(new Peach());

            List<Fruit> mixedFruits2 = new List<Fruit>();
            mixedFruits2.AddRange(apples);
            mixedFruits2.AddRange(peaches);

            IEnumerable<Fruit> fruits = apples;  // OK!
            // fruits = apples.Concat(peaches);  // Compile error!
            fruits = fruits.Concat(peaches);
        }
    }

    public class Fruit
    {
    }

    public class Apple : Fruit
    {
    }

    public class Peach : Fruit
    {
    }
}
