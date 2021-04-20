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
    [Route("api/Itens")]
    [ApiController]
    public class ItensController : ControllerBase
    {
        private readonly FarfetchContext _context;
        DB db = new DB();
        public ItensController(FarfetchContext context)
        {
            _context = context;
        }

        // GET: api/Itens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItens()
        {
            List<Item> l = new List<Item>();

            SqlConnection connection = db.connect();

            String sql = "SELECT * FROM Itens";
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

        // GET: api/Itens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            SqlConnection connection = db.connect();

            String sql = "SELECT * FROM Itens WHERE ItemId=" + id;
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
                connection.Close();
                return NotFound();
            }
        }

        //UPDATE
        // PUT: api/Itens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            //List<ItemDTO> l = new List<ItemDTO>();

            SqlConnection connection = db.connect();

            String sql = "UPDATE Itens SET Name = '" + item.Name + "', Material='" + item.Material + "', BrandName='" + item.BrandName + "', Designer='" + item.Designer + 
                "', Color='" + item.Color + "', Season='" + item.Season + "'" + " WHERE ItemId=" + id;
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

        //INSERT
        // POST: api/Itens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            SqlConnection connection = db.connect();

            String sql = "INSERT INTO Itens (Name, Material, BrandName, Designer, Color, Season) VALUES ('" + item.Name + "', '" + item.Material + "', '" + item.BrandName + "', '" +
                           item.Designer + "', '" + item.Color + "', '" + item.Season + "' )";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            try
            {
                command.ExecuteReader();
                connection.Close();
                return CreatedAtAction(nameof(GetItem), new { id = item.ItemId }, item);
            }
            catch
            {
                connection.Close();
                return BadRequest();
            }
        }

        // DELETE: api/Itens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            SqlConnection connection = db.connect();

            String sql1 = "DELETE FROM List WHERE ItemId = " + id + "; " + 
                          "DELETE FROM Itens WHERE ItemId=" + id;

            SqlCommand command1 = new SqlCommand(sql1, connection);

            connection.Open();
            try
            {
                command1.ExecuteReader();

                connection.Close();
                return Ok();
                
            }
            catch
            {
                connection.Close();
                return NotFound();
            }
        }
    }
}
