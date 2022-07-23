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
            // Find first day of the month
            DateTime FirstDay = new DateTime(_Year, _Month, 1);

            // Find the amount of days in current month
            int DaysInMonth   = DateTime.DaysInMonth(_Year, _Month);

            int dayoftheweek = Convert.ToInt32(FirstDay.DayOfWeek.ToString("d"));

            // Add the empty month days to position the starting day of the month correctly
            bool EmptyDaysToAdd = dayoftheweek > 0;
            while (EmptyDaysToAdd) 
            {
                CalendarGrid.Controls.Add(new EmptyDay());
                EmptyDaysToAdd  = (--dayoftheweek > 0);
            }

            bool DaysToAdd = DaysInMonth > 0;
            int  Days = 1;
            while (DaysToAdd) 
            {
                CalendarDay DayToAdd = new CalendarDay();
                DayToAdd.AddDayLabel(Days++.ToString());
                CalendarGrid.Controls.Add(DayToAdd);
                DaysToAdd = --DaysInMonth > 0;
            }
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            CalendarGrid.Controls.Clear();
            DisplayMonth(--Month, Year);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            CalendarGrid.Controls.Clear();
            DisplayMonth(++Month, Year);
        }
    }
}