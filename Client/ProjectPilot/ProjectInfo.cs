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
    public partial class ProjectInfo : Form
    {
        public ProjectInfo(string projectName)
        {
            InitializeComponent();
            label3.Text = projectName;
        }

        private async void ProjectInfo_Load(object sender, EventArgs e)
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
                        string projectName = project["name"].ToString();
                        listBox1.Items.Add(projectName);

                        if (projectName == label3.Text)
                        {
                            Label label = new Label();
                            label.Text = project["description"].ToString();
                            label.AutoSize = true;
                            label.TextAlign = ContentAlignment.TopLeft;
                            label.Padding = new Padding(5);
                            panel2.Controls.Add(label);

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

                                    // Set the text of label7 to the concatenated string of related users
                                    label5.Text = string.Join(", ", relatedUsers);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = comboBox1.GetItemText(comboBox1.SelectedItem);

            if (option == "Edit")
            {
                MessageBox.Show("Editing project");
            } else
            {
                MessageBox.Show("Are you sure you want to delete this project?");
            }
        }
    }
}
