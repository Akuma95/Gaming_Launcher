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

namespace Gaming_Launcher.UC
{
    /// <summary>
    /// Interaktionslogik für UCProgramme.xaml
    /// </summary>
    public partial class UCProgramme : UserControl
    {
        public UCProgramme()
        {
            InitializeComponent();
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tcAll.SelectedIndex.ToString().Equals("3"))
            {
                Window yourParentWindow = Window.GetWindow(this);
                yourParentWindow.Close();
            }
            Button[] allBtns = new Button[16] { btn_programm_1, btn_programm_2, btn_programm_3, btn_programm_4, btn_programm_5, btn_programm_6, btn_programm_7, btn_programm_8, btn_games_1, btn_games_2, btn_games_3, btn_games_4, btn_games_5, btn_games_6, btn_games_7, btn_games_8 };
            Image[] allImgs = new Image[16] { img_programm_1, img_programm_2, img_programm_3, img_programm_4, img_programm_5, img_programm_6, img_programm_7, img_programm_8, img_games_1, img_games_2, img_games_3, img_games_4, img_games_5, img_games_6, img_games_7, img_games_8 };

            for (int i = 0; i < allBtns.Length; i++)
            {
                SqlConection conn = new SqlConection(Properties.Resources.Connection);
                conn.Open();
                DataTable dt = conn.GetDataTable("SELECT pfad, img FROM TablePfade WHERE btn = '" + allBtns[i].Name + "'");
                foreach (DataRow row in dt.Rows)
                {
                    allBtns[i].ToolTip = row.ItemArray[0].ToString();
                    FileInfo fi = new FileInfo(@"C:\Users\Akuma\source\repos\Toolbar\Toolbar\UserControll\" + row.ItemArray[1].ToString());
                    if (fi.Exists)
                    {
                        allImgs[i].Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"C:\Users\Akuma\source\repos\Toolbar\Toolbar\UserControll\" + row.ItemArray[1].ToString());
                    }
                }
            }
        }
        public void btn_programm_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var source = btn.ToolTip.ToString();
            Process.Start(source.Replace('/', '\\'));
        }
        private void CbSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = sender as ComboBox;
            String cbItem = cb.SelectedItem.ToString();
            String btnName = getBtnName(cbItem, cb);


            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open();
            DataTable dt = conn.GetDataTable("SELECT pfad, img FROM TablePfade WHERE btn = '" + btnName + "'");
            foreach (DataRow row in dt.Rows)
            {
                if (cb.Name.Equals("cb_Programm") && row.ItemArray[0] != null)
                {
                    ProgrammPfad.Text = row.ItemArray[0].ToString();
                    int exist = 0;
                    foreach (String cbi in ProgrammImg.Items)
                    {
                        if (cbi.Equals(row.ItemArray[1].ToString()))
                        {
                            exist++;
                        }
                    }
                    if (exist > 0)
                    {
                        ProgrammImg.Text = row.ItemArray[1].ToString();
                    }
                    else
                    {
                        ProgrammImg.Items.Add(row.ItemArray[1].ToString());
                        ProgrammImg.Text = row.ItemArray[1].ToString();
                    }

                }
                else if (cb.Name.Equals("cb_Games") && row.ItemArray[0] != null)
                {
                    GamePfad.Text = row.ItemArray[0].ToString(); int exist = 0;
                    foreach (String cbi in ProgrammImg.Items)
                    {
                        if (cbi.Equals(row.ItemArray[1].ToString()))
                        {
                            exist++;
                        }
                    }
                    if (exist > 0)
                    {
                        GameImg.Text = row.ItemArray[1].ToString();
                    }
                    else
                    {
                        GameImg.Items.Add(row.ItemArray[1].ToString());
                        GameImg.Text = row.ItemArray[1].ToString();
                    }
                }
            }
        }
        private string getBtnName(string cbItem, ComboBox cb)
        {
            string btnName = null;
            if (cb.Name.Equals("cb_Programm"))
            {
                if (cbItem.Contains("btn_1"))
                {
                    btnName = "btn_programm_1";
                }
                else if (cbItem.Contains("btn_2"))
                {
                    btnName = "btn_programm_2";
                }
                else if (cbItem.Contains("btn_3"))
                {
                    btnName = "btn_programm_3";
                }
                else if (cbItem.Contains("btn_4"))
                {
                    btnName = "btn_programm_4";
                }
                else if (cbItem.Contains("btn_5"))
                {
                    btnName = "btn_programm_5";
                }
                else if (cbItem.Contains("btn_6"))
                {
                    btnName = "btn_programm_6";
                }
                else if (cbItem.Contains("btn_7"))
                {
                    btnName = "btn_programm_7";
                }
                else if (cbItem.Contains("btn_8"))
                {
                    btnName = "btn_programm_8";
                }
            }
            else if (cb.Name.Equals("cb_Games"))
            {
                if (cbItem.Contains("btn_1"))
                {
                    btnName = "btn_games_1";
                }
                else if (cbItem.Contains("btn_2"))
                {
                    btnName = "btn_games_2";
                }
                else if (cbItem.Contains("btn_3"))
                {
                    btnName = "btn_games_3";
                }
                else if (cbItem.Contains("btn_4"))
                {
                    btnName = "btn_games_4";
                }
                else if (cbItem.Contains("btn_5"))
                {
                    btnName = "btn_games_5";
                }
                else if (cbItem.Contains("btn_6"))
                {
                    btnName = "btn_games_6";
                }
                else if (cbItem.Contains("btn_7"))
                {
                    btnName = "btn_games_7";
                }
                else if (cbItem.Contains("btn_8"))
                {
                    btnName = "btn_games_8";
                }
            }
            return btnName;
        }
    }
}
