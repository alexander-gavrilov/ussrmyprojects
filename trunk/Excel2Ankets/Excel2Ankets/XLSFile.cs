using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;
using Excel2Ankets.cbd_anketsDataSetTableAdapters;
using Excel2Ankets.testDataSetTableAdapters;
using Excel2Ankets;
using System.Windows.Forms;
using bd_org_tTableAdapter = Excel2Ankets.testDataSetTableAdapters.bd_org_tTableAdapter;

namespace Excel2Ankets
{
    class XlsFile
    {
        public Protocol LogFile;
        public String currentFileName;
        public String fileName;
        public int mfo;
        public int porc;
        //public ProgressBar prBarSheets;
        /// <summary>
        /// ConnectionString для файла excel
        /// </summary>
        private String _excelConnectionString = "";
        /// <summary>
        /// ConnectionString для базы mysql
        /// </summary>
        private String _mysqlConnectionString = "";
        /// <summary>
        /// Словарь соответствия полей MySql и анкеты в Excel юридических лиц
        /// </summary>
        private Dictionary<String, String> _fieldsDictUL;
        /// <summary>
        /// Словарь соответствия полей MySql и анкеты в Excel индивидуальных предпринимателей
        /// </summary>
        private Dictionary<String, String> _fieldsDictIP;

        public OleDbConnection excelConnection;
        /// <summary>
        /// connection to MySql
        /// </summary>
        MySql.Data.MySqlClient.MySqlConnection _mysqlConnection;

        /// <summary>
        /// Метод инициализации БД БИАС
        /// </summary>
        public XlsFile()
        {
            //LogFile = logFile;
            _fieldsDictUL = new Dictionary<string, string> { { "наименование", "name" } };
            _fieldsDictUL.Add("регистрационныйномер", "reg_num"); //,
            _fieldsDictUL.Add("датарегистрации", "reg_dat");
            _fieldsDictUL.Add("наименованиерегистрирующегооргана", "reg_org");
            _fieldsDictUL.Add("учетныйномерплательщика", "unp");
            _fieldsDictUL.Add("регион(область,район)", "region");
            _fieldsDictUL.Add("населенныйпункт", "city");
            _fieldsDictUL.Add("улица", "street");
            _fieldsDictUL.Add("номердома", "build");
            _fieldsDictUL.Add("офис", "office");
            _fieldsDictUL.Add("номерконтактныхтелефонов,", "tel");
            _fieldsDictUL.Add("адресэлектроннойпочты<*>", "e_mail");
            _fieldsDictUL.Add("адрессайтавинтернете<*>", "e_addr");
            _fieldsDictUL.Add("размерзарегистрированногоуставногофонда", "ust_fond");
            _fieldsDictUL.Add("количествоработников", "kol_rab");
            _fieldsDictUL.Add("сведенияосчетах,открытыхвдругихбанках<*>", "scheta");
            _fieldsDictUL.Add("историяорганизации,положениенарынке(сведенияореорганизациях,измененияхвхарактередеятельности)", "history");
            _fieldsDictUL.Add("наименованиеаудиторскойорганизации(аудитора-индивидуальногопредпринимателя),проводившей(го)последнююаудиторскуюпроверку,атакжесведенияовозможностипредставленияаудиторскогозаключения", "audit_org");
            _fieldsDictUL.Add("обоснованиевысокойстепенириска(вслучаеееприсвоения)", "h_risk_exp");
            _fieldsDictUL.Add("решениеответственногодолжностноголицаодальнейшихдействияхвотношенииклиента,срокихвыполнения", "decision");
            _fieldsDictUL.Add("результатыдополнительныхмероприятий,проведенныхприидентификацииклиента", "results");
            _fieldsDictUL.Add("иныесведениядляформированияпредставленияоклиенте(егособственниках)ихарактереегодеятельности", "prochie");
            _fieldsDictUL.Add("датазаполнения(обновления,актуализации)анкеты", "dt_set");

            _fieldsDictIP = new Dictionary<string, string>();
            _fieldsDictIP.Add("фамилия", "lastname");
            _fieldsDictIP.Add("имя", "name");
            _fieldsDictIP.Add("отчество", "otch");
            _fieldsDictIP.Add("фамилиядоизменения(девичья)<*>", "prev_lastn");
            _fieldsDictIP.Add("гражданство", "state");
            _fieldsDictIP.Add("датарождения", "date_birth");
            _fieldsDictIP.Add("месторождения", "place_birth");
            _fieldsDictIP.Add("местожительства(регистрации)", "place_reg");
            _fieldsDictIP.Add("кемонвыдан", "reg_org_doc");
            _fieldsDictIP.Add("когдаонвыдан", "reg_dat_doc");
            _fieldsDictIP.Add("регистрационныйномер", "reg_num");
            _fieldsDictIP.Add("датарегистрации", "reg_dat");
            _fieldsDictIP.Add("наименованиерегистрирующегооргана", "reg_org");
            _fieldsDictIP.Add("личныйномер", "pn");
            _fieldsDictIP.Add("учетныйномерплательщика", "unp");
            _fieldsDictIP.Add("номердомашнеготелефона", "tel");
            _fieldsDictIP.Add("номермобильноготелефона", "tel_mob");
            _fieldsDictIP.Add("адресэлектроннойпочты<*>", "e_mail");
            _fieldsDictIP.Add("адрессайтавинтернете<*>", "e_addr");
            _fieldsDictIP.Add("сведенияосчетах,открытыхвдругихбанках<*>", "scheta");
            _fieldsDictIP.Add("обоснованиевысокойстепенириска(вслучаеееприсвоения)", "h_risk_exp");
            _fieldsDictIP.Add("решениеответственногодолжностноголицаодальнейшихдействияхвотношенииклиента,срокихвыполнения", "decision");
            _fieldsDictIP.Add("результатыдополнительныхмероприятий,проведенныхприидентификацииклиента", "results");
            _fieldsDictIP.Add("иныесведениядляформированияпредставленияоклиентеихарактереегодеятельности", "prochie");
            _fieldsDictIP.Add("датазаполнения(обновления,актуализации)анкеты", "dt_set");                                                               



            //FileInfo fInfo = new FileInfo(xlsFilePath);

            //if (!fInfo.Exists)
            //{
            //    throw new FileNotFoundException("The file was not found.", xlsFilePath);

            //}
            //else
            //{
            //    currentFileName = xlsFilePath;
            //    fileName = fInfo.Name;
            //}
            //currentFileName = xlsFilePath;

        }
        
