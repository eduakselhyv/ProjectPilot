using mainPage1;
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
using Label = System.Windows.Forms.Label;

namespace ProjectPilot
{
    public partial class TaskManager : Form
    {
        private Label desc_label;
        public TaskManager(string projectName)
        {
            InitializeComponent();
            label3.Text = projectName;
            desc_label = new Label();
        }

        private async void TaskManager_Load(object sender, EventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5000?requestType=projects");

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    JArray projects = JArray.Parse(responseData);

                    listBox1.Items.Clear();

                    foreach (var project in projects)
                    {
                        if (project["status"].ToString() != "active") continue;
                        string projectName = project["name"].ToString();
                        listBox1.Items.Add(projectName);

                        if (projectName == label3.Text)
                        {
                            label6.Text = project["id"].ToString();
                            desc_label.Text = project["description"].ToString();
                            desc_label.AutoSize = true;
                            desc_label.TextAlign = ContentAlignment.TopLeft;
                            desc_label.Padding = new Padding(5);
                            panel2.Controls.Add(desc_label);

                            // Fetch roles for the current project
                            HttpResponseMessage responseRoles = await httpClient.GetAsync($"http://localhost:5000?requestType=roles&project_id={project["id"]}");

                            if (responseRoles.IsSuccessStatusCode)
                            {
                                string rolesData = await responseRoles.Content.ReadAsStringAsync();
                                JArray roles = JArray.Parse(rolesData);

                                // Fetch users
                                HttpResponseMessage responseUsers = await httpClient.GetAsync("http://localhost:5000?requestType=users");

                                if (responseUsers.IsSuccessStatusCode)
                                {
                                    string usersData = await responseUsers.Content.ReadAsStringAsync();
                                    JArray users = JArray.Parse(usersData);

                                    // Accumulate related users
                                    List<string> relatedUsers = new List<string>();

                                    foreach (var role in roles)
                                    {
                                        foreach (var user in users)
                                        {
                                            if (role["user_id"].ToString() == user["id"].ToString())
                                            {
                                                relatedUsers.Add(user["username"].ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error getting projects...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string project = listBox1.GetItemText(listBox1.SelectedItem);

            if (project != "")
            {
                MessageBox.Show("Selected project " + project);

                ProjectInfo projectinfo = new ProjectInfo(project);
                projectinfo.Show();
                this.Close();
            }
            else
            {
                MainPage mainpage = new MainPage();
                mainpage.Show();
                this.Close();
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = comboBox1.GetItemText(comboBox1.SelectedItem);

            if (option == "Edit")
            {
                MessageBox.Show("Editing project");
                ProjectEditor projecteditor = new ProjectEditor(label3.Text, desc_label.Text, label6.Text);
                projecteditor.ShowDialog();

                MainPage mainpage = new MainPage();
                mainpage.Show();
                this.Close();
            }
            else // Delete project
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this project?", "confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var formContent2 = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("id", label6.Text),
                        new KeyValuePair<string, string>("name", label3.Text),
                        new KeyValuePair<string, string>("description", desc_label.Text),
                        new KeyValuePair<string, string>("status", "deleted"),
                    });

                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5000?requestType=project", formContent2);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Successfully deleted project!");
                        MainPage mainpage = new MainPage();
                        mainpage.Show();
                        this.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // switch to project info tab
        {
            MessageBox.Show("Switching to project info!");
            ProjectInfo projectinfo = new ProjectInfo(label3.Text); // label3.Text is project name
            projectinfo.Show();
            this.Close();
        }
    }
}
