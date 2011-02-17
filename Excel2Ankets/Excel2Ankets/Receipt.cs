using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Excel2Ankets
{
    public class Receipt
       {
        private StreamWriter logFile;
        public Receipt(String logFileName)
    {
        try
        {
            logFile = new StreamWriter(logFileName, false, Encoding.GetEncoding("cp866"));
            
            
            //logFile.WriteLine("\n---------------------------------------------------------------------------------\n");
            //logFile.Write("Excel2Ankets " + Application.ProductVersion + "\n" + "Время запуска " + DateTime.Now.ToString() + "\n");


        }
        catch (Exception)
        {

            throw new FileLoadException("Невозможно открыть файл протокола", logFileName);
        }
 
    }
        public void Wrile2Log(String msgText)
        {
            try
            {
                //StreamWriter strW = new StreamWriter();
                String toWriteText = DateTime.Now.ToString() + "\t" + msgText.Replace('\n', ' ').Replace('\r', ' ') + "\n";
                //byte[] info = new ASCIIEncoding().GetBytes(toWriteText);
                //logFile.Write(info,0,toWriteText.Length);
                
                logFile.Write(toWriteText);
                logFile.Flush();


            }
            catch (Exception)
            {

                throw new Exception("Невозможно запсать файл квитанции");
            }
            
        }

        public void Close()
       {
           logFile.Close();
       }

       }
}
