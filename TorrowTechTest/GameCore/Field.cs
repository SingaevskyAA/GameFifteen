using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace TorrowTechTest.GameCore
{    
    public class Field
    {
        const int fiedlDimension = 4;
        const int maxValue = fiedlDimension * fiedlDimension;
        private int[,] field;

        //Метод создает новое поле для игры
        public static string GetNewField()
        {
            Random rnd = new Random();
            var field = Enumerable.Range(1, maxValue).OrderBy(c => rnd.Next()).ToArray();

            //TO DO: Solvable

            return string.Join(",", field);
        }

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

        //Метод совершает ход клеткой (x,y), если он возможен
        public bool Turn(int x, int y)
        {
            if (x >= fiedlDimension || y >= fiedlDimension)
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
            var result = new StringBuilder();
            foreach(var elem in field)
            {
                result.Append(elem);
                result.Append(',');
            }
            result.Length--;
            return result.ToString();
        }
    }

    static class Extention
    {        
        public static void Swap<T>(this T[,] array, int x1, int y1, int x2, int y2)
        {
            T temp = array[x1, y1];
            array[x1, y1] = array[x2, y2];
            array[x2, y2] = temp;
        }
    }
}
