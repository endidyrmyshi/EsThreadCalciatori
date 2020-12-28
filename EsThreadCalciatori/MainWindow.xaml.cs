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
        readonly Uri uriRonaldo = new Uri("Ronaldo.jfif", UriKind.Relative); //parallelo del URL ma del file locale..
        readonly Uri uriMessi = new Uri("Messi.png", UriKind.Relative);
        int posRonaldo;
        int posMessi;

        public MainWindow()
        {
            InitializeComponent();
           
            Thread t1 = new Thread(new ThreadStart(MuoviRonaldo));

            ImageSource imm = new BitmapImage(uriRonaldo);  //creo l'oggetto
            imgRonaldo.Source = imm;
            t1.Start();


            Thread t2 = new Thread(new ThreadStart(MuoviMessi));

            ImageSource imm2 = new BitmapImage(uriMessi);  //creo l'oggetto
            imgMessi.Source = imm2;

            t2.Start();



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
        public void MuoviMessi()
        {

            while (posMessi < 500)
            {
                posMessi += 100;

                Thread.Sleep(TimeSpan.FromMilliseconds(200));

                this.Dispatcher.BeginInvoke(new Action(() =>    //visto che cè un conflitto usiamo Dispatcher che attraverso un delegato action
                {
                    imgMessi.Margin = new Thickness(posMessi, 300, 0, 0);


                }));

            }




        }
    }
}
