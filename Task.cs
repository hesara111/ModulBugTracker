using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursModul.Net_2nd_mounth_
{
    class Task
    {
        public int number { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public int complexity { get; set; }
        public int priority { get; set; }
        public int TimeOfExecution { get; set; }
        public Task() { }
        public Task(int number, string description, int complexity)
        {
            this.number = number;
            this.description = description;
            this.status = "ToDo";
            this.complexity = complexity;
            
        }

        public virtual void ToString()
        {
            
        }
    }
}
