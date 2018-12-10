using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursModul.Net_2nd_mounth_
{
    class Feature : Task
    {
        public Feature()
        {
            priority = 1;
            TimeOfExecution = priority * complexity;
            status = "ToDo";
        }
        public Feature(int number, string description, int complexity)
            :base(number, description,complexity)
        {
            priority = 1;
        }
        public override void ToString()
        {
            Console.WriteLine($"Feature {this.number} description: {this.description}" +
                $", complexity: {this.complexity}, priority: {this.priority}, status: {this.status}");
        }
    }
}
