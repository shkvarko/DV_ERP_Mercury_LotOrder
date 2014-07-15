namespace ERPMercuryLotOrder
{
    partial class frmLotList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLotList));
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMakeSupplDeleted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEventLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistoryLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuKLPList = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelBackground = new System.Windows.Forms.TableLayoutPanel();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRefresh,
            this.toolStripSeparator1,
            this.menuMakeSupplDeleted,
            this.toolStripSeparator2,
            this.menuEventLog,
            this.menuHistoryLog,
            this.toolStripMenuItem1,
            this.menuKLPList});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(170, 132);
            this.toolTipController.SetSuperTip(this.contextMenuStrip, null);
            // 
            // menuRefresh
            // 
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size = new System.Drawing.Size(169, 22);
            this.menuRefresh.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // menuMakeSupplDeleted
            // 
            this.menuMakeSupplDeleted.Name = "menuMakeSupplDeleted";
            this.menuMakeSupplDeleted.Size = new System.Drawing.Size(169, 22);
            this.menuMakeSupplDeleted.Text = "Удалить заказ";
            this.menuMakeSupplDeleted.ToolTipText = "Изменить состояние заказа на \"удален\"";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // menuEventLog
            // 
            this.menuEventLog.Name = "menuEventLog";
            this.menuEventLog.Size = new System.Drawing.Size(169, 22);
            this.menuEventLog.Text = "Журнал событий";
            // 
            // menuHistoryLog
            // 
            this.menuHistoryLog.Name = "menuHistoryLog";
            this.menuHistoryLog.Size = new System.Drawing.Size(169, 22);
            this.menuHistoryLog.Text = "Журнал состояний";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 6);
            // 
            // menuKLPList
            // 
            this.menuKLPList.Name = "menuKLPList";
            this.menuKLPList.Size = new System.Drawing.Size(169, 22);
            this.menuKLPList.Text = "Журнал КЛП";
            // 
            // tableLayoutPanelBackground
            // 
            this.tableLayoutPanelBackground.ColumnCount = 1;
            this.tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBackground.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBackground.Name = "tableLayoutPanelBackground";
            this.tableLayoutPanelBackground.RowCount = 1;
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBackground.Size = new System.Drawing.Size(728, 575);
            this.toolTipController.SetSuperTip(this.tableLayoutPanelBackground, null);
            this.tableLayoutPanelBackground.TabIndex = 1;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // frmLotList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 575);
            this.Controls.Add(this.tableLayoutPanelBackground);
            this.Name = "frmLotList";
            this.toolTipController.SetSuperTip(this, null);
            this.Text = "Журнал приходов на склад приёмки товара";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLotList_FormClosing);
            this.Load += new System.EventHandler(this.frmLotList_Load);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.Utils.ImageCollection imageCollection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuMakeSupplDeleted;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuEventLog;
        private System.Windows.Forms.ToolStripMenuItem menuHistoryLog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuKLPList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackground;
    }
}