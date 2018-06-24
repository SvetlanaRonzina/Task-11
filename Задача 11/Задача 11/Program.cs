using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ex11
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                    int count;
                    while (!int.TryParse(Console.ReadLine(), out count) || (count < 2))
                 Console.WriteLine("Введите натуральное число больше 1 ");
                    var places = new int[count];                                // инициализация массива-карты
                    var dePlaces = new int[count];                              // массив-карта для дешифровки
                    bool flag = false;
                    //ввод последовательности
                    while (flag == false)
                    {
                        flag = true;
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine("Введите " + (i + 1) + " элемент для перестановки (число от 1 до " + count
                                + ", которое вы еще не вводили");
                            while (!int.TryParse(Console.ReadLine(), out places[i]) || (places[i] > count) || (places[i] < 1))
                                Console.WriteLine("Введите число от 1 до " + count + ", которое вы еще не вводили");
                        }
                        for (int j = 0; j < count; j++)
                            for (int q = j + 1; q < count; q++)
                                if (places[j] == places[q])
                                    flag = false;
                    }
                    for (int i = 0; i < count; i++)
                        places[i] = places[i] - 1;


                        for (int i = 0; i < count; i++)
                    dePlaces[places[i]] = i;

                Console.WriteLine();

                    Console.WriteLine("Введите текст");
                    string cur = Console.ReadLine();              // хранение данного слова
                    string crypting = "";                                         // зашифрованный вариант слова
                    string decripting = "";                                        // расшифрованный вариант слова

                if (cur.Length % count > 0)                                 // заполнение пробелами справа
                    cur = cur.PadRight(cur.Length + (count - cur.Length % count));

                var blocks = cur.Length / count;                            // количество блоков

                for (var i = 0; i < blocks; i++)                            // по-блочно
                {
                    for (var j = 0; j < count; j++)                         // внутри блока - побуквенно
                    {
                        crypting += cur[places[j]];                         // шифровка по карте
                        decripting += cur[dePlaces[j]];
                    }
                    

                    cur = cur.Remove(0, count);                             // удаление расшифрованных символов
                }

                Console.WriteLine("Шифрованное от исходного слово: " + crypting);
                Console.WriteLine("Дешифрованное от исходного слово: " + decripting);

                Console.ReadLine();
            }

        }
    }
}
