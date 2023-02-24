using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Honeywell.UniSim.Operations.Toolkit.Utilities.Shared_Toolkit_and_Interface_classes.ScadaAdapter
{
    public class AnalogPointInfo
    {
        public int WordOffset { get; set; }
        public string ItemName { get; set; }
        public string UdspParentPointNameAndParameter { get; set; } // What tag and parameter in the parent block does this represent 
        public ChannelType PeerType { get; set; }
        public float PVSource { get; set; }
        public float PVDestination { get; set; }
        public float RawPVSource { get; set; }
        public float RawPVDestination { get; set; }
        public string PVSourceName { get; set; }
        public string PVDestinationName { get; set; }
        public bool IsPVSourceScaled { get; set; }
        public bool IsPVDestinationScaled { get; set; }
        public ScadaDataFormat PVSourceDataFormat { get; set; }
        public ScadaDataFormat PVDestinationDataFormat { get; set; }
        public float SetpointSource { get; set; }
        public float SetpointDestination { get; set; }
        public float RawSetpointSource { get; set; }
        public float RawSetpointDestination { get; set; }
        public string SetpointSourceName { get; set; }
        public string SetpointDestinationName { get; set; }
        public bool IsSetpointSourceScaled { get; set; }
        public bool IsSetpointDestinationScaled { get; set; }
        public ScadaDataFormat SetpointSourceDataFormat { get; set; }
        public ScadaDataFormat SetpointDestinationDataFormat { get; set; }
        public float OutputSource { get; set; }
        public float OutputDestination { get; set; }
        public float RawOutputSource { get; set; }
        public float RawOutputDestination { get; set; }
        public string OutputSourceName { get; set; }
        public string OutputDestinationName { get; set; }
        public bool IsOutpointSourceScaled { get; set; }
        public bool IsOutpointDestinationScaled { get; set; }
        public ScadaDataFormat OutputSourceDataFormat { get; set; }
        public ScadaDataFormat OutputDestinationDataFormat { get; set; }
        public float Aux1Source { get; set; }
        public float Aux1Destination { get; set; }
        public float RawAux1Source { get; set; }
        public float RawAux1Destination { get; set; }
        public string Aux1SourceName { get; set; }
        public string Aux1DestinationName { get; set; }
        public bool IsAux1SourceScaled { get; set; }
        public bool IsAux1DestinationScaled { get; set; }
        public ScadaDataFormat Aux1SourceDataFormat { get; set; }
        public ScadaDataFormat Aux1DestinationDataFormat { get; set; }
        public float Aux2Source { get; set; }
        public float Aux2Destination { get; set; }
        public float RawAux2Source { get; set; }
        public float RawAux2Destination { get; set; }
        public string Aux2SourceName { get; set; }
        public string Aux2DestinationName { get; set; }
        public bool IsAux2SourceScaled { get; set; }
        public bool IsAux2DestinationScaled { get; set; }
        public ScadaDataFormat Aux2SourceDataFormat { get; set; }
        public ScadaDataFormat Aux2DestinationDataFormat { get; set; }
        public float Aux3Source { get; set; }
        public float Aux3Destination { get; set; }
        public float RawAux3Source { get; set; }
        public float RawAux3Destination { get; set; }
        public string Aux3SourceName { get; set; }
        public string Aux3DestinationName { get; set; }
        public bool IsAux3SourceScaled { get; set; }
        public bool IsAux3DestinationScaled { get; set; }
        public ScadaDataFormat Aux3SourceDataFormat { get; set; }
        public ScadaDataFormat Aux3DestinationDataFormat { get; set; }
        public float Aux4Source { get; set; }
        public float Aux4Destination { get; set; }
        public float RawAux4Source { get; set; }
        public float RawAux4Destination { get; set; }
        public string Aux4SourceName { get; set; }
        public string Aux4DestinationName { get; set; }
        public bool IsAux4SourceScaled { get; set; }
        public bool IsAux4DestinationScaled { get; set; }
        public ScadaDataFormat Aux4SourceDataFormat { get; set; }
        public ScadaDataFormat Aux4DestinationDataFormat { get; set; }
        public int ModeSource { get; set; }
        public int ModeDestination { get; set; }
        public string ModeSourceName { get; set; }
        public string ModeDestinationName { get; set; }
        public int ModeSourceBitOffset { get; set; }
        public int ModeDestinationBitOffset { get; set; }
        public int PhysicalSMNode { get; set; }
        public float PreviousPVDestination { get; set; }
        public float PreviousSetpointDestination { get; set; }
        public float PreviousOutputDestination { get; set; }
        public float PreviousAux1Destination { get; set; }
        public float PreviousAux2Destination { get; set; }
        public float PreviousAux3Destination { get; set; }
        public float PreviousAux4Destination { get; set; }
        public int PreviousModeDestination { get; set; }
        public bool Reverse { get; set; }   // Reverse/direct OP
        public float EULow { get; set; }
        public float EUHigh { get; set; }
        public float SetpointLow { get; set; }
        public float SetpointHigh { get; set; }
        public float OutputLow { get; set; }
        public float OutputHigh { get; set; }
        public string PointDescription { get; set; }
        public string EUDescription { get; set; }
        public string[] PARAM { get; set; } // 200 element array UDSP
        public int NumberOfParams { get; set; }
        public string Parent { get; set; }
        public string EntName { get; set; }
        public string Area { get; set; }
        public bool PVAlgo7 { get; set; }
        public bool ActionAlgo68 { get; set; }
        public string NormalMode { get; set; }  // This will be treated as an enum for display
        public bool ForcePV { get; set; }   // Transient

        public AnalogPointInfo()
        {
         WordOffset = 0;
         ItemName = string.Empty;
          PeerType = ChannelType.GENERIC;
         PVSource = 0.0F;
         PVDestination = 0.0F;
         RawPVSource = 0.0F;
         RawPVDestination = 0.0F;
         PVSourceName = string.Empty;
         PVDestinationName = string.Empty;
         IsPVSourceScaled = false;
         IsPVDestinationScaled = false;
         PVSourceDataFormat = ScadaDataFormat.None;
         PVDestinationDataFormat = ScadaDataFormat.None;
         SetpointSource = 0.0F;
         SetpointDestination = 0.0F;
         RawSetpointSource = 0.0F;
         RawSetpointDestination = 0.0F;
         SetpointSourceName = string.Empty;
         SetpointDestinationName = string.Empty;
         IsSetpointSourceScaled = false;
         IsSetpointDestinationScaled = false;
         SetpointSourceDataFormat = ScadaDataFormat.None;
         SetpointDestinationDataFormat = ScadaDataFormat.None;
         OutputSource = 0.0F;
         OutputDestination = 0.0F;
         RawOutputSource = 0.0F;
         RawOutputDestination = 0.0F;
         OutputSourceName = string.Empty;
         OutputDestinationName = string.Empty;
         IsOutpointSourceScaled = false;
         IsOutpointDestinationScaled = false;
         OutputSourceDataFormat = ScadaDataFormat.None;
         OutputDestinationDataFormat = ScadaDataFormat.None;
         Aux1Source = 0.0F;
         Aux1Destination = 0.0F;
         RawAux1Source = 0.0F;
         RawAux1Destination = 0.0F;
         Aux1SourceName = string.Empty;
         Aux1DestinationName = string.Empty;
         IsAux1SourceScaled = false;
         IsAux1DestinationScaled = false;
         Aux1SourceDataFormat = ScadaDataFormat.None;
         Aux1DestinationDataFormat = ScadaDataFormat.None;
         Aux2Source = 0.0F;
         Aux2Destination = 0.0F;
         RawAux2Source = 0.0F;
         RawAux2Destination = 0.0F;
         Aux2SourceName = string.Empty;
         Aux2DestinationName = string.Empty;
         IsAux2SourceScaled = false;
         IsAux2DestinationScaled = false;
         Aux2SourceDataFormat = ScadaDataFormat.None;
         Aux2DestinationDataFormat = ScadaDataFormat.None;
         Aux3Source = 0.0F;
         Aux3Destination = 0.0F;
         RawAux3Source = 0.0F;
         RawAux3Destination = 0.0F;
         Aux3SourceName = string.Empty;
         Aux3DestinationName = string.Empty;
         IsAux3SourceScaled = false;
         IsAux3DestinationScaled = false;
         Aux3SourceDataFormat = ScadaDataFormat.None;
         Aux3DestinationDataFormat = ScadaDataFormat.None;
         Aux4Source = 0.0F;
         Aux4Destination = 0.0F;
         RawAux4Source = 0.0F;
         RawAux4Destination = 0.0F;
         Aux4SourceName = string.Empty;
         Aux4DestinationName = string.Empty;
         IsAux4SourceScaled = false;
         IsAux4DestinationScaled = false;
         Aux4SourceDataFormat = ScadaDataFormat.None;
         Aux4DestinationDataFormat = ScadaDataFormat.None;
         ModeSource = 0;
         ModeDestination = 0;
         ModeSourceName = string.Empty;
         ModeDestinationName = string.Empty;
         ModeSourceBitOffset = 0;
         ModeDestinationBitOffset = 0;
         PhysicalSMNode = 0;
         PreviousPVDestination = 0.0F;
         PreviousSetpointDestination = 0.0F;
         PreviousOutputDestination = 0.0F;
         PreviousAux1Destination = 0.0F;
         PreviousAux2Destination = 0.0F;
         PreviousAux3Destination = 0.0F;
         PreviousAux4Destination = 0.0F;
         PreviousModeDestination = 0;
         Reverse = false;   // Reverse/direct OP
         EULow = 0.0F;
         EUHigh = 100.0F;
         SetpointLow = 0.0F;
         SetpointHigh = 100.0F;
         OutputLow = 0.0F;
         OutputHigh = 100.0F;
         PointDescription = string.Empty;
         EUDescription = string.Empty;
         PARAM = new string[200]; // 200 element array UDSP
         for (var index = 0; index < PARAM.Length; index++) PARAM[index] = String.Empty;
         NumberOfParams = 0;
         Parent = string.Empty;
         EntName = string.Empty;
         Area = string.Empty;
         PVAlgo7 = false;
         ActionAlgo68 = false;
         NormalMode = "MAN";  // This will be treated as an enum for display
         ForcePV = false;   // Transient
    }

    public void HandleScaling()
        {
            if (IsPVSourceScaled) PVSource = ScadaDataFormatter.Scale(RawPVSource, EUHigh, EULow, PVSourceDataFormat);
            else PVSource = RawPVSource;

            if (IsPVSourceScaled) PVSource = ScadaDataFormatter.Scale(RawPVSource, EUHigh, EULow, PVSourceDataFormat);
            else PVSource = RawPVSource;

            if (IsSetpointSourceScaled) SetpointSource = ScadaDataFormatter.Scale(RawSetpointSource, SetpointHigh, SetpointLow, SetpointSourceDataFormat);
            else SetpointSource = RawSetpointSource;

            if (IsOutpointSourceScaled) OutputSource = ScadaDataFormatter.Scale(RawOutputSource, OutputHigh, OutputLow, OutputSourceDataFormat);
            else OutputSource = RawOutputSource;

            if (IsAux1SourceScaled) Aux1Source = ScadaDataFormatter.Scale(RawAux1Source, EUHigh, EULow, Aux1SourceDataFormat);
            else Aux1Source = RawAux1Source;

            if (IsAux2SourceScaled) Aux2Source = ScadaDataFormatter.Scale(RawAux2Source, EUHigh, EULow, Aux2SourceDataFormat);
            else Aux2Source = RawAux2Source;

            if (IsAux3SourceScaled) Aux3Source = ScadaDataFormatter.Scale(RawAux3Source, EUHigh, EULow, Aux3SourceDataFormat);
            else Aux3Source = RawAux3Source;

            if (IsAux4SourceScaled) Aux4Source = ScadaDataFormatter.Scale(RawAux4Source, EUHigh, EULow, Aux4SourceDataFormat);
            else Aux4Source = RawAux4Source;
        }

        public void HandleDescaling()
        {
            if (IsPVDestinationScaled) RawPVDestination = ScadaDataFormatter.Scale(PVDestination, EUHigh, EULow, PVDestinationDataFormat);
            else RawPVDestination = PVDestination;

            if (IsSetpointDestinationScaled) RawSetpointDestination = ScadaDataFormatter.Scale(SetpointDestination, SetpointHigh, SetpointLow, SetpointDestinationDataFormat);
            else RawSetpointDestination = SetpointDestination;

            if (IsOutpointDestinationScaled) RawOutputDestination = ScadaDataFormatter.Scale(OutputDestination, OutputHigh, OutputLow, OutputDestinationDataFormat);
            else RawOutputDestination = OutputDestination;

            if (IsAux1DestinationScaled) RawAux1Destination = ScadaDataFormatter.Scale(Aux1Destination, EUHigh, EULow, Aux1DestinationDataFormat);
            else RawAux1Destination = Aux1Destination;

            if (IsAux2DestinationScaled) RawAux2Destination = ScadaDataFormatter.Scale(Aux2Destination, EUHigh, EULow, Aux2DestinationDataFormat);
            else RawAux2Destination = Aux2Destination;

            if (IsAux3DestinationScaled) RawAux3Destination = ScadaDataFormatter.Scale(Aux3Destination, EUHigh, EULow, Aux3DestinationDataFormat);
            else RawAux3Destination = Aux3Destination;

            if (IsAux4DestinationScaled) RawAux4Destination = ScadaDataFormatter.Scale(Aux4Destination, EUHigh, EULow, Aux4DestinationDataFormat);
            else RawAux4Destination = Aux4Destination;
        }
    }
}
