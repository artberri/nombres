using System;

namespace Names.Web.EventHandlers
{
    public class YearChangeHandler
    {
        public event EventHandler<int> YearChanged;

        public void ChangeTo(int yearId)
        {
            OnYearChanged(yearId);
        }

        protected virtual void OnYearChanged(int yearId)
        {
            EventHandler<int> handler = YearChanged;
            if (handler != null)
            {
                handler(this, yearId);
            }
        }
    }
}
