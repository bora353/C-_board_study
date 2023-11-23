using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Model
{
    public class Board
    {
        public int Id { get; set; }

        public String Subject { get; set; }
        public String Writer { get; set; }
        public DateTime RegDate { get; set; }
        public int ReadCount { get; set; }
        public String Content { get; set; }
        public int GroupNo { get; set; }
        public int PrinitNo { get; set; }
        public int PrintLevel { get; set; }



    }
}
