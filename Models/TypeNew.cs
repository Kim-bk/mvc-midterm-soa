using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.Models
{
    public class TypeNew
    {
        public TypeNew(){
            News = new List<New>();
        }
        public int Id { get; set; }
        public string TypeNewName { get; set; }
        public List<New> News { get; set; }
    }
}