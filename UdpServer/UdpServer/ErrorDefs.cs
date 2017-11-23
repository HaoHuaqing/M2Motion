using System;
using System.Collections.Generic;
using System.Text;
using MccDaq;

namespace ErrorDefs
{

    public class clsErrorDefs
    {
        public static MccDaq.ErrorReporting ReportError;
        public static MccDaq.ErrorHandling HandleError;
        public static bool GeneralError;

        public static void DisplayError(MccDaq.ErrorInfo ErrCode)
        {
            System.Windows.Forms.MessageBox.Show
                ("Cannot run sample program. Error reported: " +
                ErrCode.Message, "Unexpected Universal Library Error", 
                System.Windows.Forms.MessageBoxButtons.OK);
            GeneralError = true;
        }

    }

}
