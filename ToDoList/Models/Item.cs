using System;
using System.Collections.Generic;  

namespace ToDoList.Models
{
  public class Item
  {
    // properties, constructors, methods, go here

    public string Description { get; set; }
    private static List<Item> _instances = new List<Item>{};
    //public string GetAll { get; }

    public Item(string description) 
    {
      Description = description;
      _instances.Add(this);

    }

    public static List<Item> GetAll()
      {
        return _instances;
      }
    
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}