
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Entities;

namespace MauiApp1.Services
{
    public interface IDbService
    {
        public IEnumerable<Museum> GetAllMuseums();
        public IEnumerable<Exhibit> GetMuseumExhibits(int id);
        public void Init();
    }
}
