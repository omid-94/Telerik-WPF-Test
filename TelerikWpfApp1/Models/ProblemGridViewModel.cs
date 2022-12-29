using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikWpfApp1.Models
{
    public class ProblemGridViewModel
    {
        public int ProblemId { get; set; }
        public string ProblemDesc { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Keywords { get; set; }
        public bool IsSolved { get; set; }
    }
}
