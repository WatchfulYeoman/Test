using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace OLEDB_Example
{
    public partial class Form1 : Form
    {
        private MySqlConnection mysqlConn;
        private string server;
        private string database;
        private string uid;
        private string password;

        DataTable workTable = new DataTable("dtReadings");

        BackgroundWorker bwOpen = new BackgroundWorker();
        BackgroundWorker bwAdd = new BackgroundWorker();
        BackgroundWorker bwStation = new BackgroundWorker();

        Exception error = new Exception();

        public Form1()
        {
            InitializeComponent();
            server = "localhost";
            database = "polair";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(buttonClose, "Return to tabular view");

            mysqlConn = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                mysqlConn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                mysqlConn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void importData(string dataSource)
        {
            if (dataSource != null)
            {
                OleDbConnection oleConn = new OleDbConnection();
                oleConn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dataSource + @";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1;ImportMixedTypes= Text;TypeGuessRows=0""";                

                OleDbCommand oleCommand = new OleDbCommand(
                        "SELECT * " +
                        "FROM [Polair$] " +
                        "WHERE [Date & Time] IS NOT NULL", oleConn
                    );

                OleDbDataAdapter adapter = new OleDbDataAdapter(oleCommand);
                workTable.Clear();
                workTable.Columns.Clear();
                try
                {
                    adapter.Fill(workTable);
                }
                catch (Exception e)
                {
                    error = e;                    
                    oleConn.Close();
                }

                oleConn.Close();

                if (workTable.Rows.Count > 0)
                {
                    workTable.Columns["Date & Time"].ColumnName = "Date";

                    //Parse dates in Date column
                    int i = 0;
                    string stringDate = "";
                    DateTime date;
                    DataRow row;
                    while (i < workTable.Rows.Count)
                    {
                        stringDate = workTable.Rows[i]["Date"].ToString();
                        //Remove (sometimes erroneous) time from date
                        stringDate = stringDate.Split(' ').First();

                        if (DateTime.TryParseExact(stringDate, "dd/MM/yyyy", null, DateTimeStyles.None, out date))
                        {
                            //Convert date into DateTime format necessary for MySQL entry
                            stringDate = date.ToString("yyyy/MM/dd");
                            workTable.Rows[i]["Date"] = stringDate;
                        }
                        else
                        {
                            //Remove rows with erroneous dates
                            row = workTable.Rows[i];
                            row.Delete();
                        }
                        i++;
                    }
                    workTable.AcceptChanges();
                }
            }
        }

        private void populateReadingNamesTable()
        {
            if (this.OpenConnection() == true)
            {
                DataTable readingNameTable = new DataTable("dtReadingNames");

                //Collect reading table names from DB table readingtablenames and fill DT readingNameTable
                MySqlCommand mysqlCmd = new MySqlCommand(
                    "SELECT * FROM readingtablenames WHERE readingName LIKE 'readingspm%'", mysqlConn
                    );
                MySqlDataAdapter adapter = new MySqlDataAdapter(mysqlCmd);
                readingNameTable.Clear();
                readingNameTable.Columns.Clear();
                adapter.Fill(readingNameTable);

                this.CloseConnection();

                //Populate reading names comboBoxes
                comboBoxDatabaseReading.DataSource = readingNameTable;
                comboBoxDatabaseReading.DisplayMember = readingNameTable.Columns["readingDesc"].ToString();
                comboBoxDatabaseReading.Text = "Select which pollutant";
            }
        }

        public bool UpdateMySQLDatabase(string selectedReadingDesc)
        {
            if (this.OpenConnection() == true)
            {
                //Identify selected readingDesc in comboBox and find matching readingName in DB table readingtablenames
                MySqlCommand mysqlCmd3 = new MySqlCommand(
                    "SELECT readingName FROM readingtablenames WHERE readingDesc = '" + selectedReadingDesc + "'", mysqlConn
                    );
                string selectedReadingName = (mysqlCmd3.ExecuteScalar() + "");

                DataTable stationTable = new DataTable("dtStations");

                //Dynamic query for selecting only the DB table station rows that have corresponding columns in spreadsheet
                string stations = "";
                int i = 1;
                while (i < workTable.Columns.Count)
                {
                    stations = string.Concat(stations, "'", workTable.Columns[i].ColumnName);
                    i++;
                    if (i < workTable.Columns.Count)
                        stations = string.Concat(stations, "', ");
                    else
                        stations = string.Concat(stations, "'");
                }

                //Fill DT stationTable with selected rows from the above dynamic query
                MySqlCommand mysqlCmd4 = new MySqlCommand(
                    "SELECT * FROM stations WHERE stationDesc in (" + stations + ")", mysqlConn
                    );
                MySqlDataAdapter adapter = new MySqlDataAdapter(mysqlCmd4);
                stationTable.Clear();
                stationTable.Columns.Clear();
                adapter.Fill(stationTable);

                //Strings creation for dynamic queries
                string stationColumns = "";
                string stationParameters = "";
                string stationParametersAQI = "";
                i = 0;
                while (i < stationTable.Rows.Count)
                {
                    stationColumns = string.Concat(stationColumns, ", ");
                    stationColumns = string.Concat(stationColumns, stationTable.Rows[i]["stationName"].ToString());

                    stationParameters = string.Concat(stationParameters, ", @");
                    stationParameters = string.Concat(stationParameters, stationTable.Rows[i]["stationName"].ToString());

                    stationParametersAQI = string.Concat(stationParametersAQI, ", @");
                    stationParametersAQI = string.Concat(stationParametersAQI, stationTable.Rows[i]["stationName"].ToString());
                    stationParametersAQI = string.Concat(stationParametersAQI, "AQI");
                    i++;
                }

                MySqlCommand mysqlCmdInsert = new MySqlCommand(
                    "INSERT INTO " + selectedReadingName + " (date" + stationColumns + ") " +                    
                    "VALUES (@Date" + stationParameters + ")", mysqlConn
                    );

                MySqlCommand mysqlCmdInsertAQIPM10 = new MySqlCommand(
                    "INSERT INTO readingsaqipm10 (date" + stationColumns + ") " +
                    "VALUES (@DateAQI"+ stationParametersAQI + ")", mysqlConn
                    );

                MySqlCommand mysqlCmdInsertAQIPM25 = new MySqlCommand(
                    "INSERT INTO readingsaqipm25 (date" + stationColumns + ") " +
                    "VALUES (@DateAQI"+ stationParametersAQI + ")", mysqlConn
                    );

                i = 0;
                int y = 0;
                double aqi = 0;
                double reading = 0;
                int multipleDateCount = 0;
                int multipleDateCountAQI = 0;
                while (i < workTable.Rows.Count)
                {
                    mysqlCmdInsert.Parameters.Clear();
                    mysqlCmdInsert.Parameters.AddWithValue("@Date", workTable.Rows[i]["Date"]);

                    MySqlCommand mysqlFindDate = new MySqlCommand(
                        "SELECT COUNT(date) FROM " + selectedReadingName + " WHERE date = '" + workTable.Rows[i]["Date"].ToString() + "'", mysqlConn
                        );

                    multipleDateCount = 0;
                    multipleDateCount = int.Parse(mysqlFindDate.ExecuteScalar() + "");

                    y = 0;
                    while (y < stationTable.Rows.Count)
                    {
                        if (multipleDateCount == 0)
                        {
                            stationParameters = "";
                            stationParameters = string.Concat("@", stationTable.Rows[y]["stationName"].ToString());
                            if (double.TryParse(Convert.ToString(workTable.Rows[i][stationTable.Rows[y]["stationDesc"].ToString()]), out reading))
                            {
                                mysqlCmdInsert.Parameters.AddWithValue(stationParameters, reading);
                            }
                            else
                            {
                                mysqlCmdInsert.Parameters.AddWithValue(stationParameters, null);
                            }
                            
                        } else
                        {
                            if (double.TryParse(Convert.ToString(workTable.Rows[i][stationTable.Rows[y]["stationDesc"].ToString()]), out reading))
                            {
                                MySqlCommand mysqlCmdUpdate = new MySqlCommand(
                                    "UPDATE " + selectedReadingName + " SET " + stationTable.Rows[y]["stationName"] + " = " + reading + " WHERE date = '" + workTable.Rows[i]["Date"].ToString() + "'", mysqlConn
                                    );
                                mysqlCmdUpdate.ExecuteNonQuery();
                            }                            
                            else
                            {
                                MySqlCommand mysqlCmdUpdate = new MySqlCommand(
                                    "UPDATE " + selectedReadingName + " SET " + stationTable.Rows[y]["stationName"] + " = null WHERE date = '" + workTable.Rows[i]["Date"].ToString() + "'", mysqlConn
                                    );
                                mysqlCmdUpdate.ExecuteNonQuery();
                            }
                        }
                        y++;
                    }


                    multipleDateCountAQI = 0;
                    switch (selectedReadingDesc)
                    {
                        case "PM10":
                            mysqlCmdInsertAQIPM10.Parameters.Clear();
                            mysqlCmdInsertAQIPM10.Parameters.AddWithValue("@DateAQI", workTable.Rows[i]["Date"]);

                            MySqlCommand mysqlFindDateAQIPM10 = new MySqlCommand(
                                "SELECT COUNT(date) FROM readingsaqipm10 WHERE date = '" + workTable.Rows[i]["Date"].ToString() + "'", mysqlConn
                                );
                            multipleDateCountAQI = int.Parse(mysqlFindDateAQIPM10.ExecuteScalar() + "");
                            break;
                        case "PM2.5":
                            mysqlCmdInsertAQIPM25.Parameters.Clear();
                            mysqlCmdInsertAQIPM25.Parameters.AddWithValue("@DateAQI", workTable.Rows[i]["Date"]);

                            MySqlCommand mysqlFindDateAQIPM25 = new MySqlCommand(
                                "SELECT COUNT(date) FROM readingsaqipm25 WHERE date = '" + workTable.Rows[i]["Date"].ToString() + "'", mysqlConn
                                );
                            multipleDateCountAQI = int.Parse(mysqlFindDateAQIPM25.ExecuteScalar() + "");
                            break;
                        default:
                            break;
                    }

                    y = 0;
                    while (y < stationTable.Rows.Count)
                    {
                        if (multipleDateCountAQI == 0)
                        {
                            stationParametersAQI = "";
                            stationParametersAQI = string.Concat("@", stationTable.Rows[y]["stationName"].ToString());
                            stationParametersAQI = string.Concat(stationParametersAQI, "AQI");
                            if (double.TryParse(Convert.ToString(workTable.Rows[i][stationTable.Rows[y]["stationDesc"].ToString()]), out reading))
                            {
                                aqi = computeAQI(selectedReadingDesc, reading);
                                switch (selectedReadingDesc)
                                {
                                    case "PM10":
                                        mysqlCmdInsertAQIPM10.Parameters.AddWithValue(stationParametersAQI, aqi);
                                        break;
                                    case "PM2.5":
                                        mysqlCmdInsertAQIPM25.Parameters.AddWithValue(stationParametersAQI, aqi);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (selectedReadingDesc)
                                {
                                    case "PM10":
                                        mysqlCmdInsertAQIPM10.Parameters.AddWithValue(stationParametersAQI, null);
                                        break;
                                    case "PM2.5":
                                        mysqlCmdInsertAQIPM25.Parameters.AddWithValue(stationParametersAQI, null);
                                        break;
                                    default:
                                        break;
                                }
                            }

                        } else
                        {
                            if (double.TryParse(Convert.ToString(workTable.Rows[i][stationTable.Rows[y]["stationDesc"].ToString()]), out reading))
                            {
                                aqi = computeAQI(selectedReadingDesc, reading);
                                switch (selectedReadingDesc)
                                {
                                    case "PM10":
                                        MySqlCommand mysqlCmdUpdatePM10 = new MySqlCommand(
                                            "UPDATE readingsaqipm10 SET " + stationTable.Rows[y]["stationName"] + " = " + aqi + " WHERE date = '" + workTable.Rows[i]["Date"].ToString() + "'", mysqlConn
                                            );
                                        mysqlCmdUpdatePM10.ExecuteNonQuery();
                                        break;
                                    case "PM2.5":
                                        MySqlCommand mysqlCmdUpdatePM25 = new MySqlCommand(
                                            "UPDATE readingsaqipm25 SET " + stationTable.Rows[y]["stationName"] + " = " + aqi + " WHERE date = '" + workTable.Rows[i]["Date"].ToString() + "'", mysqlConn
                                            );
                                        mysqlCmdUpdatePM25.ExecuteNonQuery();
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (selectedReadingDesc)
                                {
                                    case "PM10":
                                        MySqlCommand mysqlCmdUpdatePM10 = new MySqlCommand(
                                            "UPDATE readingsaqipm10 SET " + stationTable.Rows[y]["stationName"] + " = null WHERE date = '" + workTable.Rows[i]["Date"].ToString() + "'", mysqlConn
                                            );
                                        mysqlCmdUpdatePM10.ExecuteNonQuery();
                                        break;
                                    case "PM2.5":
                                        MySqlCommand mysqlCmdUpdatePM25 = new MySqlCommand(
                                            "UPDATE readingsaqipm25 SET " + stationTable.Rows[y]["stationName"] + " = null WHERE date = '" + workTable.Rows[i]["Date"].ToString() + "'", mysqlConn
                                            );
                                        mysqlCmdUpdatePM25.ExecuteNonQuery();
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        y++;
                    }

                    if (multipleDateCount == 0) {
                        mysqlCmdInsert.ExecuteNonQuery();
                    }                    
                    if (multipleDateCountAQI == 0)
                    {
                        switch (selectedReadingDesc)
                        {
                            case "PM10":
                                mysqlCmdInsertAQIPM10.ExecuteNonQuery();
                                break;
                            case "PM2.5":
                                mysqlCmdInsertAQIPM25.ExecuteNonQuery();
                                break;
                            default:
                                break;
                        }
                    }

                    i++;

                }

               this.CloseConnection();
                return true;                
            }
            else
            {
                return false;
            }
        }

        private double computeAQI(string selectedPollutant, double reading)
        {
            double aqi;
            switch (selectedPollutant)
            {
                case "PM10":
                    if(reading >= 0 && reading < 55)
                    {
                        aqi = Math.Round(((50.0 - 0.0) / (54.0 - 0.0)) * (reading - 0.0) + 0.0 , 0);
                    }
                    else if (reading >= 55 && reading < 155)
                    {
                        aqi = Math.Round(((100.0 - 51.0) / (154.0 - 55.0)) * (reading - 55.0) + 51.0, 0);
                    }
                    else if (reading >= 155 && reading < 255)
                    {
                        aqi = Math.Round(((150.0 - 101.0) / (254.0 - 155.0)) * (reading - 155.0) + 101.0, 0);
                    }
                    else if (reading >= 255 && reading < 355)
                    {
                        aqi = Math.Round(((200.0 - 151.0) / (354.0 - 255.0)) * (reading - 255.0) + 151.0, 0);
                    }
                    else if (reading >= 355 && reading < 455)
                    {
                        aqi = Math.Round(((300.0 - 201.0) / (454.0 - 355.0)) * (reading - 355.0) + 201.0, 0);
                    }
                    else if (reading >= 455 && reading < 505)
                    {
                        aqi = Math.Round(((400.0 - 301.0) / (504.0 - 455.0)) * (reading - 455.0) + 301.0, 0);
                    }
                    else if (reading >= 505 && reading <= 604)
                    {
                        aqi = Math.Round(((500.0 - 401.0) / (604.0 - 505.0)) * (reading - 505.0) + 401.0, 0);
                    } else
                    {
                        aqi = -1;
                    }
                    break;
                case "PM2.5":
                    if (reading >= 0 && reading < 12.1)
                    {
                        aqi = Math.Round(((50.0 - 0.0) / (12.0 - 0.0)) * (reading - 0.0) + 0.0, 0);
                    }
                    else if (reading >= 12.1 && reading < 35.5)
                    {
                        aqi = Math.Round(((100.0 - 51.0) / (35.4 - 12.1)) * (reading - 12.1) + 51.0, 0);
                    }
                    else if (reading >= 35.5 && reading < 55.5)
                    {
                        aqi = Math.Round(((150.0 - 101.0) / (55.4 - 35.5)) * (reading - 35.5) + 101.0, 0);
                    }
                    else if (reading >= 55.5 && reading < 150.5)
                    {
                        aqi = Math.Round(((200.0 - 151.0) / (150.4 - 55.5)) * (reading - 55.5) + 151.0, 0);
                    }
                    else if (reading >= 150.5 && reading < 250.5)
                    {
                        aqi = Math.Round(((300.0 - 201.0) / (250.4 - 150.5)) * (reading - 150.5) + 201.0, 0);
                    }
                    else if (reading >= 250.5 && reading < 350.5)
                    {
                        aqi = Math.Round(((400.0 - 301.0) / (350.4 - 250.5)) * (reading - 250.5) + 301.0, 0);
                    }
                    else if (reading >= 350.5 && reading <= 500.4)
                    {
                        aqi = Math.Round(((500.0 - 401.0) / (500.4 - 350.5)) * (reading - 350.5) + 401.0, 0);
                    }
                    else
                    {
                        aqi = -1;
                    }
                    break;
                default:
                    aqi = -1;
                    break;
            }                       
            return aqi;
        }

        private string addStation(string stationText, int stationType)
        {
            if (this.OpenConnection() == true)
            {
                DataTable readingTable = new DataTable();

                //Collect tables to modify
                MySqlCommand mysqlCmd2 = new MySqlCommand(
                    "SELECT readingName FROM readingtablenames", mysqlConn
                    );
                MySqlDataAdapter adapter = new MySqlDataAdapter(mysqlCmd2);
                adapter.Fill(readingTable);

                //Parse text input
                string stationColumn = "";
                stationColumn = stationText;
                stationColumn = stationColumn.Replace("Station", "").Replace(" ", "");
                stationColumn = string.Concat("station", stationColumn);
                string stationDesc = "";
                stationDesc = stationText;
                stationDesc = stationDesc.Replace(" Station", "");
                stationDesc = string.Concat(stationDesc, " Station");
                //Station type tag
                string stationColumnType = "";
                switch (stationType)
                {
                    case 1:
                        stationColumnType = "roadside";
                        break;
                    case 2:
                        stationColumnType = "ambient";
                        break;
                }

                //Check for existing stations
                mysqlCmd2.CommandText = "SELECT stationName FROM stations WHERE stationName = '" + stationColumn + "'";
                string existingStation = (mysqlCmd2.ExecuteScalar() + "");

                //if (!string.IsNullOrEmpty(existingStation))                                           //Delete switch
                if (string.IsNullOrEmpty(existingStation))                                              //Add switch
                {
                    int i = 0;
                    while (i < readingTable.Rows.Count)
                    {
                        MySqlCommand mysqlCmd = new MySqlCommand(
                            "ALTER TABLE " + readingTable.Rows[i]["readingName"] +
                            //" DROP COLUMN " + stationColumn, mysqlConn                                //Delete switch
                            " ADD COLUMN " + stationColumn +                                            //Add switch
                            " DOUBLE", mysqlConn                                                        //Add switch
                        );
                        mysqlCmd.ExecuteNonQuery();
                        i++;
                    }

                    MySqlCommand mysqlCmd3 = new MySqlCommand(
                        //"DELETE FROM stations WHERE stationName ='" + stationColumn + "'", mysqlConn                                              //Delete switch
                        "INSERT INTO stations (stationName, stationDesc, stationType) VALUES ('" + stationColumn + "','" + stationDesc + "', '" + stationColumnType + "')", mysqlConn         //Add switch
                        );
                    mysqlCmd3.ExecuteNonQuery();
                }
                else
                {
                    stationDesc = "existing";
                }

                this.CloseConnection();

                return stationDesc;
            }       
            else
            {
                return null;
            }
        }

        private void buttonAddSpreadsheet_Click(object sender, EventArgs e)
        {
            string selectedReadingDesc = this.comboBoxDatabaseReading.GetItemText(this.comboBoxDatabaseReading.SelectedItem);

            dataGridView1.DataSource = null;

            //Show loading elements
            progressBar1.Visible = true;
            labelLoading.Visible = true;
            labelLoading.Text = "Adding...";
            Cursor = Cursors.WaitCursor;

            //Disable all controls
            panelMiscControls.Enabled = false;
            groupBoxAddStation.Enabled = false;
            panelSpreadsheetControls.Enabled = false;
            panelAddSpreadsheet.Enabled = false;

            bool addSuccess = false;
            bwAdd = new BackgroundWorker();
            bwAdd.DoWork += (s, f) =>
            {
                addSuccess = UpdateMySQLDatabase(selectedReadingDesc);
            };
            bwAdd.RunWorkerCompleted += (s, f) => {
                this.Invoke(new Action(() => {
                    //Hide loading elements
                    labelLoading.Visible = false;
                    progressBar1.Visible = false;
                    Cursor = Cursors.Default;

                    if (addSuccess)
                    {
                        MessageBox.Show("Spreadsheet added to database.", "Success");
                    }
                    else
                    {
                        MessageBox.Show("Error in adding spreadsheet to database.", "Error!");
                    }
                    
                    //Restore controls to default state
                    panelMiscControls.Enabled = true;
                    groupBoxAddStation.Enabled = true;
                    panelSpreadsheetControls.Enabled = true;
                    comboBoxDatabaseReading.DataSource = null;
                    labelFileName.Text = "No file selected";
                }));
            };
            bwAdd.RunWorkerAsync();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }

        private void buttonTruncate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Truncate all readings tables? This will delete all recorded data.", "DEBUG", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand truncateComm = new MySqlCommand(
                    "TRUNCATE TABLE readingspm10", mysqlConn
                    );
                    truncateComm.ExecuteNonQuery();
                    MySqlCommand truncateComm2 = new MySqlCommand(
                    "TRUNCATE TABLE readingspm25", mysqlConn
                    );
                    truncateComm2.ExecuteNonQuery();
                    MySqlCommand truncateComm4 = new MySqlCommand(
                    "TRUNCATE TABLE readingsaqipm10", mysqlConn
                    );
                    truncateComm4.ExecuteNonQuery();
                    MySqlCommand truncateComm5 = new MySqlCommand(
                    "TRUNCATE TABLE readingsaqipm25", mysqlConn
                    );
                    truncateComm5.ExecuteNonQuery();
                    this.CloseConnection();

                    MessageBox.Show("Truncate operation completed.", "DEBUG");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelAddSpreadsheet.Enabled = false;

            buttonAddStation.Enabled = false;
            radioButtonStationRoadside.Enabled = false;
            radioButtonStationAmbient.Enabled = false;
            radioButtonStationRoadside.Checked = true;

            if (user.account == "admin")
            {
                groupBoxDebug.Visible = true;
                groupBoxRegister.Visible = true;
                buttonRegister.Enabled = false;
                buttonDeauthorize.Enabled = false;
            }
            else
            {
                groupBoxDebug.Visible = false;
                groupBoxRegister.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bwOpen.IsBusy || bwAdd.IsBusy || bwStation.IsBusy)
            {
                MessageBox.Show("Please wait for current tasks to complete before exiting the program.", "Caution");
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        private string getFile()
        {
            OpenFileDialog spreadsheetFile = new OpenFileDialog();
            spreadsheetFile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            spreadsheetFile.FilterIndex = 1;

            if (spreadsheetFile.ShowDialog() == DialogResult.OK)
            {
                return spreadsheetFile.FileName;
            }
            else
            {
                return null;
            }
        }

        private void buttonOpenSpreadsheet_Click(object sender, EventArgs e)
        {
            string fileName = getFile();
            error = new Exception();

            if (fileName != null)
            {
                //labelFileName.Text = "Selected file: " + fileName.Split('\\').Last();

                dataGridView1.DataSource = null;

                //Show loading elements
                progressBar1.Visible = true;
                labelLoading.Visible = true;
                labelLoading.Text = "Opening...";
                Cursor = Cursors.WaitCursor;

                //Disable all controls
                panelMiscControls.Enabled = false;
                groupBoxAddStation.Enabled = false;
                panelSpreadsheetControls.Enabled = false;
                panelAddSpreadsheet.Enabled = false;
                comboBoxDatabaseReading.DataSource = null;
                comboBoxDatabaseReading.Items.Clear();

                bwOpen = new BackgroundWorker();
                bwOpen.DoWork += (s, f) =>
                {
                     importData(fileName);
                };
                bwOpen.RunWorkerCompleted += (s, f) => {
                    this.Invoke(new Action(() => {
                        //Hide loading elements
                        labelLoading.Visible = false;
                        progressBar1.Visible = false;
                        Cursor = Cursors.Default;

                        //Restore controls to default state
                        panelMiscControls.Enabled = true;
                        groupBoxAddStation.Enabled = true;
                        panelSpreadsheetControls.Enabled = true;

                        if (workTable.Rows.Count > 0)
                        {
                            labelFileName.Text = "Selected file: " + fileName.Split('\\').Last();

                            //Prepare "Add Spreadsheet to Database" elements
                            panelAddSpreadsheet.Enabled = true;
                            buttonAddSpreadsheet.Enabled = false;
                            comboBoxDatabaseReading.Enabled = true;
                            comboBoxDatabaseReading.DataSource = null;
                            comboBoxDatabaseReading.Items.Clear();
                            comboBoxDatabaseReading.Items.Add("Select which pollutant");
                            comboBoxDatabaseReading.SelectedItem = "Select which pollutant";

                            dataGridView1.DataSource = workTable;
                            dataGridView1.ClearSelection();
                        }
                        else
                        {
                            labelFileName.Text = "No file selected";
                            if (error is System.InvalidOperationException)
                            {
                                MessageBox.Show("Access Database Engine is not installed or version is not compatible with application build.", "Error!");
                            }
                            if (error is System.Data.OleDb.OleDbException)
                            {
                                MessageBox.Show(fileName.Split('\\').Last() + " is an empty or invalid spreadsheet.", "Error!");
                            }                                
                        }
                    }));
                };
                bwOpen.RunWorkerAsync();
            }
            else if (dataGridView1.DataSource == null)
            {
                labelFileName.Text = "No file selected";
            }
        }

        private void comboBoxDatabaseReading_SelectionChangeCommitted(object sender, EventArgs e)
        {
            buttonAddSpreadsheet.Enabled = true;
        }

        private void textBoxStationName_TextChanged(object sender, EventArgs e)
        {
            if(textBoxStationName.Text.Length > 0)
            {
                buttonAddStation.Enabled = true;
                radioButtonStationRoadside.Enabled = true;
                radioButtonStationAmbient.Enabled = true;
            }
            else
            {
                buttonAddStation.Enabled = false;
                radioButtonStationRoadside.Enabled = false;
                radioButtonStationAmbient.Enabled = false;
            }
        }

        private void buttonAddStation_Click(object sender, EventArgs e)
        {
            string stationText = textBoxStationName.Text;
            int stationType = 0;

            if (radioButtonStationRoadside.Checked)
            {
                stationType = 1;
            }
            else if (radioButtonStationAmbient.Checked)
            {
                stationType = 2;
            }

            //Show loading elements
            labelStationLoading.Visible = true;
            Cursor = Cursors.WaitCursor;

            //Disable all controls
            panelMiscControls.Enabled = false;
            panelStation.Enabled = false;
            groupBoxAddSpreadsheet.Enabled = false;

            string station = "";
            bwStation = new BackgroundWorker();
            bwStation.DoWork += (s, f) =>
            {
                station = addStation(stationText, stationType);
            };
            bwStation.RunWorkerCompleted += (s, f) => {
                this.Invoke(new Action(() => {
                    //Hide loading elements
                    labelStationLoading.Visible = false;
                    Cursor = Cursors.Default;

                    if (!string.IsNullOrEmpty(station) && station != "existing")
                    {
                        MessageBox.Show(station + " added to database.", "Success");
                        textBoxStationName.Clear();
                    }
                    else if (station == "existing")
                    {
                        MessageBox.Show("Station already exists in database.", "Error!");
                    }
                    else
                    {
                        MessageBox.Show("Error in adding station to database.", "Error!");
                    }

                    //Restore controls to default state
                    panelMiscControls.Enabled = true;
                    panelStation.Enabled = true;
                    groupBoxAddSpreadsheet.Enabled = true;

                    textBoxStationName.Focus();
                    buttonAddStation.Enabled = false;
                }));
            };
            bwStation.RunWorkerAsync();
        }

        private void comboBoxDatabaseReading_DropDown(object sender, EventArgs e)
        {
            if (comboBoxDatabaseReading.Items.Contains("Select which pollutant"))
            {
                comboBoxDatabaseReading.Items.Remove("Select which pollutant");
            }
            populateReadingNamesTable();
            buttonAddSpreadsheet.Enabled = true;
        }

        private void buttonDeleteStation_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete all stations? This will delete all station columns and their readings data.", "DEBUG", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.OpenConnection() == true)
                {
                    DataTable readingTable = new DataTable();
                    DataTable stationsTable = new DataTable();

                    //Collect tables to modify
                    MySqlCommand mysqlCmd2 = new MySqlCommand(
                        "SELECT readingName FROM readingtablenames", mysqlConn
                        );
                    MySqlDataAdapter adapter = new MySqlDataAdapter(mysqlCmd2);
                    adapter.Fill(readingTable);
                    //Collect stations to delete
                    mysqlCmd2.CommandText = "SELECT stationName from stations";
                    adapter.Fill(stationsTable);

                    int x = 0;
                    int i = 0;
                    while (x < stationsTable.Rows.Count)
                    {
                        string stationColumn = stationsTable.Rows[x][0].ToString();
                        i = 0;
                        while (i < readingTable.Rows.Count)
                        {
                            MySqlCommand mysqlCmd = new MySqlCommand(
                                "ALTER TABLE " + readingTable.Rows[i]["readingName"] +
                                " DROP COLUMN " + stationColumn, mysqlConn
                            );
                            mysqlCmd.ExecuteNonQuery();
                            i++;
                        }
                        MySqlCommand mysqlCmd3 = new MySqlCommand(
                                "DELETE FROM stations WHERE stationName ='" + stationColumn + "'", mysqlConn
                            );
                        mysqlCmd3.ExecuteNonQuery();

                        x++;
                    }
                    this.CloseConnection();

                    MessageBox.Show("Station deletion operation completed.", "DEBUG");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxRegisterPassword.Text == textBoxRegisterRePassword.Text)
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand mysqlCmd = new MySqlCommand(
                    "SELECT username FROM users WHERE username = '" + textBoxRegisterUsername.Text + "'", mysqlConn
                        );
                    string username = Convert.ToString(mysqlCmd.ExecuteScalar() + "");
                    if (string.IsNullOrEmpty(username))
                    {
                        mysqlCmd.CommandText = "INSERT INTO users (username, password) VALUES ('" + textBoxRegisterUsername.Text + "', '" + textBoxRegisterPassword.Text + "')";
                        mysqlCmd.ExecuteNonQuery();
                        this.CloseConnection();
                        MessageBox.Show("User " + textBoxRegisterUsername.Text + " registered.", "Success");
                        textBoxRegisterUsername.Clear();
                        textBoxRegisterPassword.Clear();
                        textBoxRegisterRePassword.Clear();
                    }
                    else
                    {
                        this.CloseConnection();
                        MessageBox.Show("User " + textBoxRegisterUsername.Text + " already exists.", "Error");
                    }
                }
                labelRegisterError.Visible = false;
                textBoxRegisterUsername.Focus();
            }
            else
            {
                labelRegisterError.Visible = true;
            }
            buttonRegister.Enabled = false;
        }

        private void textBoxRegisterUsername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRegisterUsername.Text.Length > 0 && textBoxRegisterPassword.Text.Length > 0 && textBoxRegisterRePassword.Text.Length > 0)
            {
                buttonRegister.Enabled = true;
            }
            else
            {
                buttonRegister.Enabled = false;
            }
        }

        private void textBoxRegisterPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRegisterUsername.Text.Length > 0 && textBoxRegisterPassword.Text.Length > 0 && textBoxRegisterRePassword.Text.Length > 0)
            {
                buttonRegister.Enabled = true;
            }
            else
            {
                buttonRegister.Enabled = false;
            }
        }

        private void textBoxRegisterRePassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRegisterUsername.Text.Length > 0 && textBoxRegisterPassword.Text.Length > 0 && textBoxRegisterRePassword.Text.Length > 0)
            {
                buttonRegister.Enabled = true;
            }
            else
            {
                buttonRegister.Enabled = false;
            }
        }

        private void textBoxDeauthorize_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDeauthorize.Text.Length > 0)
            {
                buttonDeauthorize.Enabled = true;
            }
            else
            {
                buttonDeauthorize.Enabled = false;
            }
        }

        private void buttonDeauthorize_Click(object sender, EventArgs e)
        {
            if (textBoxDeauthorize.Text != "admin")
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand mysqlCmd = new MySqlCommand(
                        "SELECT username FROM users WHERE username = '" + textBoxDeauthorize.Text + "'", mysqlConn
                        );
                    string username = Convert.ToString(mysqlCmd.ExecuteScalar() + "");
                    if (!string.IsNullOrEmpty(username))
                    {
                        mysqlCmd.CommandText = "DELETE FROM users WHERE username = '" + username + "'";
                        mysqlCmd.ExecuteNonQuery();
                        this.CloseConnection();
                        MessageBox.Show("User " + username + " deauthorized.", "Success");
                        textBoxDeauthorize.Clear();
                    }
                    else
                    {
                        this.CloseConnection();
                        MessageBox.Show("User " + textBoxDeauthorize.Text + " does not exist.", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Cannot delete admin account.", "Stupid");
                textBoxDeauthorize.Clear();
            }
            buttonDeauthorize.Enabled = false;
            textBoxDeauthorize.Focus();
        }
    }
}
