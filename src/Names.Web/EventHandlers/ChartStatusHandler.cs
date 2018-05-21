using System;
using Names.Web.Enums;

namespace Names.Web.EventHandlers
{
    public class ChartStatusHandler
    {
        public event EventHandler<ChartStatusType> ChartStatusChanged;

        public void ChangeTo(ChartStatusType chartStatus)
        {
            OnChartStatusChanged(chartStatus);
        }

        protected virtual void OnChartStatusChanged(ChartStatusType chartStatus)
        {
            EventHandler<ChartStatusType> handler = ChartStatusChanged;
            if (handler != null)
            {
                handler(this, chartStatus);
            }
        }
    }
}
