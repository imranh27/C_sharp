using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForIteration
{
    class Program
    {
        public static void Main(string[] args)
        {
            DateTime now = DateTime.Now;

            foreach (TablesList table in (TablesList[])Enum.GetValues(typeof(TablesList)))
            {
                Console.WriteLine(addDateUpdated(table.ToString(), now));
            }

            Console.ReadLine();
        }

        private static string addDateUpdated(string tableName, DateTime now)
        {
            return $"UPDATE {tableName} SET date_built={now.TimeOfDay}";
        }

        enum TablesList
        {
            call_assignees,
            call_closure_codes,
            call_closure_codes2,
            call_details,
            call_priority,
            call_replies,
            call_status,
            call_change_requests,
            call_users
        }
    }
}
