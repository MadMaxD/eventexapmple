using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEx
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("В формате dd/mm/yyyy:");
            //DateTime cuureTime = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine(cuureTime.ToString("dd.MM.yyyy"));
            //var pErArrayList = new List<Person>();
            //pErArrayList.Add(new Person("a", 1, Convert.ToDateTime("20/11/1993")));
            //pErArrayList.Add(new Person("b", 2, Convert.ToDateTime("30/09/1983")));
            //pErArrayList.Add(new Person("c", 3, Convert.ToDateTime("10/11/1973")));
            //pErArrayList.Add(new Person("d", 4, Convert.ToDateTime("20/06/1976")));
            //pErArrayList.Add(new Person("f", 5, Convert.ToDateTime("20/02/1950")));
            //pErArrayList.Add(new Person("g", 6, Convert.ToDateTime("19/03/1958")));
            //pErArrayList.Add(new Person("h", 7, Convert.ToDateTime("18/05/1962")));
            //pErArrayList.Add(new Person("j", 8, Convert.ToDateTime("11/12/1978")));
            //pErArrayList.Add(new Person("k", 9, Convert.ToDateTime("09/01/1988")));

            //Person goodPerson=pErArrayList.Find(s => s.birthDay == cuureTime);

            //foreach (Person o in pErArrayList)
            //{
            //    o.fstrdata(o.birthDay);
            //    Console.WriteLine(o.Age);
            //}
            BirthdayBoy birthdayBoy = new BirthdayBoy("Yeah", Convert.ToDateTime("22/11/1963"));
            Guest g1 = new Guest(birthdayBoy);
            Guest g2 = new Guest(birthdayBoy);
            Guest g3 = new Guest(birthdayBoy);
            Guest g4 = new Guest(birthdayBoy);
            Guest g5 = new Guest(birthdayBoy);
            Guest g6 = new Guest(birthdayBoy);
            Guest g7 = new Guest(birthdayBoy);
            Guest g8 = new Guest(birthdayBoy);
            Guest g9 = new Guest(birthdayBoy);
            Guest g10 = new Guest(birthdayBoy);

            birthdayBoy.MyDay(Convert.ToDateTime("22/11/1963"));
            Console.ReadKey();
        }
    }


    public abstract class Entity
    {
        public abstract void rt();
    }

    public class Person : Entity, ICloneable
    {
        public static int Count;
        public string Name;
        public string P;
        //public Person[] Child = new Person[5];
        public Person(string name, int i, DateTime birthDay)
        {
            this.birthDay = birthDay;
            Age = DateTime.Now.Day - birthDay.Day >= 0 && DateTime.Now.Month - birthDay.Month >= 0
                ? DateTime.Now.Year - birthDay.Year
                : DateTime.Now.Year - birthDay.Year - 1;
            Name = name;
            Count = Count + 1;
            P = Enum.GetName(typeof (Professional), i);
        }

        public Person()
        {
        }

        public DateTime birthDay { get; set; }
        public int Age { get; set; }


        //private static Random gen = new Random();

        //static DateTime RandomDay()
        //{
        //    DateTime start = new DateTime(1950, 1, 1);
        //    DateTime end = new DateTime(2000,1,1);
        //    int range = (end - start).Days;
        //    return start.AddDays(gen.Next(range));
        //}


        //public string BDateString = BDate.ToString("dd-MM-yyyy");


        //public Person this[int i]
        //{
        //    get { return Child[i]; }
        //    set { Child[i] = value; }
        //}

        public object Clone()
        {
            var a = new Person();
            a.Name = Name;
            a.P = P;
            //a.Child = Child;
            a.Age = Age;
            Count += 1;
            return a;
        }


        public override void rt()
        {
            Console.WriteLine("Hello!");
        }

        public object CloneT()
        {
            Count += 1;
            return MemberwiseClone();
        }

        public virtual void Learn()
        {
        }
    }

    public static class util
    {
        public static void Rename(this Person a, string s)
        {
            a.Name = s;
        }

        public static void ChaAge(this Person a, int i)
        {
            a.Age = i;
        }

        public static void fstrdata(this Person a, DateTime time)
        {
            Console.WriteLine(time.ToString("dd/MM/yyyy"));
        }
    }

    public enum Professional
    {
        Doctor = 1,
        Driver = 2,
        Head = 3
    }

    public interface IA
    {
        void f();
    }

    public interface IB
    {
        void f1();
    }


    public sealed class Student : Person, IA, IB
    {
        public void f()
        {
            Console.WriteLine("f");
        }

        public void f1()
        {
            Console.WriteLine("f1");
        }

        public override void Learn()
        {
            base.Learn();
            Console.WriteLine("Учиться!");
        }
    }

    public delegate void BirthDay(DateTime timeTime);

    public class BirthdayBoy : Person
    {
        public new event BirthDay birthDay;

        public BirthdayBoy(string name, DateTime time)
        {
            Name = name;
        }

        public void MyDay(DateTime time)
        {
            if (birthDay != null)
            {
                birthDay(time);
                Console.WriteLine("У меня день рождение {0}. Будет {1} гостей, подарят {2} подарков и {3} денег",
                    time.ToString("dd/MM/yyyy"), Guest.countGuest, Guest.countGift, Guest.sumMoney);
            }
        }
    }

    public class Guest : Person
    {
        private BirthdayBoy BirthdayBoy;

        public static int countGuest;
        public static int countGift;
        public static int sumMoney;
        


        public Guest(BirthdayBoy boy)
        {
            BirthdayBoy = boy;
            BirthdayBoy.birthDay += GoHandler;
        }


        public void GoHandler(DateTime time)
        {
            Random random = new Random();
            if (random.NextDouble() > 0.5)
            {
                countGuest++;
                
                if (random.NextDouble() > 0.5)
                {
                    countGift++;
                    //Console.WriteLine("Я {0} пойду {1} на ДР к {2} и подарю подарок", Name, time.ToString("dd/MM/yyyy"), BirthdayBoy.Name);
                }
                else
                {

                    int Money = random.Next(500, 10000);
                    sumMoney += Money;
                    // Console.WriteLine("Я {0} пойду {1} на ДР к {2} и подарю {3}", Name, time.ToString("dd/MM/yyyy"), BirthdayBoy.Name, Money);
                }
            }
            
        }
    }

    //public class AR : Student { 
    //}
}