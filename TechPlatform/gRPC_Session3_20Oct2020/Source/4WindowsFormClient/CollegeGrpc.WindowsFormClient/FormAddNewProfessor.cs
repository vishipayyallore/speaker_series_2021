using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows.Forms;
using static College.GrpcServer.Protos.CollegeService;

namespace CollegeGrpc.WindowsFormClient
{
    public partial class FormAddNewProfessor : Form
    {
        private static IConfiguration _config;
        static private CollegeServiceClient _client;

        public FormAddNewProfessor()
        {
            InitializeComponent();

            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();

            textBoxName.Text = NameGenerator.GenerateName(12);

            _client = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            var newProfessor = await _client.AddProfessorAsync(GenerateNewProfessor());

            MessageBox.Show($"New Professor Added with Id: {newProfessor.ProfessorId}");
        }

        

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBoxName.Text = NameGenerator.GenerateName(12);
            textBoxTeaches.Text = "CSharp, Java";
            textBoxSalary.Text = "1234.56";
            checkBoxIsPhd.Checked = false;
        }

        private async void buttonFind_Click(object sender, EventArgs e)
        {
            var professorRequest = new GetProfessorRequest { ProfessorId = textBoxProfessorId.Text };
            var professor = await _client.GetProfessorByIdAsync(professorRequest);

            textBoxName.Text = professor.Name;
            textBoxTeaches.Text = professor.Teaches;
            textBoxSalary.Text = professor.Salary.ToString();
            checkBoxIsPhd.Checked = professor.IsPhd;
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            var updatedProfessor = new UpdateProfessorRequest
            {
                ProfessorId = textBoxProfessorId.Text,
                Name = textBoxName.Text,
                Teaches = textBoxTeaches.Text,
                Salary = double.Parse(textBoxSalary.Text),
                IsPhd = checkBoxIsPhd.Checked
            };

            var _ = await _client.UpdateProfessorByIdAsync(updatedProfessor);
            MessageBox.Show($"Professor Updated with Id: {updatedProfessor.ProfessorId}");
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private NewProfessorRequest GenerateNewProfessor()
        {
            return new NewProfessorRequest()
            {
                Name = textBoxName.Text,
                Doj = Timestamp.FromDateTime(DateTime.Now.AddYears(-1 * RandomNumberGenerator.GetRandomValue(1, 10)).ToUniversalTime()),
                Teaches = textBoxTeaches.Text,
                Salary = double.Parse(textBoxSalary.Text),
                IsPhd = checkBoxIsPhd.Checked
            };
        }

    }

}
