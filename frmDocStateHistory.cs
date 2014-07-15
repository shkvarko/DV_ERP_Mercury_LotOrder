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
        #region �����������
        public frmDocStateHistory( )
        {
            InitializeComponent();
        }
        #endregion

        #region ���������� ������� ���������
        /// <summary>
        /// ��������� ������ ���������
        /// </summary>
        /// <returns>true - �������� ����������; false - ������</returns>
        public void LoadLotOrderHistory( UniXP.Common.CProfile objProfile, System.Guid uuidLotOrderId, System.String strLotOrderNum, System.String strVendorName )
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                treeListDocState.Nodes.Clear();
                lblInfo.Text = strLotOrderNum;

                lblMoney.Text = strVendorName;

                //������ ���������
                System.Int32 iRes = 0;
                System.String strErr = "";
                CLotOrderHistory objList = CLotOrderRepository.GetLotOrderHistory(  objProfile, null, uuidLotOrderId, ref iRes, 
                    ref strErr );
                if( ( objList != null ) && ( objList.LotOrderHistoryRecordList.Count > 0 ) )
                {
                    foreach (CLotOrderHistory.LotOrderHistoryRecord objDocStateHistory in objList.LotOrderHistoryRecordList)
                    {
                        // ��������� ���� � ������
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
                "������ ���������� ������� ���������.\n\n����� ������: " + f.Message, "��������",
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

        #region �������� �����
        private void barBtnClose_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                this.Close();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                "������ �������� ������� ���������.\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

        #region ������
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
                DevExpress.XtraEditors.XtraMessageBox.Show( "������ ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

    }
}