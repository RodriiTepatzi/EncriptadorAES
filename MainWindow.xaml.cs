using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncriptadorDES
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        double xClick, yClick;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public IntPtr handle;

        private static char[] ValidHexChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        MsgWindow MsgWindoww;

        public MainWindow()
        {
            InitializeComponent();
            handle = new WindowInteropHelper(this).Handle;
        }

        private void close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void minimizar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Foreground == Application.Current.TryFindResource("BlackSecondary") as SolidColorBrush)
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Foreground = Application.Current.TryFindResource("GreenPrimary") as SolidColorBrush;
                }
            }
        }

        private void tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Text.Trim().Equals("") || ((TextBox)sender).Text.Trim().Equals("Texto normal"))
                {
                    ((TextBox)sender).Foreground = Application.Current.TryFindResource("BlackSecondary") as SolidColorBrush;
                    ((TextBox)sender).Text = "Texto normal";
                }
            }
        }

        private void tb2_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Foreground == Application.Current.TryFindResource("BlackSecondary") as SolidColorBrush)
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Foreground = Application.Current.TryFindResource("GreenPrimary") as SolidColorBrush;
                }
            }
        }

        private void tb2_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Text.Trim().Equals("") || ((TextBox)sender).Text.Trim().Equals("Texto encriptado"))
                {
                    ((TextBox)sender).Foreground = Application.Current.TryFindResource("BlackSecondary") as SolidColorBrush;
                    ((TextBox)sender).Text = "Texto encriptado";
                }
            }
        }

        private void tb3_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Foreground == Application.Current.TryFindResource("BlackSecondary") as SolidColorBrush)
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Foreground = Application.Current.TryFindResource("GreenPrimary") as SolidColorBrush;
                }
            }
        }

        private void tb3_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Text.Trim().Equals("") || ((TextBox)sender).Text.Trim().Equals("Llave (32 caracteres) (Hexadecimal)"))
                {
                    ((TextBox)sender).Foreground = Application.Current.TryFindResource("BlackSecondary") as SolidColorBrush;
                    ((TextBox)sender).Text = "Llave (32 caracteres) (Hexadecimal)";
                }
            }
        }

        private void encriptar_btn_Click(object sender, RoutedEventArgs e)
        {
            String llave = TextboxLlave.Text;
            String nombreDeArchivo = "TextoEncriptado.txt";
            String textoEncriptar = txt_normal.Text;
            bool wasSucess = false;


            if (llave == null || llave.Length != 32
                || textoEncriptar == null || textoEncriptar.Length > 100
                || nombreDeArchivo == null
                || !llave.ToUpper().ToCharArray().All(x => ValidHexChars.Contains(x)))
            {
                if (textoEncriptar == "Texto normal")
                {
                    MsgWindoww = new MsgWindow("Campo texto normal vacio.", "Error");
                    MsgWindoww.ShowDialog();
                }
                else if(llave == null)
                {
                    MsgWindoww = new MsgWindow("Campo llave vacio.", "Error");
                    MsgWindoww.ShowDialog();
                }
                else if (llave.Length != 32)
                {
                    MsgWindoww = new MsgWindow("La llave debe contener 32 caracteres.", "Error");
                    MsgWindoww.ShowDialog();
                }
                else if (!llave.ToUpper().ToCharArray().All(x => ValidHexChars.Contains(x)))
                {
                    MsgWindoww = new MsgWindow("La llave debe ser en formato hexadecimal.", "Error");
                    MsgWindoww.ShowDialog();
                }
                return;
            }


            byte[] llaveComoBytes = Util.StringToByteArray(llave);
            var datosEncryptados = EncriptadorAES.EncriptarConAES256(llaveComoBytes, textoEncriptar);

            if (datosEncryptados != null)
            {
                wasSucess = Util.WriteByteArrayToFile("./" + nombreDeArchivo, datosEncryptados);
                txt_encriptado.Text = Encoding.Default.GetString(datosEncryptados);
                txt_encriptado.Foreground = Application.Current.TryFindResource("GreenPrimary") as SolidColorBrush;
            }

            if (wasSucess)
            {
                MsgWindoww = new MsgWindow("Encriptación correcta.", "Correcto");
                MsgWindoww.ShowDialog();
            }
            else
            {
                MsgWindoww = new MsgWindow("Error desconocido al encriptar. Intentelo de nuevo", "Error");
                MsgWindoww.ShowDialog();
            }
        }

        private void desencriptar_btn_Click(object sender, RoutedEventArgs e)
        {
            String llave = TextboxLlave.Text;
            String encriptado = txt_encriptado.Text;
            String nombreDeArchivo = "temp.txt";

            //Encoding.ASCII.GetBytes(encriptado)

            if (llave == null || llave.Length != 32
            || nombreDeArchivo == null
            || !llave.ToUpper().ToCharArray().All(x => ValidHexChars.Contains(x)))
            {
                if (encriptado == "Texto encriptado")
                {
                    MsgWindoww = new MsgWindow("Campo texto encriptado vacio.", "Error");
                    MsgWindoww.ShowDialog();
                }
                else if (llave == null)
                {
                    MsgWindoww = new MsgWindow("Campo llave vacio.", "Error");
                    MsgWindoww.ShowDialog();
                }
                else if (llave.Length != 32)
                {
                    MsgWindoww = new MsgWindow("La llave debe contener 32 caracteres.", "Error");
                    MsgWindoww.ShowDialog();
                }
                else if (!llave.ToUpper().ToCharArray().All(x => ValidHexChars.Contains(x)))
                {
                    MsgWindoww = new MsgWindow("La llave debe ser en formato hexadecimal.", "Error");
                    MsgWindoww.ShowDialog();
                }
                return;
            }

            var datosEncryptados = Encoding.Default.GetBytes(encriptado);

            var textoPlano = EncriptadorAES.DesencriptarConAES256(Util.StringToByteArray(llave), datosEncryptados);

            if (textoPlano == null)
            {
                MsgWindoww = new MsgWindow("Ocurrio un error desconcido al desencriptar. Intentelo de nuevo.", "Error");
                textoPlano = "Texto normal";
                MsgWindoww.ShowDialog();

                txt_normal.Text = textoPlano;
                txt_normal.Foreground = Application.Current.TryFindResource("BlackSecondary") as SolidColorBrush;
            }
            else
            {
                MsgWindoww = new MsgWindow("Desencriptación correcta.", "Correcto");
                MsgWindoww.ShowDialog();

                txt_normal.Text = textoPlano;
                txt_normal.Foreground = Application.Current.TryFindResource("GreenPrimary") as SolidColorBrush;
            }
        }

        private void title_label_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Label).Foreground = Application.Current.TryFindResource("GreenPrimary") as SolidColorBrush;
        }

        private void title_label_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Label).Foreground = Application.Current.TryFindResource("BlackSecondary") as SolidColorBrush;
        }

        private void copiar1_Click(object sender, RoutedEventArgs e)
        {
            if (txt_normal.Text.ToString() != "Texto normal")
            {
                Clipboard.SetText(txt_normal.Text);
            }
            else
            {
                MsgWindoww = new MsgWindow("El campo esta vacio. No es posible realizar esta acción.", "Error");
                MsgWindoww.ShowDialog();
            }
        }

        private void copiar2_Click(object sender, RoutedEventArgs e)
        {
            if (txt_encriptado.Text.ToString() != "Texto encriptado")
            {
                Clipboard.SetText(txt_encriptado.Text);
            }
            else
            {
                MsgWindoww = new MsgWindow("El campo esta vacio. No es posible realizar esta acción.", "Error");
                MsgWindoww.ShowDialog();
            }
        }

        private void copiar3_Click(object sender, RoutedEventArgs e)
        {
            if (TextboxLlave.Text.ToString() != "Llave (32 caracteres) (Hexadecimal)" && TextboxLlave.Text.ToUpper().ToCharArray().All(x => ValidHexChars.Contains(x)))
            {
                Clipboard.SetText(TextboxLlave.Text);
            }
            else
            {
                MsgWindoww = new MsgWindow("El campo esta vacio o no es hexadecimal. No es posible realizar esta acción.", "Error");
                MsgWindoww.ShowDialog();
            }
        }

        private void mainFrame_MouseDown(object sender, MouseButtonEventArgs e)
        {

            /*if (e.ChangedButton == MouseButton.Left)
                this.DragMove();*/
            Keyboard.ClearFocus();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void minimizar_MouseEnter(object sender, MouseEventArgs e)
        {
            minimizar.Source = new BitmapImage(new Uri("/minimizar_hover.png", UriKind.Relative));
        }

        private void minimizar_MouseLeave(object sender, MouseEventArgs e)
        {
            minimizar.Source = new BitmapImage(new Uri("/minimizar.png", UriKind.Relative));
        }

        private void generar_Click(object sender, RoutedEventArgs e)
        {
            GeneradorLlave generadorLlave = new GeneradorLlave();
            TextboxLlave.Text = generadorLlave.Generar();
            TextboxLlave.Foreground = Application.Current.TryFindResource("GreenPrimary") as SolidColorBrush;
        }


    }
}
