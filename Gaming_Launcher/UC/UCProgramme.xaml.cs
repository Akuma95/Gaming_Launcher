using Gaming_Launcher.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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

            GetBtnName(0, "game");
            GetBtnName(2, "programm");
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
                        allImgs[i].Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"C:\Users\Akuma\source\repos\Toolbar\Toolbar\UserControll\" + 
                            row.ItemArray[1].ToString());
                    }
                }
            }
        }
        public void Btn_programm_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var source = btn.ToolTip.ToString();
            Process.Start(source.Replace('/', '\\'));
        }
        private string GetBtnName(int btnNumber, string kategorie)
        {
            SqlConection conn = new SqlConection(Properties.Settings.Default.LauncherConnectionString);
            conn.Open();
            DataTable dt = conn.GetDataTable("SELECT btnName, img, route FROM ButtonLink, Game " +
                "WHERE ButtonLink.game = Game.name " +
                "AND ButtonLink.kategorie = '" + kategorie + "'; ");
            string btnName = null;

            foreach (DataRow row in dt.Rows)
            {
                Debug.Fail(row[btnNumber].ToString());
                btnName = row[btnNumber].ToString();
            }

            return btnName;
        }
    }
}
