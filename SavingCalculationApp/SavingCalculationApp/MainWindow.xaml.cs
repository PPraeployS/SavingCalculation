using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SavingCalculationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double income = 0;
        private double expense = 0;
        private double price = 0;
        private int numberOfDays = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            //verify input is valids
            if (Textbox_Income.Text == string.Empty || Textbox_Expense.Text == string.Empty || Textbox_Price.Text == string.Empty)
            {
                MessageBox.Show("Information is not valid");
                return;
            }

            // get input and calculate
            income = double.Parse(Textbox_Income.Text);
            expense = double.Parse(Textbox_Expense.Text);
            price = double.Parse(Textbox_Price.Text);

            numberOfDays = CalculateNumberOfDaysForSaving();

            if (numberOfDays < 0)
            {
                MessageBox.Show("Your expense is more than income, please try to save more");
                return;
            }

            // display result
            Textbox_NumberOfThedaysSaving.Text = numberOfDays.ToString();
        }


        private int CalculateNumberOfDaysForSaving()
        {
            double balance = 0;
            balance = income - expense;

            return (int)Math.Ceiling(price / balance);
        }
    }
}