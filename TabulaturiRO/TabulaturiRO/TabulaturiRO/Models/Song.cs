using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TabulaturiRO
{
    public class Song
    {
        [PrimaryKey , AutoIncrement]
        public int Id { get; set; }
        
        [MaxLength(255)]
        public string Name { get; set; }


        public string Content{ get; set; }

    }
}
