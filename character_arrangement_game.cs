using System;

namespace Game_1
{
    class Program
    {
        //function to get the number of right answers
        static int right(int[] L1)
        {
            int total = 0;
            for (int i = 0; i < L1.Length; i++)
            {
                if (L1[i] == 1)
                    total++;
            }
            return total;
        }
        //function to get the number of wrong answers
        static int wrong(int[] L2)
        {
            int total = 0;
            for (int i = 0; i < L2.Length; i++)
            {
                if (L2[i] == 0)
                    total++;
            }
            return total;
        }
        //function to view all the questions with correct and answered responses
        static void show(string[] u, string[] v, string[] w)
        {
            Console.WriteLine("Question \t User Answer \t Correct Answer");
            for (int i = 0; i < u.Length; i++)
            {
                Console.WriteLine(u[i] + " \t " + v[i] + " \t " + w[i]);
            }
        }



        static void Main(string[] args)
        {
            // ask the user to enter the maximum number of questions
            Console.WriteLine("Please enter the maximum number of questions : ");
            int Qnumber;
            Qnumber = int.Parse(Console.ReadLine());

            // ask the user to enter the maximum number of letters
            Console.WriteLine("Please enter an integer value between 2 and 9 ( max number of alphabetic characters to be ordered )");
            int charnum;
            charnum = int.Parse(Console.ReadLine());


            // array reservation
            string[] question = new string[Qnumber + 1];
            string[] correctanswer = new string[Qnumber + 1];
            string[] useranswer = new string[Qnumber + 1];
            int[] result = new int[Qnumber + 1];

            string chars = "", Tanswer, Uanswer, chosen;



            for (int q = 1; q <= Qnumber; q++)
            {
                Console.WriteLine("Question : " + q);
                for (int L = 0; L < charnum; L++)
                {
                    //generate a random characters
                    int N;
                    Random number = new Random();
                    N = number.Next(65, 90);
                    chars = chars + (char)N;
                }
                // ask the user to give an answer
                char[] Letter;
                Console.WriteLine("What is the correct order of following characters");
                Console.WriteLine(chars);
                Console.WriteLine("To ignore the question, type Ignore");

                Letter = chars.ToCharArray();

                for (int L = 0; L < charnum; L++)
                    for (int An = 0; An < charnum - 1; An++)
                    {
                        // correct answer to the question
                        if ((int)Letter[An] > (int)Letter[An + 1])
                        {
                            char x;
                            x = Letter[An];
                            Letter[An] = Letter[An + 1];
                            Letter[An + 1] = x;
                        }
                    }

                Tanswer = new string(Letter);
                question[q] = chars;
                Uanswer = Console.ReadLine();
                correctanswer[q] = Tanswer;
                useranswer[q] = Uanswer;
                Console.WriteLine("======================================================");


                //store within the result array
                if (Uanswer == Tanswer)
                    result[q] = 1;
                else
                    result[q] = 0;
                chars = "";
            }


            // show options to the user
            Console.WriteLine("To get the number of right answers, type 1 ");
            Console.WriteLine("To get the number of wrong answers, type 2 ");
            Console.WriteLine("To view all the questions with correct and answered responses, type 3 ");
            Console.WriteLine("To exit type exit");
            chosen = Console.ReadLine();

            //show user selection
            while (chosen != "exit")
            {
                if (chosen == "1")
                {
                    //function to right answers call
                    int total;
                    total = right(result);
                    Console.WriteLine("The number of right answers is : " + total);
                }
                else
           if (chosen == "2")
                {
                    //function to wrong answers call
                    int total;
                    total = wrong(result);
                    Console.WriteLine("The number of wrong answers is : " + (total - 1));
                }
                else
            if (chosen == "3")
                    //function to view all the questions with correct and answered responses call
                    show(question, useranswer, correctanswer);


                Console.WriteLine("To get the number of right answers, type 1");
                Console.WriteLine("To get the number of wrong answers, type 2");
                Console.WriteLine("To view all the questions with correct and answered responses, type 3");
                Console.WriteLine("To exit type exit");
                chosen = Console.ReadLine();
                //THE END
            }
        }
    }
}
