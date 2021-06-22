// =======================================================================================================================
// Title ..............................: 
// Product Version ....................:  
// Description.........................: 
// Author(s) ..........................: Kumar, Vinod
// =======================================================================================================================


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ArrayOperation
{
    class ArrayCoreOperation
    {
        internal static string[]  ArrayConCatinationSingleDimention(string[] array1, string[] array2)
        { 
            int i = array1.Length;
            foreach (string arr in array2)
            {
                Array.Resize(ref array1, i + 1);
                array1[i] = arr;
                i++;
            }
            return array1;
        }
        internal string[] ArrayConCatinationSingleDimention1(string[] array1, string[] array2)
        {
            int i = array1.Length;
            foreach (string arr in array2)
            {
                Array.Resize(ref array1, i + 1);
                array1[i] = arr;
                i++;
            }
            return array1;
        }
    }
}
