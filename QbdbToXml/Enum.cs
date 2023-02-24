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
#endregion
namespace Honeywell.UniSim.Operations.Toolkit.Utilities.Shared_Toolkit_and_Interface_classes.ScadaAdapter
{
    /// <summary>
    /// Enumerated States from SCAN point download file
    /// </summary>
    public enum ScanPointState
    {
        DEL
      , ADD
      , RANGE
      , AREA
      , PVSOURCE
      , SPSOURCE
      , SPDESTIN
      , A1SOURCE
      , A1DESTIN
      , A2SOURCE
      , A2DESTIN
      , A3SOURCE
      , A3DESTIN
      , A4SOURCE
      , A4DESTIN
      , PVCLAMP
      , SPLIMIT
      , OPLIMIT
      , ALARM
      , A1NAME
      , A2NAME
      , A3NAME
      , A4NAME
      , OPSOURCE
      , OPDESTIN
      , ALMINH
      , PVPERIOD
      , STATEDES
      , OPWIDTH
      , TARGET
      , REVERSE
      , OPPERIOD
      , MDSOURCE
      , MDPERIOD
      , MDDESTIN
      , SPPERIOD
      , ITEM
      , SDELIMITER
      , EDELIMITER
      , ENDSRC
      , A1PERIOD
      , A2PERIOD
      , A3PERIOD
      , A4PERIOD
      , OPPULSE
      , ACTALGO
      , ALARMLIM1
      , ALARMLIM2
      , ALARMLIM3
      , ALARMLIM4
      , DRIFTDB
      , GROUP1
      , DISPLAY1
      , ALG1
      , HISSLOW
      , HISFAST
      , ONSCAN
      , CNTRLTO
      , MDNORMAL
      , MDDISABL
      , ALGOR1
      , PVALGO
      , ALARMDB
      , CNTRLDB
      , DEF
      , HISTEXTD
      , PNTDTLPG
      , AKDESTIN
      , ALMXCHG  // 1-848U9 - Added these six PS R500 parameters
      , ALMLIM5
      , ALMLIM6
      , ALMLIM7
      , ALMLIM8
      , PARAM
      , GRPDTLPG
      , CNTRLLVL
      , PARENT
      , ENTNAM
      , PNTSRVTP
      , SCRIPT
      , UNHANDLED
      , PVREVERS
      , OPREVERS
      , MDREVERS
      , PVDESTIN
      , PVDYNSCN
    }

    public enum HardwareDefinition
    {
        CHN  //CHANNEL		
        , RTU  //CONTROLLER  
        , STN  //STATION	
        , LPT  //PRINTER		
    }

    public enum ChannelType
    {
        ABR        //AB_TYPE - Allen Bradley Channel
       , FSC       //FSC_TYPE       /* Generic driver */ enum value 2
       , GENERIC   /* Any of the other protocols that are not supported for address resolution - engineering task */
       , USERTASK
       , OPC       //OPC_TYPE
       , MOD       //MODCON_TYPE	/* Generic driver */ enum value 6
       , SM        //enum value 7
       , SIMSM     //enum value 8
       , FSCETH    //FSC_E_TYPE  
       , SMPKS     //SMPKS_TYPE	
       , SMPKSETH  //SMPKS_E_TYPE
       , DB        //USER_TYPE     /* Already a User Table address */
    }

    public enum ControllerType
    {
        ANALOG, 
        STATUS,
        ACCUM
    }

    public enum ErrorConstants
    {
        OK = 0,
        FILE_ERROR = -1,
        READ_ERROR = -2,
        NOTFOUND = -3,
        WRITE_ERROR = -4,
        BADFILE = -5
    }

    public enum PointType
    {
      ANA // Analog
    , STA //Status
    , ACC // Accumulator
    }
    public enum ScadaDataFormat
    {
        None = 0,
        // Standard Data Types (Modbus)
        U4095,
        U100,
        U999,
        U1023,
        U9998,
        U9999,
        S9999,
        U8B,
        S8B,
        U14B,
        U15B,
        U16B,
        S16B,
        S32B,
        U32B,
        S32BS,
        U32BS,
        U32BB,
        U32BSB,
        S32BB,
        S32BSB,
        // Safety Manager Specific Data Types
        SM020MA,
        SM420MA,
        SM05V,
        SM15V,
        SM010V,
        SM210V,
        // FSC Specific Data Types
        FSC020MA,
        FSC420MA,
        FSC05V,
        FSC15V,
        FSC010V,
        FSC210V,
        // Binary Encoded Decimal Specific Data Types
        U3BCD,
        U4BCD,
        U6BCD,
        U8BCD,
        UBCD12,
        UBCD16,
        // OPC UA Specific Data Types
        D9999,
        U16B0TO20MA,
        U16B4TO20MA,
        U16B0TO5V,
        U16B1TO5V,
        U16B0TO10V,
        U16B2TO10V,
        // Allen Bradley Specific Data Types
        SLC_AI,
        SLC_AO,
        // Raw Data Type
        C16

    }
    public enum PointMode
    {
        
        Auto=1,
        Casc=2,
        Comp=3,
        SMan=4,
        SAuto=5,
        SCasc=6,
        SComp=7
    }
}
