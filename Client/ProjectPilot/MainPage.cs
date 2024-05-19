using Newtonsoft.Json.Linq;
using ProjectPilot;

namespace mainPage1
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void MainPage_Load(object sender, EventArgs e)
        {
            try
            {
                // Create a new HttpClient to handle the request
                HttpClient httpClient = new HttpClient();

                // Send a Get request to the specified URL
                HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5000?requestType=projects");

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Get the response content as a string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Parse the response data as a JSON array
                    JArray projects = JArray.Parse(responseData);

                    // Clear existing items in the ListBox
                    listBox1.Items.Clear();

                    // Add project names to the ListBox
                    foreach (var project in projects)
                    {
                        listBox1.Items.Add(project["name"].ToString());
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

        // When user selects project
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
                Console.WriteLine("");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateProject createproject = new CreateProject();
            createproject.Show();
            this.Close();
        }


    }
}
