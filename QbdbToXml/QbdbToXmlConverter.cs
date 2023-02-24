using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Honeywell.UniSim.Operations.Toolkit.Utilities.Shared_Toolkit_and_Interface_classes.ScadaAdapter;

namespace QbdbToXml
{
    public class QbdbToXmlConverter
    {
        private Channel _channel = new Channel();
        private readonly string _customerHdwFileName;
        private readonly string _customerPntFileName;
        private readonly string _trainerHdwFileName;
        private readonly string _trainerPntFileName;
        private int _numPackets = 0;
        public QbdbToXmlConverter(string trainerHdwFileName,
            string trainerPntFileName,
            string customerHdwFileName,
            string customerPntFileName
            )
        {
            _trainerHdwFileName = trainerHdwFileName;
            _trainerPntFileName = trainerPntFileName;

            _customerHdwFileName = customerHdwFileName;
            _customerPntFileName = customerPntFileName;
        }
        public bool Convert()
        {
            Parse();
            Serialize();
            return true;
        }

        private void Parse()
        {
            // Parse the trainer files first
            ParseTrainerHdwFileName();
            ParseTrainerPntFileName();

            // Parse the original files from customer for any missing data
            ParseCustomerHdwFileName();
            ParseCustomerPntFileName();

            _numPackets = CalculateNumPackets();
        }

        public void Serialize()
        {
            string fileName = Path.GetDirectoryName(_trainerHdwFileName) + @"\PointInfo.xml";
            var ser = new XmlSerializer(typeof(Channel));
            TextWriter writer = new StreamWriter(fileName);
            ser.Serialize(writer, _channel);
            writer.Close();
        }

