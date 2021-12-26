using Microsoft.AspNetCore.Mvc;
using webapp.Data;
using webapp.Models;

namespace webapp.Controllers;

public class CategoryController: Controller
{
    private readonly BookDbContext _ctx;

    public CategoryController(BookDbContext context)
    {
        _ctx = context;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> categoriesList = _ctx.Categories;
        return View(categoriesList);
    }
    //Get
    public IActionResult Create()
    {
        return View();
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if(category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name.");
        }
        if(ModelState.IsValid)
        {
            _ctx.Categories.Add(category);
            _ctx.SaveChanges();
            TempData["success"] = "Category created successfully";

            return RedirectToAction("Index", "Category");
        }
        return View(category);
    }
    //edit
    public IActionResult Edit(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }
        var dbObj = _ctx.Categories.Find(id);
        if(dbObj == null)
        {
            return NotFound();
        }

        return View(dbObj);
    }

    //Edit post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if(category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name.");
        }
        if(ModelState.IsValid)
        {
            _ctx.Categories.Update(category);
            _ctx.SaveChanges();
            TempData["success"] = "Category edited successfully";
            return RedirectToAction("Index", "Category");
        }
        return View(category);
    }

    //delete
    public IActionResult Delete(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }
        var dbObj = _ctx.Categories.Find(id);
        if(dbObj == null)
        {
            return NotFound();
        }

        return View(dbObj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var dbObj = _ctx.Categories.Find(id);
        if(dbObj == null)
        {
            return NotFound();
        }

        _ctx.Categories.Remove(dbObj);
        _ctx.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index", "Category");
    }
}