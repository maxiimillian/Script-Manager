/* By: Sinew
 * Date: 03/01/2021
 * Desc: Save, run, and manage scripts or files in one location.
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

namespace Final_Project
{

    public partial class Form1 : Form
    {
        public static string path = "";
        public static string dbPath = "Data Source=C:/Users/frogg/source/repos/Final Project/Final Project/db.db";
        public static IDictionary<string, System.Diagnostics.Process> processes = new Dictionary<string, System.Diagnostics.Process>();
        public static Button deleteButton = new Button();
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
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
                    return Convert.ToString(value["path"]);
                }
                return "err";
            }
        }

        //Loads all saved scripts on open
        private void Form1_Load(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM scripts";

                var value = command.ExecuteReader();
                while (value.Read())
                {
                    lstBoxTest.Items.Add(Convert.ToString(value["name"]));

                }

            }
        }

        private void lstBoxTest_MouseUp(object sender, MouseEventArgs e)
        {
            //Check if click is left or right and its locaiton
            Point p = new Point(e.X, e.Y);
            object item;

            //Stops the program from clicking where theres no box
            try
            {
                
                item = lstBoxTest.Items[lstBoxTest.IndexFromPoint(p)];
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
                    lstBoxTest.Items.Remove(item);
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
       

        private async void lstBoxTest_DoubleClick(object sender, EventArgs e)
        {
            Process p;
            try
            {
                /*Might be able to do this with location instead of looping? 
                 * Currently checks for the path of the active process clicked and 
                 * starts that program
                 */
                foreach (var item in lstBoxTest.SelectedItems)
                {
                    try
                    {
                        string filePath = getPath(item.ToString());

                        lstBoxProcesses.Items.Add(item.ToString());

                        p = Process.Start(filePath);
                        processes.Add(item.ToString(), p);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    //This is to eat up any errors raised by the opened programming not persisting
                    // I.e a jpg 
                    try
                    {
                        await waitForProcessAsync(p);
                    }
                    catch (Exception)
                    {

                    }
                    processes.Remove(item.ToString());
                    for (int n = lstBoxProcesses.Items.Count - 1; n >= 0; --n)
                    {
                        if (lstBoxProcesses.Items[n].ToString().Contains(item.ToString()))
                        {
                            lstBoxProcesses.Items.RemoveAt(n);
                        }
                    }


                }
            }
            catch (Exception)
            {
                
            }

        }

        private void lstBoxProcesses_DoubleClick(object sender, EventArgs e)
        {
            //Once again may be able to do this with location later
            //Brings clicked process into focus
            foreach (var item in lstBoxProcesses.SelectedItems)
            {
                SetForegroundWindow(processes[item.ToString()].MainWindowHandle);
                return;
            }
        }

        private void textBoxProcesses_TextChanged(object sender, EventArgs e)
        {
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
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(path))
            {
                lblSave.Text = "You can't leave any boxes empty";
                return;
            }

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
            lstBoxTest.Items.Add(name);
            inputName.Text = "";
            btnFile.Text = "Browse";
            path = "";
            lblSave.Text = "Create New Save";
        }

        private void lstBoxProcesses_SelectedIndexChanged(object sender)
        {

        }

        private void inputName_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
