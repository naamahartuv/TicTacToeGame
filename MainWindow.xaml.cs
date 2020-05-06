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
            {
                b.Content = "X";
                turn = !turn;
            }

            else
                b.Content = "O";    //here mabey i need to send to cpu

            
            b.IsEnabled = false;
            turn_count++;
            if (!checkForWinner())
            {
                if (!turn && CPU()!= null)
                {
                    CPU().Content = "O";
                    turn = !turn;
                    turn_count++;
                    bool ans = checkForWinner();
                        
                }
                else
                    _ = checkForWinner();
            }
        }

        private bool checkForWinner()
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
                return true;
            }

            else
            {
                if (turn_count ==9)
                {
                    MessageBox.Show("Draw!", "Bummer!");
                    return true;
                }
                return false;
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

        public Button CPUMoveRandom()
        {
            Button b = null;

            if ((A1 != null) && (A1.Content == ""))
                return A1;
            else if ((A2 != null) && (A2.Content == ""))
                return A2;
            else if ((A3 != null) && (A3.Content == ""))
                return A3;

            else if ((B1 != null) && (B1.Content == ""))
                return B1;
            else if ((B2 != null) && (B2.Content == ""))
                return B2;
            else if ((B3 != null) && (B3.Content == ""))
                return B3;

            else if ((C1 != null) && (C1.Content == ""))
                return C1;
            else if ((C2 != null) && (C2.Content == ""))
                return C2;
            else if ((C3 != null) && (C3.Content == ""))
                return C3;


            return null;
        }

        public Button CPU()
        {
            Button b = null;
            b = CPUTryWinorDefend("O");
            if (b != null)
            {
                b.IsEnabled = false;
                return b;
            }
            else
            {
                b = CPUTryWinorDefend("X");
                if (b != null)
                {
                    b.IsEnabled = false;
                    return b;
                }
                else
                {
                    Button x = CPUMoveRandom();
                    if (x != null) {
                        x.IsEnabled = false;
                    }
                    return x;
                }

            }
        }

        public Button CPUTryWinorDefend(string s)
        {
            Button b = null;
            //horizontal check
            if ((A1.Content == A2.Content) && A1.Content == s && A3.Content == "")
                return A3;
            else if ((A1.Content == A3.Content) && A1.Content == s && A2.Content == "")
                return A2;
            else if ((A2.Content == A3.Content) && A2.Content == s && A1.Content == "")
                return A1;

            else if ((B1.Content == B2.Content) && B1.Content == s && B3.Content == "")
                return B3;
            else if ((B1.Content == B3.Content) && B1.Content == s && B2.Content == "")
                return B2;
            else if ((B2.Content == B3.Content) && B2.Content == s && B1.Content == "")
                return B1;

            else if ((C1.Content == C2.Content) && C1.Content == s && C3.Content == "")
                return C3;
            else if ((C1.Content == C3.Content) && C1.Content == s && C2.Content == "")
                return C2;
            else if ((C2.Content == C3.Content) && C2.Content == s && C1.Content == "")
                return C1;

            //vertical checks
            else if ((A1.Content == B1.Content) && A1.Content == s && C1.Content == "")
                return C1;
            else if ((A1.Content == C1.Content) && A1.Content == s && B1.Content == "")
                return B1;
            else if ((C1.Content == B1.Content) && B1.Content == s && A1.Content == "")
                return A1;

            else if ((C2.Content == B2.Content) && B2.Content == s && A2.Content == "")
                return A2;
            else if ((C2.Content == A2.Content) && A2.Content == s && B2.Content == "")
                return B2;
            else if ((B2.Content == A2.Content) && B2.Content == s && C2.Content == "")
                return C2;

            else if ((C3.Content == B3.Content) && B3.Content == s && A3.Content == "")
                return A3;
            else if ((C3.Content == A3.Content) && C3.Content == s && B3.Content == "")
                return B3;
            else if ((A3.Content == B3.Content) && A3.Content == s && C3.Content == "")
                return C3;

            //daigonal checks
            else if ((A1.Content == B2.Content) && B2.Content == s && C3.Content == "")
                return C3;
            else if ((A1.Content == C3.Content) && A1.Content == s && B2.Content == "")
                return B2;
            else if ((B2.Content == C3.Content) && B2.Content == s && A1.Content == "")
                return A1;

            else if ((C1.Content == B2.Content) && B2.Content == s && A3.Content == "")
                return A3;
            else if ((C1.Content == A3.Content) && C1.Content == s && B2.Content == "")
                return B2;
            else if ((A3.Content == B2.Content) && A3.Content == s && C1.Content == "")
                return C1;

            else
                return null;
        }

    }
}
