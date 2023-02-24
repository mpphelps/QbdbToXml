/////////////////////////////////////////////////////////////////////////////
//
//							  COPYRIGHT (c) 2021
//								HONEYWELL LTD.
//							  ALL RIGHTS RESERVED
//
//  This software is a copyrighted work and/or information protected as a
//  trade secret. Legal rights of Honeywell Ltd. in this software is distinct
//  from ownership of any medium in which the software is embodied. Copyright
//  or trade secret notices included must be reproduced in any copies
//  authorised by Honeywell Ltd.
//
/////////////////////////////////////////////////////////////////////////////
#region Using Declarations
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion
namespace Honeywell.UniSim.Operations.Toolkit.Utilities.Shared_Toolkit_and_Interface_classes.ScadaAdapter
{
    public class Controller
    {
        public Controller()
        {
            AnalogPoints = new List<AnalogPointInfo>();
            StatusPoints = new List<StatusPointInfo>();
            AccumPoints = new List<AccumulatorPointInfo>();
        }
        /// <summary>
        /// Gets\Sets Controller Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets\Sets Controller Type
        /// </summary>
        public ControllerType Type { get; set; }
        /// <summary>
        /// Indicates the Unique Controller Number
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Defines the Asset for the Controller
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// List of Analog Scada Points
        /// </summary>
        public List<AnalogPointInfo> AnalogPoints { get; set; }
        /// <summary>
        /// List of Status Scada Points
        /// </summary>
        public List<StatusPointInfo> StatusPoints { get; set; }
        /// <summary>
        /// List of Accumulator Scada Points
        /// </summary>
        public List<AccumulatorPointInfo> AccumPoints { get; set; }
    }
}
