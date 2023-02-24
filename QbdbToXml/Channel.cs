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
    public class Channel
    {
        #region Private Variables
        #endregion

        public Channel()
        {
            Controllers = new List<Controller>();
        }
        /// <summary>
        /// Gets\Sets Channel Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets\Sets Channel Type
        /// </summary>
        public ChannelType Type { get; set; }

        /// <summary>
        /// Gets\Sets Channel Number
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Defines the Asset for the Controller
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// List of Scada Controllers
        /// </summary>
        public List<Controller> Controllers { get; set; }

        /// <summary>
        /// Channel Marg value
        /// </summary>
        public string Marg { get; set; }
    }
}