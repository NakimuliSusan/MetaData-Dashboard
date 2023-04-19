using MetaData_ScraperDashboardAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace MetaData_ScraperDashboardAPI.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]
        public class ScraperCountController : ControllerBase
        {
            private readonly JibudocsContext _context; 

            public ScraperCountController(JibudocsContext context)
            {
                _context = context;
            }

            // GET: api/ScraperCount
            [HttpGet("get-count-scraper")]
            public ActionResult<IEnumerable<object>> Get()
            {
                var results = _context.Documents
                    .Join(
                        _context.ScraperBlobStores,
                        d => d.Id,
                        sbs => sbs.DocumentId,
                        (d, sbs) => new { scraper = d.Scraper, ContentType = sbs.FileContentType }
                    )
                    .GroupBy(x => new { x.scraper, x.ContentType })
                    .Select(g => new
                    {
                        Scraper = g.Key.scraper,
                        FileContentType = g.Key.ContentType,
                        Count = g.Count()
                    })
                    .OrderBy(x => x.Scraper)
                    .ToList();

                return Ok(results);
            }

        [HttpGet("lastopened")]
        public async Task<IActionResult> GetLastOpened()
        {
            /* var lastOpened = await _context.Runs

                 .Select(r => new { r.StartTimeUtc, r.Target })
                 .FirstOrDefaultAsync();

             return Ok(lastOpened);*/

            // this method returns the runs when the scraper last opened the target
            var runs = await _context.Runs.ToListAsync();

            if (runs == null || !runs.Any())
            {
                return NotFound();
            }

            return Ok(runs);
        }
    }
    }



