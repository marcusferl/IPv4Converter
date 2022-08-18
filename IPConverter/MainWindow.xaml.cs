using System.Windows;
using System.Windows.Controls;


namespace IPConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int prefix;
        public MainWindow()
        {
            InitializeComponent();
            FillComboBox(combo_box);

        }
        public void FillComboBox(ComboBox combobox)
        {
            var end = 32;
            for (prefix = 0; prefix <= end; prefix++)
            {
                combobox.Items.Add(prefix);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(combo_box.Text.Length > 0 && textbox_ip.Text.Length > 0)
            {
                int prefix = combo_box.SelectedIndex;
                string ip = textbox_ip.Text;
                Berechnung ipv4 = new Berechnung(ip, prefix);

                //Binäre Ausgaben
                bin_broadcast.Text = ipv4.BinärBroadcast;
                bin_mask.Text = ipv4.BinärMask;
                bin_ipv4.Text = ipv4.BinärIp;
                bin_net_id.Text = ipv4.BinärNetId;
                bin_first_ip.Text = ipv4.BinärMinIp;
                bin_lastip.Text = ipv4.BinärMaxIp;

                //Decimale Ausgaben
                decimal_broadcast.Text = ipv4.DecimalBroadcast.Replace(' ', '.');
                decimal_mask.Text = ipv4.DecimalMask.Replace(' ', '.');
                decimal_net_id.Text = ipv4.DecimalNetId.Replace(' ', '.');
                decimal_ipv4.Text = textbox_ip.Text;
                decimal_last_ip.Text = ipv4.DecimalMaxIp.Replace(' ', '.');
                decimal_fist_ip.Text = ipv4.DecimalMinIp.Replace(' ', '.');
            }
            else
            {
                MessageBox.Show("Bitte Ipv4 und Prefix angeben");
            }
            

        }
    }
}
