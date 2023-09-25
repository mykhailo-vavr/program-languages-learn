using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_Lab_1
{
    public partial class Form1 : Form
    {
        public static string File;
        public static List<Cars> list = new List<Cars>();
        public bool changes = false;

        public DataTable dt = new DataTable();

        public BindingSource bindingSource1 = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsEmpty()
        {
            return dt.Rows.Count == 0;
        }

        public void UpdateTable()
        {
            dt.Rows.Clear();
            foreach (var item in list)
            {
                dt.Rows.Add(item.Brand, item.Type, item.CreationYear, item.Price);
            }
            dataGridView1.DataSource = dt;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {}

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form info = new Form()
            {
                Width = 320,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                BackColor = Color.GhostWhite,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Help"
            };
            Label label = new Label()
            {
                Text = "This form is a database for Cars.\n" +
                        "- Choose 'Open' to open an existed file.\n" +
                        "- Choose 'Create' to create new database\n" +
                        "- Choose 'Edit' to update table with new Educational hours.\n" +
                        "- Choose 'Chart' to illustrate database.\n" +
                        "- Choose 'Sort' to sort database.",
                Width = 300,
                Height = 400
            };
            info.Controls.Add(label);
            info.ShowDialog();
        }

        private void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form info = new Form()
            {
                Width = 300,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                BackColor = Color.GhostWhite,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Author"
            };
            Label label = new Label(){ 
                Text = "LNU, PMI-23, Vavrykovych Mykhailo",
                Width = 200,
                Height = 500 
            };
            info.Controls.Add(label);
            info.ShowDialog();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {}

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Visible = true;
            saveAsToolStripMenuItem.Visible = true;

            if (!IsEmpty())
            {
                list.Clear();
                UpdateTable();
            }
            dataGridView1.DataSource = list;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Visible = true;
            saveAsToolStripMenuItem.Visible = true;
            if (!IsEmpty())
            {
                list.Clear();
                UpdateTable();
            }

            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.Text = ofd.SafeFileName;
                    File = ofd.FileName;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    BindDataCSV(ofd.FileName);
                }
            }
        }

        private void BindDataCSV(string filepath)
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            if (lines.Length > 0)
            {
                string columns = lines[0];
                string[] headers = columns.Split(',');
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].ToString() != headers[i].ToString())
                    {
                        MessageBox.Show("Tables don`t match! Try another file");
                        return;
                    }
                }
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    DataRow row = dt.NewRow();
                    int columnIndex = 0;

                    foreach (var header in headers)
                    {
                        row[header] = data[columnIndex++];
                    }
                    list.Add(new Cars(row[0].ToString(), row[1].ToString(), Convert.ToDateTime(row[2]), Convert.ToInt32(row[3])));
                }
            }
            if (list.Count > 0)
            {
                UpdateTable();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
