using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace QuestionsAndAnswersGame {

    public class LastGameData {
        public int PlayerID { get; set; }
        public int CorrectAnswer { get; set; }
        public int IncorrectAnswer { get; set; }
        public int TimeTaken { get; set; }
    }

    public class LastGameAccess {
        private string connectionString;

        public LastGameAccess(string connectionString) {
            this.connectionString = connectionString;
        }
        public OleDbDataAdapter GetDataAdapter() {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                string sql = "SELECT * FROM LastGameStats";
                adapter.SelectCommand = new OleDbCommand(sql, connection);
            }
            return adapter;
        }

        public List<LastGameData> ReadData() {
            List<LastGameData> LastGameDataList = new List<LastGameData>();

            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "SELECT * FROM LastGameStats";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    try {
                        using (OleDbDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                LastGameData lastGameData = new LastGameData();
                                lastGameData.PlayerID = (int)reader["PlayerID"];
                                lastGameData.CorrectAnswer = (int)reader["CorrectAnswer"];
                                lastGameData.IncorrectAnswer = (int)reader["IncorrectAnswer"];
                                lastGameData.TimeTaken = (int)reader["TimeTaken"];

                                LastGameDataList.Add(lastGameData);
                            }
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine("Please check if Microsoft Access is closed");
                        Console.WriteLine("Exception: " + e);
                    }
                }
            }

            return LastGameDataList;
        }

        public void WriteData(LastGameData LastGameData) {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "INSERT INTO LastGameStats (PlayerID, CorrectAnswer, IncorrectAnswer, TimeTaken) " +
                             "VALUES (@PlayerID, @CorrectAnswer, @IncorrectAnswer, @TimeTaken)";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@PlayerID", LastGameData.PlayerID);
                    command.Parameters.AddWithValue("@CorrectAnswer", LastGameData.CorrectAnswer);
                    command.Parameters.AddWithValue("@IncorrectAnswer", LastGameData.IncorrectAnswer);
                    command.Parameters.AddWithValue("@TimeTaken", LastGameData.TimeTaken);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ModifyData(int id, LastGameData LastGameData) {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "UPDATE LastGameStats " +
                             "SET CorrectAnswer = @CorrectAnswer, IncorrectAnswer = @IncorrectAnswer, TimeTaken = @TimeTaken " +
                             "WHERE PlayerID = @PlayerID";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@CorrectAnswer", LastGameData.CorrectAnswer);
                    command.Parameters.AddWithValue("@IncorrectAnswer", LastGameData.IncorrectAnswer);
                    command.Parameters.AddWithValue("@TimeTaken", LastGameData.TimeTaken);
                    command.Parameters.AddWithValue("@PlayerID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteData(int id) {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                string sql = "DELETE FROM LastGameStats WHERE PlayerID = @PlayerID";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@PlayerID", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void printData() {
            List<LastGameData> LastGameDataList = ReadData();

            foreach (LastGameData LastGameData in LastGameDataList) {
                Console.WriteLine($"PlayerID: {LastGameData.PlayerID} | CorrectAnswer: {LastGameData.CorrectAnswer} | IncorrectAnswer: {LastGameData.IncorrectAnswer} | TimeTaken: {LastGameData.TimeTaken}");
            }
        }

        public bool Contains(string type, string value) {
            List<LastGameData> lastGameData = ReadData();
            foreach (LastGameData LastGameData in lastGameData) {
                if (type == "PlayerID" && LastGameData.PlayerID.ToString() == value) { return true; }
                else if (type == "CorrectAnswer" && LastGameData.CorrectAnswer.ToString() == value) { return true; }
                else if (type == "IncorrectAnswer" && LastGameData.IncorrectAnswer.ToString() == value) { return true; }
                else if (type == "TimeTaken" && LastGameData.TimeTaken.ToString() == value) { return true; }
            }
            return false;
        }

    }
}