        private void ParseTrainerHdwFileName()
        {
            using (var sr = new StreamReader(_trainerHdwFileName))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    if (line.StartsWith("DEF CHN"))
                    {
                        ParseTrainerChannel(line);
                    }
                    else if (line.StartsWith("DEF RTU"))
                    {
                        ParseTrainerController(line);
                    }
                    line = sr.ReadLine();
                }
            }
        }

        private void ParseTrainerChannel(string line)
        {
            var parameters = line.Split(' ');
            foreach (var param in parameters)
            {
                if (param.StartsWith("NAME")) _channel.Name = param.Split('=')[1];
                if (param.StartsWith("MARG")) _channel.Marg = param.Split('=')[1];
                _channel.Number = 1;
            }
        }

        private void ParseTrainerController(string line)
        {
            var controller = new Controller();
            _channel.Controllers.Add(controller);
            var parameters = line.Split(' ');
            foreach (var param in parameters)
            {
                if (param.StartsWith("RTU"))
                {
                    controller.Number = int.Parse(param.Split('.')[1]);
                }
                if (param.StartsWith("NAME"))
                {
                    controller.Name = param.Split('=')[1];
                    switch (controller.Name.Split('-')[0])
                    {
                        case "ANALOG":
                            controller.Type = ControllerType.ANALOG;
                            break;
                        case "STATUS":
                            controller.Type = ControllerType.STATUS;
                            break;
                        case "ACCUM":
                            controller.Type = ControllerType.ACCUM;
                            break;
                    }
                }
            }
        }

        private void ParseTrainerPntFileName()
        {
            using (var sr = new StreamReader(_trainerPntFileName))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    var tokens = line.Split().Where(s => s.Length > 0).ToArray();
                    if (tokens.Length > 0 && tokens[0] == "ADD")
                    {
                        if (tokens[2].StartsWith("ANA")) ParseAnalogPoint(line, sr);
                        if (tokens[2].StartsWith("STA")) ParseStatusPoint(line, sr);
                        if (tokens[2].StartsWith("ACC")) ParseAccumPoint(line, sr);
                    }
                    line = sr.ReadLine();
                }
            }
        }

        private void ParseAnalogPoint(string line, StreamReader sr)
        {
            var point = new AnalogPointInfo();
            bool foundController = false;
            while (line != "&") // & is token for end of point definition
            {
                var tokens = line.Split().Where(s => s.Length > 0).ToArray();
                if (tokens.Length == 0)
                {
                    line = sr.ReadLine();
                    continue; // found a blank line, skip
                }
                switch (tokens[0])
                {
                    case "ADD":
                        // ADD POINTNAME POINTTYPE DESCRIPTION DESCRIPTION DESCRIPTION.....
                        point.ItemName = tokens[1];
                        if (tokens.Length <= 3) break; // point has no description
                        var temp = new StringBuilder();
                        for (int i = 3; i < tokens.Length; i++) // point description starts at index 4
                            temp.Append(tokens[i] + ' ');
                        temp.Remove(temp.Length - 1, 1); // Remove final space
                        point.PointDescription = temp.ToString();
                        break;
                    case "ENTNAME":
                        if (tokens.Length <= 2) break; // Point has no Entity Name Assigned
                        point.EntName = tokens[2];
                        break;
                    case "RANGE":
                        // RANGE POINTNAME EULO EUHI EUDESC
                        point.EULow = int.Parse(tokens[2]);
                        point.EUHigh = int.Parse(tokens[3]);
                        if (tokens.Length <= 4) break; // Point has no EU Description
                        point.EUDescription = tokens[4];
                        break;
                    case "AREA":
                        // AREA POINTNAME ASSET
                        if (tokens.Length <= 2) break; // Point has no Asset Assigned
                        point.Area = tokens[2];
                        break;
                    case "PVSOURCE":
                    case "OPSOURCE":
                    case "OPDESTIN":
                    case "MDSOURCE":
                    case "MDDESTIN":
                    case "SPSOURCE":
                    case "SPDESTIN":
                    case "A1SOURCE":
                    case "A1DESTIN":
                    case "A2SOURCE":
                    case "A2DESTIN":
                    case "A3SOURCE":
                    case "A3DESTIN":
                    case "A4SOURCE":
                    case "A4DESTIN":
                        // XXXSOURCE POINTNAME CONTROLLER OFFSET DATATYPE
                        // Will need to read the original point file again for the actual data type, since it'll be type 'real' in trainer
                        // Need to track if point to controller relationship established, as link could be any of the address fields.
                        foundController = ParseAnalogPointAddress(line, point, foundController);
                        break;
                    case "OPLIMIT":
                        if (tokens.Length <= 2) break; // Point has no limits configured
                        point.OutputLow = float.Parse(tokens[2]);
                        point.OutputHigh = float.Parse(tokens[3]);
                        break;
                    case "SPLIMIT":
                        if (tokens.Length <= 2) break; // Point has no limits configured
                        point.SetpointLow = float.Parse(tokens[2]);
                        point.SetpointHigh = float.Parse(tokens[3]);
                        break;
                    case "ACTALGO":
                        if (tokens[2] == "68") point.ActionAlgo68 = true;
                        break;
                    case "PVALGO":
                        if (tokens[2] == "7") point.ActionAlgo68 = true;
                        break;
                    case "JNLONLY":
                    case "PVDYNSCN":
                    case "SPDYNSCN":
                    case "OPDYNSCN":
                    case "MDDYNSCN":
                    case "A1DYNSCN":
                    case "A2DYNSCN":
                    case "A3DYNSCN":
                    case "A4DYNSCN":
                    case "ALARM":
                    case "GNONDLY":
                    case "GNOFFDLY":
                    case "ALMXCHG":
                    case "DRIFTDB":
                    case "ALARMDB":
                    case "CNTRLDB":
                    case "PVCLAMP":
                    case "ALMIN":
                        break;
                }
                line = sr.ReadLine();
            }
            if (!foundController) Console.WriteLine($"Could not find an associated controller for point {point.ItemName}");
        }

        private bool ParseAnalogPointAddress(string line, AnalogPointInfo point, bool foundController)
        {
            var tokens = line.Split().Where(s => s.Length > 0).ToArray();
            if (tokens.Length < 4)
            {
                Console.WriteLine($"{point.ItemName} has incomplete {tokens[0]}");
                return foundController;
            }
            // If wordoffset hasn't been set yet, then set.  PVSOURCE may not be the first offset in the point.
            if (point.WordOffset == 0) point.WordOffset = int.Parse(tokens[3]);

            // copy the address line into the point
            switch (tokens[0])
            {
                case "PVSOURCE":
                    point.PVSourceName = line;
                    break;
                case "OPSOURCE":
                    point.OutputSourceName = line;
                    break;
                case "OPDESTIN":
                    point.OutputDestinationName = line;
                    break;
                case "MDSOURCE":
                    point.ModeSourceName = line;
                    break;
                case "MDDESTIN":
                    point.ModeDestinationName = line;
                    break;
                case "SPSOURCE":
                    point.SetpointSourceName = line;
                    break;
                case "SPDESTIN":
                    point.SetpointDestinationName = line;
                    break;
                case "A1SOURCE":
                    point.Aux1SourceName = line;
                    break;
                case "A1DESTIN":
                    point.Aux1DestinationName = line;
                    break;
                case "A2SOURCE":
                    point.Aux2SourceName = line;
                    break;
                case "A2DESTIN":
                    point.Aux2DestinationName = line;
                    break;
                case "A3SOURCE":
                    point.Aux3SourceName = line;
                    break;
                case "A3DESTIN":
                    point.Aux3DestinationName = line;
                    break;
                case "A4SOURCE":
                    point.Aux4SourceName = line;
                    break;
                case "A4DESTIN":
                    point.Aux4DestinationName = line;
                    break;
            }

            if (foundController) return true;  // don't re-link point to controller if link already established
            foreach (var controller in _channel.Controllers)
                if (controller.Number == int.Parse(tokens[2]))
                {
                    controller.AnalogPoints.Add(point);
                    foundController = true;
                }

            return foundController;
        }

        private void ParseStatusPoint(string line, StreamReader sr)
        {
            var point = new StatusPointInfo();
            bool foundController = false;
            while (line != "&") // & is token for end of point definition
            {
                var tokens = line.Split().Where(s => s.Length > 0).ToArray();
                if (tokens.Length == 0)
                {
                    line = sr.ReadLine();
                    continue; // found a blank line, skip
                }
                switch (tokens[0])
                {
                    case "ADD":
                        // ADD POINTNAME POINTTYPE DESCRIPTION DESCRIPTION DESCRIPTION.....
                        point.ItemName = tokens[1];
                        if (tokens.Length <= 3) break; // point has no description
                        var temp = new StringBuilder();
                        for (int i = 3; i < tokens.Length; i++) // point description starts at index 4
                            temp.Append(tokens[i] + ' ');
                        temp.Remove(temp.Length - 1, 1); // Remove final space
                        point.PointDescription = temp.ToString();
                        break;
                    case "RANGE":
                        // RANGE POINTNAME EULO EUHI
                        point.EULow = int.Parse(tokens[2]);
                        point.EUHigh = int.Parse(tokens[3]);
                        if (point.EUHigh == 7) point.NumberOfInputs = 3; // 8 states (0..7) means 3 inputs
                        else if (point.EUHigh == 3) point.NumberOfOutputs = 2; // 4 states (0..3) means 3 inputs
                        else point.NumberOfInputs = 1; // default 2 inputs
                        break;
                    case "AREA":
                        // AREA POINTNAME ASSET
                        if (tokens.Length <= 2) break; // Point has no Asset Assigned
                        point.Area = tokens[2];
                        break;
                    case "PVSOURCE":
                    case "A2SOURCE":
                    case "OPSOURCE":
                    case "A4SOURCE":
                    case "OPDESTIN":
                    case "A3DESTIN":
                    case "A4DESTIN":
                    case "MDSOURCE":
                    case "MDDESTIN":
                    case "AKDESTIN":
                        // XXXSOURCE POINTNAME CONTROLLER OFFSET DATATYPE
                        // Will need to read the original point file again for the actual data type, since it'll be type 'real' in trainer
                        // Need to track if point to controller relationship established, as link could be any of the address fields.
                        foundController = ParseStatusPointAddress(line, point, foundController);
                        break;
                    case "A1SOURCE":
                        point.NonConsecutivePV = true;
                        foundController = ParseStatusPointAddress(line, point, foundController);
                        break;
                    case "A3SOURCE":
                        point.NonConsecutiveOP = true;
                        foundController = ParseStatusPointAddress(line, point, foundController);
                        break;
                    case "ACTALGO":
                        if (tokens[2] == "7") point.ActionAlgo68 = true;
                        break;
                    case "PVREVERS":
                        var pvRevChars = tokens[3].ToCharArray();
                        point.ReversePV1 = pvRevChars[0] == 'Y';
                        point.ReversePV2 = pvRevChars[1] == 'Y';
                        point.ReversePV3 = pvRevChars[2] == 'Y';
                        break;
                    case "OPREVERS":
                        var opRevChars = tokens[3].ToCharArray();
                        point.ReverseOP1 = opRevChars[0] == 'Y';
                        point.ReverseOP2 = opRevChars[1] == 'Y';
                        point.ReverseOP3 = opRevChars[2] == 'Y';
                        break;
                    case "MDREVERS":
                        point.ReverseMode = tokens[2] == "Y";
                        break;
                    case "OPWIDTH":
                        point.NumberOfOutputs = int.Parse(tokens[2]);
                        break;
                    case "A1NAME":
                    case "A2NAME":
                    case "PVDYNSCN":
                    case "A3NAME":
                    case "A4NAME":
                    case "OPDYNSCN":
                    case "MDDYNSCN":
                    case "STATEDES":
                    case "ALARM":
                    case "S0ONDLY":
                    case "S0OFFDLY":
                    case "S1ONDLY":
                    case "S1OFFDLY":
                    case "S2ONDLY":
                    case "S2OFFDLY":
                    case "S3ONDLY":
                    case "S3OFFDLY":
                    case "S4ONDLY":
                    case "S4OFFDLY":
                    case "S5ONDLY":
                    case "S5OFFDLY":
                    case "S7ONDLY":
                    case "S7OFFDLY":
                    case "ALMXCHG":
                    case "TARGET":
                    case "ALMINH":
                    case "JNLONLY":
                        break;
                }
                line = sr.ReadLine();
            }
            if (!foundController) Console.WriteLine($"Could not find an associated controller for point {point.ItemName}");
        }

        private bool ParseStatusPointAddress(string line, StatusPointInfo point, bool foundController)
        {
            var tokens = line.Split().Where(s => s.Length > 0).ToArray();
            if (tokens.Length < 4)
            {
                Console.WriteLine($"{point.ItemName} has incomplete {tokens[0]}");
                return foundController;
            }
            // If wordoffset hasn't been set yet, then set.  PVSOURCE may not be the first offset in the point.
            if (point.WordOffset == 0) point.WordOffset = int.Parse(tokens[3]);

            // copy the address line into the point
            switch (tokens[0])
            {
                case "PVSOURCE":
                    point.PVSourceName1 = line;
                    break;
                case "A1SOURCE":
                    point.PVSourceName2 = line;
                    break;
                case "A2SOURCE":
                    point.PVSourceName3 = line;
                    break;
                case "OPSOURCE":
                    point.OutputSourceName1 = line;
                    break;
                case "A3SOURCE":
                    point.OutputSourceName2 = line;
                    break;
                case "A4SOURCE":
                    point.OutputSourceName3 = line;
                    break;
                case "OPDESTIN":
                    point.OutputDestinationName1 = line;
                    break;
                case "A3DESTIN":
                    point.OutputDestinationName2 = line;
                    break;
                case "A4DESTIN":
                    point.OutputDestinationName3 = line;
                    break;
                case "MDSOURCE":
                    point.ModeSourceName1 = line;
                    break;
                case "MDDESTIN":
                    point.ModeDestinationName1 = line;
                    break;
                case "AKDESTIN":
                    point.AlarmAckDestinationName1 = line;
                    break;

            }

            if (foundController) return true;  // don't re-link point to controller if link already established
            foreach (var controller in _channel.Controllers)
                if (controller.Number == int.Parse(tokens[2]))
                {
                    controller.StatusPoints.Add(point);
                    foundController = true;
                }

            return foundController;
        }
        private void ParseAccumPoint(string line, StreamReader sr)
        {
            var point = new AccumulatorPointInfo();
            while (line != "&") // & is token for end of point definition
            {
                var tokens = line.Split().Where(s => s.Length > 0).ToArray();
                if (tokens.Length == 0)
                {
                    line = sr.ReadLine();
                    continue; // found a blank line, skip
                }
                switch (tokens[0])
                {
                    case "ADD":
                        // ADD POINTNAME POINTTYPE DESCRIPTION DESCRIPTION DESCRIPTION.....
                        point.ItemName = tokens[1];
                        if (tokens.Length <= 3) break; // point has no description
                        var temp = new StringBuilder();
                        for (int i = 3; i < tokens.Length; i++) // point description starts at index 4
                            temp.Append(tokens[i] + ' ');
                        temp.Remove(temp.Length - 1, 1); // Remove final space
                        point.PointDescription = temp.ToString();
                        break;
                    case "RANGE":
                        // RANGE POINTNAME EULO EUHI EUDESC
                        point.EULow = int.Parse(tokens[2]);
                        point.EUHigh = int.Parse(tokens[3]);
                        if (tokens.Length <= 4) break; // Point has no EU Description
                        point.EUDescription = tokens[4];
                        break;
                    case "AREA":
                        // AREA POINTNAME ASSET
                        if (tokens.Length <= 2) break; // Point has no Asset Assigned
                        point.Area = tokens[2];
                        break;
                    case "PVSOURCE":
                        // PVSOURCE POINTNAME CONTROLLER OFFSET DATATYPE
                        // Will need to read the original point file again for the actual data type, since it'll be type 'real' in trainer
                        point.WordOffset = int.Parse(tokens[3]);
                        bool foundController = false;
                        foreach (var controller in _channel.Controllers)
                        {
                            if (controller.Number == int.Parse(tokens[2]))
                            {
                                controller.AccumPoints.Add(point);
                                foundController = true;
                            }
                        }
                        if (!foundController) Console.WriteLine($"Could not find an associated controller for point {point.ItemName}");
                        break;
                    case "SCALE":
                        point.ScalingFactor = int.Parse(tokens[2]);
                        break;
                    case "METER":
                        point.MeterFactor = int.Parse(tokens[2]);
                        break;
                    case "ROLOVR":
                        point.MeterRollover = int.Parse(tokens[2]);
                        break;
                }
                line = sr.ReadLine();
            }
        }

        private void ParseCustomerHdwFileName()
        {
            using (var sr = new StreamReader(_customerHdwFileName))
            {
                // Nothing to do here
            }
        }

        private void ParseCustomerPntFileName()
        {
            using (var sr = new StreamReader(_customerPntFileName))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    var tokens = line.Split().Where(s => s.Length > 0).ToArray();
                    if (tokens.Length == 0)
                    {
                        line = sr.ReadLine();
                        continue; // found a blank line, skip
                    }
                    AnalogPointInfo point;
                    bool isValidType = false;
                    switch (tokens[0])
                    {
                        case "PVSOURCE":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.PVSourceDataFormat = format;
                                    point.IsPVSourceScaled = true;
                                }
                            }
                            break;
                        case "PVDESTIN":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.PVDestinationDataFormat = format;
                                    point.IsPVDestinationScaled = true;
                                }
                            }
                            break;
                        case "OPSOURCE":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.OutputSourceDataFormat = format;
                                    point.IsOutpointSourceScaled = true;
                                }
                            }
                            break;
                        case "OPDESTIN":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.OutputDestinationDataFormat = format;
                                    point.IsOutpointDestinationScaled = true;
                                }
                            }
                            break;
                        case "SPSOURCE":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.SetpointSourceDataFormat = format;
                                    point.IsSetpointSourceScaled = true;
                                }
                            }
                            break;
                        case "SPDESTIN":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.SetpointDestinationDataFormat = format;
                                    point.IsSetpointDestinationScaled = true;
                                }
                            }
                            break;
                        case "A1SOURCE":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.Aux1SourceDataFormat = format;
                                    point.IsAux1SourceScaled = true;
                                }
                            }
                            break;
                        case "A1DESTIN":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.Aux1DestinationDataFormat = format;
                                    point.IsAux1DestinationScaled = true;
                                }
                            }
                            break;
                        case "A2SOURCE":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.Aux2SourceDataFormat = format;
                                    point.IsAux2SourceScaled = true;
                                }
                            }
                            break;
                        case "A2DESTIN":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.Aux2DestinationDataFormat = format;
                                    point.IsAux2DestinationScaled = true;
                                }
                            }
                            break;
                        case "A3SOURCE":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.Aux3SourceDataFormat = format;
                                    point.IsAux3SourceScaled = true;
                                }
                            }
                            break;
                        case "A3DESTIN":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.Aux3DestinationDataFormat = format;
                                    point.IsAux3DestinationScaled = true;
                                }
                            }
                            break;
                        case "A4SOURCE":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.Aux4SourceDataFormat = format;
                                    point.IsAux4SourceScaled = true;
                                }
                            }
                            break;
                        case "A4DESTIN":
                            point = GetAnalogPointByName(tokens[1]);
                            if (tokens.Length <= 4) break; // Data format is not specified
                            if (point != null) // if analog point was found then...
                            {
                                isValidType = Enum.TryParse(tokens[4], true, out ScadaDataFormat format);
                                if (isValidType)
                                {
                                    point.Aux4DestinationDataFormat = format;
                                    point.IsAux4DestinationScaled = true;
                                }
                            }
                            break;
                    }
                    line = sr.ReadLine();
                }
            }
        }

        private AnalogPointInfo GetAnalogPointByName(string name)
        {
            foreach (var controller in _channel.Controllers)
            {
                foreach (var analogPoint in controller.AnalogPoints)
                {
                    if (analogPoint.ItemName == name) return analogPoint;
                }
            }
            return null;
        }

        private int CalculateNumPackets()
        {
            int packets = 0;
            return packets;
        }


    }
}
