namespace CalendarApp
{

    // ## TODO
    //    * Traverse Months  - DONE
    //    * Display Days     - DONE 
    //    * Fix UI
    //    Documentation

    public partial class Form1 : Form
    {
        int Month, Year;
        string[] Months = {"Jan", "Feb", "Mar", "Apr", "May",
                           "Jun", "Jul", "Aug", "Sep", "Oct", 
                           "Nov", "Dec"};
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime CurrentDate = DateTime.Now;
            DisplayMonth(Month = CurrentDate.Month, Year = CurrentDate.Year);
        }

        /// <summary>
        /// .....
        /// </summary>
        private void DisplayMonth(int _Month,int _Year) 
        {
            // Display Month Info 
            CalendarMonth.Text = $"{Months[_Month - 1]} {_Year}";

            // Find first day of the month
            DateTime FirstDay = new DateTime(_Year, _Month, 1);

            // Find the amount of days in current month
            int DaysInMonth   = DateTime.DaysInMonth(_Year, _Month);
            // Find the amount of padding days to position the starting day of the month correctly
            int EmptyDays = Convert.ToInt32(FirstDay.DayOfWeek.ToString("d")) - 1;

            // Place Empty Days
            bool EmptyDaysToAdd = EmptyDays > 0;
            while (EmptyDaysToAdd) 
            {
                CalendarGrid.Controls.Add(new EmptyDay());
                EmptyDaysToAdd  = (--EmptyDays > 0);
            }

            // Place Actual Days
            bool DaysToAdd = DaysInMonth > 0;
            int  Days = 1;
            while (DaysToAdd) 
            {
                CalendarDay NewDay = new CalendarDay();
                NewDay.AddDayLabel(Days++.ToString());
                CalendarGrid.Controls.Add(NewDay);
                DaysToAdd = --DaysInMonth > 0;
            }
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            CalendarGrid.Controls.Clear();
            DisplayMonth(--Month, Year);
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            CalendarGrid.Controls.Clear();
            DisplayMonth(++Month, Year);
        }
    }
}