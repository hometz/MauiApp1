using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Entities
{
    [SQLite.Table("Museums")]
    public class Museum
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

    }
}
