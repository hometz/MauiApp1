using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Entities;
using MauiApp1.Services;
using SQLite;

namespace MauiApp1.Services
{
    public class SqLiteService: IDbService
    {
        private readonly SQLiteConnection db;
        public SqLiteService()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dbFile = Path.Combine(path, "myDbSQLite.db3");

            if (File.Exists(dbFile)) File.Delete(dbFile);

            db = new SQLiteConnection(dbFile, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        }
        public IEnumerable<Museum> GetAllMuseums() 
        {
            return db.Table<Museum>().ToList();
        }
        public IEnumerable<Exhibit> GetMuseumExhibits(Museum museum) 
        {
            return db.Table<Exhibit>().Where(e => e.MuseumId == museum.Id).ToList();
        }
        public void Init()
        {

            db.CreateTable<Museum>();
            db.CreateTable<Exhibit>();

            for (int i = 0; i <= 4; ++i)
            {
                Museum museum = new Museum()
                {
                    Type = $"Тип {i}",
                    StartDate = DateTime.Now.AddDays(-i),
                    Duration = 120 * i
                };

                db.Insert(museum);

                for (int j = 1; j <= 5; ++j)
                {
                    db.Insert(new Exhibit()
                    {
                        Name = $"Экспонат {j} для музея {i}",
                        MuseumId = museum.Id
                    });
                }
            }
        }
    }
}
