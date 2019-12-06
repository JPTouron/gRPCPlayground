using System;

namespace gRPCPlayground
{
    class Program
    {
        static void Main(string[] args)
        {


            var j = new juan {  edad=15,nombre="gri"};
             (var edad,var nombre  ) = j;





            Console.WriteLine($"Hello World! {edad},  {nombre}  ");
        }
    
    }


    class juan
    {

        public int edad { get; set; }
        public string nombre { get; set; }

        internal void Deconstruct(out int edad, out string nombre)
        {
            edad = this.edad;
            nombre = this.nombre;
        }
    }

}
