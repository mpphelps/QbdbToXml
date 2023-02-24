using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.UniSim.Operations.Toolkit.Utilities.Shared_Toolkit_and_Interface_classes.ScadaAdapter
{
    public class AccumulatorPointInfo
    {
        public int WordOffset { get; set; }
        public string ItemName { get; set; }
        public ChannelType PeerType { get; set; }
        public float PVSource { get; set; }
        public float EULow { get; set; }
        public float EUHigh { get; set; }
        public string EUDescription { get; set; }
        public float ScalingFactor { get; set; }
        public float MeterFactor { get; set; }
        public int MeterRollover { get; set; }
        public string PointDescription { get; set; }
        public string Area { get; set; }

        public AccumulatorPointInfo()
        {
            WordOffset = 0;
            ItemName = string.Empty;
            PeerType = ChannelType.GENERIC;
            PVSource = 0.0F;
            EULow = 0.0F;
            EUHigh = 100.0F;
            EUDescription = string.Empty;
            ScalingFactor = 1.0F;
            MeterFactor = 1.0F;
            MeterRollover = 4095;
            PointDescription = string.Empty;
        }
    }
}
