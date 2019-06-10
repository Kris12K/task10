using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10__6_
{
    public class BinaryTree<T> 
    where T : IComparable
    {
        private BinaryTreeNode<T> head;
        private int count;

        //добавление элемента
        public void Add(T value)
        {
            //если  дерево пустое,то создать корневой узел
            if (head == null)
                head = new BinaryTreeNode<T>(value);
            //иначе найти место для вставки
            else
                AddTo(head, value);

            count++;
        }

        //вставка элемента
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            //если вставляемое значение меньше узла
            if (value.CompareTo(node.Value) < 0)
            {
                //если нет левого поддерева, то добавляем
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    //иначе идем дальше
                    AddTo(node.Left, value);
                }
            }
            //иначе -вставляемое значение больше или равно узлу
            else
            {
                //если нет правого поддерева, то добавляем добавляем
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    //иначе идем дальше
                    AddTo(node.Right, value);
                }
            }
        }
        
        //печать дерева
        public void Print()
        {
            Print(head, 5);
        }
        private void Print(BinaryTreeNode<T> p, int padding)
        {
            if (p != null)
            {
                if (p.Right != null)
                {
                    Print(p.Right, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (p.Right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(p.Value.ToString() + "\n ");
                if (p.Left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Print(p.Left, padding + 4);
                }
            }
        }
        
        //обход в ширину и подсчет узлов на ярусе
        public IEnumerable<BinaryTreeNode<T>> LevelTraversalAndCount()
        {
            //печать высоты дерева
            Console.WriteLine("Количество ярусов=" + Height(head));

            if (head == null)
            {
                yield break;
            }
            
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(head);

            int b = 0;
            int k = 1;
            while (queue.Count > 0)
            {
                if (b==0)
                {
                    Console.WriteLine("Вершин на ярусе №"+k+" = " + queue.Count);
                    k++;
                    b = queue.Count;
                }

                var node = queue.Dequeue();
                yield return node;

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
                b--;
            }
        }

        //найти высоту дерева
        public  static int Height(BinaryTreeNode<T> node)
        {
            if (node == null) return 0;
            //найти высоту левого и правого поддерева и выбрать большую
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }
    }
}
