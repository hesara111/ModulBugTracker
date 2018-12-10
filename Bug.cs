using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursModul.Net_2nd_mounth_
{
    class Bug:Task
    {
        public Bug()
        {
            priority = 2;
            TimeOfExecution = priority * complexity;
            status = "ToDo";
        }
        public Bug(int number, string description, int complexity)
            : base(number, description, complexity)
        {
            priority = 2;
        }
        public override void ToString()
        {
            Console.WriteLine($"Bug {this.number} description: {this.description}" +
                $", complexity: {this.complexity}, priority: {this.priority}, status: {this.status}");
        }
    }
}
