using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Calculator.ViewModel;
using Calculator.Models;
using System.Text.RegularExpressions;
using System.Threading;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MViewModel ViewModel { get; init; }
        private List<Button> buttons { get; init; }
        public MainWindow()
        {
            buttons = new();
            InitializeComponent();
            ViewModel = (MViewModel)DataContext;
            foreach(Button but in MainGrid.Children.OfType<Button>())
            {
                buttons.Add(but);
            }
            Events();
        }

        private void Events() => buttons.ForEach(f => f.Click += (s, e) => Do(s, e));
        private void Do(object sender, RoutedEventArgs e)
        {
            var but = (Button)sender;
            #region Switch
            switch (but.Content)
            {
                case "1":
                    ViewModel.TextBlock += 1;
                    break;
                case "2":
                    ViewModel.TextBlock += 2;
                    break;
                case "3":
                    ViewModel.TextBlock += 3;
                    break;
                case "4":
                    ViewModel.TextBlock += 4;
                    break;
                case "5":
                    ViewModel.TextBlock += 5;
                    break;
                case "6":
                    ViewModel.TextBlock += 6;
                    break;
                case "7":
                    ViewModel.TextBlock += 7;
                    break;
                case "8":
                    ViewModel.TextBlock += 8;
                    break;
                case "9":
                    ViewModel.TextBlock += 9;
                    break;
                case "0":
                    ViewModel.TextBlock += 0;
                    break;
                case "*":
                    ViewModel.TextBlock += "*";
                    break;
                case "/":
                    ViewModel.TextBlock += "/";
                    break;
                case "+":
                    ViewModel.TextBlock += "+";
                    break;
                case "-":
                    ViewModel.TextBlock += "-";
                    break;
                case "^":
                    ViewModel.TextBlock += "^";
                    break;
                case "sqrt(x)":
                    ViewModel.TextBlock += "sqrt";
                    break;
                case ".":
                    ViewModel.TextBlock += ".";
                    break;
                case ",":
                    ViewModel.TextBlock += ",";
                    break;
                case "AC":
                    ViewModel.TextBlock = "";
                    break;
                case "Log10":
                    ViewModel.TextBlock += "log10";
                    break;
                case "e":
                    ViewModel.TextBlock += "e";
                    break;
                case "x":
                    ViewModel.TextBlock += "x";
                    break;
                case "Cos(x)":
                    ViewModel.TextBlock += "cos";
                    break;
                case "Sin(x)":
                    ViewModel.TextBlock += "sin";
                    break;
                case "Tg(x)":
                    ViewModel.TextBlock += "tg";
                    break;
                case "Ctg(x)":
                    ViewModel.TextBlock += "ctg";
                    break;
                case "x/Dx":
                    ViewModel.TextBlock = Operation.Derivative(ViewModel.TextBlock);
                    break;
                case "Sum":
                    //Coming soon
                    break;
                case "!":
                    ViewModel.TextBlock += "!";
                    break;
                case "asin(x)":
                    ViewModel.TextBlock += "asin";
                    break;
                case "acos(x)":
                    ViewModel.TextBlock += "acos";
                    break;
                case "atg(x)":
                    ViewModel.TextBlock += "atg";
                    break;
                case "actg(x)":
                    Thread.Sleep(2000);
                    MW.Close();
                    break;
                case "exp":
                    ViewModel.TextBlock = Math.Exp(double.Parse(ViewModel.TextBlock)).ToString();
                    break;
                case "(":
                    ViewModel.TextBlock += "(";
                    break;
                case ")":
                    ViewModel.TextBlock += ")";
                    break;
                case "Pi":
                    ViewModel.TextBlock += 3.14;
                    break;
                case "=":
                    DataTable dataTable = new DataTable();
                    try
                    {   
                        ViewModel.TextBlock = dataTable.Compute(ViewModel.TextBlock, null).ToString();
                    }
                    catch
                    {
                        ViewModel.TextBlock = Operation.TrigonomCompute(ViewModel.TextBlock).ToString();
                    }
                    break;
            }
            #endregion
        }
    }
}
