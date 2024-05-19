using mainPage1;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjectPilot
{
    public partial class CreateProject : Form
    {
        public CreateProject()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string project_name = textBox2.Text;
            string project_description = richTextBox1.Text;

            if (project_name != "" && project_description != "")
            {

                // Add username and password into the request body
                var formContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("name", project_name),
                new KeyValuePair<string, string>("description", project_description),
                new KeyValuePair<string, string>("status", "active"),
                });

                // Add username and password into the request body


                // Create a new HttpClient to handle the login request
                HttpClient httpClient = new HttpClient();

                // Send a Post request to the specified url with the body after it
                HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5000?requestType=project", formContent);


                // If the statuscode is successful (succesfully logged in)
                if (response.IsSuccessStatusCode)
                {
                    HttpResponseMessage response2 = await httpClient.GetAsync("http://localhost:5000?requestType=users");

                    // Get the response content as a string
                    string responseData = await response2.Content.ReadAsStringAsync();

                    // Parse the response data as a JSON array
                    JArray users = JArray.Parse(responseData);

                    if (response.IsSuccessStatusCode)
                    {
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {   
                            // Get the value of the item
                            string value = checkedListBox1.Items[i].ToString();

                            foreach (var user in users)
                            {
                                if (user["username"].ToString() == value)
                                {
                                    // Add user into project
                                    string projectId = await response.Content.ReadAsStringAsync();

                                    // Create form content to send additional data
                                    var formContent2 = new FormUrlEncodedContent(new[]
                                    {
                                        new KeyValuePair<string, string>("user_id", user["id"].ToString()),
                                        new KeyValuePair<string, string>("project_id", projectId),
                                        new KeyValuePair<string, string>("name", "unassigned"),
                                    });

                                    HttpResponseMessage response3 = await httpClient.PostAsync("http://localhost:5000?requestType=role", formContent2);
                                }
                            }
                        }
                    }

                    MessageBox.Show("Successfully created project!");
                    // This is not part of the request
                    MainPage mainpage = new MainPage();
                    mainpage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error creating project...");
                }

            }
            else
            {
                MessageBox.Show("Please give the project a name and a description!");
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                checkedListBox1.Items.Add(textBox3.Text);
                textBox3.Text = "";
            } else
            {
                MessageBox.Show("Please enter an username!");
            }
        }

        // Remove added user
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Iterate through each checked item in reverse order
            for (int i = checkedListBox1.CheckedItems.Count - 1; i >= 0; i--)
            {
                // Get the index of the checked item
                int index = checkedListBox1.Items.IndexOf(checkedListBox1.CheckedItems[i]);

                // Check if the index is valid
                if (index >= 0 && index < checkedListBox1.Items.Count)
                {
                    // Remove the checked item from the CheckedListBox
                    checkedListBox1.Items.RemoveAt(index);
                }
            }
        }
    }
}
