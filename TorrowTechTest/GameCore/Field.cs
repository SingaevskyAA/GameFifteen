using System;
using System.Linq;


namespace TorrowTechTest.GameCore
{    
    public class Field
    {
        const int fiedlDimension = 4;
        const int maxValue = fiedlDimension * fiedlDimension;
        private int[,] field;

        /// <summary>
        /// Creates game field
        /// </summary>
        /// <returns>String representation of the field</returns>
        public static string GetNewField()
        {
            Random rnd = new Random();
            var field = Enumerable.Range(1, maxValue).OrderBy(c => rnd.Next()).ToArray();
            if(!IsSolvable(field))
            {
                if (field[0] != maxValue && field[1] != maxValue)
                    field.Swap(0, 1);
                else
                    field.Swap(2, 3);
            }           

            return string.Join(",", field);
        }


        /// <summary>
        /// Creates a game field from a string
        /// </summary>
        /// <param name="field">String representation of the field</param>
        public Field(string field)
        {
            var parsedField = field.Split(',').Select(int.Parse).ToArray();
            this.field = new int[fiedlDimension, fiedlDimension];
            for(int i = 0; i < fiedlDimension; i++)
            {
                for (int j = 0; j < fiedlDimension; j++)
                {
                    this.field[i, j] = parsedField[i * fiedlDimension + j];
                }
            }
        }

        /// <summary>
        /// Makes turn if it possible
        /// </summary>
        public bool Turn(int x, int y)
        {
            if (x >= fiedlDimension || y >= fiedlDimension || x < 0 || y < 0)
                return false;

            if (x + 1 < fiedlDimension && field[x + 1, y] == maxValue)
                field.Swap(x + 1, y, x, y);
            else if (y + 1 < fiedlDimension && field[x, y + 1] == maxValue)
                field.Swap(x, y + 1, x, y);
            else if (x - 1 >= 0 && field[x - 1, y] == maxValue)
                field.Swap(x - 1, y, x, y);
            else if (y - 1 >= 0 && field[x, y - 1] == maxValue)
                field.Swap(x, y - 1, x, y);
            else
                return false;
            return true;
        }
               
        public override string ToString()
        {
            return string.Join(",", field.Cast<int>());
        }

        /// <summary>
        /// Checks the possibility of solving the game
        /// </summary>
        /// <param name="field">Field as a one-dimensional int array</param>              
        private static bool IsSolvable(int[] field)
        {
            var invCounter = 0;
            int currenRow = 0; 
            int blankRow = 0;

            for (int i = 0; i < field.Length; i++)
            {
                if (i % fiedlDimension == 0)
                { 
                    currenRow++;
                }
                if (field[i] == maxValue)
                { 
                    blankRow = currenRow; 
                    continue;
                }
                for (int j = i + 1; j < field.Length; j++)
                {
                    if (field[i] > field[j] && field[j] != maxValue)
                    {
                        invCounter++;
                    }
                }
            }

            if (fiedlDimension % 2 == 0)
            { 
                if (blankRow % 2 == 0)
                { 
                    return invCounter % 2 == 0;
                }
                else
                { 
                    return invCounter % 2 != 0;
                }
            }
            else
            { 
                return invCounter % 2 == 0;
            }            
        }
    }
    
    static class Extention
    {
        /// <summary>
        /// Swaps two elements of a two-dimensional array
        /// </summary>        
        public static void Swap<T>(this T[,] array, int x1, int y1, int x2, int y2)
        {
            T temp = array[x1, y1];
            array[x1, y1] = array[x2, y2];
            array[x2, y2] = temp;
        }

        /// <summary>
        /// Swaps two elements of a one-dimensional array
        /// </summary>  
        public static void Swap<T>(this T[] array, int x, int y)
        {
            T temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }
    }
}
