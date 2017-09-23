using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Tic_tac_toe
{
    public partial class PlayGround : UserControl
    {
        public PlayGround()
        {
            InitializeComponent();
            expecting.Value = 0;
            expecting.IsIndeterminate = true;

            map = new int[3, 3];

            buttons = new Button[10];
            buttons[0] = button0;
            buttons[1] = button1;
            buttons[2] = button2;
            buttons[3] = button3;
            buttons[4] = button4;
            buttons[5] = button5;
            buttons[6] = button6;
            buttons[7] = button7;
            buttons[8] = button8;
        }

        private Button[] buttons;
        private int[,] map;
        private char computer;
        private char player;
        private int freeFields = 9;

        private void Occupy(int number, char marker)
        {
            map[number / 3, number % 3] = marker == player ? 1 : -1; 
            buttons[number].Content = marker;
            --freeFields;
        }

        private void OnButtonsClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = button.Name[6] - 48;
            if (map[index / 3, index % 3] != 0)
            {
                return;
            }

            Occupy(index, player);
            if (freeFields > 0)
            {
                ComputersMove();
            }
            else
            {
                GameOver();
            }
        }

        private void ComputersMove()
        {
            if (VictoryLine() != -1)
            {
                Victory(VictoryLine());
                return;
            }

            if (map[1, 1] == 0)
            {
                Occupy(4, computer);
                return;
            }

            if (LoseLine() != -1)
            {
                Protection(LoseLine());
                return;
            }

            RandomMove();
            if (freeFields == 0)
            {
                GameOver();
            }
        }

        private void RandomMove()
        {
            string unoccupied = "";
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (map[i, j] == 0)
                    {
                        unoccupied = unoccupied + Convert.ToString(i * 3 + j);
                    }
                }
            }

            int index = unoccupied[(new Random()).Next(0, 44) % unoccupied.Length] - 48;
            Occupy(index, computer);
        }


        private void Protection(int protectionLine)
        {
            if (protectionLine < 3)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (map[protectionLine, i] == 0)
                    {
                        Occupy(protectionLine * 3 + i, computer);
                        break;
                    }
                }
            }
            else if (protectionLine < 6)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (map[i, protectionLine % 3] == 0)
                    {
                        Occupy(protectionLine % 3 + i * 3, computer);
                        break;
                    }
                }
            }
            else if (protectionLine == 6)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (map[i, i] == 0)
                    {
                        Occupy(4 * i, computer);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (map[i, 2 - i] == 0)
                    {
                        Occupy(2 + 2 * i, computer);
                        break;
                    }
                }
            }
        }

        private void Victory(int victoryLine)
        {
            if (victoryLine < 3)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (map[victoryLine, i] == 0)
                    {
                        Occupy(victoryLine + i, computer);
                        break;
                    }
                }
            }
            else if (victoryLine < 6)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (map[i, victoryLine % 3] == 0)
                    {
                        Occupy(victoryLine % 3 + i * 3, computer);
                        break;
                    }
                }
            }
            else if (victoryLine == 6)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (map[i, i] == 0)
                    {
                        Occupy(4 * i, computer);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (map[i, 2 - i] == 0)
                    {
                        Occupy(2 + 2 * i, computer);
                        break;
                    }
                }
            }

            GameOver();
        }

        private void GameOver()
        {
            dialogBox.Visibility = Visibility.Visible;
            dialogBox.FontSize = 40;
            dialogBox.Content = "Game over";
            for (int i = 0; i < 9; ++i)
            {
                buttons[i].IsEnabled = false;
            }
        }

        private int LoseLine()
        {
            for (int i = 0; i < 6; ++i)
            {
                if (i < 3)
                {
                    if (map[i, 0] + map[i, 1] + map[i, 2] == 2)
                    {
                        return i;
                    }
                }
                else
                {
                    if (map[0, i % 3] + map[1, i % 3] + map[2, i % 3] == 2)
                    {
                        return i;
                    }
                }
            }

            if (map[0, 0] + map[1, 1] + map[2, 2] == 2)
            {
                return 6;
            }

            if (map[2, 0] + map[1, 1] + map[0, 2] == 2)
            {
                return 7;
            }

            return -1;
        }

        private int VictoryLine()
        {
            for (int i = 0; i < 6; ++i)
            {
                if (i < 3)
                {
                    if (map[i, 0] + map[i, 1] + map[i, 2] == -2)
                    {
                        return i;
                    }
                }
                else
                {
                    if (map[0, i % 3] + map[1, i % 3] + map[2, i % 3] == -2)
                    {
                        return i;
                    }
                }
            }

            if (map[0, 0] + map[1, 1] + map[2, 2] == -2)
            {
                return 6;
            }

            if (map[2, 0] + map[1, 1] + map[0, 2] == -2)
            {
                return 7;
            }

            return -1;
        }

        private void OnButtonChoiceClick(object sender, RoutedEventArgs e)
        {
            player = Convert.ToChar(((Button)sender).Content);
            computer = player == 'X' ? '0' : 'X';
            button0.Visibility = Visibility.Visible;
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
            button4.Visibility = Visibility.Visible;
            button5.Visibility = Visibility.Visible;
            button6.Visibility = Visibility.Visible;
            button7.Visibility = Visibility.Visible;
            button8.Visibility = Visibility.Visible;
            grid.Children.Remove(buttonChoice0);
            grid.Children.Remove(buttonChoiceX);
            dialogBox.Visibility = Visibility.Collapsed;
            playerBox.Visibility = Visibility.Visible;
            playerBox.Content = "Player | " + player;
            computerBox.Visibility = Visibility.Visible;
            computerBox.Content = "Computer | " + computer;
            if (computer == 'X')
            {

                ComputersMove();
                return;
            }

            //tip.Visibility = Visibility.Visible;
            //tip.Content = "Your move";
        }

        private void OnButtonOKClick(object sender, RoutedEventArgs e)
        {
            dialogBox.Content = "choose your counter,\nplease";
            buttonChoiceX.Visibility = Visibility.Visible;
            buttonChoice0.Visibility = Visibility.Visible;
            buttonChoiceX.IsEnabled = true;
            buttonChoiceX.IsEnabled = true;
            grid.Children.Remove(buttonOK);
        }
    }
}
