using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace AsyncAwaitPattern
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string conStr = "";
            SqlConnection conn = new SqlConnection(conStr);

            //void wird zurück gegeben
            Task task =  conn.OpenAsync();
            task.Wait(); //Callback
            await conn.OpenAsync();

            Task<string> result = Task.Run(DayTime);
            result.Wait();

            string result1 = await Task.Run(DayTime);
        }

        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now;

            return dateTime.Hour < 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }
    }
}
