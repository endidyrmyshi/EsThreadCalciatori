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
using System.Diagnostics;

namespace EsThreadCalciatori
{

    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Uri uriRonaldo = new Uri("Ronaldoo2.png", UriKind.Relative); //parallelo del URL ma del file locale..
        readonly Uri uriMessi = new Uri("Messi.png", UriKind.Relative);
        int posRonaldo;
        int posMessi;


        public int posOrizzontaleWrestler1 = 196;
        public int posOrizzontaleWrestler2 = 442;

        Random r1 = new Random();
        Random r2 = new Random();
        public int giaVinto = 0;



        public MainWindow()
        {
            InitializeComponent();

            Thread t1 = new Thread(new ThreadStart(MuoviRonaldo));

            ImageSource imm = new BitmapImage(uriRonaldo);  //creo l'oggetto
            imgRonaldo2.Source = imm;
            t1.Start();


            Thread t2 = new Thread(new ThreadStart(MuoviMessi));

            ImageSource imm2 = new BitmapImage(uriMessi);  //creo l'oggetto
            imgMessi.Source = imm2;

            t2.Start();

            t1.Join(1);
            t2.Join(1);

        }

        public void MuoviRonaldo()
        {

            while (posRonaldo < 500)
            {
                posRonaldo += r1.Next(1, 5);

                Thread.Sleep(TimeSpan.FromMilliseconds(300));

                this.Dispatcher.BeginInvoke(new Action(() =>    //visto che cè un conflitto usiamo Dispatcher che attraverso un delegato action
                {

                    imgRonaldo2.Margin = new Thickness(posRonaldo, 100, 0, 0);


                }));

            }
            if (giaVinto == 0)
            {
                giaVinto = 1;
                MessageBox.Show("Ha vinto RONALDO!!");
            }




        }
        public void MuoviMessi()
        {

            while (posMessi < 500)
            {
                posMessi += r1.Next(1, 5);

                Thread.Sleep(TimeSpan.FromMilliseconds(300));

                this.Dispatcher.BeginInvoke(new Action(() =>    //visto che cè un conflitto usiamo Dispatcher che attraverso un delegato action
                {
                    imgMessi.Margin = new Thickness(posMessi, 300, 0, 0);


                }));

            }
            if (giaVinto == 0)
            {
                giaVinto = 1;
                MessageBox.Show("Ha vinto MESSI!!");





            }
        }
    }
}
