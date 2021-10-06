using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace A_New_Chapter
{
    public class Logger
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //Use this method when you want exception type as error
        public static void Log(Exception exception) 
        {
            Log(exception,EventLogEntryType.Error);
        }
        //Use this method when you want to specify the exception type like Information,Warning etc..
        public static void Log(Exception exception, EventLogEntryType eventLogEntryType) 
        {
            //Create an instance of the StringBuilder class
            StringBuilder sbExceptionMessage = new StringBuilder();
            sbExceptionMessage.Append("Exception Type:"+Environment.NewLine);
            //Get the exception type
            sbExceptionMessage.Append(exception.GetType().Name);
            //Environment.NewLine acts as \n
            sbExceptionMessage.Append("Message"+Environment.NewLine);
            //Get the exception message
            sbExceptionMessage.Append(exception.Message+Environment.NewLine+Environment.NewLine);
            sbExceptionMessage.Append("Stack Trace"+Environment.NewLine);
            sbExceptionMessage.Append(exception.StackTrace+Environment.NewLine+Environment.NewLine);

            //Retrieve the inner exception if any
            Exception innerException = exception.InnerException;
            //if inner exception exists
            while (innerException!=null) 
            {
                sbExceptionMessage.Append("Exception Type"+Environment.NewLine);
                sbExceptionMessage.Append(innerException.GetType().Name);
                sbExceptionMessage.Append(Environment.NewLine+Environment.NewLine);
                sbExceptionMessage.Append("Message"+Environment.NewLine);
                sbExceptionMessage.Append(innerException.Message+Environment.NewLine+Environment.NewLine);
                sbExceptionMessage.Append("Stack Trace"+Environment.NewLine);
                sbExceptionMessage.Append(innerException.StackTrace+Environment.NewLine+Environment.NewLine);

                //Retrieve inner exception if any
                innerException = innerException.InnerException;

                //Loggin exception in the database
                Logger logger = new Logger();
            }

            //If the Event log source exists

            if (EventLog.SourceExists("ANewChapter.com"))
            {
                //Create an instance of the event log
                EventLog _log = new EventLog("ANewChapter");
                //set the source for the eventlog
                _log.Source = "ANewChapter.com";
                //Write the exception details to the log as an error
                _log.WriteEntry(sbExceptionMessage.ToString(), eventLogEntryType);
            }

        }
    }
}