using Microsoft.AspNetCore.Mvc;

namespace ApiPropia.Entidades
{
    public class Productos 
    {
        public int Id { get; set; }
        public string Nombre { get; set;} = string.Empty;
        public int Stock { get; set; } 
    }
}
