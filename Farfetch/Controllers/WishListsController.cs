using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Farfetch.Models;
using System.Data.SqlClient;

namespace Farfetch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListsController : ControllerBase
    {
        DB db = new DB();

        private readonly FarfetchContext _context;

        public WishListsController(FarfetchContext context)
        {
            _context = context;
        }

        // GET: api/WishLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishList>>> GetWishList()
        {
            List<WishList> l = new List<WishList>();

            SqlConnection connection = db.connect();

            String sql = "SELECT * FROM WishLists";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new WishList
                {
                    WishId = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                l.Add(item);
            }
            connection.Close();
            if (l.Count > 0)
            {
                return l;
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/WishLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WishList>> GetWishList(int id)
        {
            SqlConnection connection = db.connect();

            String sql = "SELECT * FROM WishLists WHERE WishId=" + id;
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                var item = new WishList
                {
                    WishId = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                connection.Close();
                return item;
            }
            else
            {
                connection.Close();
                return NotFound();
            }
        }

        // PUT: api/WishLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutWishList(WishList wishList)
        {
            SqlConnection connection = db.connect();

            String sql = "UPDATE WishLists SET Name = '" + wishList.Name + "' WHERE WishId=" + wishList.WishId;
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            try
            {
                command.ExecuteReader();
                connection.Close();
                return Ok();
            }
            catch
            {
                connection.Close();
                return NotFound();
            }
        }

        // POST: api/WishLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WishList>> PostWishList(WishList wishList)
        {
            SqlConnection connection = db.connect();

            String sql = "INSERT INTO WishLists (Name) VALUES ('" + wishList.Name + "' )";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            try
            {
                command.ExecuteReader();
                connection.Close();
                return CreatedAtAction(nameof(GetWishList), new { id = wishList.WishId }, wishList);
            }
            catch
            {
                connection.Close();
                return BadRequest();
            }
        }

        // DELETE: api/WishLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishList(int id)
        {
            SqlConnection connection = db.connect();

            String sql1 = "DELETE FROM List WHERE WishID = " + id + "; " +
                          "DELETE FROM WishLists WHERE WishId=" + id;

            SqlCommand command1 = new SqlCommand(sql1, connection);
            connection.Open();
            try
            {
                command1.ExecuteReader();

                connection.Close();
                return NoContent();

            }
            catch
            {
                connection.Close();
                return NotFound();
            }
        }
    }
}
