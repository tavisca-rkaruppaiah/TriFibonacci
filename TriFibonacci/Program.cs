using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            TriFibonacci triFibonacci = new TriFibonacci();
            int[] a = new int[] { -1, 2, 5, 1 };
            Console.WriteLine("missing : " + triFibonacci.Complete(a));
        }
    }

    public class TriFibonacci
    {
        public int Complete(int[] test)
        {
            int position = 0, missingElement = 0;
            for(int i = 0; i< test.Length; i++)
            {
                if(test[i] == -1)
                {
                    position = i;
                }
            }

            test[position] = 0;
            if (IsTriFibonacci(test) == true)
            {
                return -1;
            }
            else
            {
                if(position<3)
                {
                    switch(position)
                    {
                        case 0:
                            missingElement = test[position + 3] - test[position + 2] - test[position + 1];
                            test[position] = missingElement;
                            break;
                        case 1:
                            missingElement = test[position + 2] - test[position + 1] - test[position - 1];
                            test[position] = missingElement;
                            break;
                        case 2:
                            missingElement = test[position + 1] - test[position - 1] - test[position - 2];
                            test[position] = missingElement;
                            break;
                    }
                    if(missingElement>0)
                    {
                        if (IsTriFibonacci(test) == false)
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                    
                }
                else
                {
                    missingElement = test[position - 1] + test[position - 2] + test[position - 3];
                    test[position] = missingElement;
                    if (IsTriFibonacci(test) == false)
                    {
                        return -1;
                    }
                }
                
                   

                
            }

            
            return missingElement;
        }

        public bool IsTriFibonacci(int[] array)
        {
            int[] realArray = new int[array.Length];
            for(int i=0;i<array.Length;i++)
            {
                if(i < 3)
                {
                    realArray[i] = array[i];
                }
                else
                {
                    realArray[i] = array[i - 1] + array[i - 2] + array[i - 3];
                }
            }

            for(int i =0; i<realArray.Length; i++)
            {
                Console.WriteLine(realArray[i]+"missarr"+array[i]);
            }
            bool isEqual = Enumerable.SequenceEqual(realArray, array);
            return isEqual;
        }
    }
}
