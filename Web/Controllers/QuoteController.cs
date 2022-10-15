using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class QuoteController:Controller
{
    private readonly IQuoteService _quoteService;

    public QuoteController(IQuoteService departmentService)
    {
        _quoteService = departmentService;
    }
    
    public async Task<IActionResult> Index()
    {
        //return list of departments 
        var quotes = await _quoteService.GetQuotes();
        return View(quotes);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        var emptyQuote = new AddQuoteDto();
        return View(emptyQuote);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddQuoteDto addQuoteDto)
    {
        if (ModelState.IsValid == false)
        {
            return View(addQuoteDto);
        }
        await _quoteService.AddQuote(addQuoteDto);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var quote = await _quoteService.GetQuoteById(id);
        return View(quote);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateQuoteDto updateQuoteDto)
    {
        if (ModelState.IsValid == false)
        {
            return View(updateQuoteDto);
        }
        await _quoteService.UpdateQuote(updateQuoteDto);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _quoteService.DeleteDepartment(id);
        return RedirectToAction("Index");
    }
    
    
   
}