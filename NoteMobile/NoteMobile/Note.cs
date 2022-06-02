using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace NoteMobile
{
    [Table("Node")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int id { get; set; } = 0;
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("url")]
        public string Url { get; set; }
        public Note()
        {
            id = 0;
        }
    }
}
