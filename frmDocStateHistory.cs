using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ERPMercuryLotOrder
{
    public partial class frmDocStateHistory : DevExpress.XtraEditors.XtraForm
    {
        #region Конструктор
        public frmDocStateHistory( )
        {
            InitializeComponent();
        }
        #endregion

        #region Построение журнала состояний
        /// <summary>
        /// Обновляет журнал состояний
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        public void LoadLotOrderHistory( UniXP.Common.CProfile objProfile, System.Guid uuidLotOrderId, System.String strLotOrderNum, System.String strVendorName )
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                treeListDocState.Nodes.Clear();
                lblInfo.Text = strLotOrderNum;

                lblMoney.Text = strVendorName;

                //список состояний
                System.Int32 iRes = 0;
                System.String strErr = "";
                CLotOrderHistory objList = CLotOrderRepository.GetLotOrderHistory(  objProfile, null, uuidLotOrderId, ref iRes, 
                    ref strErr );
                if( ( objList != null ) && ( objList.LotOrderHistoryRecordList.Count > 0 ) )
                {
                    foreach (CLotOrderHistory.LotOrderHistoryRecord objDocStateHistory in objList.LotOrderHistoryRecordList)
                    {
                        // добавляем узел в дерево
                        treeListDocState.AppendNode( new object[] { ( objDocStateHistory.RecordDateTimeUpdate.ToShortDateString() + " " + objDocStateHistory.RecordDateTimeUpdate.ToShortTimeString() ),
                            objDocStateHistory.LotOrderState.Name, 
                            objDocStateHistory.RecordUserUpdate }, null );
                    }
                }

                objList = null;
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                "Ошибка построения журнала состояний.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ShowDialog();
            }

            return;
        }
        #endregion

        #region Закрытие формы
        private void barBtnClose_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                this.Close();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                "Ошибка закрытия журнала состояний.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

        #region Печать
        private void barBtnPrint_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if( DevExpress.XtraPrinting.PrintHelper.IsPrintingAvailable )
                    DevExpress.XtraPrinting.PrintHelper.ShowPreview( treeListDocState );
                else
                    MessageBox.Show( "XtraPrinting Library is not found...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
                Cursor.Current = Cursors.Default;
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( "Ошибка печати.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

    }
}