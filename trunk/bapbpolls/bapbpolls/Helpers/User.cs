using System;
using System.Collections.Generic;

namespace admin
{
    public class User
    {
        public User()
        {
            dictionary_arms = new Dictionary<Int32, GrantArm>();
        }

        public class GrantArm
        {
            public Int32 CodObl;
            public Int32 CodMfo;
            public Int32 CodRKC;
            public Dictionary<Int32, Char> ref_func;
            public GrantArm(int obl, int mfo, int rkc)
            {
                CodObl = obl;
                CodMfo = mfo;
                CodRKC = rkc;
                ref_func = new Dictionary<Int32,Char>();
            }
        }

        public Dictionary<Int32, GrantArm> dictionary_arms;

        public Int32 Id_user { get; set; }

        public Int32 Edit_user { get; set; }

        public Int32 CodObl { get; set; }

        public Int32 CodMfo { get; set; }

        public Int32 CodRKC { get; set; }

        public Int32 ID_depart { get; set; }

        public String Login { get; set; }

        public String N_depart { get; set; }

        public String Password { get; set; }

        public String Surname { get; set; }

        public String FName { get; set; }

        public String LName { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        public String Info { get; set; }

        public DateTime BegExp { get; set; }

        public DateTime EndExp { get; set; }

        public DateTime DT_Create { get; set; }

        public DateTime DT_Modify { get; set; }

        public List<Int32> User_Arms { get; set; }

        public Int32 CodObl_admin { get; set; }

        public Int32 CodMfo_admin { get; set; }

        public Int32 CodRKC_admin { get; set; }

        public Int32 CodObl_broker { get; set; }

        public Int32 CodMfo_broker { get; set; }

        public Int32 CodRKC_broker { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsBroker { get; set; }

        public Int32 Id_CManager { get; set; }
    }
}