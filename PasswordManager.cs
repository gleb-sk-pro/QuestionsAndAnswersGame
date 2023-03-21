using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace QuestionsAndAnswersGame {

    public class CredentialData {
        public int AccountID { get; set; }
        public string Pass { get; set; }
    }

    public class CredentialAccess {
        private string connectionString;

        public CredentialAccess(string connectionString) {
            this.connectionString = connectionString;
        }
        public OleDbDataAdapter GetDataAdapter() {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                string sql = "SELECT * FROM AccountInfo";
                adapter.SelectCommand = new OleDbCommand(sql, connection);
            }
            return adapter;
        }

        public List<CredentialData> ReadData() {
            List<CredentialData> CredentialDataList = new List<CredentialData>();

            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "SELECT * FROM AccountInfo";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    try {
                        using (OleDbDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                CredentialData CredentialData = new CredentialData();
                                CredentialData.AccountID = (int)reader["AccountID"];
                                CredentialData.Pass = reader["Pass"].ToString();

                                CredentialDataList.Add(CredentialData);
                            }
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine("Please check if Microsoft Access is closed");
                        Console.WriteLine("Exception: " + e);
                    }
                }
            }

            return CredentialDataList;
        }

        public void WriteData(CredentialData CredentialData) {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                string sql = "INSERT INTO AccountInfo (AccountID, Pass) " +
                             "VALUES (@AccountID, @Pass)";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@AccountID", CredentialData.AccountID);
                    command.Parameters.AddWithValue("@Pass", CredentialData.Pass);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteData(int id) {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                string sql = "DELETE FROM AccountInfo WHERE AccountID = @AccountID";

                using (OleDbCommand command = new OleDbCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@AccountID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void printData() {
            List<CredentialData> CredentialDataList = ReadData();

            foreach (CredentialData CredentialData in CredentialDataList) {
                Console.WriteLine($"AccountID: {CredentialData.AccountID} | Pass: {CredentialData.Pass}");
            }
        }
        public bool Contains(string type, string value) {
            List<CredentialData> lastGameData = ReadData();
            foreach (CredentialData PlayerData in lastGameData) {
                if (type == "AccountID" && PlayerData.AccountID.ToString() == value) { return true; }
                else if (type == "Pass" && PlayerData.Pass.ToString() == value) { return true; }
            }
            return false;
        }

    }
}
