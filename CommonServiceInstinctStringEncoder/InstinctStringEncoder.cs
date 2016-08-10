using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CommonServiceInstinctStringEncoder
{
    public class InstinctStringEncoder
    {
        static InstinctStringEncoder()
        {

        }

        /// <summary>
        /// Read .txt file which contains multi instinct format lines, return single line collection.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region 
        public static ICollection<string> GetInstinctStringFromFile(string strFilePath)
        {
            //ICollection<string> cstrInstinct = System.Collections.ICollection<string>;

            //StreamReader sr = new StreamReader(strFilePath);
            //string strLine;
            //while((strLine = sr.ReadLine()) != null)
            //{
            //    cstrInstinct.Add(strLine);
            //}
            return null;
        }
        #endregion
    }
}
