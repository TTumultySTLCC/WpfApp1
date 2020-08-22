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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }//end MainWindow

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int decVal = Int32.Parse(txtInput.Text);

                if (radHex.IsChecked == true)
                {
                    txtOutput.Text = getHex(getBinary(decVal));
                }
                else if (radBin.IsChecked == true)
                {
                    txtOutput.Text = getBinary(decVal);
                }
                else if (radOct.IsChecked == true)
                {
                    txtOutput.Text = getOctal(getBinary(decVal));
                }
            }
            catch
            {
                txtOutput.Text = "Invalid DECIMAL input";
            }
        }//end Click

        private String getBinary(int dec)
        {
            String result = "";

            while (dec >= 1)
            {
                result = (dec % 2).ToString() + result;
                dec = (int) dec / (int) 2;
            }

            return result;
        }//getBinary

        private String getHex(String bin)
        {
            String result = "";
            
            switch (bin.Length % 4)
            {
                case 3:
                    bin = "0" + bin;
                    break;
                case 2:
                    bin = "00" + bin;
                    break;
                case 1:
                    bin = "000" + bin;
                    break;
            }

            for (int c = 1; c <= bin.Length / 4; c++)
            {   
                String segment = bin.Substring(((c - 1) * 4), 4);
                result += getHexSeg(segment);
            }
            
            return result;
        }//getHex

        private String getOctal(String bin)
        {
            String result = "";

            switch (bin.Length % 3)
            {
                case 2:
                    bin = "0" + bin;
                    break;
                case 1:
                    bin = "00" + bin;
                    break;
            }

            for (int c = 1; c <= bin.Length / 3; c++)
            {
                String segment = bin.Substring(((c - 1) * 3), 3);
                result += getOctSeg(segment);
            }

            return result;
        }//getOctal

        private String getHexSeg(String binSeg)
        {
            if (binSeg == "0000") return "0";
            else if (binSeg == "0001") return "1";
            else if (binSeg == "0010") return "2";
            else if (binSeg == "0011") return "3";
            else if (binSeg == "0100") return "4";
            else if (binSeg == "0101") return "5";
            else if (binSeg == "0110") return "6";
            else if (binSeg == "0111") return "7";
            else if (binSeg == "1000") return "8";
            else if (binSeg == "1001") return "9";
            else if (binSeg == "1010") return "A";
            else if (binSeg == "1011") return "B";
            else if (binSeg == "1100") return "C";
            else if (binSeg == "1101") return "D";
            else if (binSeg == "1110") return "E";
            else if (binSeg == "1111") return "F";
            else return "";
        }//getHexSeg

        private String getOctSeg(String binSeg)
        {
            if (binSeg == "000") return "0";
            else if (binSeg == "001") return "1";
            else if (binSeg == "010") return "2";
            else if (binSeg == "011") return "3";
            else if (binSeg == "100") return "4";
            else if (binSeg == "101") return "5";
            else if (binSeg == "110") return "6";
            else if (binSeg == "111") return "7";
            else return "";
        }//getOctSeg
    }//end class
}//end namespace
