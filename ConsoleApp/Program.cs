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
            // create a list of instcance of Animal class
            List<Animal> ourAnimal = new List<Animal>
            {
            new Animal { Id = "100", Species = "dog", Age = "1", PhysicalCondition = "good", Personality = "active", Nickname = "kila" },
            new Animal { Id = "101", Species = "cat", Age = "1", PhysicalCondition = "very_good", Personality = "active", Nickname = "kitty" }
            };

            int petId = 102;

            Console.WriteLine("Please Select an Option from the menu: ");
            Console.WriteLine("Enter 'exit' to exit the program\n");
            Console.WriteLine("1. List all of our current pet information.\r\n2. Add new Animal Details.\r\n3. Edit an animal Details.\r\n4. Delete an animal Details.\r\n5. Display selected pets' details.\n");

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
                            Console.WriteLine("All the pets details - ");
                            ListAllPetInformation(ourAnimal);
                            break;

                        case 2:
                            Console.WriteLine("Add New pet details -");
                            AddNewAnimalDetails(ourAnimal, petId);
                            petId++;
                            break;
                        case 3:
                            Console.WriteLine("Edit pets' details - ");
                            EditAnimalDetails(ourAnimal);
                            break;
                        case 4:
                            Console.WriteLine("Delete selected pets' details - ");
                            DeleteSelectedPetDetails(ourAnimal);
                            break;
                        case 5:
                            Console.WriteLine("Selected Pets' details - ");
                            string id = GetUserInput("Enter PetId: ");
                            ListSelectedPetInformation(ourAnimal, id);
                            break;                           
                        default:
                            Console.WriteLine("Invalid menu option.");
                            break;
                    }
                }

            } while (userInput != "exit");
        }

        private static void EditAnimalDetails(List<Animal> animals)
        {
            string id = GetUserInput("Enter PetId: ");
            ListSelectedPetInformation(animals, id);

            Animal animalToEdit = animals.Find(a => a.Id == id);

            if (animalToEdit != null)
            {
                //Allow user to update the information
                animalToEdit.Species = GetUserInput("New pet species (cat or dog):");
                animalToEdit.Age = GetUserInput("New pet age (years):");
                animalToEdit.PhysicalCondition = GetUserInput("New description of the pet's physical condition/characteristics:");
                animalToEdit.Personality = GetUserInput("New description of the pet's personality:");
                animalToEdit.Nickname = GetUserInput("New pet's nickname:");

                Console.WriteLine("Pet Details updated successfully!");
            }
            else
            {
                Console.WriteLine($"Pet with ID {id} not found.");
            }
        }

        private static void ListAllPetInformation(List<Animal> animals)
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

        private static void ListSelectedPetInformation(List<Animal> animals, string id) {

            Animal animalToEdit = animals.Find(a => a.Id == id);
            if (animalToEdit != null)
            {
                Console.WriteLine($"Current details for Pet ID # {animalToEdit.Id}:");
                Console.WriteLine($"Pet species : {animalToEdit.Species}");
                Console.WriteLine($"Pet age : {animalToEdit.Age}");
                Console.WriteLine($"Pet's physical condition/characteristics : {animalToEdit.PhysicalCondition}");
                Console.WriteLine($"Pet's personality : {animalToEdit.Personality}");
                Console.WriteLine($"Pet's nickname : {animalToEdit.Nickname}\n");
            }
            else
            {
                // If the specified ID is not found, print an error message
                Console.WriteLine($"Pet with ID {id} not found.");
            }
        }

        private static void AddNewAnimalDetails(List<Animal> animals, int petId)
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

        private static void DeleteSelectedPetDetails(List<Animal> animals) {

            string id = GetUserInput("Enter PetId: ");
            ListSelectedPetInformation(animals, id);

            Animal animalToDelete = animals.Find(a => a.Id == id);

            if (animalToDelete != null)
            {
                animals.Remove(animalToDelete);
                Console.WriteLine("Pets' details removed successfully");
            }
            else
            {
                Console.WriteLine($"Pet with ID {id} not found.");
            }
        }

        private static string GetUserInput(string prompt)
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
