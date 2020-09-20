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
        [PrimaryKey, Column("id")] 
        public int Id { get; set; }

        [MaxLength(250) , Column("name")]
        public string Name { get; set; }

        [MaxLength(250), Unique, Column("link_artist")]
        public string Link { get; set; }

    }

    [Table ("Track")]
    public class Track
    {
        [PrimaryKey, Column("id")]
        public int Id { get; set; }

        [MaxLength(250) , Column("title")]
        public string Title { get; set; }

        [PrimaryKey, Column("artist_id")]
        public int Artist_Id { get; set; }

        [PrimaryKey, Column("html_id")]
        public int html_id { get; set; }

        [MaxLength(250), Unique, Column("link_track")]
        public string Link_Track { get; set; }
    }

    [Table ("Html_dark")]
    public class Html_dark
    {
        [PrimaryKey, Column("id")]
        public int Id { get; set; }

        [MaxLength(250), Column("html_dark")]
        public string Html_d { get; set; }
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
            //conn.CreateTable<Artists>();
            var tasks = conn.Table<Artists>().ToList();
            conn.Close();
            return tasks;
        }


    }
}
