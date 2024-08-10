using System.Collections.Generic;

namespace GlowHarmonySkin.Models
{
    public class OrderSummaryViewModel
    {
        public UserInformation UserInformation { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
    }
}
