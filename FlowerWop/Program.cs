using FlowerWop.Models;
using FlowerWop.Services;

namespace FlowerWop.CRUD
{
    class Program
    {
        static IFlowerService flowerService = new FlowerService();
        static bool isContinueProject = true;
        static void Main(string[] args)
        {
            do
            {
                PrintMenu();

                Console.Write("Enter your command: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        flowerService.ReadAllFlowers();
                        break;
                    case "2":
                        Console.Write("Enter your flower id: ");
                        int flowerGetById = Convert.ToInt32(Console.ReadLine());
                        flowerService.GetFlower(flowerGetById);
                        break;
                    case "3":
                        Console.Write("Enter your flower id: ");
                        int flowerDeleteByid = Convert.ToInt32(Console.ReadLine());
                        flowerService.RemoveFlower(flowerDeleteByid);
                        break;
                    case "4":
                        Flower flower = new Flower();
                        Console.Write("Exsist information, enter id: ");
                        flower.Id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter your flower id: ");
                        int flowerUpdateByid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter flower name : ");
                        flower.Name = Console.ReadLine();
                        Console.Write("Enter flower color : ");
                        flower.Color = Console.ReadLine();
                        Console.Write("Enter flower cost : ");
                        flower.Cost = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter flower discreption : ");
                        flower.Discreption = Console.ReadLine();

                        flowerService.ModifyFlower(flower.Id, flower);
                        break;
                    case "5":
                        Flower flowerCreate = new Flower();
                        Console.Write("Enter flower id : ");
                        flowerCreate.Id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter flower name : ");
                        flowerCreate.Name = Console.ReadLine();
                        Console.Write("Enter flower color : ");
                        flowerCreate.Color = Console.ReadLine();
                        Console.Write("Enter flower cost : ");
                        flowerCreate.Cost = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter flower discreption : ");
                        flowerCreate.Discreption = Console.ReadLine();

                        flowerService.CreateFlower(flowerCreate);
                        break;
                }

                Console.Write("Is Continue(yes / no): ");
                string isContinue = Console.ReadLine();
                if (isContinue.Contains("no"))
                {
                    isContinueProject = false;
                }

            } while (isContinueProject is true);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Welcome to, our shop!");
            Console.WriteLine("1. Disply flowers.");
            Console.WriteLine("2. Disply one flower.");
            Console.WriteLine("3. Remove one flower.");
            Console.WriteLine("4. Modify one flower.");
            Console.WriteLine("5. Create one flower.");
        }
    }
}