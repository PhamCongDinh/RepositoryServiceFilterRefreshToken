using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoryPattern.Models;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMoMosController : ControllerBase
    {
        private IHttpClientFactory _http;
        public PaymentMoMosController(IHttpClientFactory http)
        {
            this._http = http;
        }

        private async Task<string> ExecPostRequestAsync(string url, string data)
        {
            var httpClient = _http.CreateClient();
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        [Route("on_checkout")]
        public async Task<IActionResult> OnCheckout([FromBody] Taikhoan req)
        {
            // Check if the user already exists
            // Implement the logic to check if the user exists in your database

            var endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
            var partnerCode = "MOMOBKUN20180529";
            var accessKey = "klm05TvNBzhg7h7j";
            var secretKey = "at67qH6mk8w5Y1nAyMoYKMWACiEi2bsa";

            // Map the request data to your model properties
            var username = req.TenTk;
            var email = req.Email;
            var password = req.MatKhau;
            var orderInfo = "Thanh toán tài khoản";
            var amount = "10000";

            var orderId = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            var redirectUrl = "http://127.0.0.1:5500/authen/thanks.html";
            var ipnUrl = "http://127.0.0.1:5500/authen/thanks.html";
            var extraData = new { username, password, email };

            var jsonExtraData = JsonConvert.SerializeObject(extraData);
            var requestId = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            var requestType = "payWithATM";

            var rawHash = $"accessKey={accessKey}&amount={amount}&extraData={jsonExtraData}&ipnUrl={ipnUrl}&orderId={orderId}&orderInfo={orderInfo}&partnerCode={partnerCode}&redirectUrl={redirectUrl}&requestId={requestId}&requestType={requestType}";
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                var signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawHash));
                var signature = BitConverter.ToString(signatureBytes).Replace("-", "").ToLower();

                var data = new
                {
                    partnerCode,
                    partnerName = "Test",
                    storeId = "MomoTestStore",
                    requestId,
                    amount,
                    orderId,
                    orderInfo,
                    redirectUrl,
                    ipnUrl,
                    lang = "vi",
                    extraData = jsonExtraData,
                    requestType,
                    signature
                };

                var requestData = JsonConvert.SerializeObject(data);
                var result = await ExecPostRequestAsync(endpoint, requestData);
                var jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);

                if (jsonResult != null && jsonResult.ContainsKey("payUrl"))
                {
                    return Ok(jsonResult["payUrl"]);
                }
                else
                {
                    return StatusCode(500, "Unable to access payment URL");
                }
            }

            
        }
    }
}




