using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


class Program
{
    public class bannaaan
    {
        public string namae { get; set; }
        public int id { get; set; }
        public DateTime timej { get; set; } = new DateTime();
        public TimeSpan times { get; set; } = new TimeSpan();
    }

    public static class nudeEnju
    {

        public static class sqling
        {
            public static T readFromReader<T>(IDataRecord recoord, string readProp)
            {
                try
                {
                    Type ert = typeof(T);
                    if (ert == typeof(DateTime))
                    {
                        return (T)(object)recoord.GetDateTime(recoord.GetOrdinal(readProp));
                    }
                    if(ert == typeof(TimeSpan))
                    {
                        return (T)(object)recoord.GetDateTime(recoord.GetOrdinal(readProp)).TimeOfDay;
                    }
                    return (T)recoord.GetValue(recoord.GetOrdinal(readProp));
                }
                catch(Exception ex)
                {
                    return default(T);
                }
            }
        }

        public static List<bannaaan> getBanaanFromDbRow(SqlDataReader raader)
        {
            List<bannaaan> ecchi = new List<bannaaan>();
            List<string> deFields = new List<string>();
            for (int i = 0; i < raader.FieldCount; i++)
            {
                deFields.Add(raader.GetName(i));
            }

            while (raader.Read())
            {                

                bannaaan banaa = new bannaaan();
                if (deFields.Contains("ID"))
                {
                    banaa.id = sqling.readFromReader<int>((IDataRecord)raader, "ID");
                }

                if (deFields.Contains("Voornaam"))
                {
                    banaa.namae = sqling.readFromReader<string>((IDataRecord)raader, "Voornaam");
                }

                if (deFields.Contains("DateJoined"))
                {
                    banaa.timej = sqling.readFromReader<DateTime>((IDataReader)raader, "DateJoined");
                }

                if (deFields.Contains("TimeInteken"))
                {
                    banaa.times = sqling.readFromReader<TimeSpan>((IDataRecord)raader, "TimeInteken");
                }

                ecchi.Add(banaa);
            }
            return ecchi;
        }

        static void Main()
        {
            string _ConnectionString = "Server=DESKTOP-RAR7FQP\\SQLEXPRESS; Database=newTestDb; User Id=sa; password=kanker;";
            ReadOrderData(_ConnectionString);
        }

        private static void ReadOrderData(string connectionString)
        {
            string queryString = "select * from userTable";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<bannaaan> bana = getBanaanFromDbRow(reader);

            foreach (bannaaan kuso in bana)
            {
                Console.WriteLine(kuso.id.ToString() + " " + kuso.namae + " " + kuso.timej.ToString());
            }

            reader.Close();
            Console.ReadKey();
        }

        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }
    }
}