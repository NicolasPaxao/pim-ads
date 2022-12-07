using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Model
{
    public class SeguradoraListModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public SeguradoraListModel(int? id, string? name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
