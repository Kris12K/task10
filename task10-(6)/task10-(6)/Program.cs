using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10__6_
{
    class Program
    {
        //функция проверки ввода целого числа
        public static int CheckInputInt(string message, int minValue, int maxValue)
        //(сообщение, мин вводимое значение, макс вводимое значение)
        {
            int input; //переменная, которой будет присвоено значение, введенное с клавиатуры
            do
            {
                input = maxValue + 1;  //переменной присваивается значение, выходящее за макс значение
                Console.WriteLine(message); //печать сообщения
                try
                {
                    string buf = Console.ReadLine();
                    input = Convert.ToInt16(buf);
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
            } while ((input < minValue) || (input > maxValue)); //пока значение больше макс/меньше мин
            return input;
        }

        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //программа обходит дерево по ярусам, вычисляет количество ярусов и количество вершин на каждом ярусе

            // ввод количества элементов дерева
            int n = CheckInputInt("Введите количество элементов дерева от 1 до 100", 1, 100);

            //создать дерево
            BinaryTree<int> tree = new BinaryTree<int>();

            //заполнить дерево случайными числами
            for(int i = 0; i < n; i++)
                tree.Add(rnd.Next(-100,100));

            //напечатать дерево
            tree.Print();
            Console.WriteLine();
            
            //Обойти дерево по уровням, напечатать количество вершин на уровне и уровней
            IEnumerable<BinaryTreeNode<int>> w = tree.LevelTraversalAndCount();
            foreach (BinaryTreeNode<int> a in w)
                Console.WriteLine(a.Value);

        }
    }
}
