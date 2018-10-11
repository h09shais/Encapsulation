using System;

namespace Encapsulation
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderValidator _validator;
        private readonly IOrderShipper _shipper;

        public OrderProcessor(IOrderValidator validator, IOrderShipper shipper)
        {
            this._validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this._shipper = shipper ?? throw new ArgumentNullException(nameof(shipper));
        }

        public void Process(Order order)
        {
            if (this._validator.Validate(order))
            {
                this._shipper.Ship(order);
            }
        }
    }
}
