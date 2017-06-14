using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Program programCode = new Program();
            programCode.MainCode();
        }
        public void MainCode()
        {
            // A simple .PLS file generator for live radiostations

            //example that will be generated to a .pls file
            /*[playlist]
            NumberOfEntries=1
            File1=http://vip-icecast.538.lw.triple-it.nl:80/WEB11_MP3
            Title1=538 Hitzone / 192kbps
            Length1 = -1
            NumberOfEntries=1
            Version=2*/
            string title;
            string url;
            string filename;

            Console.WriteLine("Welcome on the pls generator");
            Console.WriteLine("Please, what is the title of the radiostation (friendly name)");
            Console.Write("Title: ");
            title = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Thank you");
            Console.WriteLine("Now enter the url of the radiostation");
            Console.Write("URL: ");
            url = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Very nice");
            Console.WriteLine("Pleae enter the prefered filename, without the .pls at the end");
            Console.Write("filename: ");
            filename = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("That's kind");
            Console.WriteLine("Give me a sec, I am generating the pls file");

            string breakline = "\r\n";
            string lines = "";
            lines += @"[playlist]";
            lines += breakline;
            lines += @"NumberOfEntries=1";
            lines += breakline;
            lines += @"File1=" + url;
            lines += breakline;
            lines += @"Title1=" + title;
            lines += breakline;
            lines += @"Length1 = -1";
            lines += breakline;
            lines += @"NumberOfEntries=1";
            lines += breakline;
            lines += @"Version=2";

            try
            {
                StreamWriter filewriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + filename + ".pls");
                filewriter.WriteLine(lines);
                filewriter.Close();
                Console.WriteLine(filename + ".pls was succesfully created in " + Environment.SpecialFolder.MyDocuments);
            }
            catch (Exception e)
            {
                Console.WriteLine("ALERT - there was a error");
                Console.WriteLine("Errormessage - " + e.Message);
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Thanks for using the pls generator");
            Console.WriteLine("To make a new pls file, Please press 'N'");
            Console.WriteLine("To exit press 'C' or hit the close button");
            Console.Write("Close or New item: ");
            var newRun = Console.ReadKey();
            if (newRun.KeyChar == 'n')
            {
                Console.WriteLine(Environment.NewLine);
                MainCode();
            }
            else
            {
                Console.WriteLine("Closing application");
            }
        }
    }
}
