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
    public enum enumImportMode
    {
        Unkown = -1,
        ByPartsFullName = 0,
        ByPartsId = 1,
        ByPartsIdForLot = 2
    }
}
