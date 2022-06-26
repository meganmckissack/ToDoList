using System;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Models
{
  public class Programm
  {
    static void Main()
    {
      List<Item> ToDos = new List<Item>{ };

      Item item1 = new Item(" ");
      Item item2 = new Item(" ");

      // List<Item> result = Item.GetAll();
      // ToDos.Add(item1);
      // ToDos.Add(item2);
      Console.WriteLine("Welcome to the To Do List");

      //Console.WriteLine(item1.Description); 


      Console.WriteLine("Would you like to add an item to your list of view your list? Add/View");
      string userAdd = Console.ReadLine();
      
      Console.WriteLine("Would you like to view your list? Add/view");
      string userView = Console.ReadLine();

       bool add = userAdd == "add";

       bool view = userView == "view";

      if (add) 
      {
        Add();
      } else if (view)
      {
        View();
      }

      void Add()
      {
        Console.WriteLine("Enter an item to your to do list");
        item1.Description = Console.ReadLine();
        //Console.WriteLine(item1.Description); 
        ToDos.Add(item1);

        Console.WriteLine("Enter another item to your to do list");
        item2.Description = Console.ReadLine();
        //Console.WriteLine(item2.Description); 
        ToDos.Add(item2);
      }

      void View()
      {
        foreach (Item item in ToDos)
        {
          Console.WriteLine("Todo List item " + item.Description);
        } 
      }


      // if (userAddView == "Add") {
      //   Console.WriteLine("Enter an item to your to do list");
      //   item1.Description = Console.ReadLine();
      //   //Console.WriteLine(item1.Description); 
      //   ToDos.Add(item1);

      //   Console.WriteLine("Enter another item to your to do list");
      //   item2.Description = Console.ReadLine();
      //   //Console.WriteLine(item2.Description); 
      //   ToDos.Add(item2);

      // } else if (userAddView == "View") {
        // foreach (Item list in ToDos) {
        // Console.WriteLine(ToDos);
        // }

        //List<Item> result = Item.GetAll();
       // Console.WriteLine(result);
          // Console.WriteLine("----------------------");
          // Console.WriteLine(List<Item>.Description);
        //Console.WriteLine(result.Description);

        // foreach (Item item in ToDos)
        // {
        //   Console.WriteLine("----------------------");
        //   Console.WriteLine(item.Description);
          
        // }
      

      //Console.WriteLine(result);

        // foreach (Item list in ListOfItems) {
        //   Console.WriteLine(Item.list.GetAll());
        // }

      // foreach (Item item in ToDos)
      //   {
      //     Console.WriteLine("Todo List item " + item.Description);
          
      //   }
      
    }
  }
}