using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Model
{
    public class FuncionarioListModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public FuncionarioListModel(int? id, string? name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
