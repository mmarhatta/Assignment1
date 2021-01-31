using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace Assignment1
{
    class Program
    {

        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();


            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = SquareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("the sorted array is", arr);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:

            List<string> emails = new List<string>();
            emails.Add("dis.email+bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = uniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }







        private static void printTriangle(int n)
        {
            try
            {
                int i;
                int j;
                int k;
                for (i = 1; i <= n; i++)
                {
                    for (k = 1; k <= n - i; k++)
                    {
                        Console.Write(" ");

                    }

                    for (j = 1; j <= 2 * i - 1; j++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        private static void printPellSeries(int n2)
        {
            try
            {

                int nextNum = 0;
                int N0 = 0;
                int N1 = 1;
                int i;



                if (n2 == 1)// If no of elements we want to output is 1, then first number should be 0
                {
                    Console.WriteLine("The first few terms of the sequence are:" + 0);
                }

                else if (n2 == 2)// If no of elements we want to output is 2, then the first two number should be 0 and 1
                {
                    Console.WriteLine("The first few terms of the sequence are:" + 0 + "," + 1);
                }

                else if (n2 > 2) // If no of elements we want to output is > 2, then 
                {
                    Console.Write("The first few terms of the sequence are:" + 0 + "," + 1 + ",");

                    for (i = 1; i < n2; i++)// to iterate and repeat the task for each element based on the numbers(n2) we want in the output to be printed
                    {
                        nextNum = N1 * 2 + N0;// Find the next number by multiplying previous number(N1) by 2 and adding the number prior to the previous number(N0)
                        N0 = N1;// With every next number being added, older N1 becomes N0
                        N1 = nextNum;// and nextnumber of previous loop becomes our new N1

                        Console.Write(nextNum + ","); //Append each next number wih a comma.
                    }



                }

            }

            catch (Exception)
            {

                throw;
            }

        }

        private static bool SquareSums(int C)
        {
            try
            {
                int a;
                int b;
                int d;
                int i;

                if (C == 0)// If the number entered is 0, then it should return True as o =0^2+0^2
                {
                    return true;
                }
                for (i = C; i >= 0; i--)// Finding the largest number in reverse that is a perfect square
                {
                    for (a = 0; a < C; a++)
                    {
                        if (a * a == i)
                        {
                            d = C - i;// Find the difference between the number enetered as input(C) and the squared value of the perfect square we found(i which is equal to a*a)
                            for (b = 0; b < d; b++)
                            {
                                if (b * b == d)// oonly if the remaining value is also a perfect square only then the function returns true, else it will continue till the last value of the difference.
                                {
                                    return true;
                                }

                                else
                                {
                                    continue;
                                }
                            }

                        }

                        else
                        {
                            continue;
                        }
                    }

                }
                return false;
            }

            catch (Exception)
            {

                throw;
            }
        }

        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                int i;
                int j;
                int count = 0;
                Array.Reverse(nums);
                Debug.WriteLine(nums);
                Array.Reverse(nums);

                // print all element of array 
                foreach (int value in nums)
                {
                    Debug.Write(value + " ");
                }
                if (k == 0)
                {
                    for (i = 0; i <= nums.Length - 1; i++)
                    {
                        for (j = i + 1; j < nums.Length - 1; j++)
                        {
                            if (nums[i] == nums[j])
                            {
                                count = count + 1;

                            }

                            else
                            {
                                continue;
                            }
                        }
                    }
                    return count;
                }

                else
                {
                    for (i = 0; i <= nums.Length - 1; i++)
                    {
                        for (j = i + 1; j < nums.Length - 1; j++)
                        {

                            if (nums[i] - nums[j] == k)
                            {
                                Debug.WriteLine(nums[i]);
                                Debug.WriteLine(nums[j]);
                                count = count + 1;

                            }

                            else
                            {
                                continue;
                            }
                        }
                    }

                    return count;
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        private static int uniqueEmails(List<string> emails)
        {
            try
            {

                string domain;
                string local;
                string final_email;
                List<string> final_email_list = new List<string>();

                //"dis.email+bull@usf.com", "dis.e.mail+bob.cathy@usf.com", "disemail+david@us.f.com"]
                foreach (string email in emails)
                {
                    int index = email.IndexOf('@');// We will separate local and domain value baased on the index of '@' character as the cut offpoint
                    local = email.Substring(0, index - 1); // store the substring from beginning till the character before @ as local
                    domain = email.Substring(index + 1);// store the substring from character after @ till the end as domain
                    local = local.Substring(0, email.IndexOf('+')); //As anything after + character should be removed in local so we are storing values only till + 
                    //local = local.Replace('.',' ' );
                    local = local.Replace(".", string.Empty);//Replace any dot character in the local string with empty character
                    // final_email.ToList();
                    final_email = local + "@" + domain;// Join the local and domain together after all the cleansing.
                    final_email_list.Add(final_email);//Add all the elements to the list
                    //final_email.ToList();

                }


                int res = (from x in final_email_list select x).Distinct().Count();// Count the distinct email elements in the emails list.

                return res;
            }

            catch (Exception)
            {

                throw;
            }
        }

        private static string DestCity(string[,] paths)
        {
            int i;
            string res = "";


            try
            {
                List<string> startingPoints = new List<string>();// Define 2 strings to hold starting points and ending ponts of the trip
                List<string> endingPoints = new List<string>();
                for (i = 0; i < paths.GetLength(0); i++)

                {
                    startingPoints.Add(paths[i, 0]);// In the array of arrays first element is starting point and hence captured as paths[i,0]
                    endingPoints.Add(paths[i, 1]);// In the array of arrays second element is ending point and hence captured as paths[i,1]


                }
                foreach (string element in endingPoints)// Now check for all the elements that are present in ending points, which among that is not in start point
                {
                    if (startingPoints.Contains(element))// If the node is a starting point then it is not the final destination and hence the loop should continue till that element is found.
                    {
                        continue;
                    }
                    else
                    {
                        res = element; // Once the element/ stop is found that is present in ending points and not present in starting points, it is stores in result variable and returned. 
                        break;

                    }

                }
                return res;


            }
            catch (Exception)
            {

                throw;
            }


        }


    }

}


/* Self Reflection
 *      1.) Time taken: Problems 1 to 3 I coud solve in a day, 4th, 5th and 6th problem took longer
 *      2.) Learning: Leart iteration thrugh, arrays, lists, arrays of arrays, error handeling, checking if my logic ccovers all the corner cases,
 *          initially took a while to understand how to approach the problem, then found the base way was to first solve the question like a human mind works, then writing theps in a paper,
 *          then implementing the code, using debugger and watching the variables for their values if the actual outcome did not match the expected.
 *      3.) Recommendations: Beautifully designed questions which enforced brainstorming to get the results, covering the breadth of concepts in programming. Recommendation would be if we can
 *          solve the assignment problems in an application like openkattis or something where the system checks for the testcases with the inputs as getting aware of the issues with the code 
 *          at the same moment is effective, We remember our logic and are more keen on getting all the test cases passed than later when we get the grades.
 */

