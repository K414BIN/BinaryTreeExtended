using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            TreeFunctions tree = new TreeFunctions();
            //
            Console.Write("Введите целочисленное значение: ");
            int userX = Convert.ToInt32(System.Console.ReadLine());
            userX = Math.Abs(userX);
            System.Console.WriteLine();
            do
            {// случайные значения
                tree.DoSomeAdd(rnd.Next(userX) + 1);
                userX--;
            } while (userX != 0);
            // количество уровней древа
            int i = TreeFunctions.height(tree.Root);
            // Вывод результатов
            ShowMeNodes(tree.Root, i);
           // я эксперементально проверил, что двойка генерируется случайным образом всегда при уровне больше 3
          // если такого не случилось перезапустите программу
            Console.WriteLine("Удаляем  2 (двойку), где бы она не находилась.");
            //********************
            tree.deleteKey(2);
            //********************
            System.Console.WriteLine("Смотрим результат.");
            ShowMeNodes(tree.Root, i);
            Console.Write("Введите целочисленное значение для удаления (Не корень и не последний уровень!): ");
            userX = Convert.ToInt32(System.Console.ReadLine());
            userX = Math.Abs(userX);
            tree.deleteKey(userX);
            System.Console.WriteLine("Смотрим окончательный результат.");
            ShowMeNodes(tree.Root, i);
            System.Console.WriteLine();
            System.Console.WriteLine("| 1 Lvl | 2 Lvl | 3 Lvl | 4 Lvl | 5 Lvl | 6 Lvl | 7 Lvl | 8 Lvl | 9 Lvl |  ");
            // красиво сделать так мне и не удалось :(
            TreeFunctions.printTree(tree.Root);
            Console.ReadLine();

        }
        public static void ShowMeNodes(Node node,int i)
        {
            System.Console.WriteLine("Все значения в дереве по порядку: ");
            TreeFunctions.sorted_level_order(node);
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Breadth - first search finds nodes on each level.");
            do
            {
                System.Console.WriteLine();
                System.Console.Write("Nodes on " + i + " level: ");
                TreeFunctions.printGivenLevel(node, i);
                System.Console.WriteLine();
                i--;
            } while (i != 0);
            System.Console.WriteLine();
            System.Console.Write("Depth-first search finds this deepest node - ");
            System.Console.WriteLine(TreeFunctions.deepestNode(node));
            System.Console.WriteLine();
        }
    }
}
