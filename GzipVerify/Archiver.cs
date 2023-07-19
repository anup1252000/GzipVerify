namespace GzipVerify
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public interface IArchiver
    {
        void ArchiveFile(string sourceFilePath, string zipFilePath);
        void ExtractFile(string zipFilePath, string extractFolderPath);
    }

    public class ZipArchiver : IArchiver
    {
        public void ArchiveFile(string sourceFilePath, string zipFilePath)
        {
            try
            {
                using (FileStream sourceFileStream = new FileStream(sourceFilePath, FileMode.Open))
                {
                    using (FileStream zipFileStream = File.Create(zipFilePath))
                    {
                        using (ZipArchive zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                        {
                            string entryName = Path.GetFileName(sourceFilePath);
                            ZipArchiveEntry zipEntry = zipArchive.CreateEntry(entryName);

                            using (Stream entryStream = zipEntry.Open())
                            {
                                sourceFileStream.CopyTo(entryStream);
                            }
                        }
                    }
                }

                Console.WriteLine("File zipped successfully: " + zipFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error zipping the file: " + ex.Message);
            }
        }

        public void ExtractFile(string zipFilePath, string extractFolderPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipFilePath, extractFolderPath);

                Console.WriteLine("File extracted successfully to: " + extractFolderPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error extracting the file: " + ex.Message);
            }
        }
    }

    public class UnzipArchiver : IArchiver
    {
        public void ArchiveFile(string sourceFilePath, string zipFilePath)
        {
            Console.WriteLine("Invalid operation: Cannot archive a file using the unzip archiver.");
        }

        public void ExtractFile(string zipFilePath, string extractFolderPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipFilePath, extractFolderPath);

                Console.WriteLine("File extracted successfully to: " + extractFolderPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error extracting the file: " + ex.Message);
            }
        }
    }
}
