using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelterfromScratch
{
    //  Firstly define the structure of animals:

    public interface IAnimal // Main interface for all types of animal
    {
        string Name { get; set; }
        int Age { get; set; }

        string ToString();
        bool Equals(object obj);
    }

    abstract class Animal : IAnimal // Animal structure
    {

        public string Name
        {
            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }
        }

        public int Age { get; set; }

        public Animal (string Name, int Age)
        {
   
        }



        public override string ToString()
        {
            return "Name: " + this.Name + "   Age: " + this.Age;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }

    class Dog : Animal, IAnimal
    {
        public override string ToString()
        {
            return "Name: " + this.Name + "   Age: " + this.Age;
        }

        public Dog(string Name, int Age) : base(Name, Age)
        {
            Console.WriteLine("name: " + Name + "   Age: " + Age);
        }
    }

    class Cat : Animal, IAnimal
    {
        public Cat(string Name, int Age) : base(Name, Age)
        {
        }
    }


    // ---   Now define the shelter   ---

    interface IShelter // define requirements of the shelter
    {
        IAnimal LocateAnimal(string name);
        bool StoreAnimal(IAnimal animal);
    }

    class AnimalShelter : IShelter //create the storage array for animals within the shelter
    {
        private IAnimal[] animals;

        public AnimalShelter(int arraySize) // constructor
        {

            animals = new IAnimal[arraySize];

        }

        public IAnimal LocateAnimal(string name)
        {
            for (int z=0; z<animals.Length; z++)
            {
                if (animals[z].Name == name) return animals[z];
            }
            return null;
        }

        public bool StoreAnimal(IAnimal animal)
        {
            for (int z=0; z<animals.Length; z++)
            {
                if (animals[z] == null)
                {
                    animals[z] = animal;
                    return true;
                }
            }
            return false;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Define shelter size
            int ShelterSize = 10;
            /* Console.Write("Define size of shelter: ");
            // string ShelterSizeInput = Console.ReadLine();
            ShelterSize = Int32.Parse(ShelterSizeInput);
            */
            Console.WriteLine("Shelter of size " + ShelterSize + " created"); 
            AnimalShelter Shelter = new AnimalShelter(ShelterSize);

            //Display main menu

            int menuChoice = 0;

            while (menuChoice != 9)
            {
                Console.WriteLine("Shelter\n-------\n\n");
                Console.WriteLine("1\tDefine and store Animal");
                Console.WriteLine("2\tLocate Animal");
                Console.WriteLine("9\tExit");




                try
                {
                    string menuChoiceStr = Console.ReadLine();
                    menuChoice = Int32.Parse(menuChoiceStr);

                    switch (menuChoiceStr)
                    {
                        case "1":  //  define and store animal
                            {
                                Console.WriteLine("Enter name of animal");
                                string nameStr = Console.ReadLine();
                                Console.WriteLine("Enter age of animal");
                                string ageStr = Console.ReadLine();
                                int ageInt = Int32.Parse(ageStr);

                                Console.WriteLine("Enter type of animal ;  1 = Dog, 2 = Cat");


                                string animalTypeStr = null;

                                try
                                {
                                    while ((animalTypeStr != "1") || (animalTypeStr != "2"))
                                    {
                                        animalTypeStr = Console.ReadLine();

                                        switch (animalTypeStr)
                                        {
                                            case "1":
                                                {
                                                    Dog TobyDog = new Dog(nameStr, ageInt);
                                                    Console.WriteLine("Dog created.");

                                                    if (Shelter.StoreAnimal(TobyDog))
                                                    {
                                                        Console.WriteLine(nameStr + " stored. Press 'Return' to continue.");
                                                    }
                                                    Console.WriteLine(TobyDog.ToString());
                                                    Console.Read();
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    Cat TobyCat = new Cat(nameStr, ageInt);
                                                    Console.WriteLine("Cat created.");

                                                    if (Shelter.StoreAnimal(TobyCat))
                                                    {
                                                        Console.WriteLine(nameStr + " stored. Press 'Return' to continue.");
                                                    }
                                                    Console.Read();
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.WriteLine("Invalid number - try again");
                                                    break;
                                                }

                                        }
                                        break;
                                    }

                                }

                                catch
                                {
                                    Console.WriteLine("Try again");
                                }
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("Enter name of animal");
                                string nameSearch = Console.ReadLine();
                                Console.WriteLine(Shelter.LocateAnimal(nameSearch));

                                Console.WriteLine("2 (Locate animal) pressed. Press 'Return' to continue.");
                                Console.Read();
                                break;
                            }
                        case "9":
                            {
                                Console.WriteLine("Exit chosen. Press 'Return' to continue.");
                                Console.Read();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid number - try again");

                                break;
                            }
                    }
                }
                catch
                {
                    Console.WriteLine("Enter an integer! Press any key to continue.");
                }
            }
        }
    }
 
}

