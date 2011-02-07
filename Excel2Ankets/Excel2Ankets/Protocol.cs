using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Excel2Ankets
{
    public class Protocol

    {
        private StreamWriter logFile;
    public Protocol(String logFilePath)
    {
 
        try
        {
            logFile = File.AppendText(logFilePath+"\\excel2ankets_"+DateTime.Today.ToShortDateString()+".log");
            logFile.AutoFlush = true;
            logFile.WriteLine("\n---------------------------------------------------------------------------------\n");
            logFile.Write("Excel2Ankets " + Application.ProductVersion + "\n" + "Время запуска "+DateTime.Now.ToString()+"\n");


        }
        catch (Exception)
        {
            
            throw new FileLoadException("Невозможно открыть файл протокола", logFilePath);
        }
    }
        public void Wrile2Log(String msgText)
        {
            try
            {
                msgText.Replace((char)13, ' ');
                logFile.Write(DateTime.Now.ToString()+"\t"+msgText+"\n");
                //logFile.Flush();
            }
            catch (Exception)
            {

                throw new Exception("Невозможно запсать файл протокола");
            }
            
        }

}
}
