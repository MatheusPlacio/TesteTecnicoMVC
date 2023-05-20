using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoMVC.Context;
using TesteTecnicoMVC.Models;

public class ConveniosController : Controller
{
    private readonly MyContext _context;

    public ConveniosController(MyContext context)
    {
        _context = context;
    }

    // GET: Convenios
    public async Task<IActionResult> Index()
    {
        var convenios = await _context.Convenios.ToListAsync();
        return View(convenios);
    }

    // GET: Convenios/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Convenios/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Convenio convenio)
    {
        _context.Convenios.Add(convenio);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
