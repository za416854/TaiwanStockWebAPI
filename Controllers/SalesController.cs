using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Data; 

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SalesController : Controller
    {
        private readonly TestWebAPIContext _context;
        private readonly string connectionString;
        public SalesController(TestWebAPIContext context)
        {
            _context = context;
            connectionString = "Server=localhost\\sqlexpress;Database=MeetingRoomDB;Trusted_Connection=True;TrustServerCertificate=True;User ID=KRIS\\z4168;Password=";
        }

        //GET: Sales
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var sales = await _context.Sales.ToListAsync();
        //    //var res = sales.Where(x => x.Price < 8000);
        //    return Ok(sales);
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Sales> sales = new List<Sales>();
            string query = "SELECT * FROM Sales";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Sales sale = new()
                        {
                            SaleId = (int)reader["sale_id"],
                            ProductId = (int)reader["product_id"],
                            Year = (int)reader["year"],
                            Quantity = (int)reader["quantity"],
                            Price = (int)reader["price"]
                        };

                        sales.Add(sale);
                    }
                }
            }

            return Ok(sales);
        }
        [HttpGet]
        public async Task<IActionResult> GetStockTaiwanGet()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https:" + "//openapi.twse.com.tw/v1/exchangeReport/MI_INDEX";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        // 在這裡處理回應資料，例如將其轉換為物件或回傳給前端
                        return Ok(responseBody);
                    }
                    else
                    {
                        // API 呼叫失敗，返回錯誤訊息或其他處理
                        return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    List<Sales> sales = new List<Sales>();

        //    string query = "SELECT * FROM Sales";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(query, connection);

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Sales sale = new Sales
        //                {
        //                    SaleId = (int)reader["sale_id"],
        //                    ProductId = (int)reader["product_id"],
        //                    Year = (int)reader["year"],
        //                    Quantity = (int)reader["quantity"],
        //                    Price = (int)reader["price"]
        //                };

        //                sales.Add(sale);
        //            }
        //        }
        //    }

        //    return Ok(sales);
        //}

        // POST api/sales
        [HttpPost]
        public async Task<IActionResult> Post(Sales sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = sale.SaleId }, sale);
        }

        // PUT api/sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Sales sale)
        {
            if (id != sale.SaleId)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
