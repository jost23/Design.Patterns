using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// http://www.c-sharpcorner.com/UploadFile/b1df45/proxy-design-pattern-using-C-Sharp/

namespace Design.Patterns {

    // ISubject interface
    public interface IPrice {
        int GetPrice();
    }

    // Concreate implementation of the ISubject
    public class GoldPrice : IPrice {
        public int GetPrice() {
            Random rnd = new Random();
            return rnd.Next(999, 99999);
        }
    }

    // Proxy class
    public class ProxyAPI {
        IPrice _iPrice;     //refrerence of the ISubject

        public int GetCurrentGoldPrice(bool getPrice) {
            if (getPrice) {
                _iPrice = new GoldPrice();  // get the actual resource
                return _iPrice.GetPrice();
            } else {
                return 0;
            }

        }
    }
}
