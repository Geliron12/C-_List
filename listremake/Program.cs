using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listremake
{
    public class elem
    {
        public int data;
        public string name;
        public elem next;
        public elem prev;
        public elem(int inf,string f)
        {
            name = f;
            data = inf;
            next = null;
            prev = null;
        }
        public elem()
        {
            next = null;
            prev = null;
        }
        public void reset_next(elem that)
        {
            this.next = that;
        }
        public void reset_prev(elem that)
        {
            this.next = that;
        }
    }
    class list
    {
        public elem nul = new elem();
        elem tail = new elem();
        elem head = new elem();
        public list()
        {
            tail.prev = head;
            head.next = tail;
        }
        public void print(elem n)
        {
            Console.WriteLine("Значение узла - " + n.data+" Название узла - "+n.name);
        }
        public void add_elem(int a, int b)
        {
            Console.WriteLine("Введите значение и имя через enter");
            bool g=true;
            while (g)
            {
                try
                {
                    int u = Convert.ToInt32(Console.ReadLine());

                    string d = Console.ReadLine();

                    elem f = new elem(u, d);
                    if (b == 0)
                    {
                        tail.prev.next = f;
                        f.next = tail;
                        f.prev = tail.prev;
                        tail.prev = f;
                    }
                    else
                    {
                        elem h = find_elem(a);
                        h.next.prev = f;
                        f.next = h.next;
                        f.prev = h;
                        h.next = f;
                    }
                    g = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод");
                }
            }

        }
        public elem find_elem(int a)
        {
            int count = 0;
            elem h = new elem();
            h = head;
            while (h != tail)
            {
                if (h.data == a)
                {
                    count++;
                    break;
                }
                h = h.next;
            }
            if (count == 0) return nul;
            else return h;
        }
        public void print_all()
        {
            elem h = new elem();
            h = head.next;
            while (h != tail)
            {
                print(h);
                h = h.next;
            }
        }
        void swap(elem h, elem k)
        {
            elem t1 = h.prev;
            elem t2 = k.next;
            h.next = k.next;
            k.next = h;
            k.prev = h.prev;
            h.prev = k;
            t1.next = k;
            t2.prev = h;
        }
        public void sort_list()
        {
            elem temp = new elem();
            elem h = head.next;
            while (h != tail)
            { 
                temp = h.next;
                while ((h != tail.prev) && (h.data > temp.data))
                    swap(h, h.next);
                h = temp;
            }
        }
        public void red_elem(elem h)
        {
            Console.WriteLine("Введите новые данные через enter");
            bool g = true;
            while (g)
            {
                try
                {
                    h.data = Convert.ToInt32(Console.ReadLine());
                    h.name = Console.ReadLine();
                    g = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод");
                }
            }
        }
    }
    class Program

    {
        public static void Main(string[] args)
        {
            int a;
            list asd = new list();
            Console.WriteLine("Введите количество элементов в списке");
            a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                asd.add_elem(0, 0);
            }
            a = 1;
            int g;
            while (a != 0)
            {
                Console.WriteLine("Выберите одну из следующих операций для работы со списоком: \n" +
                     "1. добавить элемент в конец\n" +
                     "2. добавление элемента в конкретное место \n" +
                     "3. Найти элемент\n" +
                     "4. Редактировать элемент\n" +
                     "5. вывести весь список\n" +
                     "6. сортировать по ключю\n" +
                    "0.выйти\n");
                bool z=true;
                while (z)
                {
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                        z = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверный ввод");
                    }
                }


                switch (a)
                {
                    case 1:
                        asd.add_elem(0, 0);
                        break;
                    case 2:
                        Console.WriteLine("Введите номер элемента : ");
                        g = Convert.ToInt32(Console.ReadLine());
                        asd.add_elem(g, 1);
                        break;
                    case 3:
                        Console.WriteLine("Введите номер элемента : ");
                        g = Convert.ToInt32(Console.ReadLine());
                        if (asd.find_elem(g) == asd.nul)
                            Console.WriteLine("такого элемента нет");
                        else
                            asd.print(asd.find_elem(g));
                        break;
                    case 4:
                        Console.WriteLine("Введите номер элемента : ");
                        g = Convert.ToInt32(Console.ReadLine());
                        asd.red_elem(asd.find_elem(g));
                        break;
                    case 5:
                        asd.print_all();
                        break;
                    case 6:
                        asd.sort_list();
                        break;

                }



            }

        }
    }
}
