using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oracle;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using OracleInternal.SqlAndPlsqlParser;


namespace readData
{
    public class jsonEqualityCheck
    {
        process processclass = new process();
        public void deserializeJson()
        {
            string json = JsonConvert.SerializeObject(processclass.tb2);
            forTable2 deserializetable = JsonConvert.DeserializeObject<forTable2>(json);

            string jsonAnother = JsonConvert.SerializeObject(processclass.tb1);
            forTable1 deserializetableAnother = JsonConvert.DeserializeObject<forTable1>(jsonAnother);
            if (string.IsNullOrEmpty(json) && string.IsNullOrEmpty(jsonAnother))
            {

                throw new ArgumentException($"'{nameof(json)}' cannot be null or empty", nameof(json));
                throw new ArgumentException($"'{nameof(jsonAnother)}' cannot be null or empty", nameof(jsonAnother));

            }
            else
            {
                    foreach (forTable1 elements in processclass.table1)
                    {
                        var docs = elements;
                        foreach (forTable2 elements1 in processclass.table2)
                        {
                            var tble2 = elements1;
                            if (json != jsonAnother)
                            {

                                try
                                {
                                    List<string> insertList = new List<string>();
                                    insertList.Add(processclass.tb2.userID.ToString());
                                    insertList.Add(processclass.tb2.Password);
                                    insertList.Add(processclass.tb2.Address);
                                    insertList.Add(processclass.tb2.Description);
                                    insertList.Add(processclass.tb2.PhoneN);
                                    insertList.Add(processclass.tb2.Department);
                                    insertList.Add(processclass.tb2.Name);
                                    insertList.Add(processclass.tb2.Surname);

                                    foreach (var inserts in insertList)
                                    {
                                    processclass.con.Open();
                                        var qString = "INSERT INTO CK_USERTABLE1(USERID,USERNAME,PASSWORD,ADRESS,DESCRIPTION,PHONE,DEPARTMENT,NAME,SURNAME) VALUES ('" + inserts[0] + "','" + inserts[1] + "','" + inserts[2] + "','" + inserts[3] + "','" + inserts[4] + "','" + inserts[5] + "','" + inserts[6] + "','" + inserts[7] + "','" + inserts[8] + "')";
                                    processclass.cmd = new OracleCommand(qString, processclass.con);
                                    processclass.cmd.ExecuteNonQuery();
                                    processclass.cmd.Dispose();
                                    processclass.con.Close();
                                    }
                                    //"Insert Into CK_USERTABLE1 (USERID,USERNAME,PASSWORD,ADRESS,DESCRIPTION,PHONE,DEPARTMENT,NAME,SURNAME) values ('" + tble2.userID + tble2.Username + tble2.Password + tble2.Address + tble2.Description + tble2.PhoneN + tble2.Department + tble2.Name + tble2.Surname + "')";
                                    //con.Open();
                                    //var queryString = "INSERT INTO CK_USERTABLE1(USERID,USERNAME,PASSWORD,ADRESS,DESCRIPTION,PHONE,DEPARTMENT,NAME,SURNAME) VALUES ('" + tble2.userID + "','" + tble2.Username + "','" + tble2.Password + "','" + tble2.Address + "','" + tble2.Description + "','" + tble2.PhoneN + "','" + tble2.Department + "','" + tble2.Name + "','" + tble2.Surname + "') ";
                                    //cmd = new OracleCommand(queryString, con);
                                    //cmd.ExecuteNonQuery();
                                    //cmd.Dispose();
                                    //con.Close();
                                }
                                catch (Exception ex)
                                { Console.WriteLine(ex.ToString()); break; }


                            }
                            else
                            {
                                if (json == jsonAnother)
                                { }
                                else
                                {
                                    try
                                    {
                                        List<string> updateList = new List<string>();
                                        updateList.Add(processclass.tb2.userID.ToString());
                                        updateList.Add(processclass.tb2.Password);
                                        updateList.Add(processclass.tb2.Address);
                                        updateList.Add(processclass.tb2.Description);
                                        updateList.Add(processclass.tb2.PhoneN);
                                        updateList.Add(processclass.tb2.Department);
                                        updateList.Add(processclass.tb2.Name);
                                        updateList.Add(processclass.tb2.Surname);

                                        foreach
                                            (var updates in updateList)
                                        {
                                        processclass.con.Open();
                                            var qString = "UPDATE CK_USERTABLE1 SET USERID='" + Convert.ToInt32(updates[0]) + "',USERNAME='" + updates[1] + "',PASSWORD='" + updates[2] + "',ADRESS='" + updates[3] + "',DESCRIPTION='" + updates[4] + "',PHONE='" + updates[5] + "',DEPARTMENT='" + updates[6] + "',NAME='" + updates[7] + "',SURNAME='" + updates[8] + "'";
                                        processclass.cmd = new OracleCommand(qString, processclass.con);
                                        processclass.cmd.ExecuteNonQuery();
                                        processclass.cmd.Dispose();
                                        processclass.con.Close();
                                        processclass.con.Close();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.ToString());
                                        Console.ReadLine();
                                        break;
                                    }

                                    //con.Open();
                                    //var queryString1 = "UPDATE CK_USERTABLE1 SET USERID='" + Convert.ToInt32(tble2.userID) + "',USERNAME='" + tble2.Username + "',PASSWORD='" + tble2.Password + "',ADRESS='" + tble2.Address + "',DESCRIPTION='" + tble2.Description + "',PHONE='" + tble2.PhoneN + "',DEPARTMENT='" + tble2.Department + "',NAME='" + tble2.Name + "',SURNAME='" + tble2.Surname + "'WHERE USERID='" + tble2.userID + "'";
                                    //cmd = new OracleCommand(queryString1, con);
                                    //cmd.ExecuteNonQuery();
                                    //cmd.Dispose();
                                    //con.Close();
                                }
                            }
                        }
                    }
                }
            }
        }
}
