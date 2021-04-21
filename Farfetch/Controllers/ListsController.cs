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
    [Route("api/WishLists")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        DB db = new DB();

        private readonly FarfetchContext _context;

        public ListsController(FarfetchContext context)
        {
            _context = context;
        }

        // GET: api/WishLists/5/Itens
        [HttpGet("{WishId}/Itens")]
        public async Task<ActionResult<IEnumerable<Item>>> GetList(int WishId)
        {
            List<Item> l = new List<Item>();

            SqlConnection connection = db.connect();

            String sql = "SELECT * " +
                         " FROM Itens" +
                         " JOIN List" +
                         " ON Itens.ItemId = List.ItemId" +
                         " JOIN WishLists" +
                         " ON WishLists.WishId = List.WishId WHERE WishLists.WIshId = " + WishId;
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new Item
                {
                    ItemId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Material = reader.GetString(2),
                    BrandName = reader.GetString(3),
                    Designer = reader.GetString(4),
                    Color = reader.GetString(5),
                    Season = reader.GetString(6)
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

        // GET: api/WishLists/5/Itens/5
        [HttpGet("{WishId}/Itens/{ItemId}")]
        public async Task<ActionResult<Item>> GetList(int WishId, int ItemId)
        {
            SqlConnection connection = db.connect();

            String sql = "SELECT * " +
                         " FROM Itens" +
                         " JOIN List" +
                         " ON Itens.ItemId = List.ItemId" +
                         " JOIN WishLists" +
                         " ON WishLists.WishId = List.WishId WHERE WishLists.WishId = " + WishId + 
                         " AND Itens.ItemId = " + ItemId;
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                var item = new Item
                {
                    ItemId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Material = reader.GetString(2),
                    BrandName = reader.GetString(3),
                    Designer = reader.GetString(4),
                    Color = reader.GetString(5),
                    Season = reader.GetString(6)
                };
                connection.Close();

                return item;
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/WishLists/5/Itens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{WishId}/Itens/{ItemId}")]
        public async Task<IActionResult> PutList(int WishId, int ItemId)
        {
            return BadRequest();
        } */

        // POST: api/WishLists/5/Itens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{WishId}/Itens/{ItemId}")]
        public async Task<ActionResult<Item>> PostList(int WishId, int ItemId)
        {
            SqlConnection connection = db.connect();

            String sql = "INSERT INTO List VALUES (" + ItemId + "," + WishId + ")";
                         
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
                return BadRequest();
            }
        }

        // DELETE: api/WishLists/5/Itens/5
        [HttpDelete("{WishId}/Itens/{ItemId}")]
        public async Task<IActionResult> DeleteList(int WishId, int ItemId)
        {
            SqlConnection connection = db.connect();

            String sql = "DELETE FROM List WHERE ItemId = " + ItemId + " AND WishID = " + WishId;

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
                return BadRequest();
            }
        }

    }

}
