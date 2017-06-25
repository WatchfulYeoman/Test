using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OLEDB_Example
{
    public partial class Form3 : Form
    {
        private MySqlConnection mysqlConn;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Form3()
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
            //AQI levels        
            tooltip.SetToolTip(label17, "Air quality is considered satisfactory, and air pollution poses little or no risk.");
            tooltip.SetToolTip(label18, "Air quality is acceptable; however, for some pollutants there may be a moderate health concern for a very small number of people who are unusually sensitive to air pollution.");
            tooltip.SetToolTip(label19, "Members of sensitive groups may experience health effects. The general public is not likely to be affected. ");
            tooltip.SetToolTip(label20, "Everyone may begin to experience health effects; members of sensitive groups may experience more serious health effects.");
            tooltip.SetToolTip(label21, "Health alert: everyone may experience more serious health effects.");
            tooltip.SetToolTip(label22, "Health warnings of emergency conditions. The entire population is more likely to be affected.");

            //Control objects
            tooltip.SetToolTip(checkBoxIncludeForecasts, "Deselect if you only want to view actual data");
            tooltip.SetToolTip(buttonCopyNotes, "Copy reports to clipboard");

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

        private void populateReadingNamesTable()
        {
            if (this.OpenConnection() == true)
            {
                DataTable readingNameTable = new DataTable("dtReadingNames");
                //DataTable readingNameTable2 = new DataTable("dtReadingNames2");

                //Collect reading table names from DB table readingtablenames and fill DT readingNameTable
                MySqlCommand mysqlCmd = new MySqlCommand(
                    //"SELECT * FROM readingtablenames", mysqlConn
                    "SELECT * FROM readingtablenames ORDER BY CASE WHEN readingdesc LIKE 'pm%' THEN 1 ELSE 2 END", mysqlConn
                    );
                MySqlDataAdapter adapter = new MySqlDataAdapter(mysqlCmd);
                readingNameTable.Clear();
                readingNameTable.Columns.Clear();
                adapter.Fill(readingNameTable);

                this.CloseConnection();

                /*
                readingNameTable2.Clear();
                readingNameTable2.Columns.Clear();
                readingNameTable2 = readingNameTable.Copy();
                */

                //Populate reading names comboBoxes
                comboBoxReading.DataSource = readingNameTable;
                comboBoxReading.DisplayMember = readingNameTable.Columns["readingDesc"].ToString();
                //comboBoxReading.DataSource = readingNameTable2;
                //comboBoxReading.DisplayMember = readingNameTable2.Columns["readingDesc"].ToString();
            }
        }

        private void populateStationsTable(int stationType)
        {
            if (this.OpenConnection() == true)
            {
                DataTable stationTable = new DataTable("dtStations");

                //Collect station names from DB table stations and fill DT stationTable
                MySqlCommand mysqlCmd = new MySqlCommand(
                    "SELECT stationDesc FROM stations", mysqlConn
                    );
                switch (stationType)
                {
                    case 0:
                        mysqlCmd.CommandText = "SELECT stationDesc FROM stations";
                        break;
                    case 1:
                        mysqlCmd.CommandText = "SELECT stationDesc FROM stations WHERE stationType = 'roadside'";
                        break;
                    case 2:
                        mysqlCmd.CommandText = "SELECT stationDesc FROM stations WHERE stationType = 'ambient'";
                        break;
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(mysqlCmd);
                stationTable.Clear();
                stationTable.Columns.Clear();
                adapter.Fill(stationTable);

                this.CloseConnection();

                int i = 0;
                while (i < stationTable.Rows.Count)
                {
                    listBoxCollection.Items.Add(stationTable.Rows[i][0].ToString());
                    i++;
                }
            }
        }

        private void generateTable(string selectedReadingName, string startDate, string endDate, DateTime startDateDT, DateTime endDateDT)
        {
            if (this.OpenConnection() == true)
            {
                //Select stations
                string selectedStations = "";
                int i = 0;
                while (i < listBoxSelected.Items.Count)
                {
                    selectedStations = string.Concat(selectedStations, "'", listBoxSelected.Items[i].ToString());
                    i++;
                    if (i < listBoxSelected.Items.Count)
                        selectedStations = string.Concat(selectedStations, "', ");
                    else
                        selectedStations = string.Concat(selectedStations, "'");
                }

                DataTable stationTable = new DataTable("dtStations");
                MySqlCommand mysqlCmdStations = new MySqlCommand(
                    "SELECT * FROM stations WHERE stationDesc in (" + selectedStations + ") ORDER BY stationDesc", mysqlConn
                    );
                MySqlDataAdapter adapter = new MySqlDataAdapter(mysqlCmdStations);
                stationTable.Clear();
                stationTable.Columns.Clear();
                adapter.Fill(stationTable);

                string stationColumns = "";
                i = 0;
                while (i < stationTable.Rows.Count)
                {
                    stationColumns = string.Concat(stationColumns, stationTable.Rows[i]["stationName"].ToString());
                    i++;
                    if (i < stationTable.Rows.Count)
                        stationColumns = string.Concat(stationColumns, ", ");
                }

                //Get rows
                DataTable readingsTable = new DataTable("dtReadings");
                MySqlCommand mysqlCmdSelect = new MySqlCommand(
                    "SELECT date, " + stationColumns + " FROM " + selectedReadingName + " WHERE date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY date ASC", mysqlConn
                    );
                adapter.SelectCommand = mysqlCmdSelect;
                readingsTable.Clear();
                readingsTable.Columns.Clear();
                adapter.Fill(readingsTable);

                if (checkBoxIncludeForecasts.Checked)
                {
                    readingsTable = forecast(selectedReadingName, stationTable, readingsTable, endDateDT, startDate, endDate);
                    readingsTable = trimForecasts(startDateDT, endDateDT, readingsTable);
                }

                if (notNullCells(readingsTable) > 0)
                {
                    readingsTable = appendBlankDatesRows(readingsTable, startDateDT, endDateDT);
                    readingsTable = tableColumnCleanUp(readingsTable, stationTable);
                    summarizeReport(readingsTable, startDate, endDate);
                    if (radioButtonFilterEnable.Checked)
                    {
                        readingsTable = filterTable(readingsTable, selectedReadingName);
                    }
                    dataGridView1.DataSource = readingsTable;
                    dataGridView1.Sort(dataGridView1.Columns["Date"], ListSortDirection.Ascending);
                    dataGridView1.Columns[0].HeaderCell.Value = "Date";
                    colorizeGrid(dataGridView1, selectedReadingName);
                    if (checkBoxIncludeForecasts.Checked)
                    {
                        emboldenGrid(selectedReadingName, startDateDT, startDate, endDate);
                    }
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("No data found with corresponding parameters.", "Caution");
                }

                this.CloseConnection();
            }
        }

        private int notNullCells(DataTable readingsTable)
        {
            int i = 1;
            int notNullCells = 0;
            while (i < readingsTable.Columns.Count)
            {
                DataRow[] result = readingsTable.Select(readingsTable.Columns[i].ColumnName + " is not null");
                foreach (DataRow row in result)
                {
                    notNullCells++;
                }
                i++;
            }
            return notNullCells;
        }

        private DataTable appendBlankDatesRows(DataTable readingsTable, DateTime startDateDT, DateTime endDateDT)
        {
            int i = 0;
            string stringFirstDate = "";
            DateTime firstDate;
            string stringLastDate = "";
            DateTime lastDate;

            string stringDateUno = "";
            DateTime dateUno;
            string stringDateDos = "";
            DateTime dateDos;
            stringFirstDate = Convert.ToString(readingsTable.Rows[0][0]);
            stringFirstDate = Convert.ToDateTime(stringFirstDate).ToString("dd/MM/yyyy");
            firstDate = DateTime.ParseExact(stringFirstDate, "dd/MM/yyyy", null);
            stringLastDate = Convert.ToString(readingsTable.Rows[readingsTable.Rows.Count - 1][0]);
            stringLastDate = Convert.ToDateTime(stringLastDate).ToString("dd/MM/yyyy");
            lastDate = DateTime.ParseExact(stringLastDate, "dd/MM/yyyy", null);

            //Append rows at the beginning of the table
            i = 0;
            int numberOfDays = (firstDate - startDateDT).Days;
            if (numberOfDays > 0)
            {
                while (i < numberOfDays)
                {
                    DataRow blankRows = readingsTable.NewRow();
                    blankRows["date"] = startDateDT.AddDays(i);
                    readingsTable.Rows.Add(blankRows);
                    i++;
                }
            }

            //Fill gaps in the middle of the table
            i = 0;
            while (i < readingsTable.Rows.Count - 1)
            {
                stringDateUno = Convert.ToString(readingsTable.Rows[i][0]);
                stringDateUno = Convert.ToDateTime(stringDateUno).ToString("dd/MM/yyyy");
                dateUno = DateTime.ParseExact(stringDateUno, "dd/MM/yyyy", null);
                stringDateDos = Convert.ToString(readingsTable.Rows[i + 1][0]);
                stringDateDos = Convert.ToDateTime(stringDateDos).ToString("dd/MM/yyyy");
                dateDos = DateTime.ParseExact(stringDateDos, "dd/MM/yyyy", null);

                numberOfDays = (dateDos - dateUno).Days;

                if (numberOfDays - 1 > 1)
                {
                    int z = 1;
                    while (z < numberOfDays)
                    {
                        DataView dv = readingsTable.DefaultView;
                        dv.Sort = "Date asc";
                        readingsTable = dv.ToTable();
                        DataRow blankRows = readingsTable.NewRow();
                        blankRows["date"] = dateUno.AddDays(z);
                        readingsTable.Rows.Add(blankRows);
                        z++;
                    }
                }
                i++;
            }

            //Append rows at the end of the table
            i = 0;
            numberOfDays = (endDateDT - lastDate).Days;
            lastDate = lastDate.AddDays(1);
            if (numberOfDays > 0)
            {
                while (i < numberOfDays)
                {
                    DataRow blankRows = readingsTable.NewRow();
                    blankRows["date"] = lastDate.AddDays(i);
                    readingsTable.Rows.Add(blankRows);
                    i++;
                }
            }

            return readingsTable;
        }

        private void emboldenGrid(string selectedReadingName, DateTime startDate, string stringStartDate, string stringEndDate)
        {
            MySqlCommand mysqlCmdSelect = new MySqlCommand(
                "SELECT date FROM " + selectedReadingName, mysqlConn
                );
            MySqlCommand mysqlCmdStation = new MySqlCommand(
                 "SELECT stationName FROM stations WHERE stationDesc = ''", mysqlConn
                );
            MySqlDataAdapter adapter = new MySqlDataAdapter(mysqlCmdSelect);
            string selectedStation = "";
            string stringLastDate = "";
            DateTime lastDate;
            DateTime originalStartDate = startDate;

            string date;
            DateTime dateDT = new DateTime();

            int i = 0;
            int z = 1;

            //while (z < listBoxSelected.Items.Count)
            while (z < dataGridView1.Columns.Count)
            {
                //mysqlCmdStation.CommandText = "SELECT stationName FROM stations WHERE stationDesc = '" + listBoxSelected.Items[z].ToString() + "'";
                mysqlCmdStation.CommandText = "SELECT stationName FROM stations WHERE stationDesc = '" + dataGridView1.Columns[z].Name + "'";
                selectedStation = (mysqlCmdStation.ExecuteScalar() + "");

                mysqlCmdSelect.CommandText = "SELECT date FROM " + selectedReadingName + " WHERE " + selectedStation + " IS NOT NULL AND date BETWEEN '" + stringStartDate + "' AND '" + stringEndDate + "' ORDER BY date DESC LIMIT 1";
                stringLastDate = Convert.ToString(mysqlCmdSelect.ExecuteScalar() + "");
                if (string.IsNullOrEmpty(stringLastDate))
                {
                    mysqlCmdSelect.CommandText = "SELECT date FROM " + selectedReadingName + " WHERE " + selectedStation + " IS NOT NULL ORDER BY date DESC LIMIT 1";
                    stringLastDate = Convert.ToString(mysqlCmdSelect.ExecuteScalar() + "");
                }
                if (!string.IsNullOrEmpty(stringLastDate))
                {
                    stringLastDate = Convert.ToDateTime(stringLastDate).ToString("dd/MM/yyyy");
                    lastDate = DateTime.ParseExact(stringLastDate, "dd/MM/yyyy", null);
                   
                    /*DataRow[] findRow = readingsTable.Select("date = '" + lastDate.ToString("MM/dd/yyyy") + "'");
                    if (findRow.Length > 0)
                        i = readingsTable.Rows.IndexOf(findRow[0]) + 1;
                    */

                    i = 0;
                    startDate = originalStartDate;
                    while (i < dataGridView1.Rows.Count)
                    {
                        //New method
                        date = dataGridView1[0, i].Value.ToString().Split(' ').First();
                        date = Convert.ToDateTime(date).ToString("dd/MM/yyyy");
                        dateDT = DateTime.ParseExact(date, "dd/MM/yyyy", null);
                        if (dateDT > lastDate)
                            dataGridView1[z, i].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);

                        /*                                             
                        if (startDate.AddDays(i) > lastDate)
                            dataGridView1[listBoxSelected.Items[z].ToString(), i].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);                        
                        */
                        i++;
                    }
                }
                z++;
            }
        }

        private DataTable trimForecasts(DateTime startDate, DateTime endDate, DataTable readingsTable)
        {
            DataView dv = readingsTable.DefaultView;
            dv.Sort = "Date asc";
            readingsTable = dv.ToTable(); 

            DataTable lastRows = new DataTable();
            lastRows = readingsTable.Clone();
            DataRow row;
            DataRow[] findRowStart = readingsTable.Select("date = '" + startDate.ToString("MM/dd/yyyy") + "'");
            DataRow[] findRowEnd = readingsTable.Select("date = '" + endDate.ToString("MM/dd/yyyy") + "'");
            if (findRowStart.Length > 0 && findRowEnd.Length > 0)
            {
                int i = readingsTable.Rows.IndexOf(findRowStart[0]);
                int x = readingsTable.Rows.IndexOf(findRowEnd[0]);
                while (i <= x)
                {
                    row = readingsTable.Rows[i];
                    lastRows.ImportRow(row);
                    i++;
                }
                readingsTable.Clear();
                readingsTable.Columns.Clear();
                readingsTable = lastRows.Copy();
            } else
            {
                //readingsTable.Clear();
            }
            return readingsTable;     
        }

        private DataTable forecast(string reading, DataTable stationTable, DataTable readingsTable, DateTime endDate, string stringStartDate, string stringEndDate)
        {
            //MySQL interaction variables
            MySqlCommand mysqlCmdSelect = new MySqlCommand(
                "SELECT date FROM " + reading, mysqlConn
                );
            MySqlCommand mysqlCmdStation = new MySqlCommand(
                 "SELECT stationName FROM stations WHERE stationDesc = ''", mysqlConn
                );
            MySqlDataAdapter adapter = new MySqlDataAdapter(mysqlCmdSelect);

            //Misc variables
            DataTable selectTable = new DataTable("dtSelect");
            string selectedStation = "";

            //Date range handler variables
            string stringLastDate;
            DateTime lastDate;
            int numberOfDays = 0;

            //Loop counters
            int z = 0;
            int i = 0;
            while (z < listBoxSelected.Items.Count)
            {
                mysqlCmdStation.CommandText = "SELECT stationName FROM stations WHERE stationDesc = '" + listBoxSelected.Items[z].ToString() + "'";
                selectedStation = (mysqlCmdStation.ExecuteScalar() + "");

                mysqlCmdSelect.CommandText = "SELECT date," + selectedStation + " FROM " + reading + " WHERE " + selectedStation + " IS NOT NULL ORDER BY date ASC";
                adapter.SelectCommand = mysqlCmdSelect;

                selectTable.Clear();
                selectTable.Columns.Clear();
                adapter.Fill(selectTable);

                if(selectTable.Rows.Count > 0)
                {
                    //Linear regression variables
                    int count = 0;              //x
                    int countSum = 0;           //summation of x
                    double sum = 0;             //y AKA reading
                    double sumOfXSquares = 0;   //x^2 AKA count^2
                    double sumOfProducts = 0;   //xy AKA count * reading
                    double commonDivisor = 0;
                    double yIntercept = 0;
                    double slope = 0;
                    i = 0;
                    while (i < selectTable.Rows.Count)
                    {
                        if (selectTable.Rows[i][selectedStation] != DBNull.Value)
                        {
                            sum += Convert.ToDouble(selectTable.Rows[i][selectedStation]);
                            count++;
                            countSum += count;
                            sumOfXSquares += Math.Pow(count, 2);
                            sumOfProducts += Convert.ToDouble(selectTable.Rows[i][selectedStation]) * count;
                        }
                        i++;
                    }
                    commonDivisor = ((count * sumOfXSquares) - Math.Pow(countSum, 2));
                    yIntercept = ((sum * sumOfXSquares) - (countSum * sumOfProducts)) / commonDivisor;
                    slope = ((count * sumOfProducts) - (countSum * sum)) / commonDivisor;

                    mysqlCmdSelect.CommandText = "SELECT date," + selectedStation + " FROM " + reading + " WHERE " + selectedStation + " IS NOT NULL ORDER BY date DESC";
                    adapter.SelectCommand = mysqlCmdSelect;

                    selectTable.Clear();
                    selectTable.Columns.Clear();
                    adapter.Fill(selectTable);

                    stringLastDate = Convert.ToString(selectTable.Rows[0]["date"]);
                    stringLastDate = Convert.ToDateTime(stringLastDate).ToString("dd/MM/yyyy");
                    stringLastDate = stringLastDate.Split(' ').First();
                    lastDate = DateTime.ParseExact(stringLastDate, "dd/MM/yyyy", null);
                    numberOfDays = (endDate - lastDate).Days;

                    i = 1;
                    while (i <= numberOfDays)
                    {
                        DataRow newForecastRow = readingsTable.NewRow();

                        lastDate = DateTime.ParseExact(stringLastDate, "dd/MM/yyyy", null).AddDays(i);

                        DataRow[] findRow = readingsTable.Select("date = '" + lastDate.ToString("MM/dd/yyyy") + "'");
                        if (findRow.Length > 0)
                        {
                            if (reading == "readingsaqipm10" || reading == "readingsaqipm25")
                            {
                                findRow[0][selectedStation] = Math.Round(yIntercept + (slope * (count + i)), 0);
                            }
                            else
                            {
                                findRow[0][selectedStation] = Math.Round(yIntercept + (slope * (count + i)), 2);
                            }
                        }
                        else
                        {
                            newForecastRow["date"] = lastDate.ToString("MM/dd/yyyy");
                            if (reading == "readingsaqipm10" || reading == "readingsaqipm25")
                            {
                                newForecastRow[selectedStation] = Math.Round(yIntercept + (slope * (count + i)), 0);
                            }
                            else
                            {
                                newForecastRow[selectedStation] = Math.Round(yIntercept + (slope * (count + i)), 2);
                            }
                            readingsTable.Rows.Add(newForecastRow);
                        }
                        i++;
                    }
                } 

                z++;
            }            
            return readingsTable;
        }

        private DataTable tableColumnCleanUp(DataTable readingsTable, DataTable stationTable)
        {
            readingsTable.Columns[0].ColumnName = "Date";
            //Rename stationName column names in workTable to stationDesc strings
            int x = 1;
            int y = 1;
            while (x < readingsTable.Columns.Count)
            {
                y = 1;
                while (y < readingsTable.Columns.Count)
                {
                    if (readingsTable.Columns[x].ColumnName == stationTable.Rows[y - 1]["stationName"].ToString())
                    {
                        readingsTable.Columns[x].ColumnName = stationTable.Rows[y - 1]["stationDesc"].ToString();
                    }
                    y++;
                }
                x++;
            }
            return readingsTable;
        }

        private DataTable filterTable(DataTable readingsTable, string selectedReading)
        {
            //DataTable readingsTable = (DataTable)grid.DataSource;

            DataTable filteredRows = new DataTable();
            filteredRows = readingsTable.Clone();
            DataRow row;

            int x = 0; //Column
            int y = 0; //Row
            bool skip = false;
            while (y < readingsTable.Rows.Count)
            {
                x = 1;
                skip = false;
                while (x < readingsTable.Columns.Count)
                {
                    switch (selectedReading)
                    {
                        case "readingsaqipm10":
                        case "readingsaqipm25":
                            if (readingsTable.Rows[y][x] != DBNull.Value && readingsTable.Rows[y][x] != null)
                            {
                                if (checkBoxFilterGood.Checked)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 0 && Convert.ToDouble(readingsTable.Rows[y][x]) < 51)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterModerate.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 51 && Convert.ToDouble(readingsTable.Rows[y][x]) < 101)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterSensitive.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 101 && Convert.ToDouble(readingsTable.Rows[y][x]) < 151)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterUnhealthy.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 151 && Convert.ToDouble(readingsTable.Rows[y][x]) < 201)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterVeryUnhealthy.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 201 && Convert.ToDouble(readingsTable.Rows[y][x]) < 301)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterHazardous.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 301 && Convert.ToDouble(readingsTable.Rows[y][x]) < 501)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                            }
                        break;
                        case "readingspm10":
                            if (readingsTable.Rows[y][x] != DBNull.Value && readingsTable.Rows[y][x] != null)
                            {
                                if (checkBoxFilterGood.Checked)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 0 && Convert.ToDouble(readingsTable.Rows[y][x]) < 55)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterModerate.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 55 && Convert.ToDouble(readingsTable.Rows[y][x]) < 155)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterSensitive.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 155 && Convert.ToDouble(readingsTable.Rows[y][x]) < 255)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterUnhealthy.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 255 && Convert.ToDouble(readingsTable.Rows[y][x]) < 355)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterVeryUnhealthy.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 355 && Convert.ToDouble(readingsTable.Rows[y][x]) < 425)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterHazardous.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 425 && Convert.ToDouble(readingsTable.Rows[y][x]) < 604)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                            }
                            break;
                        case "readingspm25":
                            if (readingsTable.Rows[y][x] != DBNull.Value && readingsTable.Rows[y][x] != null)
                            {
                                if (checkBoxFilterGood.Checked)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 0 && Convert.ToDouble(readingsTable.Rows[y][x]) < 12.1)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterModerate.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 12.1 && Convert.ToDouble(readingsTable.Rows[y][x]) < 35.5)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterSensitive.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 35.5 && Convert.ToDouble(readingsTable.Rows[y][x]) < 55.5)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterUnhealthy.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 55.5 && Convert.ToDouble(readingsTable.Rows[y][x]) < 150.5)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterVeryUnhealthy.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 150.5 && Convert.ToDouble(readingsTable.Rows[y][x]) < 250.5)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                                if (checkBoxFilterHazardous.Checked && !skip)
                                {
                                    if (Convert.ToDouble(readingsTable.Rows[y][x]) >= 250.5 && Convert.ToDouble(readingsTable.Rows[y][x]) < 500.4)
                                    {
                                        row = readingsTable.Rows[y];
                                        filteredRows.ImportRow(row);
                                        skip = true;
                                    }
                                }
                            }
                            break;
                    }
                    if (skip)
                        break;
                    x++;
                }
                y++;
            }
            //dataGridView1.DataSource = filteredRows;
            readingsTable = filteredRows.Copy();
            return readingsTable;
        }

        private void colorizeGrid(DataGridView grid, string reading)
        {
            //Colorize cells of given DataGridView according to AQI category
            int x = 1;      //Skip date column
            int y = 0;
            while (x < grid.Columns.Count)
            {
                y = 0;
                while (y < grid.Rows.Count)
                {
                    if (grid[x, y].Value != DBNull.Value && grid[x, y].Value != null)
                    {
                        switch (reading)
                        {
                            case "readingsaqipm10":
                            case "readingsaqipm25":
                                if (Convert.ToDouble(grid[x, y].Value) >= 0 && Convert.ToDouble(grid[x, y].Value) < 51)
                                {
                                    grid[x, y].Style.BackColor = Color.Lime;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 51 && Convert.ToDouble(grid[x, y].Value) < 101)
                                {
                                    grid[x, y].Style.BackColor = Color.Yellow;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 101 && Convert.ToDouble(grid[x, y].Value) < 151)
                                {
                                    grid[x, y].Style.BackColor = Color.Orange;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 151 && Convert.ToDouble(grid[x, y].Value) < 201)
                                {
                                    grid[x, y].Style.BackColor = Color.OrangeRed;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 201 && Convert.ToDouble(grid[x, y].Value) < 301)
                                {
                                    grid[x, y].Style.BackColor = Color.MediumVioletRed;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 301 && Convert.ToDouble(grid[x, y].Value) < 501)
                                {
                                    grid[x, y].Style.BackColor = Color.Firebrick;
                                }
                                break;
                            case "readingspm10":
                                if (Convert.ToDouble(grid[x, y].Value) >= 0 && Convert.ToDouble(grid[x, y].Value) < 55)
                                {
                                    grid[x, y].Style.BackColor = Color.Lime;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 55 && Convert.ToDouble(grid[x, y].Value) < 155)
                                {
                                    grid[x, y].Style.BackColor = Color.Yellow;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 155 && Convert.ToDouble(grid[x, y].Value) < 255)
                                {
                                    grid[x, y].Style.BackColor = Color.Orange;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 255 && Convert.ToDouble(grid[x, y].Value) < 355)
                                {
                                    grid[x, y].Style.BackColor = Color.OrangeRed;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 355 && Convert.ToDouble(grid[x, y].Value) < 425)
                                {
                                    grid[x, y].Style.BackColor = Color.MediumVioletRed;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 425 && Convert.ToDouble(grid[x, y].Value) <= 604)
                                {
                                    grid[x, y].Style.BackColor = Color.Firebrick;
                                }
                                break;
                            case "readingspm25":
                                if (Convert.ToDouble(grid[x, y].Value) >= 0 && Convert.ToDouble(grid[x, y].Value) < 12.1)
                                {
                                    grid[x, y].Style.BackColor = Color.Lime;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 12.1 && Convert.ToDouble(grid[x, y].Value) < 35.5)
                                {
                                    grid[x, y].Style.BackColor = Color.Yellow;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 35.5 && Convert.ToDouble(grid[x, y].Value) < 55.5)
                                {
                                    grid[x, y].Style.BackColor = Color.Orange;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 55.5 && Convert.ToDouble(grid[x, y].Value) < 150.5)
                                {
                                    grid[x, y].Style.BackColor = Color.OrangeRed;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 150.5 && Convert.ToDouble(grid[x, y].Value) < 250.5)
                                {
                                    grid[x, y].Style.BackColor = Color.MediumVioletRed;
                                }
                                else if (Convert.ToDouble(grid[x, y].Value) >= 250.5 && Convert.ToDouble(grid[x, y].Value) <= 500.4)
                                {
                                    grid[x, y].Style.BackColor = Color.Firebrick;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    y++;
                }
                x++;
            }
        }

        private void summarizeReport(DataTable readingsTable, string startDate, string endDate)
        {
            string selectedReadingDesc = this.comboBoxReading.GetItemText(this.comboBoxReading.SelectedItem);

            //Better dates
            startDate = Convert.ToDateTime(startDate).ToString("MM/dd/yyyy");
            endDate = Convert.ToDateTime(endDate).ToString("MM/dd/yyyy");
            DateTime startDateDT = Convert.ToDateTime(startDate);
            DateTime endDateDT = Convert.ToDateTime(endDate);

            //Find collection start and end dates
            MySqlCommand mysqlCmd = new MySqlCommand("", mysqlConn);
            mysqlCmd.CommandText = "SELECT readingName FROM readingtablenames WHERE readingDesc = '" + selectedReadingDesc + "'";
            string selectedReading = (mysqlCmd.ExecuteScalar() + "");
            mysqlCmd.CommandText = "SELECT date FROM " + selectedReading + " ORDER BY date DESC LIMIT 1";
            string stringLastDate = Convert.ToString(mysqlCmd.ExecuteScalar() + "");
            stringLastDate = Convert.ToDateTime(stringLastDate).ToString("MM/dd/yyyy");
            DateTime stationsLastDate = DateTime.ParseExact(stringLastDate, "MM/dd/yyyy", null);
            mysqlCmd.CommandText = "SELECT date FROM " + selectedReading + " ORDER BY date ASC LIMIT 1";
            string stringStartDate = Convert.ToString(mysqlCmd.ExecuteScalar() + "");
            stringStartDate = Convert.ToDateTime(stringStartDate).ToString("MM/dd/yyyy");
            DateTime stationsStartDate = DateTime.ParseExact(stringStartDate, "MM/dd/yyyy", null);

            //Find max and min averages
            List<double> averageList = new List<double>();
            double maxAve = 0;
            double minAve = 0;
            string maxAveStation = "";
            string minAveStation = "";
            string maxAveDesc = "";
            string minAveDesc = "";
            int i = 1;
            int x = 0;
            while(i < readingsTable.Columns.Count)
            {
                DataRow[] result = readingsTable.Select("[" + readingsTable.Columns[i].ColumnName + "] is not null");
                if (result.Length > 0)
                {
                    if (selectedReadingDesc == "AQI PM10" || selectedReadingDesc == "AQI PM2.5")
                    {
                        averageList.Add(Math.Round((double)readingsTable.Compute("AVG([" + readingsTable.Columns[i].ColumnName + "])", ""), 0));
                    }
                    else
                    {
                        averageList.Add(Math.Round((double)readingsTable.Compute("AVG([" + readingsTable.Columns[i].ColumnName + "])", ""), 2));
                    }

                    if (averageList[x] == averageList.Max())
                    {
                        maxAve = averageList[x];
                        maxAveStation = readingsTable.Columns[i].ColumnName;
                    }
                    if (averageList[x] == averageList.Min())
                    {
                        minAve = averageList[x];
                        minAveStation = readingsTable.Columns[i].ColumnName;
                    }
                    x++;

                    switch (selectedReadingDesc)
                    {
                        case "AQI PM2.5":
                        case "AQI PM10":
                            if (maxAve >= 0 && maxAve < 51)
                            {
                                maxAveDesc = "GOOD";
                            }
                            else if (maxAve >= 51 && maxAve < 101)
                            {
                                maxAveDesc = "MODERATE";
                            }
                            else if (maxAve >= 101 && maxAve < 151)
                            {
                                maxAveDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (maxAve >= 151 && maxAve < 201)
                            {
                                maxAveDesc = "UNHEALTHY";
                            }
                            else if (maxAve >= 201 && maxAve < 301)
                            {
                                maxAveDesc = "VERY UNHEALTHY";
                            }
                            else if (maxAve >= 301 && maxAve < 501)
                            {
                                maxAveDesc = "HAZARDOUS";
                            }

                            if (minAve >= 0 && minAve < 51)
                            {
                                minAveDesc = "GOOD";
                            }
                            else if (minAve >= 51 && minAve < 101)
                            {
                                minAveDesc = "MODERATE";
                            }
                            else if (minAve >= 101 && minAve < 151)
                            {
                                minAveDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (minAve >= 151 && minAve < 201)
                            {
                                minAveDesc = "UNHEALTHY";
                            }
                            else if (minAve >= 201 && minAve < 301)
                            {
                                minAveDesc = "VERY UNHEALTHY";
                            }
                            else if (minAve >= 301 && minAve < 501)
                            {
                                minAveDesc = "HAZARDOUS";
                            }
                            break;
                        case "PM10":
                            if (maxAve >= 0 && maxAve < 55)
                            {
                                maxAveDesc = "GOOD";
                            }
                            else if (maxAve >= 55 && maxAve < 155)
                            {
                                maxAveDesc = "MODERATE";
                            }
                            else if (maxAve >= 155 && maxAve < 255)
                            {
                                maxAveDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (maxAve >= 255 && maxAve < 355)
                            {
                                maxAveDesc = "UNHEALTHY";
                            }
                            else if (maxAve >= 355 && maxAve < 425)
                            {
                                maxAveDesc = "VERY UNHEALTHY";
                            }
                            else if (maxAve >= 425 && maxAve < 604)
                            {
                                maxAveDesc = "HAZARDOUS";
                            }

                            if (minAve >= 0 && minAve < 55)
                            {
                                minAveDesc = "GOOD";
                            }
                            else if (minAve >= 55 && minAve < 155)
                            {
                                minAveDesc = "MODERATE";
                            }
                            else if (minAve >= 155 && minAve < 255)
                            {
                                minAveDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (minAve >= 255 && minAve < 355)
                            {
                                minAveDesc = "UNHEALTHY";
                            }
                            else if (minAve >= 355 && minAve < 425)
                            {
                                minAveDesc = "VERY UNHEALTHY";
                            }
                            else if (minAve >= 425 && minAve < 604)
                            {
                                minAveDesc = "HAZARDOUS";
                            }
                            break;
                        case "PM2.5":
                            if (maxAve >= 0 && maxAve < 12.1)
                            {
                                maxAveDesc = "GOOD";
                            }
                            else if (maxAve >= 12.1 && maxAve < 35.5)
                            {
                                maxAveDesc = "MODERATE";
                            }
                            else if (maxAve >= 35.5 && maxAve < 55.5)
                            {
                                maxAveDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (maxAve >= 55.5 && maxAve < 150.5)
                            {
                                maxAveDesc = "UNHEALTHY";
                            }
                            else if (maxAve >= 150.5 && maxAve < 250.5)
                            {
                                maxAveDesc = "VERY UNHEALTHY";
                            }
                            else if (maxAve >= 250.5 && maxAve < 500.4)
                            {
                                maxAveDesc = "HAZARDOUS";
                            }

                            if (minAve >= 0 && minAve < 12.1)
                            {
                                minAveDesc = "GOOD";
                            }
                            else if (minAve >= 12.1 && minAve < 35.5)
                            {
                                minAveDesc = "MODERATE";
                            }
                            else if (minAve >= 35.5 && minAve < 55.5)
                            {
                                minAveDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (minAve >= 55.5 && minAve < 150.5)
                            {
                                minAveDesc = "UNHEALTHY";
                            }
                            else if (minAve >= 150.5 && minAve < 250.5)
                            {
                                minAveDesc = "VERY UNHEALTHY";
                            }
                            else if (minAve >= 250.5 && minAve < 500.4)
                            {
                                minAveDesc = "HAZARDOUS";
                            }
                            break;
                        
                    }

                }
                i++;
            }

            //Find columns with no data
            List<string> emptyColumns = new List<string>();
            i = 1;
            while (i < readingsTable.Columns.Count)
            {
                DataRow[] result = readingsTable.Select("[" + readingsTable.Columns[i].ColumnName + "] is not null");
                if (result.Length < 1)
                {
                    emptyColumns.Add(readingsTable.Columns[i].ColumnName);
                }
                i++;
            }

            //Per station reports
            List<double> maxReadingsList = new List<double>();
            List<double> minReadingsList = new List<double>();
            List<string> generalReadingsReports = new List<string>();
            double maxReading = 0;
            double minReading = 0;
            double aveReading = 0;
            string maxReadingDesc = "";
            string minReadingDesc = "";
            string aveReadingDesc = "";
            string maxReadingDates = "";
            string minReadingDates = "";
            int index = 0;
            i = 1;
            while (i < readingsTable.Columns.Count)
            {
                DataRow[] result = readingsTable.Select("[" + readingsTable.Columns[i].ColumnName + "] is not null");
                if (result.Length > 0)
                {
                    //Determine data percentage
                    //Within collection period
                    mysqlCmd.CommandText = "SELECT stationName FROM stations WHERE stationDesc = '" + readingsTable.Columns[i].ColumnName + "'";
                    string selectedStation = (mysqlCmd.ExecuteScalar() + "");
                    int totalDays = (stationsLastDate - stationsStartDate).Days + 1;
                    mysqlCmd.CommandText = "SELECT COUNT(*) FROM " + selectedReading + " WHERE " + selectedStation + " IS NOT NULL";
                    int stationCount = int.Parse(mysqlCmd.ExecuteScalar() + "");
                    double recordedPercentage = Math.Round(Convert.ToDouble(stationCount) / Convert.ToDouble(totalDays) * 100, 2);
                    //Within specified date range
                    mysqlCmd.CommandText = "SELECT COUNT(*) FROM " + selectedReading + " WHERE date BETWEEN '" + Convert.ToDateTime(startDate).ToString("yyyy/MM/dd") + "' AND '" + Convert.ToDateTime(endDate).ToString("yyyy/MM/dd") + "' AND " + selectedStation + " IS NOT NULL";
                    int marginStationCount = int.Parse(mysqlCmd.ExecuteScalar() + "");
                    int marginTotalDays = (endDateDT - startDateDT).Days + 1;
                    double marginRecordedPercentage = Math.Round(Convert.ToDouble(marginStationCount) / Convert.ToDouble(marginTotalDays) * 100, 2);

                    //Get station type
                    string stationType = "";
                    mysqlCmd.CommandText = "SELECT stationType FROM stations WHERE stationDesc = '" + readingsTable.Columns[i].ColumnName + "'";
                    stationType = (mysqlCmd.ExecuteScalar() + "");
                    switch (stationType)
                    {
                        case "roadside":
                            stationType = "(Roadside)";
                            break;
                        case "ambient":
                            stationType = "(General Ambient)";
                            break;
                    }

                    //Find average, min and max readings per station
                    maxReading = (double)readingsTable.Compute("MAX([" + readingsTable.Columns[i].ColumnName + "])", "");
                    minReading = (double)readingsTable.Compute("MIN([" + readingsTable.Columns[i].ColumnName + "])", "");

                    DataRow[] maxResult = readingsTable.Select("[" + readingsTable.Columns[i].ColumnName + "] = " + maxReading);
                    DataRow[] minResult = readingsTable.Select("[" + readingsTable.Columns[i].ColumnName + "] = " + minReading);
                    x = 0;
                    maxReadingDates = "";
                    minReadingDates = "";
                    while (x < maxResult.Length)
                    {
                        index = readingsTable.Rows.IndexOf(maxResult[x]);
                        maxReadingDates = string.Concat(maxReadingDates, Convert.ToString(readingsTable.Rows[index][0]).Split(' ').First());
                        x++;
                        if (x < maxResult.Length)
                        {
                            maxReadingDates = string.Concat(maxReadingDates, ", ");
                        }
                    }
                    x = 0;
                    while (x < minResult.Length)
                    {
                        index = readingsTable.Rows.IndexOf(minResult[x]);
                        minReadingDates = string.Concat(minReadingDates, Convert.ToString(readingsTable.Rows[index][0]).Split(' ').First());
                        x++;
                        if (x < minResult.Length)
                        {
                            minReadingDates = string.Concat(minReadingDates, ", ");
                        }
                    }
                    if (selectedReadingDesc == "AQI PM10" || selectedReadingDesc == "AQI PM2.5")
                    {
                        aveReading = Math.Round((double)readingsTable.Compute("AVG([" + readingsTable.Columns[i].ColumnName + "])", ""), 0);
                    }
                    else
                    {
                        aveReading = Math.Round((double)readingsTable.Compute("AVG([" + readingsTable.Columns[i].ColumnName + "])", ""), 2);
                    }

                    switch (selectedReadingDesc)
                    {
                        case "AQI PM2.5":
                        case "AQI PM10":
                            if (maxReading >= 0 && maxReading < 51)
                            {
                                maxReadingDesc = "GOOD";
                            }
                            else if (maxReading >= 51 && maxReading < 101)
                            {
                                maxReadingDesc = "MODERATE";
                            }
                            else if (maxReading >= 101 && maxReading < 151)
                            {
                                maxReadingDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (maxReading >= 151 && maxReading < 201)
                            {
                                maxReadingDesc = "UNHEALTHY";
                            }
                            else if (maxReading >= 201 && maxReading < 301)
                            {
                                maxReadingDesc = "VERY UNHEALTHY";
                            }
                            else if (maxReading >= 301 && maxReading < 501)
                            {
                                maxReadingDesc = "HAZARDOUS";
                            }

                            if (minReading >= 0 && minReading < 51)
                            {
                                minReadingDesc = "GOOD";
                            }
                            else if (minReading >= 51 && minReading < 101)
                            {
                                minReadingDesc = "MODERATE";
                            }
                            else if (minReading >= 101 && minReading < 151)
                            {
                                minReadingDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (minReading >= 151 && minReading < 201)
                            {
                                minReadingDesc = "UNHEALTHY";
                            }
                            else if (minReading >= 201 && minReading < 301)
                            {
                                minReadingDesc = "VERY UNHEALTHY";
                            }
                            else if (minReading >= 301 && minReading < 501)
                            {
                                minReadingDesc = "HAZARDOUS";
                            }

                            if (aveReading >= 0 && aveReading < 51)
                            {
                                aveReadingDesc = "GOOD";
                            }
                            else if (aveReading >= 51 && aveReading < 101)
                            {
                                aveReadingDesc = "MODERATE";
                            }
                            else if (aveReading >= 101 && aveReading < 151)
                            {
                                aveReadingDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (aveReading >= 151 && aveReading < 201)
                            {
                                aveReadingDesc = "UNHEALTHY";
                            }
                            else if (aveReading >= 201 && aveReading < 301)
                            {
                                aveReadingDesc = "VERY UNHEALTHY";
                            }
                            else if (aveReading >= 301 && aveReading < 501)
                            {
                                aveReadingDesc = "HAZARDOUS";
                            }
                            break;
                        case "PM10":
                            if (maxReading >= 0 && maxReading < 55)
                            {
                                maxReadingDesc = "GOOD";
                            }
                            else if (maxReading >= 55 && maxReading < 155)
                            {
                                maxReadingDesc = "MODERATE";
                            }
                            else if (maxReading >= 155 && maxReading < 255)
                            {
                                maxReadingDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (maxReading >= 255 && maxReading < 355)
                            {
                                maxReadingDesc = "UNHEALTHY";
                            }
                            else if (maxReading >= 355 && maxReading < 425)
                            {
                                maxReadingDesc = "VERY UNHEALTHY";
                            }
                            else if (maxReading >= 425 && maxReading < 604)
                            {
                                maxReadingDesc = "HAZARDOUS";
                            }

                            if (minReading >= 0 && minReading < 55)
                            {
                                minReadingDesc = "GOOD";
                            }
                            else if (minReading >= 55 && minReading < 155)
                            {
                                minReadingDesc = "MODERATE";
                            }
                            else if (minReading >= 155 && minReading < 255)
                            {
                                minReadingDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (minReading >= 255 && minReading < 355)
                            {
                                minReadingDesc = "UNHEALTHY";
                            }
                            else if (minReading >= 355 && minReading < 425)
                            {
                                minReadingDesc = "VERY UNHEALTHY";
                            }
                            else if (minReading >= 425 && minReading < 604)
                            {
                                minReadingDesc = "HAZARDOUS";
                            }

                            if (aveReading >= 0 && aveReading < 55)
                            {
                                aveReadingDesc = "GOOD";
                            }
                            else if (aveReading >= 55 && aveReading < 155)
                            {
                                aveReadingDesc = "MODERATE";
                            }
                            else if (aveReading >= 155 && aveReading < 255)
                            {
                                aveReadingDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (aveReading >= 255 && aveReading < 355)
                            {
                                aveReadingDesc = "UNHEALTHY";
                            }
                            else if (aveReading >= 355 && aveReading < 425)
                            {
                                aveReadingDesc = "VERY UNHEALTHY";
                            }
                            else if (aveReading >= 425 && aveReading < 604)
                            {
                                aveReadingDesc = "HAZARDOUS";
                            }
                            break;
                        case "PM2.5":
                            if (maxReading >= 0 && maxReading < 12.1)
                            {
                                maxReadingDesc = "GOOD";
                            }
                            else if (maxReading >= 12.1 && maxReading < 35.5)
                            {
                                maxReadingDesc = "MODERATE";
                            }
                            else if (maxReading >= 35.5 && maxReading < 55.5)
                            {
                                maxReadingDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (maxReading >= 55.5 && maxReading < 150.5)
                            {
                                maxReadingDesc = "UNHEALTHY";
                            }
                            else if (maxReading >= 150.5 && maxReading < 250.5)
                            {
                                maxReadingDesc = "VERY UNHEALTHY";
                            }
                            else if (maxReading >= 250.5 && maxReading < 500.4)
                            {
                                maxReadingDesc = "HAZARDOUS";
                            }

                            if (minReading >= 0 && minReading < 12.1)
                            {
                                minReadingDesc = "GOOD";
                            }
                            else if (minReading >= 12.1 && minReading < 35.5)
                            {
                                minReadingDesc = "MODERATE";
                            }
                            else if (minReading >= 35.5 && minReading < 55.5)
                            {
                                minReadingDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (minReading >= 55.5 && minReading < 150.5)
                            {
                                minReadingDesc = "UNHEALTHY";
                            }
                            else if (minReading >= 150.5 && minReading < 250.5)
                            {
                                minReadingDesc = "VERY UNHEALTHY";
                            }
                            else if (minReading >= 250.5 && minReading < 500.4)
                            {
                                minReadingDesc = "HAZARDOUS";
                            }

                            if (aveReading >= 0 && aveReading < 12.1)
                            {
                                aveReadingDesc = "GOOD";
                            }
                            else if (aveReading >= 12.1 && aveReading < 35.5)
                            {
                                aveReadingDesc = "MODERATE";
                            }
                            else if (aveReading >= 35.5 && aveReading < 55.5)
                            {
                                aveReadingDesc = "UNHEALTHY FOR SENSITIVE GROUPS";
                            }
                            else if (aveReading >= 55.5 && aveReading < 150.5)
                            {
                                aveReadingDesc = "UNHEALTHY";
                            }
                            else if (aveReading >= 150.5 && aveReading < 250.5)
                            {
                                aveReadingDesc = "VERY UNHEALTHY";
                            }
                            else if (aveReading >= 250.5 && aveReading < 500.4)
                            {
                                aveReadingDesc = "HAZARDOUS";
                            }
                            break;

                    }

                    //One-line per station reports
                    //generalReadingsReports.Add("Average " + selectedReadingDesc + " from " + readingsTable.Columns[i].ColumnName + " is " + aveReading + " with a high of " + maxReading + " on " + maxReadingDates + " and a low of " + minReading + " on " + minReadingDates);
                    //generalReadingsReports.Add(readingsTable.Columns[i].ColumnName + " " + selectedReadingDesc + " -- Average: " + aveReading + " (" + aveReadingDesc + "), High: " + maxReading + " (" + maxReadingDesc + ") on [" + maxReadingDates + "], Low: " + minReading + " (" + minReadingDesc + ") on [" + minReadingDates + "]");
                    //Multi-line reports
                    generalReadingsReports.Add(readingsTable.Columns[i].ColumnName + " " + stationType + ", " + selectedReadingDesc);
                    generalReadingsReports.Add(" -- Average: " + aveReading + " (" + aveReadingDesc + ")");
                    generalReadingsReports.Add(" -- High: " + maxReading + " (" + maxReadingDesc + ") on " + maxReadingDates + "");
                    generalReadingsReports.Add(" -- Low: " + minReading + " (" + minReadingDesc + ") on " + minReadingDates + "");
                    generalReadingsReports.Add(" -- Data within Date Range: " + marginRecordedPercentage + "%");
                    generalReadingsReports.Add(" -- Data within Collection Period: " + recordedPercentage + "%");
                }
                i++;
            }

            //Report findings
            List<string> reportsList = new List<string>();
            if (checkBoxIncludeForecasts.Checked)
            {
                label4.Text = "Reports from " + startDate + " to " + endDate + " (Forecasts included)";
            }
            else
            {
                label4.Text = "Reports from " + startDate + " to " + endDate;
            }

            //Filters
            /*
            if (radioButtonFilterEnable.Checked)
            {
                reportsList.Add("Filters enabled, only showing reports of dates with at least one station with air quality level of: ");
                if (checkBoxFilterGood.Checked)
                    reportsList.Add(" -- Good");
                if (checkBoxFilterModerate.Checked)
                    reportsList.Add(" -- Moderate");
                if (checkBoxFilterSensitive.Checked)
                    reportsList.Add(" -- Sensitive");
                if (checkBoxFilterUnhealthy.Checked)
                    reportsList.Add(" -- Unhealthy");
                if (checkBoxFilterVeryUnhealthy.Checked)
                    reportsList.Add(" -- Very Healthy");
                if (checkBoxFilterHazardous.Checked)
                    reportsList.Add(" -- Hazardous");
                reportsList.Add("");
            }
            */

            reportsList.Add("GENERAL REPORTS:");
            foreach (string emptyStation in emptyColumns)
            {
                reportsList.Add("No data in " + emptyStation);
            }

            reportsList.Add("Highest average " + selectedReadingDesc + " is " + maxAve + " (" + maxAveDesc + ") from " + maxAveStation);
            reportsList.Add("Lowest average " + selectedReadingDesc + " is " + minAve + " (" + minAveDesc + ") from " + minAveStation);
            reportsList.Add("Start of collected data: " + stringStartDate);
            reportsList.Add("End of collected data: " + stringLastDate);
            reportsList.Add("");
            reportsList.Add("PER STATION REPORTS:");
            reportsList.AddRange(generalReadingsReports);

            listBoxNotes.DataSource = reportsList;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            populateStationsTable(0);
            populateReadingNamesTable();
            checkBoxIncludeForecasts.Checked = true;

            buttonAdd.Enabled = false;
            buttonRemove.Enabled = false;

            listBoxSelected.Sorted = true;
            listBoxCollection.Sorted = true;

            radioButtonStartCustom.Checked = true;
            radioButtonEndCustom.Checked = true;
            radioButtonStationAll.Checked = true;

            radioButtonFilterDisable.Checked = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(listBoxCollection.SelectedIndex != -1)
            {
                listBoxSelected.Items.Add(listBoxCollection.SelectedItem);
                listBoxCollection.Items.Remove(listBoxCollection.SelectedItem);
                buttonAdd.Enabled = false;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if(listBoxSelected.SelectedIndex != -1)
            {
                listBoxCollection.Items.Add(listBoxSelected.SelectedItem);
                listBoxSelected.Items.Remove(listBoxSelected.SelectedItem);
                buttonRemove.Enabled = false;
            }
        }

        private void buttonAddAll_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < listBoxCollection.Items.Count)
            {
                listBoxSelected.Items.Add(listBoxCollection.Items[i]);
                i++;
            }
            listBoxCollection.Items.Clear();
            buttonAdd.Enabled = false;
            buttonRemove.Enabled = false;
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            listBoxSelected.Items.Clear();
            listBoxCollection.Items.Clear();
            if (radioButtonStationAll.Checked)
            {
                populateStationsTable(0);
            }
            else if (radioButtonStationRoadside.Checked)
            {
                populateStationsTable(1);
            }
            else if (radioButtonStationAmbient.Checked)
            {
                populateStationsTable(2);
            }
            buttonAdd.Enabled = false;
            buttonRemove.Enabled = false;
        }

        private void listBoxSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemove.Enabled = true;
        }

        private void listBoxCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = true;
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            //Clear reports controls
            label4.Text = "Reports";
            DataTable emptyDT = new DataTable();
            emptyDT.Clear();
            listBoxNotes.DataSource = emptyDT;

            if (this.OpenConnection() == true)
            {
                //Select reading
                string selectedReadingDesc = this.comboBoxReading.GetItemText(this.comboBoxReading.SelectedItem);
                MySqlCommand mysqlCmdReading = new MySqlCommand(
                    "SELECT readingName FROM readingtablenames WHERE readingDesc = '" + selectedReadingDesc + "'", mysqlConn
                    );
                string selectedReadingName = (mysqlCmdReading.ExecuteScalar() + "");

                //Select dates
                string startDate = "";
                string endDate = "";
                MySqlCommand mysqlCmdDate = new MySqlCommand(
                    "SELECT date FROM " + selectedReadingName, mysqlConn
                    );
                //Start date
                if (radioButtonStartEarliest.Checked)
                {
                    mysqlCmdDate.CommandText = "SELECT date FROM " + selectedReadingName + " ORDER BY date ASC LIMIT 1";
                    startDate = Convert.ToString(mysqlCmdDate.ExecuteScalar() + "");
                }
                else if (radioButtonStartLatest.Checked)
                {
                    mysqlCmdDate.CommandText = "SELECT date FROM " + selectedReadingName + " ORDER BY date DESC LIMIT 1";
                    startDate = Convert.ToString(mysqlCmdDate.ExecuteScalar() + "");
                }
                else if (radioButtonStartCustom.Checked)
                {
                    startDate = dateTimePickerStart.Value.ToString("yyyy/MM/dd");
                }
                DateTime startDateDT = new DateTime();
                if (!string.IsNullOrEmpty(startDate))
                {
                    startDate = Convert.ToDateTime(startDate).ToString("yyyy/MM/dd");
                    startDateDT = Convert.ToDateTime(startDate);
                }

                //End date
                if (radioButtonEndLatest.Checked)
                {
                    mysqlCmdDate.CommandText = "SELECT date FROM " + selectedReadingName + " ORDER BY date DESC LIMIT 1";
                    endDate = Convert.ToString(mysqlCmdDate.ExecuteScalar() + "");
                }
                else if (radioButtonEndCustom.Checked)
                {
                    endDate = dateTimePickerEnd.Value.ToString("yyyy/MM/dd");
                }
                DateTime endDateDT = new DateTime();
                if (!string.IsNullOrEmpty(endDate))
                {
                    endDate = Convert.ToDateTime(endDate).ToString("yyyy/MM/dd");
                    endDateDT = Convert.ToDateTime(endDate);
                }                

                this.CloseConnection();

                if (listBoxSelected.Items.Count == 0)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Please select station(s).", "Error");
                }
                else if (startDateDT > endDateDT)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Invalid date range!", "Error");
                }
                else if (startDateDT == default(DateTime) || endDateDT == default(DateTime))
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("No data found with corresponding parameters.", "Caution");
                }
                else
                {
                    generateTable(selectedReadingName, startDate, endDate, startDateDT, endDateDT);
                }
                
            }
        }

        private void radioButtonStartCustom_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerStart.Enabled = true;
        }

        private void radioButtonStartEarliest_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerStart.Enabled = false;
        }

        private void radioButtonStartLatest_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerStart.Enabled = false;
        }

        private void radioButtonEndCustom_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerEnd.Enabled = true;
        }

        private void radioButtonEndLatest_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerEnd.Enabled = false;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (user.loggedIn)
            {
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
            else
            {
                this.Hide();
                Form5 form = new Form5();
                form.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMakeChart_Click(object sender, EventArgs e)
        {
            buttonTable_Click(sender, e);

            if (dataGridView1.DataSource != null)
            {
                DataTable readingsChart = new DataTable();
                readingsChart = ((DataTable)dataGridView1.DataSource).Copy();

                //Add station types to station names in the chart
                if (this.OpenConnection())
                {
                    int i = 1;
                    while (i < readingsChart.Columns.Count)
                    {
                        MySqlCommand mysqlCmd = new MySqlCommand(
                            "SELECT stationType FROM stations WHERE stationDesc = '" + readingsChart.Columns[i].ColumnName + "'", mysqlConn
                            );
                        string stationType = mysqlCmd.ExecuteScalar() + "";
                        switch (stationType)
                        {
                            case "roadside":
                                readingsChart.Columns[i].ColumnName = string.Concat(readingsChart.Columns[i].ColumnName, " (Roadside)");
                                break;
                            case "ambient":
                                readingsChart.Columns[i].ColumnName = string.Concat(readingsChart.Columns[i].ColumnName, " (General Ambient)");
                                break;
                        }
                        i++;
                    }
                    this.CloseConnection();
                }

                bool includesForecasts = false;
                if (checkBoxIncludeForecasts.Checked)
                {
                    includesForecasts = true;
                }
                else
                {
                    includesForecasts = false;
                }

                Form4 form = new Form4(readingsChart, this.comboBoxReading.GetItemText(this.comboBoxReading.SelectedItem), includesForecasts);
                form.Show();
            }
        }

        private void buttonCopyNotes_Click(object sender, EventArgs e)
        {
            if (listBoxNotes.Items.Count > 0)
            {
                string s1 = label4.Text + "\r\n\r\n";
                foreach (object item in listBoxNotes.Items)
                    s1 += item.ToString() + "\r\n";
                Clipboard.SetText(s1);
                MessageBox.Show("Reports copied to clipboard.", "");
            }
            else
            {
                MessageBox.Show("No reports to copy.", "Caution");
            }
        }

        private void radioButtonStationRoadside_CheckedChanged(object sender, EventArgs e)
        {
            listBoxSelected.Items.Clear();
            listBoxCollection.Items.Clear();
            populateStationsTable(1);
            buttonAdd.Enabled = false;
            buttonRemove.Enabled = false;
        }

        private void radioButtonStationAmbient_CheckedChanged(object sender, EventArgs e)
        {
            listBoxSelected.Items.Clear();
            listBoxCollection.Items.Clear();
            populateStationsTable(2);
            buttonAdd.Enabled = false;
            buttonRemove.Enabled = false;
        }

        private void radioButtonStationAll_CheckedChanged(object sender, EventArgs e)
        {
            listBoxSelected.Items.Clear();
            listBoxCollection.Items.Clear();
            populateStationsTable(0);
            buttonAdd.Enabled = false;
            buttonRemove.Enabled = false;
        }

        private void radioButtonFilterDisable_CheckedChanged(object sender, EventArgs e)
        {
            panelFilterControls.Enabled = false;
            buttonMakeChart.Enabled = true;
        }

        private void radioButtonFilterEnable_CheckedChanged(object sender, EventArgs e)
        {
            panelFilterControls.Enabled = true;
            buttonMakeChart.Enabled = false;
        }

        private void buttonFilterCheck_Click(object sender, EventArgs e)
        {
            if (buttonFilterCheck.Text.StartsWith("Uncheck"))
            {
                checkBoxFilterGood.Checked = false;
                checkBoxFilterModerate.Checked = false;
                checkBoxFilterSensitive.Checked = false;
                checkBoxFilterUnhealthy.Checked = false;
                checkBoxFilterVeryUnhealthy.Checked = false;
                checkBoxFilterHazardous.Checked = false;
                buttonFilterCheck.Text = "Check all";
            }
            else if (buttonFilterCheck.Text.StartsWith("Check"))
            {
                checkBoxFilterGood.Checked = true;
                checkBoxFilterModerate.Checked = true;
                checkBoxFilterSensitive.Checked = true;
                checkBoxFilterUnhealthy.Checked = true;
                checkBoxFilterVeryUnhealthy.Checked = true;
                checkBoxFilterHazardous.Checked = true;
                buttonFilterCheck.Text = "Uncheck all";
            }
        }
    }
}
