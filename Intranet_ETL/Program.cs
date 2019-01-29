using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using NLog;

namespace Intranet_ETL
{
    class Program
    {
        public static void Main(string[] args)
        {
            DateTime now = DateTime.Now;

            //Configure Logging
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "etl_log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);
           //config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;

            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("ETL Start");

            //Define Source and Target Connections
            using (MySqlConnection sourceConnection = new MySqlConnection(GetSourceConnectionString()))
            using (SqlConnection targetConnection = new SqlConnection(GetTargetConnectionString()))
            {
                //Open Source and Target
                sourceConnection.Open();
                targetConnection.Open();

                var tablesList = Enum.GetValues(typeof(TablesList)).Cast<TablesList>();

                foreach (Enum table in tablesList)
                {
                    //Build Query
                    MySqlCommand getSourceTable = new MySqlCommand(GetSourceQuery(table.ToString()), sourceConnection);
                    MySqlDataReader sourceData = getSourceTable.ExecuteReader();

                    //setup Bulkcopy object
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(targetConnection))
                    {
                        //Define target for payload
                        string targetTable = table.ToString();
                        bulkCopy.DestinationTableName = table.ToString();

                        //Clear down destination
                        SqlCommand emptyDestinationTable = new SqlCommand(clearDestinationTable(targetTable), targetConnection);
                        emptyDestinationTable.ExecuteNonQuery();
                        logger.Info($"{targetTable} cleared down");

                        //Write data to target
                        try
                        {
                            bulkCopy.WriteToServer(sourceData);
                            logger.Info($"{targetTable} started");
                        }
                        catch (Exception ex)
                        {
                            logger.Error($"{ex} - {targetTable} failed to fill");
                        }
                        finally
                        {
                            sourceData.Close();
                            logger.Info($"{targetTable} finished");
                        }

                        //Add date updated to table
                        SqlCommand updateDateUpdated = new SqlCommand(addDateUpdated(targetTable), targetConnection);
                        updateDateUpdated.ExecuteNonQuery();
                        logger.Info($"{targetTable} date built updated");

                        Console.WriteLine($"{targetTable} has been filled");
                    }
                    
                }
            }


            logger.Info("ETL Finished");

            //Console.ReadLine();
        }

        private static string GetSourceConnectionString()
        {
            //MySQL
            string sourceServer = "serverName";
            string sourceDatabase = "call_logging";
            string sourceUserName = "UserName";
            string sourcePassword = "password";

            string sourceConnectionString = $"server={sourceServer};database={sourceDatabase};user={sourceUserName};password={sourcePassword}";

            return sourceConnectionString;
        }

        private static string GetTargetConnectionString()
        {
            string targetServer = "SQL02";
            string targetDatabase = "Conveyancing_DW_Test";

            string targetConnectionString = $"Server ={targetServer}; Database ={targetDatabase}; trusted_Connection = True;";

            return targetConnectionString;
        }

        
        private static string GetSourceQuery(string tableName)
        {
            string sourceQuery = "";

            switch (tableName)
            {
                case "call_assignees":
                    sourceQuery = "SELECT call_assignee_id, call_assignee_name, call_assignee_email, primary_handler, hidden FROM call_assignees";
                    break;
                case "call_closure_codes":
                    sourceQuery = "SELECT call_closure_code_id, call_closure_code_name FROM call_closure_codes";
                    break;
                case "call_closure_codes2":
                    sourceQuery = "SELECT call_closure2_code_id, call_closure_code_id, call_closure2_code_name FROM call_closure_codes2";
                    break;
                case "call_details":
                    sourceQuery = "SELECT call_id, call_timestamp, call_user_id, call_dept_id, call_office_id, call_subject, CAST(call_detail AS CHAR(500)) as call_detail," +
                                    "call_status_id, call_assignee_id, call_priority_id, CAST(call_solution_generalview AS CHAR(500)), call_closurecode1, " +
                                    "call_closurecode2, CAST(call_it_notes AS CHAR(500)) as call_it_notes, call_closure_timestamp, call_total_time_open, call_clearvision, " +
                                    "call_changerequest, call_mfd, call_loggedbyit, call_reminder_timestamp FROM call_details";
                    break;
                case "call_priority":
                    sourceQuery = "SELECT call_priority_id, call_priority_name FROM call_priority";
                    break;
                case "call_replies":
                    sourceQuery = "SELECT reply_id, call_id, CAST(call_reply AS CHAR(500)) as call_reply, call_replier, call_reply_timestamp FROM call_replies";
                    break;
                case "call_status":
                    sourceQuery = "SELECT call_status_id, call_status FROM call_status";
                    break;
                case "call_change_requests":
                    sourceQuery = "SELECT call_id, div_auth, bs_auth, div_authorisation, bs_authorisation FROM change_requests";
                    break;
                case "call_users":
                    sourceQuery = "SELECT id, name, username FROM telephone.details";
                    break;
            }  

            return sourceQuery;
        }

        private static string clearDestinationTable(string tableName)
        {
            return $"DELETE FROM {tableName}";
        }

        private static string addDateUpdated(string tableName)
        {
            return $"UPDATE {tableName} SET date_built=GETDATE()";
        }


        enum TablesList
        {
            call_users,
            call_assignees, 
            call_closure_codes,
            call_closure_codes2,
            call_details, 
            call_priority, 
            call_replies,
            call_status,
            call_change_requests
        }
        

    }

    
}
