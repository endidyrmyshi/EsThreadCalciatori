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
using System.Threading;

namespace EsThreadCalciatori
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Uri uriRonaldo = new Uri("Ronaldo.jfif", UriKind.Relative);   //parallelo del URL ma del file locale
        int posRonaldo;
        
        public MainWindow()
        {
            InitializeComponent();
           
            Thread t1 = new Thread(new ThreadStart(MuoviRonaldo));

            ImageSource imm = new BitmapImage(uriRonaldo);  //creo l'oggetto
            imgRonaldo.Source = imm;

            t1.Start();

         

        }

        public void MuoviRonaldo()
        {

            while (posRonaldo < 500)
            {
                posRonaldo += 100;

                Thread.Sleep(TimeSpan.FromMilliseconds(200));

                this.Dispatcher.BeginInvoke(new Action(() =>    //visto che cè un conflitto usiamo Dispatcher che attraverso un delegato action
                {
                    imgRonaldo.Margin = new Thickness(posRonaldo, 100, 0, 0);


                }));

            }




        }
    }
}
