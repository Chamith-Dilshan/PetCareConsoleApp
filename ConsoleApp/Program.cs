using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] ourAnimale = { { "#100", "dog", "1", "good", "active", "kila"},{ "#101", "cat", "1", "very_good", "active", "kitty" } };
            String? userInput;
            int menuNumber = 0;
            bool validNum = false;

            Console.WriteLine("Please Select an Option from the menu: ");
            Console.WriteLine("Enter 'exit' to o exit the program\n");
            Console.WriteLine("1.List all of our current pet information.\r\n2.Assign values to the ourAnimals array fields.\r\n3.Ensure animal ages and physical descriptions are complete.\r\n4.Ensure animal nicknames and personality descriptions are complete.\r\n5.Edit an animal’s age.\r\n6.Edit an animal’s personality description.\r\n7.Display all cats with a specified characteristic.\r\n8.Display all dogs with a specified characteristic.\n");

            do { 
                userInput = Console.ReadLine()?.Trim().ToLower();
                validNum = int.TryParse(userInput, out menuNumber);

                if (!validNum && userInput != "exit") {
                    Console.WriteLine("Please Enter a valid input!\n");
                    continue;
                }
                else if ((menuNumber < 1 || menuNumber > 8) && userInput != "exit") {
                    Console.WriteLine($"The Number ({menuNumber}) is Out of bound!\n");
                    continue;
                }
                else {

                    if (menuNumber == 1)
                    {
                        for (int i = 0; i < ourAnimale.GetLength(0); i++) {
                            for (int j = 0; j < ourAnimale.GetLength(1); j++) {
                                Console.WriteLine($"Pet ID # : {ourAnimale[i, j]} ");
                                j++;
                                Console.WriteLine($"Pet species : {ourAnimale[i, j]} ");
                                j++;
                                Console.WriteLine($"Pet age : {ourAnimale[i, j]} ");
                                j++;
                                Console.WriteLine($"Pet's physical condition/characteristics : {ourAnimale[i, j]} ");
                                j++;
                                Console.WriteLine($"Pet's personality : {ourAnimale[i, j]} ");
                                j++;
                                Console.WriteLine($"Pet's nickname : {ourAnimale[i, j]}\n");
                            }
                        }
                    }
                    else if (menuNumber == 2)
                    {

                    }
                    else if (menuNumber == 3)
                    {

                    }
                    else if (menuNumber == 4)
                    {

                    }
                    else if (menuNumber == 5)
                    {

                    }
                    else if (menuNumber == 6)
                    {

                    }
                    else if (menuNumber == 7)
                    {

                    }
                    else if (menuNumber == 8)
                    {

                    }
                }

            } while (userInput != "exit");
        }
    }
}
