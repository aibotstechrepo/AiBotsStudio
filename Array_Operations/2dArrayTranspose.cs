using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Array_Operations
{

    public sealed class _2dArrayTranspose : CodeActivity
    {
         
        public InArgument<string[][]> _Array { get; set; }
        public OutArgument<string[][]> TransposedArray { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string[][] text = context.GetValue(this._Array);
            //string[][] data = new string[0][];

            int rowCount = text.Length;
            int columnCount = text[0].Length;
            string[][] transposed = new string[columnCount][];
            if (rowCount == columnCount)
            {
                transposed = (string[][])text.Clone();
                for (int i = 1; i < rowCount; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        string temp = transposed[i][j];
                        transposed[i][j] = transposed[j][i];
                        transposed[j][i] = temp;
                    }
                }
            }
            else
            {
                for (int column = 0; column < columnCount; column++)
                {
                    transposed[column] = new string[rowCount];
                    for (int row = 0; row < rowCount; row++)
                    {
                        transposed[column][row] = text[row][column];
                    }
                }
            }
            //return transposed;

            //for (int i=0; i<text.Length;i++)
            //{
            //    if (data.Length < text[i].Length)Array.Resize(ref data, text[i].Length);
            //    Array.Resize(ref data[i], text.Length);

            //    for(int j = 0; j < text[i].Length; j++)
            //    {
            //        //Array.Resize(ref data[i], text.Length);

            //        data[i][j] = text[j][i];
            //    }

            //}

            TransposedArray.Set(context, transposed);
        }
    }
}
