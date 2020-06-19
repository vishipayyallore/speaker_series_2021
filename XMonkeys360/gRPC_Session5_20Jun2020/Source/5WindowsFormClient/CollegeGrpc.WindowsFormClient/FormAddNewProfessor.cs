using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows.Forms;

namespace CollegeGrpc.WindowsFormClient
{
    public partial class FormAddNewProfessor : Form
    {
        private static IConfiguration _config;

        public FormAddNewProfessor()
        {
            InitializeComponent();

            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();

            textBoxName.Text = NameGenerator.GenerateName(12);
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            var client = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);

            var results = await client.AddProfessorAsync(GenerateNewProfessor());

            MessageBox.Show($"New Professor Added with Id: {results.ProfessorId}");
        }

        private AddProfessorRequest GenerateNewProfessor()
        {
            return new AddProfessorRequest()
            {
                Name = textBoxName.Text,
                Doj = Timestamp.FromDateTime(DateTime.Now.AddYears(-1 * RandomNumberGenerator.GetRandomValue(1, 10)).ToUniversalTime()),
                Teaches = textBoxTeaches.Text,
                Salary = double.Parse(textBoxSalary.Text),
                IsPhd = checkBoxIsPhd.Checked
            };
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBoxName.Text = NameGenerator.GenerateName(12);
            textBoxTeaches.Text = "CSharp, Java";
            textBoxSalary.Text = "1234.56";
            checkBoxIsPhd.Checked = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
