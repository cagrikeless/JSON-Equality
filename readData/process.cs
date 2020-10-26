using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Oracle;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using OracleInternal.SqlAndPlsqlParser;

namespace readData
{
    public class process
    {
        OracleConnection con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=ppm.optiim.com)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=demo)));User Id=HB_PPM_POC;Password=ppm;Pooling=true;Min Pool Size=1;Connection Lifetime=180;Max Pool Size=100;Incr Pool Size=5");
        OracleCommand cmd;
        List<forTable1> table1 = new List<forTable1>();
        List<forTable2> table2 = new List<forTable2>();

        public List<forTable1> putInfo()
        {
            string query = "SELECT * from CK_USERTABLE1";
            con.Open();
            cmd = new OracleCommand(query, con);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                forTable1 tb1 = new forTable1();
                tb1.userIDS = Convert.ToInt32(reader[0]);
                tb1.userNames = reader[1].ToString();
                tb1.passwords = reader[2].ToString();
                tb1.Addreses = reader[3].ToString();
                tb1.Descriptions = reader[4].ToString();
                tb1.phoneNumber = reader[5].ToString();
                tb1.Departmans = reader[6].ToString();
                tb1.Names = reader[7].ToString();
                tb1.surnames = reader[8].ToString();

                table1.Add(tb1);
            }
            con.Close();
            return table1;
        }
        public List<forTable2> putInfo2()
        {
            string query = "SELECT * from CK_USERTABLE2";
            con.Open();
            cmd = new OracleCommand(query, con);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                forTable2 tb2 = new forTable2();
                tb2.userIDS = Convert.ToInt32(dr[0]);
                tb2.userNames = dr[1].ToString();
                tb2.passwords = dr[2].ToString();
                tb2.Addreses = dr[3].ToString();
                tb2.Descriptions = dr[4].ToString();
                tb2.phoneNumber = dr[5].ToString();
                tb2.Departmans = dr[6].ToString();
                tb2.Names = dr[7].ToString();
                tb2.surnames = dr[8].ToString();

                table2.Add(tb2);
            }
            con.Close();
            return table2;
        }
        public void ifmethods()
        {
            foreach (var elements in table1)
            {
                var docs = elements;
                foreach (var elements1 in table2)
                {
                    var tble2 = elements1;
                    if ((tble2.userID != docs.userID)
                        && (tble2.Username != docs.Username) 
                        && (tble2.Password != docs.Password) 
                        && (tble2.Address != docs.Address) 
                        && (tble2.Description != docs.Description) 
                        && (tble2.PhoneN != docs.PhoneN) 
                        && (tble2.Department != docs.Department)
                        && (tble2.Name != docs.Name)
                        && (tble2.Surname != docs.Surname))
                    {
                        con.Open();
                        var queryString = "Insert Into CK_USERTABLE1 (USERID,USERNAME,PASSWORD,ADRESS,DESCRIPTION,PHONE,DEPARTMENT,NAME,SURNAME) values ('"+ tble2.userID + tble2.Username + tble2.Password + tble2.Address + tble2.Description + tble2.PhoneN + tble2.Department + tble2.Name + tble2.Surname +"')";
                        cmd.Dispose();
                        cmd = new OracleCommand(queryString,con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        if ((tble2.userID == docs.userID) 
                            && (tble2.Username == docs.Username) 
                            && (tble2.Password == docs.Password)
                            && (tble2.Address == docs.Address)
                            && (tble2.Description == docs.Description)
                            && (tble2.PhoneN == docs.PhoneN)
                            && (tble2.Department == docs.Department)
                            && (tble2.Name == docs.Name)
                            && (tble2.Surname == docs.Surname)){ }
                        else
                        {
                            con.Open();
                            var queryString1 = "UPDATE CK_USERTABLE1 SET USERID='"+ Convert.ToInt32(tble2.userID) +"',USERNAME='"+ tble2.Username +"',PASSWORD='" + tble2.Password +"',ADRESS='" + tble2.Address +"',DESCRIPTION='" + tble2.Description +"',PHONE='" + tble2.PhoneN +"',DEPARTMENT='" + tble2.Department +"',NAME='" + tble2.Name +"',SURNAME='" + tble2.Surname +"'WHERE USERID='"+ tble2.userID +"'";
                            cmd.Dispose();
                            cmd = new OracleCommand(queryString1,con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
        }

        
    }
}
