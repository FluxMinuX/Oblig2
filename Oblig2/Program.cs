using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig_2_Opt
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter how many nodes, type a number. Must be over 1: ");
			int nodes = int.Parse(Console.ReadLine());
			int[,] connections = new int[nodes, nodes];
			char[] color = new char[nodes];
			int[] restriction = new int[nodes];
			int[] check = new int[nodes];
			RandomColor(color, nodes);
			NumberOfConnections(check, nodes);
			RandomGraph(connections, restriction, check, nodes);
			PrintGraph(connections, nodes);
		}

		static void RandomGraph(int[,] connections, int[] restriction, int[] check, int nodes)
		{
			int teller = 0;
			int counter = 0;
			int select;
			Random rand = new Random();

			for (int i = 0; i < nodes; i++)
			{
				while (counter < check[i] || counter == 0)
				{

					select = rand.Next(1, nodes);
					if (restriction[i] == check[i])
					{
						counter = 99;
					}
					else if (restriction[select] == check[select] && teller != nodes)
					{
						teller++;
					}

					else if (i != select && restriction[i] != 3 && restriction[select] != 3 && connections[i, select] != 1)
					{
						if (connections[i, select] == 1)
						{
							continue;
						}
						connections[i, select] = 1;
						connections[select, i] = 1;
						restriction[i] = restriction[i] + 1;
						restriction[select] = restriction[select] + 1;
						counter++;
						/*Console.WriteLine("i: " + i);
						Console.WriteLine("Select: " + select);
						Console.WriteLine("Counter: " + counter);
						Console.WriteLine("Teller rest[0]: " + restriction[0]);
						Console.WriteLine("Teller check[0] " + check[0]);
						Console.WriteLine("Teller rest[1]: " + restriction[1]);
						Console.WriteLine("Teller check[1] " + check[1]);
						Console.WriteLine("Teller rest[2]: " + restriction[2]);
						Console.WriteLine("Teller check[2] " + check[2]);
						Console.WriteLine("Teller rest[3]: " + restriction[3]);
						Console.WriteLine("Teller check[3] " + check[3]);
						Console.WriteLine("Teller rest[4]: " + restriction[4]);
						Console.WriteLine("Teller check[4] " + check[4]);
						PrintGraph(connections, nodes);*/
					}
				}
				counter = 0;
			}
		}

		static void PrintGraph(int[,] connections, int nodes)
		{
			Console.WriteLine("Print");
			for (int i = 0; i < nodes; i++)
			{
				for (int j = 0; j < nodes; j++)
				{
					Console.Write(connections[i, j]);
				}
				Console.Write(Environment.NewLine);
			}
			Console.Write(Environment.NewLine);
			Console.Read();

		}

		static void RandomColor(char[] color, int nodes)
		{
			string chars = "RWB";
			Random rand = new Random();
			for (int i = 0; i < nodes; i++)
			{
				color[i] = chars[rand.Next(chars.Length)];
				//Console.WriteLine(color[i]);
			}
			//Console.Read();
		}

		static void NumberOfConnections(int[] check, int nodes)
		{
			Random rand = new Random();
			for (int i = 0; i < nodes; i++)
			{
				check[i] = rand.Next(2, 4);
				Console.Write(check[i] + " ");
			}
			Console.Write(Environment.NewLine);
		}
	}
}
