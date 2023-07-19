using GzipVerify;
using System.Text;

string sourceFilePath = "Users.json"; // Path to the file to be zipped
string zipFilePath = "ZippedFile.zip"; // Path and filename for the resulting ZIP file
string extractFolderPath = "ExtractedFiles"; // Path to the folder where files will be extracted

IArchiver archiver = new ZipArchiver();
archiver.ArchiveFile(sourceFilePath, zipFilePath);

archiver = new UnzipArchiver();
archiver.ExtractFile(zipFilePath, extractFolderPath);