using AnnualSalesReportDemoUsingGrid.YourNamespace;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using Syncfusion.UI.Xaml.Grid;

namespace AnnualSalesReportDemoUsingGrid
{
    
    public class SalesReportViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SalesReport> Reports { get; set; }

        public ObservableCollection<QuarterlySalesReport> QuarterlyReports { get; set; }

        public ObservableCollection<MonthlySalesReport> MonthlyReports { get; set; }

        public decimal TotalSales { get; set; }

        public decimal EstimatedSales { get; set; }

        private static readonly string[] Months = {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
         };

        private static readonly string[] Quarters = { "Q1", "Q2", "Q3", "Q4" };

        private static readonly string[] ProductNames =
        {
        "Laptop", "Smartphone", "Tablet", "Smartwatch", "Headphones",
        "Bluetooth Speaker", "Desktop PC", "Gaming Console", "Monitor",
        "Keyboard", "Mouse", "Printer", "Scanner", "External Hard Drive", "Webcam"
        };

        public ICommand AnnualReportCommand { get; set; }
        public ICommand MonthlyReportCommand { get; set; }
        public ICommand QuarterlyReportCommand { get; set; }

        public SalesReportViewModel()
        {
            Reports = GenerateRandomReports();

            MonthlyReports = GenerateRandomMonthlyData();

            QuarterlyReports = GenerateQuarterlyFromMonthly(MonthlyReports);

            AnnualReportCommand = new RelayCommand(OnExportAnnualReport);
            MonthlyReportCommand = new RelayCommand(OnExportMonthlyReport);
            QuarterlyReportCommand = new RelayCommand(OnExportQuarterlyReport);

        }

        private void OnExportQuarterlyReport(object obj)
        {
            var dataGrid = obj as SfDataGrid;
            var options = new ExcelExportingOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            var excelEngine = dataGrid.ExportToExcel(dataGrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];

            SaveFileDialog sfd = new SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {

                    if (sfd.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;

                    else if (sfd.FilterIndex == 2)
                        workBook.Version = ExcelVersion.Excel2010;

                    else
                        workBook.Version = ExcelVersion.Excel2013;
                    workBook.SaveAs(stream);
                }

                //Message box confirmation to view the created workbook.

                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(sfd.FileName);
                    info.UseShellExecute = true;
                    System.Diagnostics.Process.Start(info);
                }
            }
        }

        private void OnExportMonthlyReport(object obj)
        {
            var dataGrid = obj as SfDataGrid;
            var options = new ExcelExportingOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            var excelEngine = dataGrid.ExportToExcel(dataGrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];

            SaveFileDialog sfd = new SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {

                    if (sfd.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;

                    else if (sfd.FilterIndex == 2)
                        workBook.Version = ExcelVersion.Excel2010;

                    else
                        workBook.Version = ExcelVersion.Excel2013;
                    workBook.SaveAs(stream);
                }

                //Message box confirmation to view the created workbook.

                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(sfd.FileName);
                    info.UseShellExecute = true;
                    System.Diagnostics.Process.Start(info);
                }
            }
        }

        private void OnExportAnnualReport(object obj)
        {
            var dataGrid = obj as SfDataGrid;
            var options = new ExcelExportingOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            var excelEngine = dataGrid.ExportToExcel(dataGrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];

            SaveFileDialog sfd = new SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {

                    if (sfd.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;

                    else if (sfd.FilterIndex == 2)
                        workBook.Version = ExcelVersion.Excel2010;

                    else
                        workBook.Version = ExcelVersion.Excel2013;
                    workBook.SaveAs(stream);
                }

                //Message box confirmation to view the created workbook.

                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(sfd.FileName);
                    info.UseShellExecute = true;
                    System.Diagnostics.Process.Start(info);
                }
            }
        }

        private ObservableCollection<SalesReport> GenerateRandomReports()
        {
            var random = new Random();
            var reports = new ObservableCollection<SalesReport>();

            foreach (var name in ProductNames)
            {
                decimal estimated = random.Next(10000, 200000); // Random estimated sales between 10k and 200k
                                                                // Simulate achieved sales with +/- 30% variability
                decimal achieved = estimated * (decimal)(0.7 + random.NextDouble() * 0.6);
                achieved = Math.Round(achieved, 2);               

                bool increased = achieved > estimated; // Mark as increased if above estimate



                reports.Add(new SalesReport
                {
                    ProductName = name,
                    EstimatedSales = estimated,
                    SalesAchieved = achieved,
                    SalesPercent = GetSalesPercent(estimated,achieved),
                    IsSalesIncreased = increased                    
                });
            }

            return reports;
        }

        
        private ObservableCollection<MonthlySalesReport> GenerateRandomMonthlyData()
        {
            var random = new Random();
            var reports = new ObservableCollection<MonthlySalesReport>();

            foreach (var month in Months)
            {
                decimal estimated = random.Next(10000, 50000); // Estimated between 10k and 50k
                decimal achieved = estimated * (decimal)(0.7 + random.NextDouble() * 0.6); // 70%–130%
                achieved = Math.Round(achieved, 2);
                TotalSales += achieved;
                EstimatedSales += estimated;
                bool increased = achieved > estimated;

                reports.Add(new MonthlySalesReport
                {
                    MonthName = month,
                    EstimatedSales = estimated,
                    SalesAchieved = achieved,
                    IsSalesIncreased = increased
                });
            }

            return reports;
        }


        public ObservableCollection<QuarterlySalesReport> GenerateQuarterlyFromMonthly(ObservableCollection<MonthlySalesReport> monthlyReports)
        {
            var quarterGroups = new Dictionary<string, string[]>
    {
        { "Q1", new[] { "January", "February", "March" } },
        { "Q2", new[] { "April", "May", "June" } },
        { "Q3", new[] { "July", "August", "September" } },
        { "Q4", new[] { "October", "November", "December" } }
    };

            var quarterlyReports = new ObservableCollection<QuarterlySalesReport>();

            foreach (var quarter in quarterGroups)
            {
                var months = monthlyReports
                    .Where(m => quarter.Value.Contains(m.MonthName))
                    .ToList();

                decimal estimated = months.Sum(m => m.EstimatedSales);
                decimal achieved = months.Sum(m => m.SalesAchieved);

                quarterlyReports.Add(new QuarterlySalesReport
                {
                    QuarterName = quarter.Key,
                    EstimatedSales = estimated,
                    SalesAchieved = achieved,
                    IsSalesIncreased = achieved > estimated
                });
            }

            return quarterlyReports;
        }













        private double GetSalesPercent(decimal estimatedSales, decimal salesAchieved)
    {
            return estimatedSales == 0 ? 0 : Math.Round((double)(salesAchieved / estimatedSales)*100);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
