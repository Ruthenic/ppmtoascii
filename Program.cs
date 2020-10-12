using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ppmtoascii
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("PPM File: ");
            string ppmfile = Console.ReadLine();
            string ppmpath = Directory.GetCurrentDirectory() + "/" + ppmfile;
            string magic;
            string heightwidth;
            string maxcol;
            using (StreamReader streamread = new StreamReader(ppmpath)){
                magic = streamread.ReadLine();
                heightwidth = streamread.ReadLine();
                maxcol = streamread.ReadLine();
            }
            string[] hw = heightwidth.Split(null);
            string height = hw[0];
            string width = hw[1];
            List<byte> pixelinfo;
            List<string> lines = ((string[])File.ReadAllLines(ppmpath)).ToList();
            Console.WriteLine(magic + ", " + heightwidth + ", " + maxcol);
            lines.RemoveRange(0, 3);
            File.WriteAllLines("unheaderedppm.binary", lines.ToArray());
            pixelinfo = File.ReadAllBytes("unheaderedppm.binary").ToList();
            foreach (byte bytey in pixelinfo.ToArray()) {
                Console.WriteLine(bytey);
            }
            File.Delete("unheaderedppm.binary");
        }
    }
}
