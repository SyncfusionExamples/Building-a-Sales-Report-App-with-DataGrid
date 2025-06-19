using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualSalesReportDemoUsingGrid
{
    public class SalesReport
    {
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }


        private decimal estimatedSales;

        public decimal EstimatedSales
        {
            get { return estimatedSales; }
            set { estimatedSales = value; }
        }

        private decimal salesAchieved;

        public decimal SalesAchieved
        {
            get { return salesAchieved; }
            set { salesAchieved = value; }
        }

        private double salesPercent;

        public double SalesPercent
        {
            get { return salesPercent; }
            set { salesPercent = value; }
        }

        // True if increased compared to last year, otherwise false
        private bool isSalesIncreased;

        public bool IsSalesIncreased
        {
            get { return isSalesIncreased; }
            set { isSalesIncreased = value; }
        }
       
    }

    public class QuarterlySalesReport
    {
        public string QuarterName { get; set; }
        public decimal EstimatedSales { get; set; }
        public decimal SalesAchieved { get; set; }
        public bool IsSalesIncreased { get; set; } // True if achieved > estimated
    }

    public class MonthlySalesReport
    {
        public string MonthName { get; set; }
        public decimal EstimatedSales { get; set; }
        public decimal SalesAchieved { get; set; }
        public bool IsSalesIncreased { get; set; } // True if achieved > estimated

    }
}
