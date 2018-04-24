using System;

namespace AnonObjectsFiddle
{
    class Program
    {

        static void Main(string[] args)
        {

            List<Customer> mylist = new List<Customer>()
            {
               new Customer("Buller"),
               new Customer("Fido")
            };

            var newlist = mylist.Select(c => new
            {
                Name = "New" + c.Name
            });
            Console.WriteLine(newlist.FirstOrDefault().Name);

            dynamic obj = new // dynamic eller var
            {
                Name = "JohnDoe",
                Age = 5
            };
            Console.WriteLine(obj.Name + " er " + obj.Age);

            dynamic gimmeObj(string name, uint age = 1000) // return anonymous object
            {
                return new
                {
                    name,
                    age,
                    mylist
                };
            }
            Console.WriteLine(gimmeObj("JohnDoe").age); // 1000 - intellisense not working
            dynamic myObj = gimmeObj("JohnDoe");
            Console.WriteLine(myObj.mylist[0].Name.Length); // 6 (Buller)

            string getname = myObj.name;
            Console.WriteLine(getname); // JohnDoe

        }

    }
    public class Customer
    {

        public string Name { get; set; }
        public Customer(string name)
        {
            Name = name;
        }

    }
}
