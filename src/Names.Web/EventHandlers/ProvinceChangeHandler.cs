using System;

namespace Names.Web.EventHandlers
{
    public class ProvinceChangeHandler
    {
        public event EventHandler<int> ProvinceChanged;

        public void ChangeTo(int provinceId)
        {
            OnProvinceChanged(provinceId);
        }

        protected virtual void OnProvinceChanged(int provinceId)
        {
            EventHandler<int> handler = ProvinceChanged;
            if (handler != null)
            {
                handler(this, provinceId);
            }
        }
    }
}
