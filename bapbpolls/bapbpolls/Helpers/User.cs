using System;
using System.Collections.Generic;

namespace admin
{
    public class User
    {
        private Int32 id_user;
        private String login;
        private Int32 codObl;
        private Int32 codMfo;
        private Int32 codRKC;
        private Int32 privilegesCodObl;
        private Int32 privilegesCodMfo;
        private Int32 privilegesCodRKC;


        private Int32 id_depart;
        private String name_depart;
        private String surname;
        private String fname;
        private String lname;
        private String phone;
        private String email;
        private String info;
        private DateTime begExp;
        private DateTime endExp;
        private Int32 edit_user;
        private DateTime dt_create;
        private DateTime dt_modify;
        private String password;
        private List<Int32> user_arms;
        private Int32 codObl_admin;
        private Int32 codMfo_admin;
        private Int32 codRKC_admin;
        private Int32 codObl_broker;
        private Int32 codMfo_broker;
        private Int32 codRKC_broker;
        private bool is_admin;
        private bool is_broker;
        private Int32 id_cmanager;
        public User()
        {
            // do nothing;
        }
        public Int32 Id_user
        {
            get { return id_user; }
            set { id_user = value;}
        }
        public Int32 Edit_user
        {
            get { return edit_user; }
            set { edit_user = value; }
        }
        public Int32 CodObl
        {
            get { return codObl; }
            set { codObl = value; }
        }
        public Int32 CodMfo
        {
            get { return codMfo; }
            set { codMfo = value; }
        }

        public Int32 CodRKC
        {
            get { return codRKC; }
            set { codRKC = value; }
        }

        public Int32 ID_depart
        {
            get { return id_depart; }
            set { id_depart = value; }
        }
        public String Login
        {
            get { return login; }
            set { login = value; }
        }

        public String N_depart
        {
            get { return name_depart; }
            set { name_depart = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public String FName
        {
            get { return fname; }
            set { fname = value; }
        }
        public String LName
        {
            get { return lname; }
            set { lname = value; }
        }

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String Info
        {
            get { return info; }
            set { info = value; }
        }
        public DateTime BegExp
        {
            get { return begExp; }
            set {begExp = value;}
        }
        public DateTime EndExp
        {
            get { return endExp; }
            set { endExp = value; }
        }
        public DateTime DT_Create
        {
            get { return dt_create; }
            set { dt_create = value; }
        }
        public DateTime DT_Modify
        {
            get { return dt_modify; }
            set { dt_modify = value; }
        }
        public List<Int32> User_Arms
        {
            get { return user_arms; }
            set { user_arms = value; }
        }
        public Int32 CodObl_admin
        {
            get { return codObl_admin; }
            set { codObl_admin = value; }
        }
        public Int32 CodMfo_admin
        {
            get { return codMfo_admin; }
            set { codMfo_admin = value; }
        }

        public Int32 CodRKC_admin
        {
            get { return codRKC_admin; }
            set { codRKC_admin = value; }
        }
        public Int32 CodObl_broker
        {
            get { return codObl_broker; }
            set { codObl_broker = value; }
        }
        public Int32 CodMfo_broker
        {
            get { return codMfo_broker; }
            set { codMfo_broker = value; }
        }

        public Int32 CodRKC_broker
        {
            get { return codRKC_broker; }
            set { codRKC_broker = value; }
        }
        public bool IsAdmin
        {
            get { return is_admin; }
            set {is_admin = value; }
        }
        public bool IsBroker
        {
            get { return is_broker; }
            set { is_broker = value; }
        }

        public Int32 Id_CManager
        {
            get { return id_cmanager;}
            set { id_cmanager = value; }
        }

        public Int32 PrivilegesCodObl { get; set; }
        public Int32 PrivilegesCodMfo { get; set; }
        public Int32 PrivilegesCodRKC { get; set; }

    }
}