using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 



namespace Excel2Ankets
{
   
    public partial class Form1 : Form
    {
        public Protocol LogFile;
        /// <summary>
        /// Путь к папке с исходными файлами.
        /// </summary>
        private String _inputDirectoryPath;

        

      public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
          LogFile=new Protocol(Application.StartupPath);
          //LogFile.Wrile2Log("TEST");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScanFiles(_inputDirectoryPath);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;

            //if (==DialogResult.OK)
            //{
            //    button1.Enabled = true;
            //    //_inputDirectoryPath = folderBrowserDialog1.SelectedPath;
            //    //_inputDirectoryPath = "E:\\projects\\.net\\Excel2Ankets\\test";
            //    textBox1.Text = _inputDirectoryPath;
            //}
        }
        private void MySqlInit()
        {
            //_mysqlConnectionString = "server=192.168.2.5;user=root;database=cbd_ankets;port=3306;password=lenin;";
            //_mysqlConnection = new MySqlConnection(_mysqlConnectionString);
            //    try
            //    {
            //        _mysqlConnection.Open();
            //        Console.WriteLine("DataSource: {0} \nDatabase: {1}",
            //            _mysqlConnection.DataSource, _mysqlConnection.Database);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            
            //MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM cdb_ankets.bd_org_t;",_mysqlConnection);
            //MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            //DataSet tmpDataSet = new DataSet();


        }
        private void ScanFiles(String inPath)
        {
            
            DirectoryInfo currentPath=new DirectoryInfo(inPath);
            LogFile.Wrile2Log("Используется каталог " + currentPath.FullName);
            LogFile.Wrile2Log("Найдено " + currentPath.GetFiles("*.xls").Count().ToString() +" файл(а,ов)");
            //int filesCount = sourcePath.GetFiles("*.xls").Count();
            OleDbConnection curConnect;
            XlsFile tmpFile;
            int mfo;
            int porc;

            try
            {
                DirectoryInfo backUpPath = new DirectoryInfo(textBox2.Text);
                LogFile.Wrile2Log("Каталог обработанных файлов " + backUpPath.FullName);
                progressBar2.Minimum = 0;
                progressBar2.Maximum = currentPath.GetDirectories("ant?????").Count();
                progressBar2.Value = 0;
                progressBar2.Step = 1;
                DirectoryInfo bakPath = Directory.CreateDirectory(backUpPath.FullName + "\\bak");

                LogFile.Wrile2Log("Создан каталог успешно обработанных файлов " + bakPath.FullName);
                DirectoryInfo badPath =
                    Directory.CreateDirectory(backUpPath.FullName + "\\bad");
                LogFile.Wrile2Log("Создан каталог ошибочных файлов " + badPath.FullName);


                
                curConnect=new OleDbConnection();
                int countFiles = 0;
                //tmpFile.excelConnection = curConnect;
                foreach (DirectoryInfo sourcePath in currentPath.GetDirectories("ant?????"))
                {
                    if (Int32.TryParse(sourcePath.Name.Substring(3,3),out mfo)&&Int32.TryParse(sourcePath.Name.Substring(6,2),out porc))
                    {
                        LogFile.Wrile2Log("+++++++++++++++++++++Обработка каталога \t" + sourcePath.Name+"+++++++++++++++++++++++++++");
                        label5.Text = progressBar2.Value.ToString() + " из " + progressBar1.Maximum + " " +
                                              sourcePath.Name;
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = sourcePath.GetFiles("*.xls").Count();
                        progressBar1.Value = 0;
                        progressBar1.Step = 1;
                        DirectoryInfo workPath = Directory.CreateDirectory(sourcePath.FullName + "\\work");
                        LogFile.Wrile2Log("Создан рабочий каталог  " + workPath.FullName);
                        countFiles = 0;

                        foreach (FileInfo currentFile in sourcePath.GetFiles("*.xls"))
                        {
                            tmpFile = new XlsFile();
                            try
                            {
                                label3.Text = progressBar1.Value.ToString() + " из " + progressBar1.Maximum + " " +
                                              currentFile.Name;
                                currentFile.CopyTo(workPath.FullName + "\\" + currentFile.Name);

                                String workFile = workPath.FullName + "\\" + currentFile.Name;
                                LogFile.Wrile2Log("********************************Чтение файла " + currentFile.Name+"**************************");
                                curConnect.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                                              "Data Source=" + workFile +
                                                              ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";

                                curConnect.Open();
                                Console.WriteLine("DataSource: {0} \nDatabase: {1}",
                                                  curConnect.DataSource, curConnect.Database);


                                tmpFile.LogFile = LogFile;
                                //tmpFile.prBarSheets = progressBar2;
                                tmpFile.excelConnection = curConnect;
                                tmpFile.currentFileName = currentFile.Name;
                                tmpFile.mfo = mfo;
                                tmpFile.porc = porc;
                                bool readRes = tmpFile.Read();
                                countFiles++;
                                progressBar1.PerformStep();
                                
                                curConnect.Close();
                                curConnect.Dispose();
                                tmpFile.excelConnection.Close();
                                tmpFile.excelConnection.Dispose();


                                if (readRes)
                                {
                                    LogFile.Wrile2Log("По файлу " + currentFile.Name +
                                                      " ошибок не обнаружено. Файл будет перемещен в " +
                                                      bakPath.Name);
                                    curConnect.Close();
                                    curConnect.Dispose();
                                    tmpFile.excelConnection.Close();
                                    tmpFile.excelConnection.Dispose();
                                    int i=0;
                                    String movedFileName=currentFile.Name;
                                    while (File.Exists(bakPath.FullName + "\\" + movedFileName))
                                    {
                                        i++;
                                        movedFileName = currentFile.Name.Insert(currentFile.Name.Length - 4,
                                                                                "_" + i.ToString("D3"));
                                    }
                                    currentFile.MoveTo(bakPath.FullName + "\\" + movedFileName);
                                    LogFile.Wrile2Log("Файл перемещен.\n\n");

                                }
                                else
                                {
                                    LogFile.Wrile2Log("По файлу " + currentFile.Name +
                                                      " обнаружены ошибки. Файл будет перемещен в " +
                                                      badPath.Name);
                                    curConnect.Close();
                                    curConnect.Dispose();
                                    tmpFile.excelConnection.Close();
                                    tmpFile.excelConnection.Dispose();
                                    int i=0;
                                    String movedFileName=currentFile.Name;
                                    while (File.Exists(badPath.FullName + "\\" + movedFileName))
                                    {
                                        i++;
                                        movedFileName = currentFile.Name.Insert(currentFile.Name.Length - 4,
                                                                                "_" + i.ToString("D3"));
                                    }
                                        currentFile.MoveTo(badPath.FullName + "\\" + movedFileName);
                                        LogFile.Wrile2Log("Файл перемещен.\n\n");


                                }

                            }
                            catch (IOException ioException)
                            {
                                LogFile.Wrile2Log("Ошибка при обработке файла " + currentFile.Name + "\n\t" +
                                                  ioException.InnerException + "\n\t" + ioException.Message);
                                curConnect.Close();
                                curConnect.Dispose();
                                tmpFile.excelConnection.Close();
                                tmpFile.excelConnection.Dispose();

                            }
                            catch (Exception exception)
                            {
                                curConnect.Close();
                                curConnect.Dispose();
                                tmpFile.excelConnection.Close();
                                tmpFile.excelConnection.Dispose();
                                LogFile.Wrile2Log("Ошибка при обработке файла " + currentFile.Name + "\n\t" +
                                                  exception.InnerException + "\n\t" + exception.Message);

                                throw;
                            }



                        }

                        GC.Collect();
                        LogFile.Wrile2Log("Обработано файлов " + countFiles + " из " + progressBar1.Maximum);
                        //sourcePath.Refresh();

                        //XlsFile tmpFile = new XlsFile(_inputDirectoryPath + "\\test.xls", LogFile);
                        //tmpFile.Read();
                       Directory.Delete(sourcePath.FullName, true);
                    }
                    progressBar2.PerformStep();


                }
            }
            catch (Exception exception)
            {


                LogFile.Wrile2Log(exception.InnerException + "\n\t" + exception.Message);
                throw;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath=textBox1.Text;
            chekDirs();
        }
        private void chekDirs()
        {
            if (Directory.Exists(textBox1.Text) && Directory.Exists(textBox2.Text))
            {

                if (Directory.GetDirectories(textBox1.Text, "ant?????").Count() > 0)
                {
                    _inputDirectoryPath = textBox1.Text;
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }

            }
            else
                button1.Enabled = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            folderBrowserDialog2.SelectedPath = textBox2.Text;
            chekDirs();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowNewFolderButton = false;
            folderBrowserDialog2.ShowDialog();
            textBox2.Text = folderBrowserDialog2.SelectedPath;

        }
  

    }
    
}
