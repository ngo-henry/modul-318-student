
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransport;

namespace SwissTransport.UI
{
    public partial class MainView : Form
    {
        Transport transport = new Transport();
        
       
        public MainView()
        {
            InitializeComponent();
        }
        //
        //Die meisten Methoden sind anhand der Methoden selbsterklärend
        //
        private void OnbtnSearch_Click(object sender, EventArgs e)
        {
            string von = tBVon.Text;
            string nach = tBNach.Text;
            DateTime date = datePicker.Value.Date;
            TimeSpan time = timePicke.Value.TimeOfDay;


        }
        public AutoCompleteStringCollection getPlaceSuggestion(string query)
        {
            List<Station> stationen = transport.GetStations(query).StationList;
            AutoCompleteStringCollection autolist = new AutoCompleteStringCollection();
            foreach(Station station in stationen)
            {
                autolist.Add(station.Name);
            }
            return autolist;
        }
        private void tB_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            AutoCompleteStringCollection autocom = getPlaceSuggestion(tb.Text);
            tb.AutoCompleteCustomSource = autocom;
        }

        //Definiert was der Search-Button bei Verbindung macht macht
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int isArrivalTime;
            Connections connections1 = new Connections();
            if(comboBox1.SelectedItem == "Ab")
            {
                isArrivalTime = 0;
            }else
            {
                isArrivalTime = 1;
            }
            var date = datePicker.Value.Date;
            var time = timePicke.Value.TimeOfDay;
            
            connections1 = transport.GetConnections(tBVon.Text, tBNach.Text, date.Add(time), isArrivalTime);
          
            listView1.Items.Clear();
            listView1.Groups.Clear();

            foreach (var item in connections1.ConnectionList)
            {
                //Konvertierung von "duration"
                TimeSpan duration = TimeSpan.Parse(item.Duration.Remove(0, 3));
                int days = int.Parse(item.Duration.Substring(0, 2));
                duration = duration.Add(new TimeSpan(days, 0, 0, 0));

                ListViewItem i = new ListViewItem(item.From.Station.Name);
                i.SubItems.Add(item.To.Station.Name);
                i.SubItems.Add(DateTime.Parse(item.From.Departure).ToShortTimeString());
                i.SubItems.Add(DateTime.Parse(item.To.Arrival).ToShortTimeString());
                i.SubItems.Add(duration.ToString());
                listView1.Items.Add(i);
            }
        }
        //Abfahrtsplan suchen
        private void btnSearch_Abfahrtsplan(object sender, EventArgs e)
        {
            StationBoardRoot connections2 = new StationBoardRoot();
            connections2 = transport.GetStationBoard(tbOrt.Text);
            listView2.Groups.Clear();
            listView2.Items.Clear();
            foreach (var item in connections2.Entries)
            {
                ListViewItem two = new ListViewItem(connections2.Station.Name);
                two.SubItems.Add(item.To);
                two.SubItems.Add(item.Stop.Departure.ToShortTimeString());
                listView2.Items.Add(two);
            }
        }
        //Konfiguration vom Webbrowser
        private void webbrowserconfig(object sender, EventArgs e)
        {
            string dest = textBox1.Text;
            var station = transport.GetStations(dest).StationList[0];
            webBrowser1.Url = new Uri( "https://www.google.ch/maps/@"+ station.Coordinate.XCoordinate+ "," + station.Coordinate.YCoordinate + "," + "16z");
        }
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            sendMail(listView1);
        }

        private void btnAbfahrtsplanSendMail_Click(object sender, EventArgs e)
        {
            sendMail(listView2);
        }
        private void sendMail(ListView listview)
        {
            if (listview.Items.Count != 0)
            {
                SendMail email = new SendMail(listview);
                email.Show();
            }
            else
            {
                MessageBox.Show(@"Suche nach gültigen Verbindungen!", @"Keine Resultate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
