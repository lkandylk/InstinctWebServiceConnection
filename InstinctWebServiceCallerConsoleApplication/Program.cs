using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstinctWebServiceConnection;
using CommonServiceLogHelper;

namespace InstinctWebServiceCallerConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.WriteInfoLog("Program Start");

            ConnectToInstinctBySingleLineString();

            LogHelper.WriteInfoLog("Program Finish");
        }

        static void ConnectToInstinctBySingleLineString()
        {
            string strInput = "SPB|CN||1000177264|05/05/2011|27/05/2011|CARD||9999||||||138|||NNNNNN|0||LT|N|B|B|SH|DS99|POST|0|C999||Y|1860|||||||||A|999999850727464X|06||PBOC测试|LU XIAN||F|27/07/1985||||||201306|2138784978|13918849999|上海环湖机械制造|上海市浦东新区|南果公路166号||||200120|2150534510|027|H||S|0|N@N||W|W|4|0|办公室||||3|M|7|551|G||PBOC测试|13918606735|||200000|21|R|||I|AZ99B738|0|||||||||2|||||||N|R||||PBOC测试|||200000|21|15800985325||M||0||||||P||||||111111|||||||111111||||0|0|0|0||||U|||||0|||||||||||||||O|||NNNN|文员|||21||||||||||2|||||||1||Y||||||0|0||LU/XIAN/|0|70|0|0|0|0|0|0|0|0|W||||||||||||||||||||||";
            LogHelper.WriteInfoLog("Request:" + strInput);

            InstinctWSConnection IWSConnection = new InstinctWSConnection();
            string strOutput = IWSConnection.InstinctFraudCheckBySingleLineString(strInput);

            LogHelper.WriteInfoLog("Instinct response:" + strOutput);
            Console.WriteLine(strOutput);
                       
            Console.ReadLine();
        }

        public void ConnectToInstinctByMultiLineFile()
        {

        }


    }
}
