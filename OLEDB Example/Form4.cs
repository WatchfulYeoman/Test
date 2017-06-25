using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OLEDB_Example
{
    public partial class Form4 : Form
    {
        DataTable readings;
        string readingType;
        bool includesForecasts;
        string startDate;
        string endDate;

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(DataTable readings, string readingType, bool includesForecasts)
        {
            InitializeComponent();
            this.readings = readings;
            this.readingType = readingType;
            this.includesForecasts = includesForecasts;
            startDate = readings.Rows[0]["date"].ToString();
            startDate = Convert.ToDateTime(startDate).ToString("MMMMM d, yyyy");
            endDate = readings.Rows[readings.Rows.Count - 1]["date"].ToString();
            endDate = Convert.ToDateTime(endDate).ToString("MMMM d, yyyy");
        }

        private void drawGraph()
        {
            chart1.DataSource = readings;

            Series seriesReadings = new Series();
            seriesReadings.ChartType = SeriesChartType.Line;

            int i = 1;
            while (i < readings.Columns.Count)
            {
                chart1.Series.Add(readings.Columns[i].ColumnName);
                chart1.Series[i - 1].XValueMember = "Date";
                chart1.Series[i - 1].YValueMembers = readings.Columns[i].ColumnName;
                chart1.Series[i - 1].ChartType = SeriesChartType.Line;
                chart1.Series[i - 1].BorderWidth = 2;
                i++;
            }

            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;

            //Format y-axis chart elements
            //Add title
            //chart1.ChartAreas[0].AxisY.Title = readingType;
            //chart1.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 12.0f);
            //Major tick and grid marks            
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 10;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Interval = 10;
            chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 10;
            //Minor tick and grid marks
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 5;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Interval = 5;

            /*
            //Format x-axis tick marks and labels with dynamic intervals based on data set size
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;

            int dayDifference;
            dayDifference = (Convert.ToDateTime(readings.Rows[readings.Rows.Count - 1]["date"]) - Convert.ToDateTime(readings.Rows[0]["date"])).Days;
            labelDebug.Visible = true;
            labelDebug.Text = dayDifference.ToString();

            if (dayDifference > 8)
            {
                chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
                chart1.ChartAreas[0].AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;
                chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
                chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            }
            if (dayDifference > 28)
            {
                //Major tick and grid marks
                chart1.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 5;
                chart1.ChartAreas[0].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 5;
                chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 5;
                //Minor tick and grid marks
                chart1.ChartAreas[0].AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;
                chart1.ChartAreas[0].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            }
            if (dayDifference > 60)
            {
                //Major tick and grid marks
                chart1.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 8;
                chart1.ChartAreas[0].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 8;
                chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 8;
                //Minor tick and grid marks
                chart1.ChartAreas[0].AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 2;
                chart1.ChartAreas[0].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 2;
            }
            if (dayDifference > 60)
            {
                //Major tick and grid marks
                chart1.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 2;
                chart1.ChartAreas[0].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 2;
                chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 2;
                //Minor tick and grid marks
                chart1.ChartAreas[0].AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;
                chart1.ChartAreas[0].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            }
            if (dayDifference > 150)
            {
                //Major tick and grid marks
                chart1.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 4;
                chart1.ChartAreas[0].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 4;
                chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 4;
                //Minor tick and grid marks
                chart1.ChartAreas[0].AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;
                chart1.ChartAreas[0].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Weeks;
                chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            }
            /*
            chart1.ChartAreas[0].AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Months;
            chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
            */

            //Title
            if (!includesForecasts)
            {
                //chart1.Titles.Add(readingType + " from " + readings.Rows[0]["date"].ToString().Split(' ').First() + " to " + readings.Rows[readings.Rows.Count - 1]["date"].ToString().Split(' ').First());
                chart1.Titles.Add(readingType + " from " + startDate + " to " + endDate);
            }
            else
            {
                //chart1.Titles.Add(readingType + " from " + readings.Rows[0]["date"].ToString().Split(' ').First() + " to " + readings.Rows[readings.Rows.Count - 1]["date"].ToString().Split(' ').First() + " (Includes Forecasts)");
                chart1.Titles.Add(readingType + " from " + startDate + " to " + endDate + " (Includes Forecasts)");
            }
            chart1.Titles[0].Font = new Font("Microsoft Sans Serif", 12.0f);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            drawGraph();
        }

        private void saveGraphAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PNG Image|*.png";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.FileName = chart1.Titles[0].Text;
            //saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Saves the Image via a FileStream created by the OpenFile method.  
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the  
                // File type selected in the dialog box.  
                // NOTE that the FilterIndex property is one-based.  
                this.chart1.SaveImage(fs, ChartImageFormat.Png);

                fs.Close();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
