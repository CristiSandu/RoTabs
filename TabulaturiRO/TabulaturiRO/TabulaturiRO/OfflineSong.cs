using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TabulaturiRO
{
    public class OfflineSong
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name_Song { get; set; }
    
        public string HTML_Song { get; set; }

        public int HTML_dark { get; set; }

    }
}
