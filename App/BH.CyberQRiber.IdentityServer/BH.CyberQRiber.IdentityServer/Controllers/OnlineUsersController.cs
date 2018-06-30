using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BH.CyberQRiber.IdentityServer.Entities;
using BH.CyberQRiber.IdentityServer.Models;

namespace BH.CyberQRiber.IdentityServer.Controllers
{
    [Produces("application/json")]
    [Route("api/OnlineUsers")]
    public class OnlineUsersController : Controller
    {
        private readonly BHCyberQRiberIdentityServerContext _context;

        public OnlineUsersController(BHCyberQRiberIdentityServerContext context)
        {
            _context = context;
        }

        // GET: api/OnlineUsers
        [HttpGet]
        public IEnumerable<OnlineUser> GetOnlineUser()
        {
            return _context.OnlineUser;
        }

        // GET: api/OnlineUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOnlineUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var onlineUser = await _context.OnlineUser.SingleOrDefaultAsync(m => m.Id == id);

            if (onlineUser == null)
            {
                return NotFound();
            }

            return Ok(onlineUser);
        }

        // PUT: api/OnlineUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnlineUser([FromRoute] int id, [FromBody] OnlineUser onlineUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != onlineUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(onlineUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnlineUserExists(id))
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

        // POST: api/OnlineUsers
        [HttpPost]
        public async Task<IActionResult> PostOnlineUser([FromBody] OnlineUser onlineUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OnlineUser.Add(onlineUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnlineUser", new { id = onlineUser.Id }, onlineUser);
        }

        // DELETE: api/OnlineUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnlineUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var onlineUser = await _context.OnlineUser.SingleOrDefaultAsync(m => m.Id == id);
            if (onlineUser == null)
            {
                return NotFound();
            }

            _context.OnlineUser.Remove(onlineUser);
            await _context.SaveChangesAsync();

            return Ok(onlineUser);
        }

        private bool OnlineUserExists(int id)
        {
            return _context.OnlineUser.Any(e => e.Id == id);
        }
    }
}