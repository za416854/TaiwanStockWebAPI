using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiwanMarketController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TaiwanStockGet()
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
        //[HttpPost]
        //public async Task<IActionResult> Post()
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            string apiUrl = "https://openapi.twse.com.tw/v1/exchangeReport/MI_INDEX";

        //            // 準備 POST 請求的內容
        //            HttpContent content = new StringContent("", Encoding.UTF8, "application/json");

        //            // 發送 POST 請求並取得回應
        //            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string responseBody = await response.Content.ReadAsStringAsync();
        //                // 在這裡處理回應資料，例如將其轉換為物件或回傳給前端
        //                return Ok(responseBody);
        //            }
        //            else
        //            {
        //                // API 呼叫失敗，返回錯誤訊息或其他處理
        //                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
