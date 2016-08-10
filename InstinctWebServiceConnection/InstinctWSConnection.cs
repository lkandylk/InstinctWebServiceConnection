using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLogHelper;

namespace InstinctWebServiceConnection
{
    public class InstinctWSConnection
    {
        #region Constructor
        public InstinctWSConnection()
        {

        }
        #endregion

        #region Fields

        #endregion

        public string InstinctFraudCheckBySingleLineString(string strInput)
        {
            InstinctFraudCheckWebService.OnlineFraudCheckSoapClient WebServiceInstinct = new InstinctFraudCheckWebService.OnlineFraudCheckSoapClient();
            try
            {
                LogHelper.WriteInfoLog("Connecting to Instinct");
                return WebServiceInstinct.InstinctFraudCheck_String(strInput);
            }
            catch(Exception ex)
            {
                LogHelper.WriteErrorLog(typeof(InstinctWSConnection), ex.Message);
                return ex.Message;
            }
        }

        public string InstinctFraudCheckByFile(string strFilePath)
        {
            return null;
        }

        public string InstinctFraudCheckByXMLString()
        {
            return null;
        }
    }

 


}
