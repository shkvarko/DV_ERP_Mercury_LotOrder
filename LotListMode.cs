using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using System.Reflection;
using ERP_Mercury.Common;
using OfficeOpenXml;

namespace ERPMercuryLotOrder
{
    public enum LotListMode
    {
        Unkown,
        /// <summary>
        /// Журнал приходов загружается из КЛП
        /// </summary>
        FromKLP,
        /// <summary>
        /// Журнал приходов загружается из корневого меню
        /// </summary>
        FromUniXP
    }
}
