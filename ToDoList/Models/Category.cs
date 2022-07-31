
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    public Category()
    {
      this.JoinEntities = new HashSet<CategoryItem>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CategoryItem> JoinEntities { get; set; }
  }
}




// using System.Collections.Generic;

// namespace ToDoList.Models
// {
//       public class Category
//     {
//         public Category()
//         {
//             this.Items = new HashSet<Item>();
//         }

//         public int CategoryId { get; set; }
//         public string Name { get; set; }
//         public virtual ICollection<Item> Items { get; set; }
//     }
// }