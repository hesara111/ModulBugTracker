using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    class TechnicalDebt: Task
    {
        public TechnicalDebt()
        {
            priority = 1;
            TimeOfExecution = priority * complexity;
            status = "ToDo";
        }
        public TechnicalDebt(int number, string description, int complexity)
            : base(number, description, complexity)
        {
            priority = 1;
            TimeOfExecution = priority * complexity;

        }
        public override void ToString()
        {
            Console.WriteLine($"Technical Debt {this.number} description: {this.description}" +
                $", complexity: {this.complexity}, priority: {this.priority}, status: {this.status}");
        }
    }
}
