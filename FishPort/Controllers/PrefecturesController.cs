
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishPort.Models;
using FishPort.Data;

public class PrefecturesController : Controller
{
    private readonly ApplicationDbContext _context;

    public PrefecturesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PREFECTURES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Prefectures.ToListAsync());
    }

    // GET: PREFECTURES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var prefecture = await _context.Prefectures
            .FirstOrDefaultAsync(m => m.Id == id);
        if (prefecture == null)
        {
            return NotFound();
        }

        return View(prefecture);
    }

    // GET: PREFECTURES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PREFECTURES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,PrefectureName")] Prefecture prefecture)
    {
        if (ModelState.IsValid)
        {
            _context.Add(prefecture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(prefecture);
    }

    // GET: PREFECTURES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var prefecture = await _context.Prefectures.FindAsync(id);
        if (prefecture == null)
        {
            return NotFound();
        }
        return View(prefecture);
    }

    // POST: PREFECTURES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,PrefectureName")] Prefecture prefecture)
    {
        if (id != prefecture.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(prefecture);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrefectureExists(prefecture.Id))
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
        return View(prefecture);
    }

    // GET: PREFECTURES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var prefecture = await _context.Prefectures
            .FirstOrDefaultAsync(m => m.Id == id);
        if (prefecture == null)
        {
            return NotFound();
        }

        return View(prefecture);
    }

    // POST: PREFECTURES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var prefecture = await _context.Prefectures.FindAsync(id);
        if (prefecture != null)
        {
            _context.Prefectures.Remove(prefecture);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PrefectureExists(int? id)
    {
        return _context.Prefectures.Any(e => e.Id == id);
    }
}
