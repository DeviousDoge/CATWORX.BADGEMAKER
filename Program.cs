using System;
using System.Collections.Generic;


namespace CatWorx.BadgeMaker
{
  class Program
  {
 async static Task Main(string[] args)
{
  // This is our employee-getting code now
bool confirmed = false;
string Key;

    Console.Write("Hey! Who are you?");
    Key = Console.ReadLine();
    Console.WriteLine("Hey, " + Key + " welcome to CatWorx!");

    ConsoleKey response;

do 
{
  Console.Write("Use the API to randomly generate Employees? [y/n]");
        response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
        if (response != ConsoleKey.Enter)
            Console.WriteLine();
} while (response != ConsoleKey.Y && response != ConsoleKey.N);

    confirmed = response == ConsoleKey.Y; 
    if (!confirmed)
    {
      List<Employee> employees = await PeopleFetcher.GetEmployees();
      Util.PrintEmployees(employees);
      Util.MakeCSV(employees);
      await Util.MakeBadges(employees);
    } 
    else 
    {
      List<Employee> employees = await PeopleFetcher.GetFromApi();
      Util.PrintEmployees(employees);
      Util.MakeCSV(employees);
      await Util.MakeBadges(employees);
    }
  // List<Employee> employees = PeopleFetcher.GetEmployees();

  // List<Employee> employees = await PeopleFetcher.GetFromApi();
  // Util.PrintEmployees(employees);
  // Util.MakeCSV(employees);
  // await Util.MakeBadges(employees);
}



  }
}