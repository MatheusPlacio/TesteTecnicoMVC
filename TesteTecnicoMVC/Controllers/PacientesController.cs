using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoMVC.Context;
using TesteTecnicoMVC.Models;
using Microsoft.EntityFrameworkCore;

public class PacientesController : Controller
{
    private readonly MyContext _context;

    public PacientesController(MyContext context)
    {
        _context = context;
    }

    // GET: Pacientes
    public async Task<IActionResult> Index()
    {
        var pacientes = await _context.Pacientes.Include(p => p.Convenio).ToListAsync();
        return View(pacientes);
    }

    public IActionResult AddOrEdit(int id = 0)
    {
        ViewBag.Convenios = new SelectList(_context.Convenios, "ConvenioId", "Nome");

        if (id == 0)
        {
            // Criar um novo paciente
            var paciente = new Paciente();
            return View(paciente);
        }
        else
        {
            // Editar um paciente existente
            var paciente = _context.Pacientes.Include(p => p.Convenio).FirstOrDefault(p => p.PacienteId == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddOrEdit(Paciente paciente)
    {
        ViewBag.Convenios = new SelectList(_context.Convenios, "ConvenioId", "Nome", paciente.ConvenioId);

        if (paciente.PacienteId == 0)
        {
            // Verificar se o CPF já existe
            var existingPaciente = _context.Pacientes.FirstOrDefault(p => p.CPF == paciente.CPF);
            if (existingPaciente != null)
            {
                ModelState.AddModelError("CPF", "O CPF já está cadastrado.");
                return View(paciente);
            }

            paciente.Convenio = _context.Convenios.Find(paciente.ConvenioId);
            await _context.AddAsync(paciente);
        }
        else
        {
            // Verificar se o CPF está sendo alterado para o CPF de outra pessoa
            var existingPaciente = _context.Pacientes.FirstOrDefault(p => p.CPF == paciente.CPF && p.PacienteId != paciente.PacienteId);
            if (existingPaciente != null)
            {
                ModelState.AddModelError("CPF", "O CPF já está cadastrado para outra pessoa.");
                return View(paciente);
            }

            paciente.Convenio = _context.Convenios.Find(paciente.ConvenioId);
            _context.Update(paciente);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
