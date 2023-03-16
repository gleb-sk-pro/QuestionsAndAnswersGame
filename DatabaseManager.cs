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
                        Console.WriteLine("Exception: "+e);
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
        public void DeleteData(int id) {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                string sql = "DELETE FROM Stats WHERE ID = @ID";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ResetDatabase() {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                // Drop the existing table
                string dropTableSql = "DROP TABLE Stats";
                using (OleDbCommand dropTableCommand = new OleDbCommand(dropTableSql, connection)) {
                    dropTableCommand.ExecuteNonQuery();
                }

                // Recreate the table with the correct schema
                string createTableSql = "CREATE TABLE Stats (ID AUTOINCREMENT, Nickname TEXT, Rating INT, Games INT, LastPlayed DATETIME)";
                using (OleDbCommand createTableCommand = new OleDbCommand(createTableSql, connection)) {
                    createTableCommand.ExecuteNonQuery();
                }
            }
        }

        public void printData() {
            List<PlayerData> playerDataList = ReadData();

            foreach (PlayerData playerData in playerDataList) {
                Console.WriteLine($"ID: {playerData.ID} | Nickname: {playerData.Nickname} | Rating: {playerData.Rating} | Games: {playerData.Games} | LastPlayed: {playerData.LastPlayed.ToString("dd/MM/yyyy")}");
            }
        }
    }

}