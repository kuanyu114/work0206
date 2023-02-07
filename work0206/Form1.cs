using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace work0206
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        
        List<TimeSet> sourceList = new List<TimeSet>();
        List<TimeSet> resultList = new List<TimeSet>();
        List<TimeReport> reportList = new List<TimeReport>();
        private void Form1_Load(object sender, EventArgs e)
        {

            TimeSet timeSet1 = new TimeSet()
            {
                Begin = new DateTime(2023, 1, 15, 12, 0, 0),
                End = new DateTime(2023, 1, 15, 15, 0, 0)

            };
            TimeSet timeSet2 = new TimeSet()
            {
                Begin = new DateTime(2023, 1, 15, 12, 0, 0, 1),
                End = new DateTime(2023, 1, 15, 14, 59, 59, 999)

            };
            TimeSet timeSet3 = new TimeSet()
            {
                Begin = new DateTime(2023, 1, 15, 12, 15, 0),
                End = new DateTime(2023, 1, 15, 14, 45, 0)

            };
            TimeSet timeSet4 = new TimeSet()
            {
                Begin = new DateTime(2023, 1, 15, 12, 15, 0, 1),
                End = new DateTime(2023, 1, 15, 14, 45, 0, 1)

            };
            sourceList.Add(timeSet1);
            sourceList.Add(timeSet2);
            sourceList.Add(timeSet3);
            sourceList.Add(timeSet4);

            dataGridView1.DataSource = sourceList;

        }
        private void button1_Click(object sender, EventArgs e)
        { 
            List<TimeSet> dataList1 = new List<TimeSet>();
            foreach (var timeSet in sourceList)
            {
                TimeSet tempTimeSet = new TimeSet() 
                { 
                Begin= timeSet.Begin.GetNextRoundDateTime(),
                End= timeSet.End.GetNextRoundDateTime(),
                };
                
                dataList1.Add(tempTimeSet);
            }
            resultList = dataList1;
            dataGridView2.DataSource= dataList1;
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            List<TimeSet> dataList2 = new List<TimeSet>();
             
            foreach (var timeSet in sourceList)
            {
                TimeSet tempTimeSet = new TimeSet()
                {
                    Begin = timeSet.Begin.GetQuarterRoundDateTime(),
                    End = timeSet.End.GetQuarterRoundDateTime(),
                };

                dataList2.Add(tempTimeSet);
            }
            resultList = dataList2;
            dataGridView2.DataSource = dataList2;
        } 

        private void button3_Click(object sender, EventArgs e)
        {
            List<TimeReport> dataList3 = new List<TimeReport>();
            TimeReport tempTimeSet = new TimeReport();
            var templist = resultList.GroupBy(n => n.Begin).Select(n => new { Time = n.Key, Qty = n.Count<TimeSet>() }).ToList();
            foreach (var item in templist)
            {
                TimeReport timeReport = new TimeReport
                {
                    Time = item.Time,
                    Qty = item.Qty,
                };
                dataList3.Add(timeReport);
            }
            reportList = dataList3;
            dataGridView3.DataSource = dataList3;
        }
    }
    public class TimeSet
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
    public class TimeReport
    {
        public DateTime Time { get; set; }
        public int Qty { get; set; }
    }
}