using System.Windows;
using System.Windows.Controls;


namespace CalendarApp
{
    public partial class FoodCategoryWindow : Window
    {
        public FoodCategory SelectedCategory { get; private set; }

        public FoodCategoryWindow()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (foodCategoryListBox.SelectedItem is ListBoxItem selectedItem)
            {
                SelectedCategory = new FoodCategory { Name = selectedItem.Content.ToString() };
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите категорию еды.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
