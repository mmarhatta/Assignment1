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
            int[] arr = { 3, 1, 4, 1, 5, 3, 1, 3, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
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
                    for (k = 1; k <= n - i; k++)// No of spaces follow a patter where we have to print them in a sequence of n(total lines to print - the current line number )
                    {
                        Console.Write(" ");

                    }

                    for (j = 1; j <= 2 * i - 1; j++)// No of *s to be printed are in a count that follow a patter of 2* row number -1, so after space print *s
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();//After printing the spaces and *s in a line we need to change the line for next iteration.
                }
            }

            catch (Exception)// For invalid input, exception will be generated
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

                if (C == 1)// If the number entered is 1, then it should return True as 1 =1^2+0^2
                {
                    return true;
                }
                for (i = C; i >= 0; i--)// Finding the largest number in reverse that is a perfect square, for eg: If enetered number is 29, code will check in reverse order till it finds number
                                        //25 which is the perfect square 
                {
                    for (a = 0; a < C; a++)
                    {
                        if (a * a == i)
                        {
                            d = C - i;// Find the difference between the number enetered as input(C) and the squared value of the perfect square we found(i which is equal to a*a)
                            for (b = 0; b < d; b++) //example 29-25 is 4, so now we will check id 4 is the square of some number starting from 0.
                            {
                                if (b * b == d)// only if the remaining value is also a perfect square only then the function returns true, else it will continue till the last value of the difference.
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
                return false;// If the number cannot be expresses a sum of squares of 2 numbers, return false
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
                bool flag = false;
                int count = 0;
                int checkdup = 0;
                // Sorting the numbers are reversing the array to get the array sorted in descending order.
                Array.Sort(nums);
                Array.Reverse(nums);

                // If k is 0, the check the adjacent numbers in descendingly sorted list for equal number
                if (k == 0)
                {
                    for (i = 0; i <= nums.Length - 1; i++)
                    {
                        for (j = i + 1; j < nums.Length; j++)
                        {
                            if (nums[j] == nums[i])
                            {
                                //checkdup has initial value as 0, and updates only when the number occurs second time, it records the number that occured second time
                                // This piece of code assigns "true" value to the flag if it finds the same number occuring twice.
                                //In the next loop if it sees the occurance of same number this if block will not be entered because flag is true and nums[j] is equal to checkdup.
                                //Hence this loop will only be entered if the first pair of same number is found(as in that case flag is false) or if the new duplicate number is 
                                //different than the previous duplicate number because of the second part of the if condition.
                                if (flag == false || nums[j] != checkdup)
                                {
                                    
                                    count = count + 1;
                                    checkdup = nums[j];
                                    flag = true;
                                }
                            else continue;// continue the loop for rest of the elements
                            }

                            else
                            {
                                continue;// continue the loop for rest of the elements
                            }
                        }
                    }
                    return count;// returns the count of pairs which have a difference of 0
                }

                //For difference other than k=0, like k=1,2,3,4,5 etc, first take all the distinct numbers out as same numbers will only give a differnce of 0, which is not needed.
                else
                {
                    nums = nums.Distinct().ToArray();
                    for (i = 0; i <= nums.Length - 1; i++)
                    {
                        for (j = i + 1; j < nums.Length; j++)// Compare the number with all the numbers after in the array
                        {

                            if (nums[i] - nums[j] == k)// As the array is sorted, the difference of every number is being checked with the enetered value that is k,
                                                       // if it matches then increase the count by 1, and if it doesnt continue with the other other elements and check.
                            {
                                //Console.WriteLine(nums[i]);
                                //Console.WriteLine(nums[j]);
                                count = count + 1;

                            }

                            else
                            {
                                continue;
                            }
                        }
                    }

                    return count;// At the end, return the distinct count of pairs.
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
                    if (local.Contains('+'))
                    {
                        local = local.Substring(0, email.IndexOf('+')); //As anything after + character should be removed in local so we are storing values only till + 
                    }
                    else
                    { 
                        local = local; //  it local does not contain,+ character, do nothing, keep local as it is
                    }

                    if (local.Contains('.'))
                        local = local.Replace(".", string.Empty);//Replace any dot character in the local string with empty character
                    else
                    {
                        local = local; //  it local does not contain,. character, do nothing, keep local as it is
                    }
          
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

