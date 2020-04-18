using System;
using System.Collections.Generic;
using System.Linq;


namespace ListsAndMoreLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //Use System.Linq for all the requirements.IE.Don't use a for/foreach loop to manipulate the users list.

            //1.Display to the console, all the passwords that are "hello".Hint: Where
            
            var passwordQuery = from Models.User user in users
                                where user.Password == "hello"
                                select user;
       
            foreach (Models.User pass in passwordQuery)
            {
                Console.WriteLine(pass.Password);
            }
            Console.ReadKey();

            //2.Delete any passwords that are the lower - cased version of their Name. Do not just look for "steve".It has to be data - driven.Hint: Remove or RemoveAll

            var complexityQuery = from Models.User user in users
                                  where user.Password == user.Name.ToLower()
                                  select user;

            foreach (Models.User pass in complexityQuery)
            {
                Console.WriteLine("ok we're deleting {0} because it's not complex", pass.Password);
                pass.Password = ""; //or could maybe use: var findNonComplex = users.RemoveAll(x => x.Password == x.Name.ToLower()) (outside the foreach statement);
                Console.WriteLine("The new password is: {0}", pass.Password);
            }
            Console.ReadKey();

            //3.Delete the first User that has the password "hello".Hint: First or FirstOrDefault

            var findFirstHello = users.Cast<Models.User>().First(t => t.Password == "hello");
            var removeFirstHello = users.Remove(users.Cast<Models.User>().First(t => t.Password == "hello"));

            Console.WriteLine("first password hello is: {0}", findFirstHello.Password);
            Console.WriteLine("removed: {0}", removeFirstHello);

            //4.Display to the console the remaining users with their Name and Password.

            Console.WriteLine("");
            Console.WriteLine("Login list: ");
            Console.WriteLine("");

            foreach (var user in users)
            {
                Console.WriteLine(user.Name + ":" + user.Password);
            }
            Console.ReadKey();

        }
    }
}
