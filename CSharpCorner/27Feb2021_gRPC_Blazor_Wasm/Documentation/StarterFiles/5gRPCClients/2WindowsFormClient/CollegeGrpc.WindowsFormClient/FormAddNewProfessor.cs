using College.GrpcServer.Protos;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows.Forms;
using static College.GrpcServer.Protos.CollegeSvc;

namespace CollegeGrpc.WindowsFormClient
{
    public partial class FormAddNewProfessor : Form
    {
        private static IConfiguration _config;

        static private CollegeSvcClient _client;

        public FormAddNewProfessor()
        {
            InitializeComponent();

            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();

            _client = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
