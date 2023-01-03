using System;
using System.IO; //files library  

namespace FileProject
{
    class Program
    {

        // ----------- In this program I read and write to the file ----------- 

        // I will add methods, one for read , another for write. (SOLID :) )
        // Pass the path and data to write in a file  by the user to input (ADD) 
        // Overwrite to the file by the user input (Delete I think)(Not Today) append or overwrite 
        // View the file, as i switch, while loop to inter input as a choices ADD - Delete - Display
        // Each method will have try-catch-finally
        // await we cant read and write in the same time - async, in the same time we can read and write

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

                fileStreamRead = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                fileStreamWrite = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                streamWriter = new StreamWriter(fileStreamWrite);

                streamReader = new StreamReader(fileStreamRead);

                streamWriter.WriteLine("   New Line");


                String fileContent = streamReader.ReadLine(); //Read only line 


                while (fileContent != null) //When there is a line to read
                {
                    Console.WriteLine(fileContent);
                    fileContent = streamReader.ReadLine(); 
                    Console.ReadLine();

                }

               /* if(File.Exists(filePath)) { 
                    Console.WriteLine("File Found"+ filePath);
                    File.Delete(filePath);

                }  */
            }
            catch (FileNotFoundException ex) //If file not found
            {
                Console.WriteLine("The file {0} is not found", ex.Message);
                Console.ReadLine();

            }
            catch (Exception e)//Any other Error
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
