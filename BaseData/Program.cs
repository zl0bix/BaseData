using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData
{
    internal class Program
    {
        static void Main(string[] args)
        {
/*
            Basedate basedate = new Basedate();
            basedate.CreateBasedate();
            basedate.SortByLvl();
            basedate.Show();*/
        /*
                    Задача 1
        У нас есть список всех преступников.
        В преступнике есть поля: ФИО, заключен ли он под стражу, рост, вес, национальность.
        Вашей программой будут пользоваться детективы.
        У детектива запрашиваются данные(рост, вес, национальность), и детективу выводятся все
        преступники, которые подходят под эти параметры,
        но уже заключенные под стражу выводиться не должны.
        */
        DataBase dataBase = new DataBase();
            dataBase.CreateDB();
            dataBase.ShowDB();
            Console.WriteLine("Max - " + dataBase.MaxHeight()+"\nMin - " + dataBase.MinHeigt());
            dataBase.SortBy();
            dataBase.ShowSort();
        }
    }


    class Criminal
    {
        public string Name;
        public int Height;
        public int Weight;
        public char Nationality;
        public bool IsArest;

        Random rnd = new Random();

        public Criminal(string name, int height, int weight, char nationality, bool isArest)
        {
            Name = name;
            Height = height;
            Weight = weight;
            Nationality = nationality;
            IsArest = isArest;
        }

        public Criminal() { }

        public string GetName()//97-122
        {
            int tmp = rnd.Next(3, 9);
            string strTmp = "";

            while(tmp != 0)
            {
                strTmp += (char)rnd.Next(97, 123);
                tmp--;
            }
            return strTmp;
        }
        public int GetHeight() { return rnd.Next(150,201); }
        public int GetWeight() { return rnd.Next(60,121); }

        public char GetNationality() { return (char)rnd.Next(97, 123); }

        public bool GetIsArest() { return Convert.ToBoolean(rnd.Next(0,2)); }

    }
    class DataBase
    {
        List<Criminal> _crim = new List<Criminal>();
        List<Criminal> _sort = new List<Criminal>();

        Random rnd = new Random();
        public void CreateDB()
        {
            Criminal criminal = new Criminal();

            for (int i = 0; i < rnd.Next(15, 31); i++)
            {
                _crim.Add(new Criminal(criminal.GetName(), criminal.GetHeight(), criminal.GetWeight(), criminal.GetNationality(), criminal.GetIsArest()));
            }
        }

        public void SortByHeight()
        {
            _sort = (_crim.Where(crim => crim.Height >= MinHeigt() + 30).Select(crim => crim).ToList());
        }

        public void SortBy()
        {
            _sort = (_crim.Where(crim => crim.IsArest == true).Select(crim => crim).ToList());
        }

        public void ShowSort()
        {
            Console.WriteLine("\n\n\n\n\nКоличество элементов в листе - " + _sort.Count);
            foreach(Criminal crim in _sort)
            {
                Console.WriteLine(crim.Name + "\t\t" + crim.Height + "\t" + crim.Weight + "\t" + crim.Nationality + "\t" + Foo(crim.IsArest));
            }
        }

        private char Foo(bool b)
        {
            if (b)
                return '+';
            return '-';
        }
        public int MaxHeight()
        {
            return _crim.Max(x => x.Height);
        }

        public int MinHeigt()
        {
            return _crim.Min(y => y.Height);
        }
                        
    

        public void ShowDB()
        {
            Console.WriteLine("Количество элементов в листе - " + _crim.Count);
            foreach (Criminal it in _crim)
            {
                Console.WriteLine("ФИО - " + it.Name + "\tРост - " + it.Height + "\tВес - " + it.Weight + "\tНациональность - " + it.Nationality + "\tПод арестом ? " + Foo(it.IsArest));
            }
        }

    }

    class Plaer
    {
        public string Name { get; private set; }
        public int Lvl {  get; private set; }

        public Plaer(string name, int lvl)
        {
            Name = name;
            Lvl = lvl;
        }
        public Plaer() { }
    }

    class Basedate
    {
        private List<Plaer> _plaers = new List<Plaer>();
        public void CreateBasedate()
        {
            Random random = new Random();
            
            int index = random.Next(1000,10001);

            Console.WriteLine("Общее колличество играков - " + index);

            for (int i = 0; i < index; i++)
            {
                if (i < 10)
                    _plaers.Add(new Plaer("name000" + i, random.Next(1, 101)));

                else if(i<100 && i > 9)
                    _plaers.Add(new Plaer("name00" + i, random.Next(1, 101)));

                else if (i < 1000 && i > 100)
                    _plaers.Add(new Plaer("name0" + i, random.Next(1, 101)));

                else 
                    _plaers.Add(new Plaer("name" + i, random.Next(1, 101)));

            }

        }
        public void Show()
        {
            foreach (Plaer it in _plaers)
            {
                Console.WriteLine($"{it.Name}\t\t\t{it.Lvl}");
            } 
        }

        public void SortByLvl()
        { 
            _plaers = _plaers.Where(plaer => plaer.Lvl >= 95).Select(plaer=>plaer).ToList();
            //_plaers = _plaers.OrderBy(plaer=> plaer).ToList();


            /*Plaer plaer = new Plaer();

            _plaers = (from Plaer in  _plaers where Plaer.Lvl > 90 select Plaer).ToList();
            var _plaers2 = from Plaer plaer in _plaers were plaer.Lvl > 80 select plaer;

            _plaers = _plaers.Where(plaer=> plaer.Name.StartsWith("name000")).ToList();*/
        }
    }

}
