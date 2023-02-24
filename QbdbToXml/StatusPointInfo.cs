using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.UniSim.Operations.Toolkit.Utilities.Shared_Toolkit_and_Interface_classes.ScadaAdapter
{
    public class StatusPointInfo
    {
        public int WordOffset { get; set; }
        public string ItemName { get; set; }   // TagName
        public string UdspParentPointNameAndParameter { get; set; } // What tag and parameter in the parent block does this represent 
        public ChannelType PeerType { get; set; }
        public float PV { get; set; }
        public float OutputSource { get; set; }
        public float OutputDestination { get; set; }
        public int ModeSource { get; set; }
        public int ModeDestination { get; set; }
        public int AlarmAck { get; set; }
        public string StateDescription { get; set; }
        public bool ReversePV1 { get; set; }
        public bool ReversePV2 { get; set; }
        public bool ReversePV3 { get; set; }
        public bool ReverseOP1 { get; set; }
        public bool ReverseOP2 { get; set; }
        public bool ReverseOP3 { get; set; }
        public bool ReverseMode { get; set; }
        public bool NonConsecutivePV { get; set; }
        public bool NonConsecutiveOP { get; set; }
        public int PVStartBit { get; set; }
        public int OPSourceStartBit { get; set; }
        public int OPDestinationStartBit { get; set; }
        public int ModeSourceStartBit { get; set; }
        public int ModeDestinationStartBit { get; set; }
        public bool[] Target { get; set; }                  // dim to 4
        public int NumberOfInputs { get; set; }
        public int NumberOfOutputs { get; set; }
        public int PulseLength { get; set; }                // sEE PDF FOR ui DISPLAY
        public bool Pulsed { get; set; }
        public int PhysicalSMNode { get; set; }
        public float PreviousOutputDestination { get; set; }
        public float PreviousModeDestination { get; set; }
        public bool PVSourceBit1 { get; set; }
        public bool PVSourceBit2 { get; set; }
        public bool PVSourceBit3 { get; set; }
        public bool OutputSourceBit1 { get; set; }
        public bool OutputSourceBit2 { get; set; }
        public bool OutputSourceBit3 { get; set; }
        public bool OutputDestinationBit1 { get; set; }
        public bool OutputDestinationBit2 { get; set; }
        public bool OutputDestinationBit3 { get; set; }
        public string PVSourceName1 { get; set; }
        public string PVSourceName2 { get; set; }
        public string PVSourceName3 { get; set; }
        public string OutputSourceName1 { get; set; }
        public string OutputSourceName2 { get; set; }
        public string OutputSourceName3 { get; set; }
        public string OutputDestinationName1 { get; set; }
        public string OutputDestinationName2 { get; set; }
        public string OutputDestinationName3 { get; set; }
        public string ModeSourceName1 { get; set; }
        public string ModeDestinationName1 { get; set; }
        public string AlarmAckDestinationName1 { get; set; }
        public float EULow { get; set; }
        public float EUHigh { get; set; }
        public string[] PARAM { get; set; } // 200 element array UDSP
        public int NumberOfParams { get; set; }
        public string PointDescription { get; set; }
        public string Area { get; set; }
        public bool ActionAlgo68 { get; set; }
        //PackedBooleanPVSource
        //PackedBooleanOPSource
        //PackedBooleanOPDest
        //PackedBooleanAlarmAck
        public StatusPointInfo()
        {
            WordOffset = 0;
            ItemName = string.Empty;   // TagName
            PeerType = ChannelType.GENERIC;
            PV = 9.9F;
            OutputSource = 0.0F;
            OutputDestination = 0.0F;
            ModeSource = 0;
            ModeDestination = 0;
            AlarmAck = 0;
            StateDescription = string.Empty;
            ReversePV1 = false;
            ReversePV2 = false;
            ReversePV3 = false;
            ReverseOP1 = false;
            ReverseOP2 = false;
            ReverseOP3 = false;
            ReverseMode = false;
            NonConsecutivePV = false;
            NonConsecutiveOP = false;
            PVStartBit = 0;
            OPSourceStartBit = 0;
            OPDestinationStartBit = 0;
            ModeSourceStartBit = 0;
            ModeDestinationStartBit = 0;
            Target = new bool[3];                  // dim to 4
            NumberOfInputs = 1;
            NumberOfOutputs = 1;
            PulseLength = 0;                // sEE PDF FOR ui DISPLAY
            Pulsed = false;
            PhysicalSMNode = 0;
            PreviousOutputDestination = 0.0F;
            PreviousModeDestination = 0.0F;
            PVSourceBit1 = false;
            PVSourceBit2 = false;
            PVSourceBit3 = false;
            OutputSourceBit1 = false;
            OutputSourceBit2 = false;
            OutputSourceBit3 = false;
            OutputDestinationBit1 = false;
            OutputDestinationBit2 = false;
            OutputDestinationBit3 = false;
            PVSourceName1 = string.Empty;
            PVSourceName2 = string.Empty;
            PVSourceName3 = string.Empty;
            OutputSourceName1 = string.Empty;
            OutputSourceName2 = string.Empty;
            OutputSourceName3 = string.Empty;
            OutputDestinationName1 = string.Empty;
            OutputDestinationName2 = string.Empty;
            OutputDestinationName3 = string.Empty;
            ModeSourceName1 = string.Empty;
            ModeDestinationName1 = string.Empty;
            AlarmAckDestinationName1 = string.Empty;
            EULow = 0.0F;
            EUHigh = 100.0F;
            PARAM = new string[200]; // 200 element array UDSP
            NumberOfParams = 0;
            PointDescription = string.Empty;
            ActionAlgo68 = false;
        }
    }
}
