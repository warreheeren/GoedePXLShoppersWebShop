using System.Threading.Tasks;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public interface IPaymentRepository
    {
        Task<bool> Pay(Pay pay);

    }
}
