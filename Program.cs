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
            File.WriteAllText("output.txt", "");
            StreamWriter sr = new StreamWriter("output.txt");
            using (StreamReader streamread = new StreamReader(ppmpath)){
                magic = streamread.ReadLine();
                heightwidth = streamread.ReadLine();
                maxcol = streamread.ReadLine();
            }
            string[] hw = heightwidth.Split(null);
            string width = hw[0];
            string height = hw[1];
            List<byte> pixelinfo;
            List<string> lines = ((string[])File.ReadAllLines(ppmpath)).ToList();
            Console.WriteLine(magic + ", " + heightwidth + ", " + maxcol);
            lines.RemoveRange(0, 3);
            File.WriteAllLines("unheaderedppm.binary", lines.ToArray());
            pixelinfo = File.ReadAllBytes("unheaderedppm.binary").ToList();
            int i = 0;
            foreach (byte bytey in pixelinfo.ToArray()) {
                Console.WriteLine(bytey);
                if (i <= int.Parse(width)) {
                    sr.WriteLine("");
                }
                if (bytey >= 1) {
                    sr.Write("$");
                    i+= 1;
                } else {
                    sr.Write(" ");
                    i+= 1;
                }
            }
            File.Delete("unheaderedppm.binary");
        }
    }
}
