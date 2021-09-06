using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    public class admin

    {
        public static void dx()
        {

            bool showMenu = true;

            while (showMenu)

            {
                showMenu = Menu();
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {

            Console.WriteLine("selecion de archio: ");
            Console.WriteLine("1. registro");
            Console.WriteLine("2. crear archivo");
            Console.WriteLine("3. eliminar archivo");
            Console.WriteLine("4. mostrar archivos");
            Console.WriteLine("5. Salir");
            Console.Write("\nOpcion: ");




            switch (Console.ReadLine())
            {
                case "1":
                    registro();
                    return true;
                case "2":
                    archivos();
                    Console.ReadKey();
                    return true;
                case "3":
                    borrar();
                    Console.ReadKey();
                    return true;
                case "4":

                    Console.WriteLine("Archivos Existentes");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}: {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;
                case "5":
                    return false;
                default:
                    return false;
            }
        }

        private static string direccion()
        {
            string path = @"C:\Users\lobo1\source\repos\ConsoleApp10\registros\usuarios.txt";
            return path;
        }

        private static void registro()
        {
            Console.Clear();
            Console.WriteLine("REGISTRO DE USUARIO.");
            Console.WriteLine("Ingrese el nomnbre de usuario :");
            String newus = Console.ReadLine();
            Console.WriteLine("ingresar la contraseña :");
            string newpass = Console.ReadLine();

            using (StreamWriter pr = File.AppendText(direccion()))
            {
                pr.WriteLine("{0}; {1}", newus, newpass);
                pr.Close();
            }
            
        }

        private static Dictionary<object, object> read()
        {
            Dictionary<object, object> listdata = new Dictionary<object, object>();
            using (var reader = new StreamReader(direccion()))
            {
                string lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listdata.Add(keyvalue[0], keyvalue[1]);
                    }
                }
            }
            return listdata;
        }





        private static string direcion()
        {
            string path = @"C:\Users\lobo1\source\repos\ConsoleApp10\registros\archivo.txt";
            return path;
        }



        private static void archivos()
        {

            Console.WriteLine("Datos de los archivos");
            Console.Write("Nombre el archivo: ");
            string archivo = Console.ReadLine();
            Console.Write("Texto : ");
            string age = Console.ReadLine();


            using (StreamWriter sw = File.AppendText(direcion()))

            {
                sw.WriteLine("{0}; {1}", archivo, age);


                sw.Close();
            }

        }
     
        private static Dictionary<object, object> readFile()
        {
            Dictionary<object, object> listData = new Dictionary<object, object>();


            using (var reader = new StreamReader(direcion()))
            {

                string lines;

                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listData.Add(keyvalue[0], keyvalue[1]);
                    }
                }

            }


            return listData;
        }


        private static bool search(string name)
        {
            if (!readFile().ContainsKey(name))
            {
                return false;
            }
            return true;
        }


 
        private static void borrar()
        {

            Console.Write("Escriba el nombre del archivo : ");
            var name = Console.ReadLine();




            if (search(name))
            {
                Console.WriteLine("archivo encontrado");
                var newAge = Console.ReadLine();

                Dictionary<object, object> temp = new Dictionary<object, object>();
                temp = readFile();

                temp[name] = newAge;
                
                File.Delete(direcion());

                using (StreamWriter sw = File.AppendText(direcion()))
                {

                    foreach (KeyValuePair<object, object> values in temp)
                    {
                        sw.WriteLine("{0}; {1}", values.Key, values.Value);

                    }
                }

            }

            else
            {
                Console.WriteLine("El archivo no se encontro!");
            }
        }
    }
}