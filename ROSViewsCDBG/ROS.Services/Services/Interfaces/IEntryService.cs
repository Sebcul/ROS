using ROSPersistence.ROSDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ros.Services.Services.Interfaces
{
    public interface IEntryService
    {
        void AddEntry(Entry entry);

        void DeleteEntry(Entry entry);

        void UpdateEntry(Entry entry);

        List<Entry> GetAllEnteries();

        Entry GetEntry(int id);

    }
}
