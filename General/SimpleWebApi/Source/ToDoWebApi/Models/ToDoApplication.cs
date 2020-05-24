using System;

namespace ToDoWebApi.Models
{
    
    public class ToDoApplication
    {

        // TODO: To be read from data store / SCM
        public ToDoApplication()
        {
            Version = "1.0";

            Description = "ToDo Application metadata.";

            LastCommitSha = "fd6973f430a3367ad718ff049f1b075843913d6f";
        }

        public Guid Id { get; } = Guid.NewGuid();

        public string Version { get; set; }

        public string Description { get; set; }

        public string LastCommitSha { get; set; }
    }

}
