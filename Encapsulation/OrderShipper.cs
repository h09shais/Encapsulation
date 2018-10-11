using System;

namespace Encapsulation
{
    //Lazy order shipper
    public class OrderShipper: IOrderShipper
    {
        private OrderShipper _shipper;
        public void Ship(Order order)
        {
            if (this._shipper == null)
            {
                this._shipper = new OrderShipper();
            }
            this._shipper.Ship(order);
        }
    }
}
