using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class DaySeven
    {
        public static long TOTAL_SPACE = 70000000;
        public static long REQUIRED_SPACE = 30000000;

        public static void Init()
        {
            string[] lines = File.ReadAllLines(@"input.txt");
            List<AOCDirectory> directories = new List<AOCDirectory>();
            string currentDir = "";
            bool checkNextLine = false;

            foreach (string line in lines) { 
                if (line.StartsWith("$ cd"))
                {
                    checkNextLine = false;
                    string cd = line.Substring(5);
                    AOCDirectory dir = new AOCDirectory();
                    bool add = true;
                    if (cd == "/")
                    {
                        dir.path = "/";
                    }
                    else if (cd == "..")
                    {
                        int index = currentDir.LastIndexOf("/");
                        dir.path = currentDir[..index];
                        if (dir.path == "")
                            dir.path+= "/";
                    }
                    else
                    {
                        if (currentDir.EndsWith("/"))
                            dir.path = currentDir + cd;
                        else
                            dir.path = currentDir + "/" + cd;

                        dir.parent = directories.Find(d => d.path == currentDir);
                        dir.parent.children.Add(dir);

                    }
                    currentDir = dir.path;
                    if (!directories.Any(d => d.path == dir.path)) 
                        directories.Add(dir);
                }
                else if (line == "$ ls")
                    checkNextLine= true;
                else
                {
                    if (checkNextLine) {                     
                        if (!line.StartsWith("dir"))
                        {
                            AOCFile file = new AOCFile();
                            file.Name = line.Split(' ')[1];
                            file.Size = Int64.Parse(line.Split(' ')[0]);
                            file.parent = directories.Find(d => d.path == currentDir);
                            file.parent.children.Add(file);

                            AOCDirectory parent = file.parent;
                            while (parent != null)
                            {
                                parent.Size += file.Size;
                                parent = parent.parent;
                            }
                        }
                    }
                }
            }

            long sum = 0;

            foreach (AOCDirectory directory in directories)
            {
                if (directory.Size < 100000)
                {
                    sum += directory.Size;
                }
            }

            /*            Console.WriteLine(sum); */ // part 1

            long usedSpace = directories[0].Size; // it's / size

            directories = directories.OrderBy(o => o.Size).ToList();


            foreach (AOCDirectory directory in directories)
            {
                if ((TOTAL_SPACE - usedSpace) + directory.Size >= REQUIRED_SPACE)
                {
                    Console.WriteLine(directory.Size);
                }
            }

        }
    }

    internal interface IFile
    {
        public long Size { get; set; }
        public string Name { get; set; }
    }

    internal class AOCFile : IFile
    {
        public string name;
        private long size;
        public long Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }
        public AOCDirectory parent;
    }

    internal class AOCDirectory : IFile 
    {
        public string path;
        public long size;
        public AOCDirectory parent;
        public List<IFile> children = new List<IFile>();

        public long Size { get => size; set => size = value; }
        public string Name {  get => path; set =>  path = value; }
    }
}
