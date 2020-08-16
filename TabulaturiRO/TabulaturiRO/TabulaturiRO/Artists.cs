using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TabulaturiRO
{
   [Table ("Artists")]
   public class Artists
    {
        [PrimaryKey, Column("Name")] 
        public string Name { get; set; }

        [MaxLength(250), Unique, Column("Link")]
        public string Link { get; set; }

    }

    public class EditArtistDb
    {
        public void saveArtist(Artists artist)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Artists>();
            conn.Insert(artist);
            conn.Close();
        }

        public void deleteAlllArtists()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Artists>();
            conn.DeleteAll<Artists>();
            conn.Close();
        }

        public List<Artists> createList()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation);
            conn.CreateTable<Artists>();
            var tasks = conn.Table<Artists>().ToList();
            conn.Close();
            return tasks;
        }
    }
}
