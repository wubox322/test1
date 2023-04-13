using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stock
{
    
    public partial class Form1 : Form
    {
        //SqlConnection db = new SqlConnection(@"Data Source = DESKTOP - LT8T67N; Initial Catalog = user02; Persist Security info = True");
        SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-LT8T67N;Initial Catalog=user02;Integrated Security=True;");
        string a;
        int b;
        int l;
        int j = 0;
        List<int> ff = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db.Open();
            

            string table = "select *from Fish";
            SqlCommand command = new SqlCommand(table, db);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[2]);
                ff.Add(0);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                if(Convert.ToInt32(data[data.Count - 1][1]) < 40)
                {
                    ff[data.Count - 1] = 1;
                    j = Convert.ToInt32(data[data.Count - 1][1]);
                    l = data.Count - 1;
                }
            }
            a = labelCount.Text;
            reader.Close();
            db.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
                b = dataGridView1.Rows.Count - 1;
                labelCount.Text = a + "\t" + data.Count + " из " + b;
            for (int i = 0; i < ff.Count; i++)
                if (ff[i] == 1)
                {
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(255, 0, 0);
                    dataGridView1.Rows[i].Cells[1].Style.Font = new Font(this.Font, FontStyle.Strikeout);
                }
                
        }
    }
}
