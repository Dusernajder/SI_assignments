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


        static void Compress(FileInfo fileToCompress)
        {
            using (FileStream originalFileStream = new FileStream(fileToCompress.FullName, FileMode.Open, FileAccess.Read))
            {
                if (IsCompressedFileNotExists(fileToCompress))
                {
                    string rawFileName = Path.GetFileNameWithoutExtension(fileToCompress.FullName);
                    string outputFile = fileToCompress.Directory + "/" + rawFileName + ".gz"; // '\' for Windows
                    using (FileStream compressedFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            Console.WriteLine($"Compressed file created: {outputFile}");
                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                }
            }
        }

        private static bool IsCompressedFileNotExists(FileInfo fileToCompress)
        {
            return (File.GetAttributes(fileToCompress.FullName) &
                    FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz";
        }
    }
}