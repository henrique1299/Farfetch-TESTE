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
        public SqlConnection connect()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "farfetchdbserver.database.windows.net";
                builder.UserID = "henrique";
                builder.Password = "admin1299@";
                builder.InitialCatalog = "Farfetch_db";

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                return connection;

            }
            catch
            {
                return null;
            }
        }
        public ItensController(FarfetchContext context)
        {
            _context = context;
        }

        // GET: api/Itens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItens()
        {
            List<ItemDTO> l = new List<ItemDTO>();

            SqlConnection connection = connect();

            String sql = "SELECT * FROM Itens";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new Item
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Material = reader.GetString(2),
                    BrandName = reader.GetString(3),
                    Designer = reader.GetString(4),
                    Color = reader.GetString(5),
                    Season = reader.GetString(6)
                };
                l.Add(ItemToDTO(item));
            }
            connection.Close();
            return l;
        }

        // GET: api/Itens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItem(int id)
        {
            List<ItemDTO> l = new List<ItemDTO>();

            SqlConnection connection = connect();

            String sql = "SELECT * FROM Itens WHERE ID=" + id;
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                var item = new Item
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Material = reader.GetString(2),
                    BrandName = reader.GetString(3),
                    Designer = reader.GetString(4),
                    Color = reader.GetString(5),
                    Season = reader.GetString(6)
                };
                connection.Close();
                return ItemToDTO(item);
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
        public async Task<IActionResult> PutItem(int id, ItemDTO itemDTO)
        {
            if (id != itemDTO.Id)
            {
                return BadRequest();
            }

            //List<ItemDTO> l = new List<ItemDTO>();

            SqlConnection connection = connect();

            String sql = "UPDATE Itens SET Name = '" + itemDTO.Name + "', Material='" + itemDTO.Material + "', BrandName='" + itemDTO.BrandName + "', Designer='" + itemDTO.Designer + 
                "', Color='" + itemDTO.Color + "', Season='" + itemDTO.Season + "' WHERE ID=" + id;
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                var item = new Item
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Material = reader.GetString(2),
                    BrandName = reader.GetString(3),
                    Designer = reader.GetString(4),
                    Color = reader.GetString(5),
                    Season = reader.GetString(6)
                };
                connection.Close();
                return NoContent();
            }
            else
            {
                connection.Close();
                return NotFound();
            }

        }

        //INSERT
        // POST: api/Itens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> PostItem(ItemDTO itemDTO)
        {
            var item = new Item
            {
                Id = itemDTO.Id,
                Name = itemDTO.Name,
                Material = itemDTO.Material,
                BrandName = itemDTO.BrandName,
                Designer = itemDTO.Designer,
                Color = itemDTO.Color,
                Season = itemDTO.Season,
            };
            SqlConnection connection = connect();

            String sql = "INSERT INTO Itens (Name, Material, BrandName, Designer, Color, Season) VALUES ('" +  itemDTO.Name + "', '" + itemDTO.Material + "', '" + itemDTO.BrandName + "', '" +
                           itemDTO.Designer + "', '" + itemDTO.Color + "', '" + itemDTO.Season + "')";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                connection.Close();
                return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
            }
            else
            {
                connection.Close();
                return NotFound();
            }
        }

        // DELETE: api/Itens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            SqlConnection connection = connect();

            String sql = "DELETE FROM Itens WHERE ID=" + id;
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteReader();
   
            connection.Close();
            return NoContent();
            
        }

        private static ItemDTO ItemToDTO(Item item) => new ItemDTO
        {
            Id = item.Id,
            Name = item.Name,
            Material = item.Material,
            BrandName = item.BrandName,
            Designer = item.Designer,
            Color = item.Color,
            Season = item.Season,

        };

    }
}
