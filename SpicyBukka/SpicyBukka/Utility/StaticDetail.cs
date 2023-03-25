using SpicyBukka.Models;
using System;

namespace SpicyBukka.Utility
{
    public static class StaticDetail
    {
        public const string DefaultFoodImage = "default_food.png";

        public const string ManagerUser = "Manager";
        public const string KitchenUser = "Kitchen";
        public const string FrontDeskUser = "FrontDesk";
        public const string CustomerEndUser = "Customer";

        public const string ssShoppingCartCount = "StaticDetail.ssShoppigCartCount";
        public const string ssCouponCode = "ssCouponCode";

        public const string StatusSubmitted = "Submitted";
        public const string StatusInProcess = "Being Prepared";
        public const string StatusReady = "Ready for Pickup";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";


        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayyIndex = 0;
            bool inside = false;



            for(int i = 0; i < source.Length; i++)
            {
                char let = source[i];

                if(let == '<')
                {
                    inside = true;
                    continue;
                }

                if (let == '>')
                {
                    inside = false;
                    continue;
                }

                if (!inside)
                {
                    array[arrayyIndex] = let;
                    arrayyIndex++;
                }
            }

            return new string(array, 0, arrayyIndex);

        }


        public static double DiscountedPrice(Coupon couponFromDb, double OriginalOrderHeaderTotal)
        {
            if(couponFromDb == null)
            {
                return OriginalOrderHeaderTotal;
            }
            else
            {
                if(couponFromDb.MinimumAmount > OriginalOrderHeaderTotal)
                {
                    return OriginalOrderHeaderTotal;
                }
                else
                {
                    if(Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Dollar)
                    {
                        return Math.Round(OriginalOrderHeaderTotal - couponFromDb.Discount, 2);
                    }

                    return Math.Round(OriginalOrderHeaderTotal - (OriginalOrderHeaderTotal * couponFromDb.Discount/100), 2);
                }

            }
            
            return OriginalOrderHeaderTotal;

        }
    }
}
