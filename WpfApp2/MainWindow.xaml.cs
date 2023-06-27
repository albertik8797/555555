using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace CalendarApp
{
    public partial class MainWindow : Window
    {
        private DateTime currentDate;
        private List<FoodCategory> selectedFoodCategories;

        public MainWindow()
        {
            InitializeComponent();

            currentDate = DateTime.Today;
            monthYearTextBlock.Text = currentDate.ToString("MMMM yyyy");
            selectedFoodCategories = new List<FoodCategory>();
            UpdateCalendar();
        }

        private void previousMonthButton_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            monthYearTextBlock.Text = currentDate.ToString("MMMM yyyy");
            UpdateCalendar();
        }

        private void nextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            monthYearTextBlock.Text = currentDate.ToString("MMMM yyyy");
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            calendarItemsControl.Items.Clear();

            // Добавляем дни недели
            string[] dayOfWeekNames = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
            foreach (string dayOfWeek in dayOfWeekNames)
            {
                calendarItemsControl.Items.Add(dayOfWeek);
            }

            // Определяем первый день месяца
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Добавляем пустые ячейки для выравнивания дней недели
            for (int i = 1; i < (int)firstDayOfMonth.DayOfWeek; i++)
            {
                calendarItemsControl.Items.Add("");
            }

            // Добавляем дни месяца
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            for (int day = 1; day <= daysInMonth; day++)
            {
                var dayTextBlock = new TextBlock()
                {
                    Text = day.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                var border = new Border()
                {
                    Child = dayTextBlock
                };

                border.MouseDoubleClick += DayTextBlock_MouseDoubleClick;

                calendarItemsControl.Items.Add(border);
            }
        }


        private void DayTextBlock_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is TextBlock textBlock)
            {
                var border = textBlock.Parent as Border;
                if (border != null)
                {
                    var selectedDay = int.Parse(textBlock.Text);
                    var foodCategoryWindow = new FoodCategoryWindow();
                    if (foodCategoryWindow.ShowDialog() == true)
                    {
                        var selectedCategory = foodCategoryWindow.SelectedCategory;
                        selectedFoodCategories.Add(selectedCategory);
                        // Сохранение выбранных пунктов в JSON
                        SaveSelectedCategoriesToJson(selectedFoodCategories, selectedDay);
                    }
                }
            }
        }


        private void SaveSelectedCategoriesToJson(List<FoodCategory> categories, int day)
        {
            var data = new Dictionary<int, List<string>>();

            if (File.Exists($"Day{day}.json"))
            {
                var json = File.ReadAllText($"Day{day}.json");
                data = JsonConvert.DeserializeObject<Dictionary<int, List<string>>>(json);
            }
            else
            {
                data[day] = new List<string>();
            }

            foreach (var category in categories)
            {
                if (!data.ContainsKey(day))
                {
                    data[day] = new List<string>();
                }
                data[day].Add(category.Name);
            }

            var jsonResult = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText($"Day{day}.json", jsonResult);
        }
    }
}
