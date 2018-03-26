using Sand.Security.Cryptography;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IQVL.DataLayer
{
   public class ClsUtility
    {
      
            private static int Pkey;

            public static Hashtable theParams = new Hashtable();

            public enum ObjectEnum
            {
                DataSet, DataTable, DataRow, ExecuteNonQuery
            }

            public static void Init_Hashtable()
            {
                theParams.Clear();
                Pkey = 0;
            }

            public static string SDate = "mdy";

            public static void AddParameters(string FieldName, SqlDbType FieldType, string FieldValue)
            {
                Pkey = Pkey + 1;
                theParams.Add(Pkey, FieldName);
                Pkey = Pkey + 1;
                theParams.Add(Pkey, FieldType);
                Pkey = Pkey + 1;
                theParams.Add(Pkey, FieldValue);
            }
            public static void AddParameters(string FieldName, SqlDbType FieldType, int FieldValue)
            {
                Pkey = Pkey + 1;
                theParams.Add(Pkey, FieldName);
                Pkey = Pkey + 1;
                theParams.Add(Pkey, FieldType);
                Pkey = Pkey + 1;
                theParams.Add(Pkey, FieldValue);
            }

            public static string Encrypt(string Parameter)
            {
                Encryptor Encry = new Encryptor(EncryptionAlgorithm.TripleDes);
                Encry.IV = Encoding.ASCII.GetBytes("t3ilc0m3");
                return Encry.Encrypt(Parameter, "3wmotherwdrtybnio12ewq23");
            }

            public static string Decrypt(string Parameter)
            {
                Decryptor Decry = new Decryptor(EncryptionAlgorithm.TripleDes);
                Decry.IV = Encoding.ASCII.GetBytes("t3ilc0m3");
                return Decry.Decrypt(Parameter, "3wmotherwdrtybnio12ewq23");
            }

            public static string GetSHA1Hash(string encode)
            {
                ASCIIEncoding UE = new ASCIIEncoding();
                byte[] HashValue, MessageBytes = UE.GetBytes(encode);
                SHA1Managed SHhash = new SHA1Managed();
                string strHex = "";
                HashValue = SHhash.ComputeHash(MessageBytes);
                foreach (byte b in HashValue)
                {
                    strHex += String.Format("{0:x2}", b);
                }
                return strHex;
            }


        }
    }

