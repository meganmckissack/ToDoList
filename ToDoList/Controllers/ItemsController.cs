using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ToDoList.Controllers
{
  [Authorize]
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public ItemsController(UserManager<ApplicationUser> userManager, ToDoListContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUser = await _userManager.FindByIdAsync(userId);
    var userItems = _db.Items.Where(entry => entry.User.Id == currentUser.Id).ToList();
    return View(userItems);
    }


//     public ActionResult Index()
//     {
//       List<Item> model = _db.Items.Include(item => item.Category).ToList();
//       return View(model);
//     }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Item item, int CategoryId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      item.User = currentUser;
      _db.Items.Add(item);
      _db.SaveChanges();
      if (CategoryId != 0)
      {
        _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

public ActionResult Details(int id)
{
    var thisItem = _db.Items
        .Include(item => item.JoinEntities)
        .ThenInclude(join => join.Category)
        .FirstOrDefault(item => item.ItemId == id);
    return View(thisItem);
}

    public ActionResult Edit(int id)
{
    var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    return View(thisItem);
}

[HttpPost]
public ActionResult Edit(Item item, int CategoryId)
{
  if (CategoryId != 0)
  {
    _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
  }
    _db.Entry(item).State = EntityState.Modified;
    _db.SaveChanges();
    return RedirectToAction("Index");
}

public ActionResult AddCategory(int id)
{
    var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    return View(thisItem);
}

[HttpPost]
public ActionResult AddCategory(Item item, int CategoryId)
{
    if (CategoryId != 0)
    {
      _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
      _db.SaveChanges();
    }
    return RedirectToAction("Index");
}


    public ActionResult Delete(int id)
    {
      var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      _db.Items.Remove(thisItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
public ActionResult DeleteCategory(int joinId)
{
    var joinEntry = _db.CategoryItem.FirstOrDefault(entry => entry.CategoryItemId == joinId);
    _db.CategoryItem.Remove(joinEntry);
    _db.SaveChanges();
    return RedirectToAction("Index");
}
  }
}
















//old style database connection code

// using Microsoft.AspNetCore.Mvc;
// using ToDoList.Models;
// using System.Collections.Generic;

// namespace ToDoList.Controllers
// {
//   public class ItemsController : Controller
//   {

//     [HttpGet("/categories/{categoryId}/items/new")]
//     public ActionResult New(int categoryId)
//     {
//       Category category = Category.Find(categoryId);
//       return View(category);
//     }

//     [HttpPost("/items/delete")]
//     public ActionResult DeleteAll()
//     {
//       Item.ClearAll();
//       return View();
//     }

//     [HttpGet("/categories/{categoryId}/items/{itemId}")]
//     public ActionResult Show(int categoryId, int itemId)
//     {
//       Item item = Item.Find(itemId);
//       Category category = Category.Find(categoryId);
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       model.Add("item", item);
//       model.Add("category", category);
//       return View(model);
//     }
//   }
// }

