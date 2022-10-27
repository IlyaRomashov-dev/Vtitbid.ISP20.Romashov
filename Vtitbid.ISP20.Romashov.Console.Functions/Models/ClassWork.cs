using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Romashov.Console.Functions
{
    internal class ClassWork
    {
        //variable 11
        public static double[] ReCreateArray(double[] array,double deletingStart, double deletingEnd, out int indexOfModuleMin,out double sum)
        {
            sum = 0;
            indexOfModuleMin = 0;
            double min = array[0];
            for(int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) < Math.Abs(min))
                {
                    min = array[i];
                    indexOfModuleMin = i;
                }
                if(array[i] < 0)
                {
                    for(int j = i; j < array.Length; j++)
                    {
                        sum += array[j];
                    }
                }
            }
            for(int i = 0; i < array.Length;i++)
            {
                if (array[i] > deletingStart && array[i] < deletingEnd)
                {
                    array[i] = 0;
                }
            }
            return array;
        }
    }
}
