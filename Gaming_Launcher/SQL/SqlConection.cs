using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gaming_Launcher.SQL
{
    class SqlConection
    {
        public SQLiteConnection Connection
        {
            get
            {
                return this._con ?? this.Open();
            }
        }
        private SQLiteConnection _con;
        private readonly string _cs;

        public SqlConection(string cs)
        {
            _cs = cs;
        }

        public SQLiteConnection Open(TextBlock feedbackLabel = null)
        {
            this._con = new SQLiteConnection(this._cs);
            if (feedbackLabel != null)
            {
                try
                {
                    if (this._con.State != System.Data.ConnectionState.Open)
                    {
                        this._con.Open();
                    }
                }
                catch (System.InvalidOperationException)
                {
                    feedbackLabel.Text = "Ein Fehler ist aufgetretten. Die Verbindung zur Datenbank konnte leider nicht hergestellt werden.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(130, 0, 0));
                }
                catch (Exception)
                {
                    feedbackLabel.Text = "Ein unbekannter Fehler ist aufgetretten.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(130, 0, 0));
                }
            }
            else
            {
                if (this._con.State != System.Data.ConnectionState.Open)
                {
                    this._con.Open();
                }
            }

            return this._con;
        }

        public DataTable GetDataTable(string request)
        {
            try
            {
                DataTable dt = new DataTable();
                SQLiteCommand sc = new SQLiteCommand(request, this._con);
                dt.Load(sc.ExecuteReader());
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int SetData(string request, TextBlock feedbackLabel = null)
        {
            SQLiteCommand sc = new SQLiteCommand(request, this._con);
                sc.ExecuteNonQuery();
            try
            {
                if (feedbackLabel != null)
                {
                    feedbackLabel.Text = "Daten wurden erfolgreich gespeichert.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(50, 130, 0));
                }
                return 1;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                if (feedbackLabel != null)
                {
                    feedbackLabel.Text = "Das gewünschte Element existiert bereits, bitte schauen sie in der Tabelle und versuchen es mit einer anderen.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(130, 0, 0));
                }
                return 0;
            }
            catch (Exception)
            {
                if (feedbackLabel != null)
                {
                    feedbackLabel.Text = "Ein unbekannter Fehler ist aufgetretten.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(130, 0, 0));
                }
                return 0;
            }
        }

        public int DeleteData(string request)
        {
            try
            {
                SQLiteCommand sc = new SQLiteCommand(request, this._con);
                return sc.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void Close()
        {
            this._con.Close();
        }

    }
}
