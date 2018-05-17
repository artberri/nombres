using System;
using Names.Web.Enums;

namespace Names.Web.EventHandlers
{
    public class QuantityTypeChangeHandler
    {
        public event EventHandler<QuantityType> QuantityTypeChanged;

        public void ChangeTo(QuantityType quantityType)
        {
            OnQuantityTypeChanged(quantityType);
        }

        protected virtual void OnQuantityTypeChanged(QuantityType quantityType)
        {
            EventHandler<QuantityType> handler = QuantityTypeChanged;
            if (handler != null)
            {
                handler(this, quantityType);
            }
        }
    }
}
