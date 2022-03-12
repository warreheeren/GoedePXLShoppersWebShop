using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using PXLPro2022Shoppers07.Models;
using Stripe;

namespace PXLPro2022Shoppers07.Services
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task<bool> Pay(Pay pay)
        {
            var options = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Number = pay.CardNumder,
                    ExpMonth = pay.Month,
                    ExpYear = pay.Year,
                    Cvc = pay.CVC
                },
            };
            var serviceToken = new TokenService();
            var stripeToken = await serviceToken.CreateAsync(options);

            var chargeOptions = new ChargeCreateOptions
            {
                Amount = pay.Amount,
                Currency = "eur",
                Description = "Stripe Test Payment",
                Source = stripeToken.Id
            };

            var chargeService = new ChargeService();
            var charge = await chargeService.CreateAsync(chargeOptions);

            if (charge.Paid)
            {

                return true;
            }

            return false;
        }
    }
}
