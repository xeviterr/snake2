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
using System.Windows.Threading;

namespace Snake2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SnakeGame jocSerp = new SnakeGame();
        DispatcherTimer timer = new DispatcherTimer();
        
        public MainWindow()
        {
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas.Children.Clear();

            int tamanyXCasella = (int)(canvas.ActualWidth / SnakeGame.X_SIZE);
            int tamanyYCasella = (int)(canvas.ActualHeight / SnakeGame.Y_SIZE);

            //Redibuixar cada vegada.
            Ellipse ellSerp = new Ellipse()
            {
                Fill = Brushes.Green,
                Width = tamanyXCasella,
                Height = tamanyYCasella,
            };
            canvas.Children.Add(ellSerp);
            Canvas.SetTop(ellSerp, jocSerp.CapSerp.Y * tamanyYCasella );
            Canvas.SetLeft(ellSerp, jocSerp.CapSerp.X * tamanyXCasella );

            foreach( var poma in jocSerp.Pomes)
            {
                Ellipse ell = new Ellipse()
                {
                    Fill = Brushes.Yellow,
                    Width = tamanyXCasella,
                    Height = tamanyYCasella,
                };
                canvas.Children.Add(ell);
                Canvas.SetTop(ell, poma.Y * tamanyYCasella);
                Canvas.SetLeft(ell, poma.X * tamanyXCasella);
            }
        }

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
                jocSerp.moure(DireccioSnake.Amunt);
            else if (e.Key == Key.Down)
                jocSerp.moure(DireccioSnake.Avall);
            else if (e.Key == Key.Left)
                jocSerp.moure(DireccioSnake.Esquerre);
            else if (e.Key == Key.Right)
                jocSerp.moure(DireccioSnake.Dreta);
        }
    }
}
