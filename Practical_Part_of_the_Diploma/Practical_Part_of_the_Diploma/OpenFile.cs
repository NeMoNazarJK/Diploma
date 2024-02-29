using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Part_of_the_Diploma
{
    internal class OpenFile
    {
        public static DataTable OnOpenDataBaseClick(object sender, EventArgs a)
        {
            DataTable dataTable = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "База даних Access (*.mdb, *.accdb)|*.mdb;*.accdb";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={openFileDialog.FileName};";
                string query = "SELECT * FROM Studens";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    dataTable = new DataTable();

                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public static string OnOpenFileKeyClick(object sender, EventArgs a)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}