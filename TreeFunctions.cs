using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{

	public class TreeFunctions
	{
		public static int maxLevel = -1;
		public static int res = -1;
		public Node Root;
		static readonly int count = 10;
		// добавление ноды
		public void DoSomeAdd(int value)
		{
			if (Root == null)
			{
				Root = new Node() { Data = value };
			}
			else DoSomeAdd(Root, value);
		}
		// самое длинное "левое" значение
		public static int deepestNode(Node root)
		{
			find(root, 0);
			return res;
		}
		// самое длинное "левое" значение
		public static void find(Node root, int level)
		{
			if (root != null)
			{
				// у меня рекурсия в середине с инкрементом
				find(root.Left, ++level);
								
				if (level > maxLevel)
				{
					res = root.Data;
					maxLevel = level;		
				}
				// и опять рекурсия
				find(root.Right, level);
			}
		}
		// самая длинная  ветка
		public static int height(Node root)
		{
			if (root == null)
			{ // В корне
				return 0;
			}
			else
			{
				//Уровень левой ветки
				int lheight = height(root.Left);
				//Уровень правой ветки
				int rheight = height(root.Right);

				// Что больше?
				if (lheight > rheight)
				{
					return (lheight + 1);
				}
				else
				{
					return (rheight + 1);
				}
			}
		}
		// поиск BSF
		public  void printLevelOrder()
		{
			int h = height(Root);
			int i;
			for (i = 1; i <= h; i++)
			{
				printGivenLevel(Root, i);
			}
		}
		// создаем ноды
		private void DoSomeAdd(Node node, int value)
		{
			if (node.Data < value)
			{   // Есть что-то справа
				if (node.Right != null)
				{
					DoSomeAdd(node.Right, value);
				}
				else
				{// ничего нет - создаем
					node.Right = new Node() { Data = value, Parent = node };
				}
			}
			else if (node.Data > value)
			{
			 // Есть что-то слева
				if (node.Left != null)
				{
					DoSomeAdd(node.Left, value);
				}
				else
				{// ничего нет - создаем
					node.Left = new Node() { Data = value, Parent = node };
				}
			}
		
		}
		// сортируем через очередь и отсортированый  набор
		public static void sorted_level_order(Node root)
		{
			Queue<Node> q = new Queue<Node>();
			SortedSet<int> s = new SortedSet<int>();
			//Добавление объекта
			q.Enqueue(root);
			// Конец очереди
			q.Enqueue(null);

			while (q.Count != 0)
			{
				//  Взял первый в очереди 
				Node tmp = q.Peek();
				// удалил его
				q.Dequeue();

				if (tmp == null)
				{  //очередь кончилась
					if (s.Count == 0) { break; }
						
					foreach (int v in s)
					{
						Console.Write(v + " ");
					}
					// Конец очереди
					q.Enqueue(null);
					//очистка набора
					s.Clear();
				}
				else
				{    // в отсортированный набор добавление
				 	s.Add(tmp.Data);

					if (tmp.Left != null)
						// в очередь дбавление левого потомка
						q.Enqueue(tmp.Left);
					if (tmp.Right != null)
						// в очередь дбавление правого потомка
						q.Enqueue(tmp.Right);
				}
			}
		}
		// удаление
		public  void deleteKey(int key)
		{ Root = deleteRec(Root, key); }
		// удаление
		public static Node deleteRec(Node root, int key)
		{
			if (root == null)
				return root;

			if (key < root.Data)
				root.Left = deleteRec(root.Left, key);
			else if (key > root.Data)
				root.Right = deleteRec(root.Right, key);
     		else
			{
				// один "лист" справа
				if (root.Left == null)
					return root.Right;
				// один "лист" слева
				else if (root.Right == null)
					return root.Left;
				// маленькое значение влево
				root.Data = minValue(root.Left);
				// удаление
				root.Left = deleteRec(root.Left, root.Data);
			}
			return root;
		}
		// минимальное значение
		public static int minValue(Node root)
		{
			int minv = root.Data;
			while (root.Right != null)
			{
				minv = root.Right.Data;
				root = root.Right;
			}
			return minv;
		}
		// идем уровень за уровнем 
		public static void printGivenLevel(Node root, int level)
		{
			if (root == null)
			{
				return;
			}
			if (level == 1)
			{
				Console.Write(root.Data + " ");
			}
			else if (level > 1)
			{
				printGivenLevel(root.Left, level - 1);
				printGivenLevel(root.Right, level - 1);
			}
		}
		// Печатает древо
		public static void printUtil(Node root, int space)
		{
			
			if (root == null) return;

			space += count;

			printUtil(root.Right, space);

			Console.Write("\n");
			for (int i = count; i < space; i++)	Console.Write("-");
			Console.Write("\b");
			Console.Write("\b");
			Console.Write("->(");
			Console.Write(root.Data +")"+ "\n");

			printUtil(root.Left, space);
		}
		// Печатает
		public static void printTree(Node root)
		{
			printUtil(root, 0);
		}
	}
}




		
	
