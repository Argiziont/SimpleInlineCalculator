using System;
using System.Linq;
using System.Text;

namespace InlineCalc
{
    public class InlineCalculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Answer is: {StringCalculator(Console.ReadLine())}");
        }
        public static double StringCalculator(string inlineStr)
        {
            //Operators which will be used
            char[] operators = { '*', '/', '+' };
            //inlineStr = inlineStr.Replace("--", "+");
            inlineStr =inlineStr.Replace("-","+-");//we don't calculate miunus so replace it with '+-'



            for (int i = 0; i < operators.Length; i++)//for all operators
            {
                if (inlineStr.IndexOf(operators[i]) != -1)//if we found where operator is
                {
                    var z = inlineStr.Count(x => x == operators[i]);
                    for (int j = 0; j != z; j++)
                    {
                        int firstNumberlength;
                        int secondNumberlength;
                        StringBuilder tmpString = new StringBuilder();
                        int operatorPos = inlineStr.IndexOf(operators[i]);//check the position of operator

                        if ((operatorPos - 1 >= 0) && (operatorPos + 1 < inlineStr.Length))
                        {
                            int counter = operatorPos - 1;
                            while (Char.IsDigit(inlineStr[counter]) || inlineStr[counter] == '-'|| inlineStr[counter] == ',')//read whole number backward
                            {
                                tmpString.Insert(0,inlineStr[counter]);
                                if (--counter < 0)
                                {
                                    break;
                                }
                            }
                            string firstNumber = tmpString.ToString();
                            firstNumberlength = tmpString.Length;
                            tmpString.Clear();
                            counter = operatorPos + 1;
                            while (Char.IsDigit(inlineStr[counter])|| inlineStr[counter]=='-' || inlineStr[counter] == ',')//read whole number forward
                            {
                                tmpString.Append(inlineStr[counter]);
                                if (++counter>= inlineStr.Length)
                                {
                                    break;
                                }
                            }
                            string secondNumber = tmpString.ToString();
                            secondNumberlength = tmpString.Length;
                            tmpString.Clear();
                            //
                            double calculatedData = Calculate(operators[i], Double.Parse(firstNumber), Double.Parse(secondNumber));//make calculation

                            inlineStr = inlineStr//replace old string with the brand new
                                .Remove(operatorPos - firstNumberlength, 1+ firstNumberlength+ secondNumberlength)
                                .Insert(operatorPos - firstNumberlength, calculatedData.ToString());
                            Console.WriteLine($"{ inlineStr} Processed operation: {firstNumber} {operators[i]} {secondNumber}");
                        }
                    }
                }
            }
            double resultNumber;
            if (Double.TryParse(inlineStr, out resultNumber))
                return resultNumber;
            else
                Console.WriteLine("Wrong line");
            System.Environment.Exit(-1);
            return -1;
        }
        static double Calculate(char choperator, double first, double second)//just returns processed number
        {

            switch (choperator)
            {
                case '*':
                    return first * second;
                case '/':
                    return Math.Round((first / second),2);
                case '+':
                    return first + second;
                default:
                    break;
            }
            return 0;
        }
    }
}
