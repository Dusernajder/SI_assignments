using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SeekAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string path = args[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"Path: {path}");

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            CompressMatchingFiles(fileName, directoryInfo);
        }


        static void CompressMatchingFiles(string fileName, DirectoryInfo directoryInfo)
        {
            foreach (var fileSystemInfo in directoryInfo.GetFileSystemInfos())
            {
                if (fileSystemInfo.ToString().EndsWith(fileName))
                {
                    Compress(new FileInfo(fileSystemInfo.FullName));
                }
                else if (Directory.Exists(fileSystemInfo.FullName))
                {
                    CompressMatchingFiles(fileName, new DirectoryInfo(fileSystemInfo.FullName));
                }
            }
        }


        static void Compress(FileInfo fileInfo)
        {
        }
    }
}