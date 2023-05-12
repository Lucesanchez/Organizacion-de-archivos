/*
* Program.cs
* Administración y organización de datos
* IINF 4° E
* Organización de archivos secuenciales
* Lucero Sanchez Angel
* 21887052
* Violeta Lizbeth Nataren Zambrano
* 21887044
*/
using System;
using System.IO;
public static class Program
{
    struct alumno_t
    {
        public string nombre;
        public int matricula;
        public string carrera;
        public int semestre;
        public char grupo;
        public decimal promedio;
        
    }
    static void Main(string[] args)
    {
        alumno_t[] alumno = new alumno_t[2];
        Console.Clear();
        try
        {
            FileStream fileStream = new FileStream("Alumnos.dat",
            FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            int i = 0;
            while (binaryReader.PeekChar() > -1)
            {
                alumno[i].nombre = binaryReader.ReadString();
                alumno[i].matricula = binaryReader.ReadInt32();
                alumno[i].carrera = binaryReader.ReadString();
                alumno[i].semestre = binaryReader.ReadInt32();
                alumno[i].grupo = binaryReader.ReadChar();
                alumno[i].promedio = binaryReader.ReadDecimal();
                i++;
            }
            binaryReader.Close();
            fileStream.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }
        Console.WriteLine("Datos del Alumno");
        Console.WriteLine("----------------");
        for (int j = 0; j < alumno.Count(); j++)
        {
            int i = 0;
            Console.WriteLine($"Nombre: {alumno[i].nombre}\n"
 + $"Número de Control: {alumno[i].matricula}\n" + $"Carrera: {alumno[i].carrera}\n" + $"Semestre: {alumno[i].semestre}\n" + $"Grupo: {alumno[i].grupo}\n" + $"Promedio: {alumno[i].promedio}");
            Console.WriteLine("----------------");
        }

        Console.Write("Presione una tecla para terminar ");
        Console.ReadKey();
    }
}
