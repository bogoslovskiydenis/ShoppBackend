using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppBackend.Model;

namespace ShoppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureImgsController : ControllerBase
    {
        private readonly MyShoppingAppContext _context;

        public FeatureImgsController(MyShoppingAppContext context)
        {
            _context = context;
        }

        // GET: api/FeatureImgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeatureImg>>> GetFeatureImgs()
        {
            return await _context.FeatureImgs.ToListAsync();
        }

        // GET: api/FeatureImgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeatureImg>> GetFeatureImg(int id)
        {
            var featureImg = await _context.FeatureImgs.FindAsync(id);

            if (featureImg == null)
            {
                return NotFound();
            }

            return featureImg;
        }

        // PUT: api/FeatureImgs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeatureImg(int id, FeatureImg featureImg)
        {
            if (id != featureImg.FeatureImgId)
            {
                return BadRequest();
            }

            _context.Entry(featureImg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureImgExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FeatureImgs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeatureImg>> PostFeatureImg(FeatureImg featureImg)
        {
            _context.FeatureImgs.Add(featureImg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeatureImg", new { id = featureImg.FeatureImgId }, featureImg);
        }

        // DELETE: api/FeatureImgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureImg(int id)
        {
            var featureImg = await _context.FeatureImgs.FindAsync(id);
            if (featureImg == null)
            {
                return NotFound();
            }

            _context.FeatureImgs.Remove(featureImg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeatureImgExists(int id)
        {
            return _context.FeatureImgs.Any(e => e.FeatureImgId == id);
        }
    }
}
