using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSPersistence.ROSDB;

namespace ROS.Services.Models
{
    public class EntryInfo : IEntryInfo
    {

        private readonly Entry _entry;

        public EntryInfo(Entry entry)
        {
          _entry = entry;
        }
        public int No { get { return _entry.No; } }

        public int SkipperId { get { return _entry.SkipperId; } }

        public string Description { get { return _entry.Description; } }

       
    }
}
