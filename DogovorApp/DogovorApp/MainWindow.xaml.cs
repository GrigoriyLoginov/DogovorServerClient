using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.ComponentModel;
using DogovorApp.DogService;
using System.Windows.Input;

namespace Client
{
    public partial class MainWindow : Window
    {
        readonly DogServiceClient client = new DogServiceClient("BasicHttpBinding_IDogService");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillGrid();
        }
        /// <summary>
        /// Converting List<T> data to DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        private static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                if (prop.Name != "ExtensionData")
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    if (prop.Name != "ExtensionData")
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        /// <summary>
        /// Inizialization GridTable
        /// </summary>
        public void FillGrid()
        {
            var client = new DogServiceClient("BasicHttpBinding_IDogService");
            DogGrid.ItemsSource = ToDataTable(client.FillDataTable()).DefaultView;
            client.Close();
        }
        /// <summary>
        /// Change Date Actual with renewal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            DateTime ActualDate = (DateTime)DateActual.SelectedDate;
            client.CheckActualDate(ActualDate);
            FillGrid();
            DogGrid.Focus();
        }
        /// <summary>
        /// Auto-form collunms and resize collumns at creation time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DogGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            if (e.PropertyType == typeof(DateTime))
            {
                if (e.Column is DataGridTextColumn dataGridTextColumn)
                {
                    dataGridTextColumn.Binding.StringFormat = "{0:dd.MM.yyyy}";
                }
            }
            if (e.PropertyName == "ID")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "ACTUAL")
                e.Column.Header = "Актуальность";
            else if (e.Column.Header.ToString() == "DOG_NO")
                e.Column.Header = "Номер договора";
            else if (e.Column.Header.ToString() == "DOG_DATE")
                e.Column.Header = "Дата договора";
            else if (e.Column.Header.ToString() == "LAST_UPDATE")
                e.Column.Header = "Дата последнего обновления";
            if (e.PropertyName == "LAST_UPDATE")
            {
                e.Column.IsReadOnly = true;
            }
        }
        #region button events
        /// <summary>
        /// Granding editing rights DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButChange_Click(object sender, RoutedEventArgs e)
        {
            DogGrid.IsReadOnly = false;
            ButUpdate.IsEnabled = true;
            DogGrid.Focus();
        }
        /// <summary>
        /// Remove editing rights DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButCancel_Click(object sender, RoutedEventArgs e)
        {
            DogGrid.IsReadOnly = true;
            ButUpdate.IsEnabled = false;
            DogGrid.SelectedIndex = 0;
            DogGrid.Focus();
        }
        /// <summary>
        /// Update selected row 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DogGrid.SelectedItem as DataRowView != null)
            {
                DataRowView dog = DogGrid.SelectedItem as DataRowView;
                Dogovor dogovor = new Dogovor
                {
                    ID = int.Parse(dog.Row["ID"].ToString()),
                    DOG_NO = dog.Row["DOG_NO"].ToString(),
                    DOG_DATE = DateTime.Parse(dog.Row["DOG_DATE"].ToString()),
                    LAST_UPDATE = DateTime.Parse(dog.Row["LAST_UPDATE"].ToString()),
                    ACTUAL = bool.Parse(dog.Row["ACTUAL"].ToString())
                };
                client.UpdateDog(dogovor);
                FillGrid();
                ButUpdate.IsEnabled = false;
                DogGrid.Focus();
            }
        }
        #endregion
    }
}
