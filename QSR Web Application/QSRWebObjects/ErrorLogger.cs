/// <summary>
/// Purpose: Class that creates error log when exceptions occur
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class ErrorLogger
    {
        //
        //Error routine for Exceptions that are thrown in the Data Objects Layer
        //
        public static void ErrorRoutine(Exception e, string obj, string method)
        {
            //create log and source with LogUtil page before using this method
            EventLog log = new EventLog();
            log.Source = "Quick Start Retailer";
            log.Log = "Quick Start Retailer";
            log.WriteEntry("Error in QSRWebObjects, object=" + obj + ", method=" + method +
                " , message=" + e.Message, EventLogEntryType.Error);
            throw new Exception("Error in Web Object");
        }
    }
}
