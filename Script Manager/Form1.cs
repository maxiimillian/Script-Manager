/* By: Sinew
 * Date: 02/12/2021
 * Desc: Save, run, and manage scripts or files in one location.
 * Version: 1.1
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;


namespace Script_Manager
{

    public partial class Form1 : Form
    {
        public static string path = "";
        public static string dbPath = "Data Source=C:/Users/frogg/source/repos/Script Manager/Script Manager/db.db";
        public static IDictionary<string, System.Diagnostics.Process> processes = new Dictionary<string, System.Diagnostics.Process>();
        public static Button deleteButton = new Button();
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Script Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            lstBoxProcesses.DrawItem += new DrawItemEventHandler(lstBoxProcesses_DrawItem);
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        //Async function allows program to wait for a program opened through it to be closed.
        private async Task waitForProcessAsync(Process p)
        {
            if (p == null) return;
            try
            {
                while (!p.HasExited)
                    await Task.Delay(100);
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        //Returns the file path of an item using its name
        private string getPath(string name)
        {
            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT path FROM scripts WHERE name=$name";
                command.Parameters.AddWithValue("$name", name);

                var value = command.ExecuteReader();
                while (value.Read())
                {
                    string path = Convert.ToString(value["path"]);
                    return path;
                }
                return "err";
            }
        }

        //Loads all saved scripts on open and readjusts the window to the bottom right
        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            this.Left = workingArea.Left + workingArea.Width - this.Size.Width;
            this.Top = workingArea.Top + workingArea.Height - this.Size.Height;

            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM scripts";

                var value = command.ExecuteReader();
                while (value.Read())
                {
                    lstBoxProcesses.Items.Add(new ListBoxItem(Color.White, Convert.ToString(value["name"]), Color.FromArgb(61, 65, 71)));

                }

            }
        }

        //Drawing custom Item to allow colour and size changes
        //Using ListBoxItem class
        private void lstBoxProcesses_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                ListBoxItem item = lstBoxProcesses.Items[e.Index] as ListBoxItem;

                if (item != null)
                {

                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    
                    e.DrawBackground();
                    e.Graphics.FillRectangle(new SolidBrush(item.BackColor), e.Bounds);
                    
                    e.DrawFocusRectangle();
                    e.Graphics.DrawString(item.Name,
                        new Font(FontFamily.GenericSansSerif,
                        14,
                        FontStyle.Bold),
                        new SolidBrush(item.ItemColor), e.Bounds);

                }
                else
                {
                    Console.WriteLine("Its null");
                }
            }
            catch (Exception)
            {
                return;
            }

        }

        //Makes each box an appropriate height for the font
        private void lstBoxProcesses_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)(lstBoxProcesses.Font.Height*1.5);
        }


        private void lstBoxProcesses_MouseUp(object sender, MouseEventArgs e)
        {
            //Check if click is left or right and its locaiton
            Point p = new Point(e.X, e.Y);
            ListBoxItem item;

            //Stops the program from clicking where theres no box
            try
            {
                item = lstBoxProcesses.Items[lstBoxProcesses.IndexFromPoint(p)] as ListBoxItem;
            }
            catch (Exception)
            {
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                //Only one delete button at a time
                if (deleteButton != null) this.Controls.Remove(deleteButton); ;

                var deleteBtn = new Button();
                deleteBtn.Name = "deleteBtn";
                deleteBtn.Text = "Delete";
                deleteBtn.BackColor = Color.FromArgb(199, 66, 66);
                deleteBtn.FlatStyle = FlatStyle.Flat;
                deleteBtn.ForeColor = Color.White;
                deleteBtn.Size = new Size(75, 25);

                deleteBtn.Cursor = Cursors.Hand;

                deleteBtn.Click += (s, ev) => 
                {
                    using (var connection = new SqliteConnection(dbPath))
                    {
                        connection.Open();

                        var command = connection.CreateCommand();
                        command.CommandText = @"DELETE FROM scripts WHERE name=$name";
                        command.Parameters.AddWithValue("$name", item.ToString());

                        command.ExecuteNonQuery();

                    }
                    lstBoxProcesses.Items.Remove(item);
                    this.Controls.Remove(deleteBtn);
                };

                deleteBtn.Location = this.PointToClient(Cursor.Position);
                Controls.Add(deleteBtn);
                deleteBtn.BringToFront();

                deleteButton = deleteBtn;
            }

        }

        private void form1_Click(object sender, EventArgs e)
        {
            //Remove the delete button if client clicks anywhere off of it
            try
            {
                this.Controls.Remove(deleteButton);
                deleteButton = null;

            }
            catch (Exception)
            {
                return;
            }
        }
       

        private async void lstBoxProcesses_DoubleClick(object sender, EventArgs e)
        {
            var item = lstBoxProcesses.SelectedItem as ListBoxItem;

            //If its found in the dictionary than its active otherwise activate it
            try
            {
                SetForegroundWindow(processes[item.Name].MainWindowHandle);
                return;
            }
            catch (KeyNotFoundException)
            {
                Process p;

                string filePath = getPath(item.Name);
                item.ItemColor = Color.Blue;

                //Start process and add to the dictionary
                p = Process.Start(filePath);
                processes.Add(item.Name, p);

                //This is to eat up any errors raised by the opened programming not persisting or just closing
                // I.e a jpg 
                try
                {
                    await waitForProcessAsync(p);
                    processes.Remove(item.Name);

                    item.ItemColor = Color.White;
                    item.BackColor = Color.FromArgb(61, 65, 71);
                }
                catch (Exception)
                {
                    processes.Remove(item.Name);

                    item.ItemColor = Color.White;
                    item.BackColor = Color.FromArgb(61, 65, 71);
                }
                

            }
            
        }

        //Dialog to upload the file to save
        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                btnFile.Text = fd.SafeFileName;
                path = fd.FileName;
            }
        }

        //Saving the name and file path into sqlite
        private void button1_Click(object sender, EventArgs e)
        {
            string name = inputName.Text;

            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO scripts (name, path) VALUES ($name,$path)";
                command.Parameters.AddWithValue("$name", name);
                command.Parameters.AddWithValue("$path", path);

                command.ExecuteNonQuery();

            }
            lstBoxProcesses.Items.Add(name);
            inputName.Text = "";
            btnFile.Text = "Browse";
            path = "";
        }

        private void inputName_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void lstBoxProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class ListBoxItem
    {
        //Custom box item to allow manual drawing with colours that can change
        public ListBoxItem(Color c, string m, Color b)
        {
            ItemColor = c;
            Name = m;
            BackColor = b;
        }

        public Color ItemColor { get; set; }
        public Color BackColor { get; set; }
        public string Name { get; set; }
    }
}
