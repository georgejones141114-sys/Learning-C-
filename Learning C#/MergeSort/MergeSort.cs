using System;
using System.Collections.Generic;

class MergeSort
{
    static void Main(string[] args)
    {
        List<int> example_list = new List<int>();
        bool stopProgram = false;
        while (!stopProgram)
        {
            Console.WriteLine("Enter a number (or type 'stop' to finish) ");
            string user_input = Console.ReadLine(); // User Input
            if (user_input.ToLower() == "stop") // Stop Program Validation
            {
                stopProgram = true;
            }
            else if (int.TryParse(user_input, out int number))
            {
                example_list.Add(number); // else, add the number to the list
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer."); // Input Validation
            }
        }

        int[] example_array = example_list.ToArray(); // Convert the list to an array
        if (example_array.Length > 0)
        {
            Sort(example_array, 0, example_array.Length - 1); // Call the Sort function
            Console.WriteLine("Sorted array: " + string.Join(", ", example_array)); // Display the sorted array
        }
        else
        {
            Console.WriteLine("No numbers were entered to sort.");
        }
    }

    static void Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            Sort(array, left, middle); // Recursively sort/split the left half
            Sort(array, middle + 1, right); // Recursively sort/split the right half
            Merge(array, left, middle, right);
        }
    }

    static void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1; 
        int n2 = right - middle;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = array[left + i];
        for (int j = 0; j < n2; j++)
            R[j] = array[middle + 1 + j];

        int k = left;
        int i1 = 0;
        int j2 = 0;

        while (i1 < n1 && j2 < n2)
        {
            if (L[i1] <= R[j2])
            {
                array[k] = L[i1];
                i1++;
            }
            else
            {
                array[k] = R[j2];
                j2++;
            }
            k++;
        }

        while (i1 < n1)
        {
            array[k] = L[i1];
            i1++;
            k++;
        }

        while (j2 < n2)
        {
            array[k] = R[j2];
            j2++;
            k++;
        }
    }
}