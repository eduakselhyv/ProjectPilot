using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPilot
{
    public partial class ProjectEditor : Form
    {
        private string projectId;
        public ProjectEditor(string name, string desc, string id)
        {
            InitializeComponent();
            textBox1.Text = name;
            richTextBox1.Text = desc;
            projectId = id;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "active" || comboBox1.Text == "deactivated")
            {
                if (textBox1.Text != "" && richTextBox1.Text != "") 
                {
                    var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("id", projectId),
                        new KeyValuePair<string, string>("name", textBox1.Text),
                        new KeyValuePair<string, string>("description", richTextBox1.Text),
                        new KeyValuePair<string, string>("status", comboBox1.Text),
                    });

                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5000?requestType=project", formContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Successfully edited project!");
                        this.Close();
                    }

                } else
                {
                    MessageBox.Show("Please enter projects name and description!");
                }
            } else
            {
                MessageBox.Show("Please select project status!");
            }
        }
    }
}
