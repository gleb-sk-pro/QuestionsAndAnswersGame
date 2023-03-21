using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace QuestionsAndAnswersGame {

    public class PlayerData {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public int Rating { get; set; }
        public int Games { get; set; }
        public DateTime LastPlayed { get; set; }
    }

    public class DataAccess {
        private string connectionString;

        public DataAccess(string connectionString) {
            this.connectionString = connectionString;
        }

        public List<PlayerData> ReadData() {
            List<PlayerData> playerDataList = new List<PlayerData>();

            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "SELECT * FROM Stats";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    try {
                        using (OleDbDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                PlayerData playerData = new PlayerData();
                                playerData.ID = (int)reader["ID"];
                                playerData.Nickname = reader["Nickname"].ToString();
                                playerData.Rating = (int)reader["Rating"];
                                playerData.Games = (int)reader["Games"];
                                playerData.LastPlayed = (DateTime)reader["LastPlayed"];
                                playerDataList.Add(playerData);
                            }
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine("Please check if Microsoft Access is closed");
                        Console.WriteLine("Exception: " + e);
                    }
                }
            }

            return playerDataList;
        }

        public void WriteData(PlayerData playerData) {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "INSERT INTO Stats (Nickname, Rating, Games, LastPlayed) " +
                             "VALUES (@Nickname, @Rating, @Games, @LastPlayed)";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@Nickname", playerData.Nickname);
                    command.Parameters.AddWithValue("@Rating", playerData.Rating);
                    command.Parameters.AddWithValue("@Games", playerData.Games);
                    command.Parameters.AddWithValue("@LastPlayed", playerData.LastPlayed);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void ModifyData(int id, PlayerData playerData) {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "UPDATE Stats " +
                             "SET Nickname = @Nickname, Rating = @Rating, Games = @Games, LastPlayed = @LastPlayed " +
                             "WHERE ID = @ID";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@Nickname", playerData.Nickname);
                    command.Parameters.AddWithValue("@Rating", playerData.Rating);
                    command.Parameters.AddWithValue("@Games", playerData.Games);
                    command.Parameters.AddWithValue("@LastPlayed", playerData.LastPlayed);
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void printData() {
            List<PlayerData> playerDataList = ReadData();

            foreach (PlayerData playerData in playerDataList) {
                Console.WriteLine($"ID: {playerData.ID} | Nickname: {playerData.Nickname} | Rating: {playerData.Rating} | Games: {playerData.Games} ");
            }
        }

        public bool Contains(string type, string value) {
            List<PlayerData> lastGameData = ReadData();
            foreach (PlayerData PlayerData in lastGameData) {
                if (type == "ID" && PlayerData.ID.ToString() == value) { return true; }
                if (type == "Nickname" && PlayerData.Nickname.ToString() == value) { return true; }
                if (type == "Rating" && PlayerData.Rating.ToString() == value) { return true; }
                if (type == "Games" && PlayerData.Games.ToString() == value) { return true; }
            }
            return false;
        }
        public int returnID(string type, string value) {
            List<PlayerData> lastGameData = ReadData();
            foreach (PlayerData PlayerData in lastGameData) {
                if (type == "Nickname" && PlayerData.Nickname.ToString() == value) { return PlayerData.ID; }
            }
            return -1;
        }
        public OleDbDataAdapter GetDataAdapter() {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                string sql = "SELECT * FROM Stats";
                adapter.SelectCommand = new OleDbCommand(sql, connection);
            }
            return adapter;
        }

        public int ReadLastID() {
            int lastID = 0;
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "SELECT TOP 1 ID FROM Stats ORDER BY ID DESC";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    try {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value) {
                            lastID = (int)result;
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine("Please check if Microsoft Access is closed");
                        Console.WriteLine("Exception: " + e);
                    }
                }
            }

            return lastID;
        }
        public void modifyRanking(int id, string type, int newValue) {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "UPDATE Stats " +
                             "SET " + type + " = @" + type +
                             " WHERE ID = @ID";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    switch (type) {
                        case "Rating":
                            command.Parameters.AddWithValue("@Rating", newValue);
                            break;
                        case "Games":
                            command.Parameters.AddWithValue("@Games", newValue);
                            break;
                    }
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
            }
        }
        public int GetCurrentRanking(int id, string type) {
            int currentRating = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "SELECT " + type + " FROM Stats WHERE ID = @ID";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@ID", id);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value) {
                        currentRating = (int)result;
                    }
                }
            }

            return currentRating;
        }

    }
}

