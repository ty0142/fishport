
using FishPort.Data;
using FishPort.Models;
using FishPort.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class PortsController : Controller
{
    private readonly ApplicationDbContext _context;

    public PortsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PORTS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Ports.ToListAsync());
    }

    // GET: PORTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        //// ビュー側の表示用として、各マスターの「名称（Name）」をViewDataに格納
        //ViewData["AreaId"] = new SelectList(await _context.Areas.ToListAsync(), "Id", "AreaName");

        if (id == null)
        {
            return NotFound();
        }

        var currentPortId = id.Value;

        var portDetails = await _context.Ports
              .Where(p => p.Id == currentPortId)
              .Join(
              _context.Areas,
              port => port.AreaId,
              area => area.Id,
              (port, area) => new { port, area }
              )
              .Join(
              _context.Prefectures,
              x => x.area.PrefectureId,
              prefecture => prefecture.Id,
              (x, prefecture) => new PortDetailsViewModel
              {
                  Port = x.port,
                  AreaName = x.area.AreaName,
                  PrefectureName = prefecture.PrefectureName
              }
              )
              .FirstOrDefaultAsync();

        var commentList = await _context.Comments
              .Where(c => c.PortId == currentPortId)
              .Join(
              _context.Users,
              comment => comment.UserId,
              user => user.Id,
              (comment, user) => new CommentViewModel
              {
                  Id = comment.Id,
                  NickName = user.NickName,
                  CommentText = comment.CommentText,
                  CreatedAt = comment.CreatedAt
              }
              )
             .OrderByDescending(c => c.CreatedAt)
             .ToListAsync();
        
        if (portDetails == null)
        {
            return NotFound();
        }

        portDetails.Comments = commentList;
        return View(portDetails);
    }

    // GET: PORTS/Create
    public async Task<IActionResult> Create()
    {
        // 都道府県一覧
        ViewData["PrefectureId"] = new SelectList(
            await _context.Prefectures
                .OrderBy(p => p.PrefectureName)
                .ToListAsync(),
            "Id",
            "PrefectureName");

        // Area一覧（JavaScript用）
        ViewBag.Areas = await _context.Areas
            .OrderBy(a => a.AreaName)
            .Select(a => new
            {
                a.Id,
                a.AreaName,
                a.PrefectureId
            })
            .ToListAsync();

        return View();
    }

    // POST: PORTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("AreaId,PortName,Address,Description")] Port port)
    {
        
        if (ModelState.IsValid)
        {
            _context.Add(port);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // ビュー側の表示用として、各マスターの「名称（Name）」をViewDataに格納
        ViewData["AreaId"] = new SelectList(
            await _context.Areas
            .OrderBy(a => a.AreaName)
            .ToListAsync(),
            "Id",
            "AreaName",
            port.AreaId);

        return View(port);
    }

    // GET: PORTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var port = await _context.Ports.FindAsync(id);
        if (port == null)
        {
            return NotFound();
        }
        // 現在のAreaを取得
        var area = await _context.Areas.FindAsync(port.AreaId);

        // 現在のPrefectureId
        var prefectureId = area?.PrefectureId;

        // 都道府県一覧
        ViewData["PrefectureId"] = new SelectList(
            await _context.Prefectures
                .OrderBy(p => p.PrefectureName)
                .ToListAsync(),
            "Id",
            "PrefectureName",
            prefectureId);

        // Area一覧（JavaScript用）
        ViewBag.Areas = await _context.Areas
            .OrderBy(a => a.AreaName)
            .Select(a => new
            {
                a.Id,
                a.AreaName,
                a.PrefectureId
            })
            .ToListAsync();

        return View(port);
    }

    // POST: PORTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("AreaId,PortName,Address,Description")] Port port)
    {
        if (id != port.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(port);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortExists(port.Id))
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
        return View(port);
    }

    // GET: PORTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var port = await _context.Ports
            .FirstOrDefaultAsync(m => m.Id == id);
        if (port == null)
        {
            return NotFound();
        }

        return View(port);
    }

    // POST: PORTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var port = await _context.Ports.FindAsync(id);
        if (port != null)
        {
            _context.Ports.Remove(port);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PortExists(int? id)
    {
        return _context.Ports.Any(e => e.Id == id);
    }


}
