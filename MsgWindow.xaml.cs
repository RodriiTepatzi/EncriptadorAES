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
using System.Windows.Shapes;

namespace EncriptadorDES
{
    /// <summary>
    /// Lógica de interacción para MsgWindow.xaml
    /// </summary>
    public partial class MsgWindow : Window
    {
        public MsgWindow(string msg, string tipo)
        {
            InitializeComponent();
            msg_label.Text = msg;
            tipo_label.Content = tipo;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void close_MouseEnter(object sender, MouseEventArgs e)
        {
            close.Source = new BitmapImage(new Uri("/close_hover.png", UriKind.Relative));
        }

        private void close_MouseLeave(object sender, MouseEventArgs e)
        {
            close.Source = new BitmapImage(new Uri("/close.png", UriKind.Relative));
        }

    }
}
