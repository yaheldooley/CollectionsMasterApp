using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            int[] intArray = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(intArray);

            //TODO: Print the first number of the array
            Console.WriteLine($"The first number in intArray is {intArray[0]}");
			//TODO: Print the last number of the array            
			Console.WriteLine($"The last number in intArray is {intArray[intArray.Length-1]}");

			Console.WriteLine("\nAll Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(intArray);

            Divider();

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");
            Array.Reverse(intArray);
            NumberPrinter(intArray);

			Divider();

			Console.WriteLine("---------REVERSE CUSTOM------------");
            intArray = ReverseArray(intArray);
            NumberPrinter(intArray);

			Divider();

			//TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
			ThreeKiller(intArray);

			Divider();

			//TODO: Sort the array in order now
			/*      Hint: Array.____()      */
			Array.Sort(intArray);
            Console.WriteLine("Sorted numbers:");
			for (int i = 0; i < intArray.Length; i++)
			{
                Console.WriteLine($"- {intArray[i]}");
			}

			Console.WriteLine("\n************End Arrays*************** \n");
			#endregion

			Divider();

			#region Lists
			Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            List<int> intList = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine($"This list's capacity is {intList.Capacity}\n");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(intList);

			//TODO: Print the new capacity
			Console.WriteLine($"\nThe list's capacity is now {intList.Capacity}\n");

			Divider();

			//TODO: Create a method that prints if a user number is present in the list
			//Remember: What if the user types "abc" accident your app should handle that!
			Console.WriteLine("What number will you search for in the number list?");

            int chosenNumber;
            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out chosenNumber))
            {
                NumberChecker(intList, chosenNumber);
			}
            else
            {
				Console.WriteLine("You did not enter a number!");
			}

			Divider();

			Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(intList.ToArray());

			Divider();


			//TODO: Create a method that will remove all odd numbers from the list then print results
			Console.WriteLine("Evens Only!!");
            OddKiller(intList);
            NumberPrinter(intList);

			Divider();

			//TODO: Sort the list then print results
			Console.WriteLine("Sorted Evens!!");
            intList.Sort();
            NumberPrinter(intList);

			Divider();

            //TODO: Convert the list to an array and store that into a variable
            int[] newIntArray = intList.ToArray();

            //TODO: Clear the list
            intList.Clear();

			#endregion
		}

        private static void ThreeKiller(int[] numbers)
        {
            List<int> multiplesOfThree = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0 && numbers[i] != 0)
                {
                    multiplesOfThree.Add(numbers[i]);
                    numbers[i] = 0;
				}
            }
            string message = "";
			foreach (int mult in multiplesOfThree)
            {
                message += $"Multiple of three = {mult}\n";
            }
            Console.WriteLine(message);
        }

        private static void OddKiller(List<int> numberList)
        {
            var allNums = numberList.ToArray();
            for (int i = 0; i < allNums.Length; i++)
            {
                if (allNums[i] % 2 != 0) numberList.Remove(allNums[i]);
            }
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
			if (numberList.Contains(searchNumber)) Console.WriteLine($"The list contains {searchNumber}!");
			else Console.WriteLine($"The list contains {searchNumber}!");
		}

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                int num = rng.Next(0, 50 + 1);
				numberList.Add(num);
                
			}
		}

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
			for (int i = 0; i < 50; i++)
            {
				int num = rng.Next(0, 50 + 1);
                numbers[i] = num;
				
			}
		}        

        private static int[] ReverseArray(int[] array)
        {
            int[] reverseArray = new int[array.Length];

            for (int i = 0; i < reverseArray.Length; i++)
            {
                int index = array.Length - (i + 1);
				reverseArray[i] = array[index];
            }

            return reverseArray;
        }

        private static void Divider()
        {
			Console.WriteLine("\nPress RETURN key to continue...");
			

			Console.WriteLine("---------------------------------");
			Console.ReadLine();
		}


        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
