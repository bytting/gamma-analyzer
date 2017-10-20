using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using System.Data.SQLite;

namespace crash
{
    public static class DB
    {
        public static Session LoadSessionFile(string sessionFile)
        {
            Session s = new Session();

            // Deserialize session object
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + sessionFile + "; Version=3; FailIfMissing=True; Foreign Keys=True;");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "select * from session";
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
                throw new Exception("No session was found in database: " + sessionFile);

            reader.Read();

            s.Name = reader["name"].ToString();
            s.IPAddress = reader["ip"].ToString();
            s.Comment = reader["comment"].ToString();
            s.Livetime = Convert.ToSingle(reader["livetime"], CultureInfo.InvariantCulture);
            s.Detector = JsonConvert.DeserializeObject<Detector>(reader["detector_data"].ToString());

            reader.Close();

            s.SessionFile = sessionFile;

            // Load session spectrums
            command.CommandText = "select * from spectrum order by session_index asc";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Spectrum spec = new Spectrum();
                spec.SessionName = reader["session_name"].ToString();
                spec.SessionIndex = Convert.ToInt32(reader["session_index"]);
                spec.GpsTime = Convert.ToDateTime(reader["start_time"]);
                spec.Latitude = Convert.ToDouble(reader["latitude"], CultureInfo.InvariantCulture);
                spec.LatitudeError = Convert.ToDouble(reader["latitude_error"], CultureInfo.InvariantCulture);
                spec.Longitude = Convert.ToDouble(reader["longitude"], CultureInfo.InvariantCulture);
                spec.LongitudeError = Convert.ToDouble(reader["longitude_error"], CultureInfo.InvariantCulture);
                spec.Altitude = Convert.ToDouble(reader["altitude"], CultureInfo.InvariantCulture);
                spec.AltitudeError = Convert.ToDouble(reader["altitude_error"], CultureInfo.InvariantCulture);
                spec.GpsTrack = Convert.ToSingle(reader["track"], CultureInfo.InvariantCulture);
                spec.GpsTrackError = Convert.ToSingle(reader["track_error"], CultureInfo.InvariantCulture);
                spec.GpsSpeed = Convert.ToSingle(reader["speed"], CultureInfo.InvariantCulture);
                spec.GpsSpeedError = Convert.ToSingle(reader["speed_error"], CultureInfo.InvariantCulture);
                spec.GpsClimb = Convert.ToSingle(reader["climb"], CultureInfo.InvariantCulture);
                spec.GpsClimbError = Convert.ToSingle(reader["climb_error"], CultureInfo.InvariantCulture);
                spec.Livetime = Convert.ToInt32(reader["livetime"]);
                spec.Realtime = Convert.ToInt32(reader["realtime"]);
                spec.TotalCount = Convert.ToInt32(reader["total_count"]);
                spec.NumChannels = Convert.ToInt32(reader["num_channels"]);
                spec.LoadSpectrumString(reader["channels"].ToString());
                spec.CalculateDoserate(s.Detector, s.GEScriptFunc);
                s.Add(spec);
            }

            connection.Close();
            return s;
        }
    }
}
