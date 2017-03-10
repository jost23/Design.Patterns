using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns {

    public class Address {
        public string CountryCode { get; set; }
    }

    public class Order {
        public decimal TotalCosts { get; set; }
        public decimal WeightInKG { get; set; }
        public string CourierTrackingId { get; set; }
        public Address DispatchAddress { get; set; }
    }


    public interface IShippingCourier {
        string GenerateConsignmentLabelFor(Address adress);
    }

    public class RoyalMail : IShippingCourier {
        public string GenerateConsignmentLabelFor(Address address) {
            return "RMXXXX-XXXX-XXXX";
        }
    }

    public class DHL : IShippingCourier {
        public string GenerateConsignmentLabelFor(Address address) {
            return "DHL-XXXX-XXXX-XXXX";
        }
    }

    public static class UKShippingCourierFactory {
        public static IShippingCourier CreateShippingCourier(Order order) {
            if((order.TotalCosts > 100) || (order.WeightInKG > 5)) {
                return new DHL();
            } else {
                return new RoyalMail();
            }
        }
    }

    public class OrderService {
        public void Dispatch(Order order) {
            IShippingCourier shippingCourier = UKShippingCourierFactory.CreateShippingCourier(order);
            order.CourierTrackingId = shippingCourier.GenerateConsignmentLabelFor(order.DispatchAddress);
        }
    } 
}

