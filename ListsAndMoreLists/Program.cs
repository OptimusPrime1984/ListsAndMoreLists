using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsAndMoreLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize a new instance of user list
            List<User> users = new List<User>();
            users.Add(new User { Name = "Dave", Password = "hello" });
            users.Add(new User { Name = "Steve", Password = "steve" });
            users.Add(new User { Name = "Lisa", Password = "hello" });
            

            //Display to the console, all the passwords that are "hello". Hint: Where
            List<User> helloList = (from x in users
                            where x.Password == "hello"
                            select x).ToList();
            
            Console.WriteLine("The Following User has password as \"hello\"");
            helloList.AsParallel().ForAll(s => Console.WriteLine(s.Name));

            //Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve". It has to be data-driven. Hint: Remove
            users.RemoveAll(x => x.Password == x.Name.ToLower());
            
            
            //Delete the first User that has the password "hello". Hint: First or FirstOrDefault
            var firstHello = (from x in users
                                    where x.Password == "hello"
                                    select x).FirstOrDefault();
            if(firstHello != null)
            {
                users.Remove(firstHello);
            }

            //Display to the console the remaining users with their Name and Password.
            Console.WriteLine("Here are remaining users");
            users.AsParallel().ForAll(s => Console.WriteLine(s.Name));

        }
        
    }
}
