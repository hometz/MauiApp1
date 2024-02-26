using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Entities
{
    [SQLite.Table("Exhibits")]
    public class Exhibit
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [SQLite.Column("Id")]
        public int ExhibitId { get; set; }
        public string Name { get; set; }
        [Indexed]
        public int MuseumId { get; set; }
    }
}
