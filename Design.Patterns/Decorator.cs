using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns {

    // Abstract classes
    public abstract class BasePizza {
        protected double myPrice;

        public virtual double GetPrice() {
            return this.myPrice;
        }
    }

    public abstract class ToppingsDecorator : BasePizza {
        protected BasePizza pizza;
        public ToppingsDecorator(BasePizza pizzaToDecorate) {
            this.pizza = pizzaToDecorate;
        }

        public override double GetPrice() {
            return (this.pizza.GetPrice() + this.myPrice);
        }
    }

    // Real classes
    public class Margherita : BasePizza {
        public Margherita() {
            this.myPrice = 6.99;
        }
    }

    public class Gourmet : BasePizza {
        public Gourmet() {
            this.myPrice = 7.49;
        }
    }

    public class ExtraCheeseTopping : ToppingsDecorator {
        public ExtraCheeseTopping(BasePizza pizzaToDecorate)
            : base(pizzaToDecorate) {
            this.myPrice = 0.99;
        }
    }

    public class MushroomTopping : ToppingsDecorator {
        public MushroomTopping(BasePizza pizzaToDecorate)
            : base(pizzaToDecorate) {
            this.myPrice = 1.49;
        }
    }

    public class JalapenoTopping : ToppingsDecorator {
        public JalapenoTopping(BasePizza pizzaToDecorate)
            : base(pizzaToDecorate) {
            this.myPrice = 1.49;
        }
    }


}
