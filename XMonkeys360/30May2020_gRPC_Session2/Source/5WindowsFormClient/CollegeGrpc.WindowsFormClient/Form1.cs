using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeGrpc.WindowsFormClient
{
    public partial class Form1 : Form
    {
        private static IConfiguration _config;

        public Form1()
        {
            InitializeComponent();

            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var client = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);

            var results = client.AddProfessorAsync(GenerateNewProfessor());

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

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBoxName.Text = NameGenerator.GenerateName(12);
            textBoxTeaches.Text = "CSharp, Java";
            textBoxSalary.Text = "1234.56";
            checkBoxIsPhd.Checked = false;
        }
    }
}
