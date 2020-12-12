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
            LoadBtns();
            GetBtnName(0, "game");
            GetBtnName(2, "programm");
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadBtns();
        }
        private void LoadBtns()
        {
            SqlConection conn = new SqlConection(Properties.Settings.Default.LauncherConnectionString);
            conn.Open();
            DataTable dt = conn.GetDataTable("SELECT [btnName], [imgName], [ButtonLink].[kategorie], [img], [pfad] FROM [ButtonLink], [Game] WHERE game = name");
            foreach (DataRow row in dt.Rows)
            {
                if (row[2].ToString() == "programm")
                {
                    Button btn = (Button)this.FindName(row[0].ToString());
                    if (btn != null)
                    {
                        btn.ToolTip = row[4].ToString();
                    }
                    Image img = (Image)this.FindName(row[1].ToString());
                    FileInfo fi = new FileInfo(@"C:\Users\Akuma\source\repos\Gaming_Launcher\Gaming_Launcher\Assets\UCProgramme\btn\" + row.ItemArray[3].ToString());
                    if (fi.Exists)
                    {
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"C:\Users\Akuma\source\repos\Gaming_Launcher\Gaming_Launcher\Assets\UCProgramme\btn\" +
                            row.ItemArray[3].ToString());
                    }
                }
                else if (row[2].ToString() == "game")
                {
                    string btnName = row[0].ToString();
                    Button btn = (Button)this.FindName(btnName);
                    if (btn != null)
                    {
                        btn.ToolTip = row[4].ToString();
                    }
                    Image img = (Image)this.FindName(row[1].ToString());
                    FileInfo fi = new FileInfo(@"C:\Users\Akuma\source\repos\Gaming_Launcher\Gaming_Launcher\Assets\UCProgramme\btn\" + row.ItemArray[3].ToString());
                    if (fi.Exists)
                    {
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"C:\Users\Akuma\source\repos\Gaming_Launcher\Gaming_Launcher\Assets\UCProgramme\btn\" +
                            row.ItemArray[3].ToString());
                        Debug.WriteLine(img.Source);
                    }
                }
                else if (row[2].ToString() == "tool")
                {
                    Button btn = (Button)this.FindName(row[0].ToString());
                    if (btn != null)
                    {
                        btn.ToolTip = row[4].ToString();
                    }
                    Image img = (Image)this.FindName(row[1].ToString());
                    FileInfo fi = new FileInfo(@"C:\Users\Akuma\source\repos\Gaming_Launcher\Gaming_Launcher\Assets\UCProgramme\btn\" + row.ItemArray[3].ToString());
                    if (fi.Exists)
                    {
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"C:\Users\Akuma\source\repos\Gaming_Launcher\Gaming_Launcher\Assets\UCProgramme\btn\" +
                            row.ItemArray[3].ToString());
                    }
                }
                else if (row[2].ToString() == "launcher")
                {
                    Button btn = (Button)this.FindName(row[0].ToString());
                    if (btn != null)
                    {
                        btn.ToolTip = row[4].ToString();
                    }
                    Image img = (Image)this.FindName(row[1].ToString());
                    FileInfo fi = new FileInfo(@"C:\Users\Akuma\source\repos\Gaming_Launcher\Gaming_Launcher\Assets\UCProgramme\btn\" + row.ItemArray[3].ToString());
                    if (fi.Exists)
                    {
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"C:\Users\Akuma\source\repos\Gaming_Launcher\Gaming_Launcher\Assets\UCProgramme\btn\" +
                            row.ItemArray[3].ToString());
                    }
                }
            }
        }
        public void Btn_programm_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var source = btn.ToolTip.ToString();
            Process.Start(source);
        }
        private string GetBtnName(int btnNumber, string kategorie)
        {
            SqlConection conn = new SqlConection(Properties.Settings.Default.LauncherConnectionString);
            conn.Open();
            DataTable dt = conn.GetDataTable("SELECT[btnName],[game],[kategorie] FROM[ButtonLink] WHERE kategorie = '" + kategorie + "'");
            string btnName = null;

            foreach (DataRow row in dt.Rows)
            {
                btnName = row[btnNumber].ToString();
            }

            return btnName;
        }
    }
}
