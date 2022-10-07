using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSProject.Shared
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty ;
        public CategoryGroup? CategoryGroup { get; set; }
        public int CategoryGroupId { get; set; }
    }
}
