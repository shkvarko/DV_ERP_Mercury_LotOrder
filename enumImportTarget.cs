using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Mercury.Common;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPMercuryLotOrder
{
    public enum enumImportTarget
    {
        Unkown = -1,
        ImportContents = 0,
        RefreshPrices = 1,
        ImportDataToLot = 2
    }
}
