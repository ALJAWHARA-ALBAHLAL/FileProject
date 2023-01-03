using System;
using System.IO;

namespace FileProject
{
    class Program
    {

        // ----------- In this program I read and write to the file ----------- 

        static void Main(String[] args)
        {
            String filePath = @"C:\Test\File.txt";

            FileInfo fileInfo = new FileInfo(filePath);

            FileStream fileStreamRead = null;

            FileStream fileStreamWrite = null;

            StreamWriter streamWriter = null;

            StreamReader streamReader = null;


            try
            {

                fileStreamRead = fileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

                fileStreamWrite = fileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

                streamWriter = new StreamWriter(fileStreamWrite);

                streamReader = new StreamReader(fileStreamWrite);

                streamWriter.WriteLine("   New Line");


                String fileContent = streamReader.ReadLine();


                while (fileContent != null)
                {
                    Console.WriteLine(fileContent);
                    fileContent = streamReader.ReadLine();
                    Console.ReadLine();

                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("The file {0} is not found", ex.Message);
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ther was a problem" + "\n" + e.Message);
                Console.ReadLine();

            }

            finally // Clean and free resources
            {
                streamWriter.Close();
                streamReader.Close();
                fileStreamRead.Close();
                fileStreamWrite.Close();
            }
        }
    }


}
