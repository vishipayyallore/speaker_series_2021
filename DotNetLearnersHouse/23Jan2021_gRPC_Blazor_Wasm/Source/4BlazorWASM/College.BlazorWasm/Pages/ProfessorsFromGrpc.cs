using College.Core.Entities;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.BlazorWasm.Pages
{

    public partial class ProfessorsFromGrpc
    {
        [Inject]
        public GrpcChannel Channel { get; set; }

        private AllProfessorsResonse AllProfessors { get; set; }

        public IList<Professor> Professors { get; set; } = new List<Professor>();

        protected override async Task OnInitializedAsync()
        {
            var client = new CollegeSvc.CollegeSvcClient(Channel);
            AllProfessors = await client.GetAllProfessorsAsync(new Empty());

            foreach (var professor in AllProfessors.Professors)
            {
                Professors.Add(GetProfessor(professor));
            }
        }

        private Professor GetProfessor(GetProfessorResponse prof)
        {
            return new Professor
            {
                ProfessorId = Guid.Parse(prof.ProfessorId),
                Name = prof.Name,
                Doj = prof.Doj.ToDateTime(),
                Teaches = prof.Teaches,
                Salary = Convert.ToDecimal(prof.Salary),
                IsPhd = prof.IsPhd,
                PictureUrl = prof.PictureUrl
            };
        }

    }

}
