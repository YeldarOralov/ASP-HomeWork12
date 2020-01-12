using BraintreeHttp;
using HW12.Models;
using PayPal.Core;
using PayPal.v1.Payments;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW12.Services
{
    public class PayPalService
    {
        private const string APPROVAL_URL = "approval_url";

        public async Task<string> CreateInvoice(Basket basket)
        {
            var environment = new SandboxEnvironment("AUcBbHNGlkF8pMud0Imkq_lEkvMeN2ebB3_fDS7-NIfvndr5x7maf6ol2WczTBEG5d4qoXHckCMqID5u", "EH8ICa3Sh-oEy_DXHDAzRpl8pjLWD2bphuGoUJeO39U-AqYr3ycFSi_icSjfz6lgz4O28VEuH91Ps33K");
            var client = new PayPalHttpClient(environment);

            int totalPrice = 0;
            foreach (var product in basket.Products.ToList())
            {
                totalPrice += product.Cost;
            }

            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        ItemList = new ItemList(),
                        Amount = new Amount()
                        {
                            Total = totalPrice.ToString(),
                            Currency = "USD"
                        }
                    }

                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = "https://example.com/cancel",
                    ReturnUrl = "https://example.com/return"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                HttpResponse response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();
                return result.Links.FirstOrDefault(link => link.Rel == APPROVAL_URL).Href;
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
                return null;
            }
        }
    }
}
