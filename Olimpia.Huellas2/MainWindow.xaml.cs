using Olimpia.Business.Caculate;
using Olimpia.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olimpia.Huellas2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstPawPrint = this.txtFirstPawPrint.Text;
                string secodPawPrint = this.txtSecodPawPrint.Text;
                int acceptanceParameter = int.Parse(this.txtAcceptanceParameter.Text);
                if (string.IsNullOrEmpty(firstPawPrint) || string.IsNullOrEmpty(secodPawPrint) || acceptanceParameter <= 0)
                {
                    MessageBox.Show("Alguno de los valores de entrada es incorrecto por favor valide nuevamente");
                }
                else
                {
                    this.txtResult.Text = "";
                    DataTest data = new DataTest() { FirstPawPrint = firstPawPrint, SecodPawPrint = secodPawPrint, AcceptanceParameter = acceptanceParameter };
                    CalculateMatch newMarch = new CalculateMatch(data);
                    this.txtResult.Text = newMarch.GetValidation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se genero un error al realizar la válidación por favor intente nuevamente");
            }
        }
    }
}
