using System;

namespace ConsoleApp
{
    class Animal
    {
        public string Id { get; set; }
        public string Species { get; set; }
        public string Age { get; set; }
        public string PhysicalCondition { get; set; }
        public string Personality { get; set; }
        public string Nickname { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            List<Animal> ourAnimal = new List<Animal>
            {
            new Animal { Id = "100", Species = "dog", Age = "1", PhysicalCondition = "good", Personality = "active", Nickname = "kila" },
            new Animal { Id = "101", Species = "cat", Age = "1", PhysicalCondition = "very_good", Personality = "active", Nickname = "kitty" }
            };

            int petId = 102;

            Console.WriteLine("Please Select an Option from the menu: ");
            Console.WriteLine("Enter 'exit' to exit the program\n");
            Console.WriteLine("1. List all of our current pet information.\r\n2. Add new Animal Details.\r\n3. Edit an animal Details.\r\n4. Delete an animal Details.\r\n5. Display all cats with a specified characteristic.\r\n6. Display all dogs with a specified characteristic.\n");

            string? userInput;
            int menuNumber = 0;

            do
            {
                userInput = Console.ReadLine()?.Trim().ToLower();

                if (!int.TryParse(userInput, out menuNumber) && userInput != "exit")
                {
                    Console.WriteLine("Please Enter a valid input!\n");
                    continue;
                }
                else if ((menuNumber < 1 || menuNumber > 6) && userInput != "exit")
                {
                    Console.WriteLine($"The Number ({menuNumber}) is Out of bound!\n");
                    continue;
                }
                else if(menuNumber >= 1 || menuNumber <= 6)
                {
                    switch (menuNumber)
                    {
                        case 1:
                            ListAllPetInformation(ourAnimal);
                            break;

                        case 2:
                            AddNewAnimalDetails(ourAnimal, petId++);
                            break;

                        case 3:


                        default:
                            Console.WriteLine("Invalid menu option.");
                            break;
                    }
                }

            } while (userInput != "exit");
        }

        static void ListAllPetInformation(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine($"Pet ID # : {animal.Id}");
                Console.WriteLine($"Pet species : {animal.Species}");
                Console.WriteLine($"Pet age : {animal.Age}");
                Console.WriteLine($"Pet's physical condition/characteristics : {animal.PhysicalCondition}");
                Console.WriteLine($"Pet's personality : {animal.Personality}");
                Console.WriteLine($"Pet's nickname : {animal.Nickname}\n");
            }
        }

        static void AddNewAnimalDetails(List<Animal> animals, int petId)
        {
            Animal newAnimal = new Animal
            {
                Id = petId.ToString(),
                Species = GetUserInput("Pet species (cat or dog):"),
                Age = GetUserInput("Pet age (years):"),
                PhysicalCondition = GetUserInput("A description of the pet's physical condition/characteristics:"),
                Personality = GetUserInput("A description of the pet's personality:"),
                Nickname = GetUserInput("Pet's nickname:")
            };

            animals.Add(newAnimal);
            Console.WriteLine("Pet Details added successfully!");
        }

        static string GetUserInput(string prompt)
        {
            string userInput;
            do
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine()?.Trim().ToLower();
            } while (string.IsNullOrEmpty(userInput));

            return userInput;
        }
    }
}