        private bool unpCheck(String unp)
        {
            try
            {

            
            int sum18 = Convert.ToInt32(unp.Substring(0, 1))*29 + Convert.ToInt32(unp.Substring(1, 1))*23 +
                        Convert.ToInt32(unp.Substring(2, 1))*19 +
                        Convert.ToInt32(unp.Substring(3, 1))*17 + Convert.ToInt32(unp.Substring(4, 1))*13 +
                        Convert.ToInt32(unp.Substring(5, 1))*7 +
                        Convert.ToInt32(unp.Substring(6, 1))*5 + Convert.ToInt32(unp.Substring(7, 1))*3;
            int t = Convert.ToInt32(unp.Substring(1,1));
            String ts = unp.Substring(1,1);
            int k = sum18%11;
            if (k==10 || k!=Convert.ToInt32(unp.Substring(8,1)) || unp.Length!=9)
            {
                return false;
            }
        else
            {
                return true;
            }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Read()
        {
            
            int currentRowXls = 0;
            int currentColumnXls = 0;
            OleDbCommand selectCmd;
            OleDbDataReader dataReader;
            bool resault = true;
            //_excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            //                                "Data Source=" + currentFileName +
            //                                ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            cbd_anketsDataSet tmpMySqlDS = new cbd_anketsDataSet();
            testDataSet tmpTestDataSet=new testDataSet();
            testDataSetTableAdapters.bd_org_tTableAdapter bdOrgTTableAdapter = new testDataSetTableAdapters.bd_org_tTableAdapter();
            testDataSetTableAdapters.bd_ip_tTableAdapter bdIpTTableAdapter = new testDataSetTableAdapters.bd_ip_tTableAdapter();

                try
                {

 

                    // The connection is automatically closed when the
                    // code exits the using block.
                    DataTable tablesList = excelConnection.GetSchema("Tables");
                    //DataTable tmp = excelConnection.GetSchema("MetaDataCollections");
                    int indexCurrentTable = 0;
                    //DataTable tmp_bd_org_t;
                    //DataTable tmp_bd_org_t;
                    //prBarSheets.Minimum = 0;
                    //prBarSheets.Maximum = tablesList.Rows.Count;
                    //prBarSheets.Value = 0;
                    //prBarSheets.Step = 1;

                    foreach (DataRow currentRow in tablesList.Rows)
                    {
                        try
                        {
                            selectCmd = new
                                OleDbCommand("SELECT * FROM [" + currentRow["TABLE_NAME"].ToString() + "];",
                                             excelConnection);
                            dataReader = selectCmd.ExecuteReader();
                            
                            LogFile.Wrile2Log("Разбор листа " + currentRow["TABLE_NAME"]);
                            int typeAnkt = 0; //Тип анкеты
                            int j = 0;
                            int x = 0;
                            int y = 0;
                            bool tableFound = false;
                            currentRowXls = 0;
                            currentColumnXls = 0;
                            /// <summary>
                            /// Определение строки юрлиц
                            /// </summary>                           
                            DataRow tmpRowUl = tmpTestDataSet.bd_org_t.Newbd_org_tRow();
//tmpRowUl init-----------------------------------------------------------------------------------------------------------------
//Наполняем запись для данных анкеты юр. лица значениями по умолчанию, 
//кроме тех которые не должны быть пустыми                            
                            tmpRowUl["main"] = 0;
                            tmpRowUl["kod_fil"] = 0;
                            tmpRowUl["rezident"] = 0;
                            tmpRowUl["reg_num"] = "";
                            tmpRowUl["reg_dat"] = DateTime.FromBinary(0);
                            tmpRowUl["reg_org"] = "";
                            tmpRowUl["state"] = "";
                            tmpRowUl["region"] = "";
                            tmpRowUl["city"] = "";
                            tmpRowUl["street"] = "";
                            tmpRowUl["build"] = "";
                            tmpRowUl["office"] = "";
                            tmpRowUl["tel"] = "";
                            tmpRowUl["e_mail"] = "";
                            tmpRowUl["e_addr"] = "";
                            tmpRowUl["sved_uchr"] = 0;
                            tmpRowUl["ust_fond"] = "";
                            tmpRowUl["kol_rab"] = 0;
                            tmpRowUl["scheta"] = "";
                            tmpRowUl["sved_kontr"] = 0;
                            tmpRowUl["profit"] = "";
                            tmpRowUl["history"] = "";
                            tmpRowUl["audit_org"] = "";
                            tmpRowUl["sved_fil"] = 0;
                            tmpRowUl["sved_infl"] = 0;
                            tmpRowUl["risk_itog"] = 0;
                            tmpRowUl["risk_client"] = 0;
                            tmpRowUl["risk_oper"] = 0;
                            tmpRowUl["risk_geo"] = 0;
                            tmpRowUl["h_risk_exp"] = " ";
                            tmpRowUl["decision"] = " ";
                            tmpRowUl["results"] = " ";
                            tmpRowUl["category"] = 0;
                            tmpRowUl["prochie"] = " ";
                            tmpRowUl["red_user"] = "";
                            tmpRowUl["dt_set"] = DateTime.Now;
//tmpRowUl init end -----------------------------------------------------------------------------------------------------

                            DataRow tmpRowIp = tmpTestDataSet.bd_ip_t.Newbd_ip_tRow();

//tmpRowIp init-----------------------------------------------------------------------------------------------------------------
//Наполняем запись для данных анкеты юр. лица значениями по умолчанию, 
//кроме тех которые не должны быть пустыми
                            tmpRowIp["kod_fil"] = 0;
                            tmpRowIp["rezident"] = 0;
                            tmpRowIp["pn"] = "";
                            //tmpRowIp["lastname"] = "";
                            tmpRowIp["name"] = "";
                            tmpRowIp["otch"] = "";
                            tmpRowIp["prev_lastn"] = "";
                            tmpRowIp["state"] = "";
                            tmpRowIp["date_birth"] = DateTime.FromBinary(0);
                            tmpRowIp["place_birth"] = "";
                            tmpRowIp["place_reg"] = "";
                            tmpRowIp["kind_visa"] = 0;
                            tmpRowIp["type_visa"] = 0;
                            tmpRowIp["term_visa"] = DateTime.FromBinary(0);
                            tmpRowIp["vid_doc"] = 0;
                            tmpRowIp["seria"] = "";
                            tmpRowIp["num_doc"] = "";
                            tmpRowIp["reg_org_doc"] = " ";
                            tmpRowIp["reg_dat_doc"] = DateTime.FromBinary(0);
                            tmpRowIp["reg_num"] = "";
                            tmpRowIp["reg_dat"] = DateTime.FromBinary(0);
                            tmpRowIp["reg_org"] = " ";
                            tmpRowIp["tel"] = "";
                            tmpRowIp["tel_mob"] = "";
                            tmpRowIp["e_mail"] = "";
                            tmpRowIp["e_addr"] = "";
                            tmpRowIp["scheta"] = " ";
                            tmpRowIp["profit"] = " ";
                            tmpRowIp["sved_infl"] = 0;
                            tmpRowIp["risk_itog"] = 0;
                            tmpRowIp["risk_client"] = 0;
                            tmpRowIp["risk_oper"] = 0;
                            tmpRowIp["risk_geo"] = 0;
                            tmpRowIp["h_risk_exp"] = " ";
                            tmpRowIp["decision"] = " ";
                            tmpRowIp["results"] = " ";
                            tmpRowIp["category"] = 0;
                            tmpRowIp["prochie"] = " ";
                            tmpRowIp["red_user"] = "";
                            tmpRowIp["dt_set"] = DateTime.Now;
//tmpRowIp init-----------------------------------------------------------------------------------------------------------------
                           
                            // Читаем текущий лист
                            while (dataReader.Read())
                            {
                                try
                                {

                                    currentRowXls++;

                                    //Определяем тип анкеты
                                    for (int i = 0; (i < dataReader.FieldCount) && (typeAnkt == 0); i++)
                                    {
                                        currentColumnXls = i;
                                        if (!dataReader.IsDBNull(i)) //если не пустая ячейка
                                        {
                                            //dataReader.
                                            String strCell = String.Concat(dataReader.GetValue(i));
                                            if (strCell.Length > 0)
                                            {
                                                if (strCell.ToLower().IndexOf("организации") > 0)
                                                {
                                                    typeAnkt = 1; //Юр. лица

                                                }
                                                if (strCell.ToLower().IndexOf("предпринимателя") > 0)
                                                {
                                                    typeAnkt = 2; //Индивидуальный предприниматель

                                                }
                                            }
                                        }
                                    }

                                    if (typeAnkt == 1)
                                    {

                                        for (int i = 0; (i < dataReader.FieldCount) && (!tableFound); i++)
                                        {
                                            currentColumnXls = i;
                                            if (!dataReader.IsDBNull(i)) //если не пустая ячейка
                                            {
                                                //Object objCell = dataReader.GetValue(i);
                                                //if (objCell.GetType()!=)
                                                //{

                                                //}
                                                String strCell = String.Concat(dataReader.GetValue(i));

                                                if (_fieldsDictUL.ContainsKey(strCell.ToLower().Replace(" ", "")))
                                                {
                                                    x = i;
                                                    y = j;
                                                    tableFound = true;
                                                    LogFile.Wrile2Log("На листе " + currentRow["TABLE_NAME"] +
                                                                      " обнаружена анкета организации");
                                                    //tmpRowUL[_fieldsDictUL[strCell.ToLower().Replace(" ", "")]] = dataReader.GetValue(x+1);
                                                }


                                            }
                                        }
                                        if (!dataReader.IsDBNull(x) && tableFound)
                                        {
                                            if (
                                                _fieldsDictUL.ContainsKey(String.Concat(dataReader.GetValue(x)).ToLower().Replace(
                                                    " ", "")))
                                            {
                                                try
                                                {
                                                    if (dataReader.IsDBNull(x+1))
                                                    {
                                                        throw new ArgumentOutOfRangeException(
                                                            _fieldsDictUL[
                                                                String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                                ], dataReader.GetValue(x + 1), "Недопустимое значение");
                                                    }

                                                    tmpRowUl[
                                                        _fieldsDictUL[String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                            ]]
                                                        = dataReader.GetValue(x + 1);
                                                    if (
                                                        _fieldsDictUL[String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                            ] ==
                                                        "unp")
                                                    {
                                                        LogFile.Wrile2Log("Контроль УНП " +
                                                                          unpCheck(
                                                                              String.Concat(dataReader.GetValue(x+1)).Replace(" ",
                                                                                                                  "")));
                                                        cbd_anketsDataSetTableAdapters.QueriesTableAdapter tmpAdp_cdb =
                                                            new cbd_anketsDataSetTableAdapters.QueriesTableAdapter();
                                                        String tmpR =
                                                            tmpAdp_cdb.count_unp_bd_org(
                                                                String.Concat(dataReader.GetValue(x+1)).Replace(" ", ""))
                                                                .
                                                                ToString();
                                                        if (tmpR != "0")
                                                        {
                                                            //LogFile.Wrile2Log("Ошибка. В таблице bd_org такой УНП " +
                                                            //                  dataReader.GetString(x + 1).Replace(" ", "") +
                                                            //                  " уже присутствует.");
                                                            throw new ArgumentOutOfRangeException(
                                                                _fieldsDictUL[
                                                                    String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                                    ], String.Concat(dataReader.GetValue(x+1)),
                                                                "Дублирование УНП в основной БД");

                                                        }
                                                        testDataSetTableAdapters.QueriesTableAdapter tmpAdp_test =
                                                            new testDataSetTableAdapters.QueriesTableAdapter();
                                                        tmpR =
                                                            tmpAdp_test.count_unp_bd_org_t(
                                                                String.Concat(dataReader.GetValue(x+1)).Replace(" ",
                                                                                                    "")).
                                                                ToString();
                                                        if (tmpR != "0")
                                                        {
                                                            //LogFile.Wrile2Log("Ошибка. В таблице bd_org_t такой УНП " +
                                                            //                  dataReader.GetString(x + 1).Replace(" ", "") +
                                                            //                  " уже присутствует.");
                                                            throw new ArgumentOutOfRangeException(
                                                                _fieldsDictUL[
                                                                    String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                                    ], String.Concat(dataReader.GetValue(x+1)),
                                                                "Дублирование УНП в транизитной БД");

                                                        }


                                                    }
                                                }
                                                catch (ArgumentOutOfRangeException outOfRangeException)
                                                {
                                                    LogFile.Wrile2Log(outOfRangeException.Message);
                                                    if (outOfRangeException.ParamName == "unp" ||
                                                        outOfRangeException.ParamName == "name")
                                                        throw new ArgumentOutOfRangeException("Лист",
                                                                                              currentRow["TABLE_NAME"],
                                                                                              "Невозможно загрузить анкету");

                                                }
                                                catch (ArgumentException argumentException)
                                                {
                                                    LogFile.Wrile2Log(argumentException.Message);
                                                }
                                                catch (Exception exp)
                                                {
                                                    LogFile.Wrile2Log(exp.Message + " Строка - " + currentRowXls +
                                                                      "\t Столбец - " + currentColumnXls);
                                                    throw;
                                                }


                                            }
                                        }



                                        y++;

                                    }
                                    //cbd_ankets
                                    if (typeAnkt == 2) //Разбор анкет ИП
                                    {
                                        for (int i = 0; (i < dataReader.FieldCount) && (!tableFound); i++)
                                        {
                                            currentColumnXls = i;
                                            if (!dataReader.IsDBNull(i)) //если не пустая ячейка
                                            {
                                                String strCell = String.Concat(dataReader.GetValue(i));

                                                if (_fieldsDictIP.ContainsKey(strCell.ToLower().Replace(" ", "")))
                                                {
                                                    x = i;
                                                    tableFound = true;
                                                    y = j;
                                                    LogFile.Wrile2Log("На листе " + currentRow["TABLE_NAME"] +
                                                                      " обнаружена анкета индивидуального предпринимателя");
                                                }

                                            }
                                        }
                                        if (!dataReader.IsDBNull(x) && tableFound)
                                        {

                                            if (
                                                _fieldsDictIP.ContainsKey(String.Concat(dataReader.GetValue(x)).ToLower().Replace(
                                                    " ", "")))
                                            {
                                                try
                                                {
                                                    if (dataReader.IsDBNull(x+1))
                                                    {
                                                        throw new ArgumentOutOfRangeException(
                                                            _fieldsDictIP[
                                                               String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                                ], dataReader.GetValue(x + 1), "Недопустимое значение");
                                                    }
                                                    tmpRowIp[
                                                        _fieldsDictIP[String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                            ]]
                                                        = dataReader.GetValue(x + 1);
                                                    if (
                                                        _fieldsDictIP[String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                            ] ==
                                                        "unp")
                                                    {
                                                        LogFile.Wrile2Log("Контроль УНП " +
                                                                          unpCheck(
                                                                              String.Concat(dataReader.GetValue(x+1)).Replace(" ",
                                                                                                                  "")));
                                                        cbd_anketsDataSetTableAdapters.QueriesTableAdapter tmpAdp_cdb =
                                                            new cbd_anketsDataSetTableAdapters.QueriesTableAdapter();
                                                        String tmpR =
                                                            tmpAdp_cdb.count_unp_bd_ip(
                                                                String.Concat(dataReader.GetValue(x+1)).Replace(" ", ""))
                                                                .
                                                                ToString();
                                                        if (tmpR != "0")
                                                        {
                                                            //LogFile.Wrile2Log("Ошибка. В таблице bd_ip такой УНП " +
                                                            //                  dataReader.GetString(x + 1).Replace(" ", "") +
                                                            //                  " уже присутствует.");
                                                            throw new ArgumentOutOfRangeException(
                                                                _fieldsDictIP[
                                                                    String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                                    ], String.Concat(dataReader.GetValue(x+1)),
                                                                "Дублирование УНП в основной БД");
                                                        }
                                                        testDataSetTableAdapters.QueriesTableAdapter tmpAdp_test =
                                                            new testDataSetTableAdapters.QueriesTableAdapter();

                                                        tmpR =
                                                            tmpAdp_test.count_unp_bd_ip_t(
                                                                String.Concat(dataReader.GetValue(x+1)).Replace(" ",
                                                                                                    "")).
                                                                ToString();
                                                        if (tmpR != "0")
                                                        {
                                                            //LogFile.Wrile2Log("Ошибка. В таблице bd_ip_t такой УНП " +
                                                            //                  dataReader.GetString(x + 1).Replace(" ", "") +
                                                            //                  " уже присутствует.");
                                                            throw new ArgumentOutOfRangeException(
                                                                _fieldsDictIP[
                                                                    String.Concat(dataReader.GetValue(x)).ToLower().Replace(" ", "")
                                                                    ], String.Concat(dataReader.GetValue(x+1)),
                                                                "Дублирование УНП в транизитной БД");


                                                        }
                                                    }
                                                }
                                                catch (ArgumentOutOfRangeException outOfRangeException)
                                                {
                                                    LogFile.Wrile2Log(outOfRangeException.Message);
                                                    if (outOfRangeException.ParamName == "unp")
                                                        throw new ArgumentOutOfRangeException("Лист",
                                                                                              currentRow["TABLE_NAME"],
                                                                                              "Невозможно загрузить анкету");
                                                }
                                                catch (ArgumentException argumentException)
                                                {
                                                    LogFile.Wrile2Log(argumentException.Message);
                                                }
                                                catch (Exception exp)
                                                {
                                                    LogFile.Wrile2Log(exp.Message + " Строка - " + currentRowXls +
                                                                      "\t Столбец - " + currentColumnXls);
                                                    throw;
                                                }

                                            }
                                        }



                                        y++;

                                    }

                                    j++;
                                }
                                catch(Exception)
                                {
                                    dataReader.Close();
                                    dataReader.Dispose();
                                    selectCmd.Cancel();
                                    selectCmd.Dispose();
                                    throw;
                                }

                            }
                            dataReader.Close();
                            dataReader.Dispose();

                            selectCmd.Cancel();
                            selectCmd.Dispose();

                            indexCurrentTable++;
                            if (typeAnkt == 1 && tableFound && tmpRowUl["name"].ToString().Length>1)
                            {
                                
                                tmpRowUl["login"] = global::Excel2Ankets.Properties.Settings.Default.login;
                                tmpRowUl["file_name"] = currentFileName;
                                tmpRowUl["sheet_name"] = currentRow["TABLE_NAME"].ToString();
                                tmpRowUl["mfo"] = mfo;
                                tmpRowUl["pack_number"] = porc;
                                tmpTestDataSet.bd_org_t.Rows.Add(tmpRowUl);
                                bdOrgTTableAdapter.Update(tmpTestDataSet.bd_org_t);
                                tmpTestDataSet.AcceptChanges();
                                LogFile.Wrile2Log("Анкета организации УНП " + tmpRowUl["unp"] + " из листа " +
                                                  currentRow["TABLE_NAME"] + " файла " + currentFileName + " загружена");
                            }
                            if (typeAnkt == 2 && tableFound && tmpRowIp["lastname"].ToString().Length>1)
                            {
                                
                                tmpRowIp["login"] = "Excel2Ankets";
                                tmpRowIp["file_name"] = currentFileName;
                                tmpRowIp["sheet_name"] = currentRow["TABLE_NAME"].ToString();
                                tmpRowIp["mfo"] = mfo;
                                tmpRowIp["pack_number"] = porc;
                                tmpTestDataSet.bd_ip_t.Rows.Add(tmpRowIp);
                                bdIpTTableAdapter.Update(tmpTestDataSet.bd_ip_t);
                                tmpTestDataSet.AcceptChanges();
                                LogFile.Wrile2Log("Анкета индивидуального предпринимателя УНП " + tmpRowIp["unp"] +
                                                  " из листа " + currentRow["TABLE_NAME"] + " файла " + currentFileName +
                                                  " загружена");
                            }
                            if (typeAnkt == 2 && tableFound && tmpRowIp["lastname"].ToString().Length <= 1)
                            {
                                throw new ArgumentOutOfRangeException("Лист ",
                                                                      currentRow["TABLE_NAME"],
                                                                      "В анкете не найдена фамилия индивидуального предпринимателя");
                            }
                            if (typeAnkt == 1 && tableFound && tmpRowUl["name"].ToString().Length <= 1)
                            {
                                throw new ArgumentOutOfRangeException("Лист ",
                                                                      currentRow["TABLE_NAME"],
                                                                      "В анкете не найдено наименование организации");
                            }

                            if(typeAnkt==0 || !tableFound)
                                throw new ArgumentOutOfRangeException("Лист ",
                                                                      currentRow["TABLE_NAME"],
                                                                      "Анкета не найдена ");
                            //prBarSheets.PerformStep();

                            //tmpMySqlDS.bd_org.Select()
                            //foreach (currentRowOfTable in dataReader)
                            //{

                            //}

                        }
                            catch(ArgumentOutOfRangeException ofRangeException)
                            {
                                LogFile.Wrile2Log(ofRangeException.Message);
                                resault = false;
                            }
                        catch(NoNullAllowedException nullAllowedException)
                        {
                                LogFile.Wrile2Log(nullAllowedException.Message);
                                resault = false;

                        }
                           



                        catch (Exception ex)
                        {


                            LogFile.Wrile2Log(ex.Message + " Строка - " + currentRowXls + "\t Столбец - " +
                                              currentColumnXls);
                            throw;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(currentFileName);
                    LogFile.Wrile2Log(ex.Message);
                    resault = false;
                }
          
            return resault;
        }
    }
}
