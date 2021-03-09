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

namespace Olimpia.Intersección
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
                if (string.IsNullOrEmpty(this.txtPositionX1.Text) ||
                    string.IsNullOrEmpty(this.txtPositionY1.Text) ||
                    string.IsNullOrEmpty(this.txtRadio1.Text) ||
                    string.IsNullOrEmpty(this.txtPositionX2.Text) ||
                    string.IsNullOrEmpty(this.txtPositionY2.Text) ||
                    string.IsNullOrEmpty(this.txtRadio2.Text))
                {
                    MessageBox.Show("Debe de ingresar información en los campos, recuerde solo números enteros");
                }
                else
                {
                    this.txtResult.Text = "";
                    int postionX1 = int.Parse(this.txtPositionX1.Text);
                    int postionY1 = int.Parse(this.txtPositionY1.Text);
                    int radio1 = int.Parse(this.txtRadio1.Text);

                    int postionX2 = int.Parse(this.txtPositionX2.Text);
                    int postionY2 = int.Parse(this.txtPositionY2.Text);
                    int radio2 = int.Parse(this.txtRadio2.Text);

                    Circle circle1 = new Circle() { X = postionX1, Y = postionY1, Radio = radio1 };
                    Circle circle2 = new Circle() { X = postionX2, Y = postionY2, Radio = radio2 };
                    CalculateIntersection newIntersection = new CalculateIntersection(circle1, circle2);
                    bool result = newIntersection.GetStatusIntersection();
                    this.txtResult.Text = result ? "Intersecciòn encontrada bajo los radios y centros suminstrados" : "No se encontro intersecciòn entre los centros y radios suministrados";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("se genero un error al convertir los datos, recuerde que son solo nùmeros enteros los que se van a validar");
            }
        }
    }
}
