// Controllers/ProjectsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Data;
using aspnet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ProjectsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var projects = await _context.Projects
            .Include(p => p.User)
            .Include(p => p.Client)
            .ToListAsync();
        return View(projects);
    }

    public IActionResult Create()
    {
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Username");
        ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProjectId,UserId,ClientId,Name,Description,DueDate")] Project project)
    {
        if (ModelState.IsValid)
        {
            _context.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Username", project.UserId);
        ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name", project.ClientId);
        return View(project);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Username", project.UserId);
        ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name", project.ClientId);
        return View(project);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ProjectId,UserId,ClientId,Name,Description,DueDate")] Project project)
    {
        if (id != project.ProjectId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(project);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(project.ProjectId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Username", project.UserId);
        ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name", project.ClientId);
        return View(project);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var project = await _context.Projects
            .Include(p => p.User)
            .Include(p => p.Client)
            .FirstOrDefaultAsync(m => m.ProjectId == id);
        if (project == null)
        {
            return NotFound();
        }

        return View(project);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProjectExists(int id)
    {
        return _context.Projects.Any(e => e.ProjectId == id);
    }
}
