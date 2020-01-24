using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMTS_MINUTES.BusinessLogic
{
    class BLZip
    {
        internal void UnzipFilenameInFolder(string filename)
        {

            ZipInputStream s = new ZipInputStream(File.OpenRead(filename));

            ZipEntry theEntry;
            string tmpEntry = String.Empty;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = Utils.imp;
                string fileName = Path.GetFileName(theEntry.Name);
                // create directory 
                if (directoryName != "")
                {
                    Directory.CreateDirectory(directoryName);
                }
                if (fileName != String.Empty)
                {
                    if (theEntry.Name.IndexOf(".ini") < 0)
                    {
                        string fullPath = directoryName + fileName;



                        FileStream streamWriter = File.Create(fullPath);
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
            }
            s.Close();


        }
        
        internal void ZipTabEsportabiliInZiPfile()
        {


            CreateZIPFromFolder(Utils.Exp + "IMTSDatiExport.zip", "" ,Utils.Exp);

            


        }

        private void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {

            string[] files = Directory.GetFiles(path);

            foreach (string filename in files)
            {
                if (!filename.EndsWith(".zip"))
                {

                    FileInfo fi = new FileInfo(filename);

                    string entryName = filename.Substring(folderOffset);
                    entryName = ZipEntry.CleanName(entryName);
                    ZipEntry newEntry = new ZipEntry(entryName);
                    newEntry.DateTime = fi.LastWriteTime;


                    newEntry.Size = fi.Length;

                    zipStream.PutNextEntry(newEntry);

                    byte[] buffer = new byte[4096];
                    using (FileStream streamReader = System.IO.File.OpenRead(filename))
                    {
                        StreamUtils.Copy(streamReader, zipStream, buffer);
                    }
                    zipStream.CloseEntry();
                }
                string[] folders = Directory.GetDirectories(path);
                foreach (string folder in folders)
                {
                    CompressFolder(folder, zipStream, folderOffset);
                }
            }
        }
        private void CreateZIPFromFolder(string outPathname, string password, string folderName)
        {
            string[] filePaths = System.IO.Directory.GetFiles(Utils.Exp);/// pulisco la directory
            foreach (string filePath in filePaths)

                System.IO.File.Delete(filePath);


            File.Copy(Utils.getBasePathName + "Materiale_Container.xml", Utils.Exp + "Materiale_Container.xml");
            File.Copy(Utils.getBasePathName + "Minute.xml", Utils.Exp + "Minute.xml");
             
            FileStream fsOut = System.IO.File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression

            zipStream.Password = password;  // optional. Null is the same as not setting. Required if using AES.


            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

            CompressFolder(folderName, zipStream, folderOffset);

            zipStream.IsStreamOwner = true;	// Makes the Close also Close the underlying stream
            zipStream.Close();

            //eleimino gli xml
            string[] filePaths1 = System.IO.Directory.GetFiles(Utils.Exp, "*.xml");/// pulisco la directory
            foreach (string filePath in filePaths1)

                System.IO.File.Delete(filePath);
        }
    }
}
