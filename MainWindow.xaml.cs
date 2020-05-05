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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool turn = true;   //true = X trun; false = Y turn
        int turn_count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        public static IEnumerable<Control> Controls { get; private set; }

        private void button_click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Content = "X";

            else
                b.Content = "O";

            turn = !turn;
            b.IsEnabled = false;
            turn_count++;
            checkForWinner();
        }

        private void checkForWinner()
        {

            bool there_is_a_winner = false;
            //horizonal checks
            if ((A1.Content == A2.Content) && (A2.Content == A3.Content) && (!A1.IsEnabled))
                there_is_a_winner = true;
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B1.IsEnabled))
                there_is_a_winner = true;
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C1.IsEnabled))
                there_is_a_winner = true;
            //vertical checks
            else if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (!A1.IsEnabled))
                there_is_a_winner = true;
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (!A2.IsEnabled))
                there_is_a_winner = true;
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (!A3.IsEnabled))
                there_is_a_winner = true;
            //diagonal checks
            else if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (!A1.IsEnabled))
                there_is_a_winner = true;
            else if ((A3.Content == B2.Content) && (B2.Content == C1.Content) && (!A3.IsEnabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                disableButtons(false);
                String winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + " wins!", "Yay!");
            }

            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Draw!", "Bummer!");
            }

        }   //end checkForWinner

        private void disableButtons(bool TF)
        {
            A1.IsEnabled = TF;
            A2.IsEnabled = TF;
            A3.IsEnabled = TF;
            B1.IsEnabled = TF;
            B2.IsEnabled = TF;
            B3.IsEnabled = TF;
            C1.IsEnabled = TF;
            C2.IsEnabled = TF;
            C3.IsEnabled = TF;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            turn = true;
            turn_count = 0;

            disableButtons(true);
            A1.Content = "";
            A2.Content = "";
            A3.Content = "";
            B1.Content = "";
            B2.Content = "";
            B3.Content = "";
            C1.Content = "";
            C2.Content = "";
            C3.Content = ""; 

        }
    }
}
