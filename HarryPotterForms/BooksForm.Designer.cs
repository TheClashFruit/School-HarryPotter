using System.ComponentModel;

namespace HarryPotterForms;

partial class BooksForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        btnDownloadBooks = new System.Windows.Forms.Button();
        dgvBooks         = new System.Windows.Forms.DataGridView();
        colOriginalTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colPages         = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colReleaseDate   = new System.Windows.Forms.DataGridViewTextBoxColumn();
        splitBottom      = new System.Windows.Forms.SplitContainer();
        lbDescription    = new System.Windows.Forms.TextBox();
        pbCover          = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
        ((System.ComponentModel.ISupportInitialize)splitBottom).BeginInit();
        splitBottom.Panel1.SuspendLayout();
        splitBottom.Panel2.SuspendLayout();
        splitBottom.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbCover).BeginInit();
        SuspendLayout();
        // 
        // btnDownloadBooks
        // 
        btnDownloadBooks.Anchor                  =  ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        btnDownloadBooks.Location                =  new System.Drawing.Point(12, 12);
        btnDownloadBooks.Name                    =  "btnDownloadBooks";
        btnDownloadBooks.Size                    =  new System.Drawing.Size(776, 30);
        btnDownloadBooks.TabIndex                =  0;
        btnDownloadBooks.Text                    =  "Load Data";
        btnDownloadBooks.UseVisualStyleBackColor =  true;
        btnDownloadBooks.Click                   += btnDownloadBooks_Click;
        // 
        // dgvBooks
        // 
        dgvBooks.Anchor              = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        dgvBooks.AutoGenerateColumns = false;
        dgvBooks.ColumnHeadersHeight = 29;
        dgvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colOriginalTitle, colPages, colReleaseDate });
        dgvBooks.Location         =  new System.Drawing.Point(12, 52);
        dgvBooks.MultiSelect      =  false;
        dgvBooks.Name             =  "dgvBooks";
        dgvBooks.ReadOnly         =  true;
        dgvBooks.RowHeadersWidth  =  51;
        dgvBooks.SelectionMode    =  System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvBooks.Size             =  new System.Drawing.Size(776, 220);
        dgvBooks.TabIndex         =  1;
        dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
        // 
        // colOriginalTitle
        // 
        colOriginalTitle.AutoSizeMode     = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        colOriginalTitle.DataPropertyName = "OriginalTitle";
        colOriginalTitle.HeaderText       = "Eredeti cím";
        colOriginalTitle.Name             = "colOriginalTitle";
        colOriginalTitle.ReadOnly         = true;
        colOriginalTitle.Width            = 483;
        // 
        // colPages
        // 
        colPages.DataPropertyName = "Pages";
        colPages.HeaderText       = "Oldalak száma";
        colPages.Name             = "colPages";
        colPages.ReadOnly         = true;
        colPages.Width            = 110;
        // 
        // colReleaseDate
        // 
        colReleaseDate.DataPropertyName = "ReleaseDate";
        colReleaseDate.HeaderText       = "Kiadás dátuma";
        colReleaseDate.Name             = "colReleaseDate";
        colReleaseDate.ReadOnly         = true;
        colReleaseDate.Width            = 130;
        // 
        // splitBottom
        // 
        splitBottom.Anchor   = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        splitBottom.Location = new System.Drawing.Point(12, 282);
        splitBottom.Name     = "splitBottom";
        // 
        // splitBottom.Panel1
        // 
        splitBottom.Panel1.Controls.Add(lbDescription);
        // 
        // splitBottom.Panel2
        // 
        splitBottom.Panel2.Controls.Add(pbCover);
        splitBottom.Size             = new System.Drawing.Size(776, 156);
        splitBottom.SplitterDistance = 400;
        splitBottom.TabIndex         = 2;
        // 
        // lbDescription
        // 
        lbDescription.Dock       = System.Windows.Forms.DockStyle.Fill;
        lbDescription.Location   = new System.Drawing.Point(0, 0);
        lbDescription.Multiline  = true;
        lbDescription.Name       = "lbDescription";
        lbDescription.ReadOnly   = true;
        lbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        lbDescription.Size       = new System.Drawing.Size(400, 156);
        lbDescription.TabIndex   = 0;
        // 
        // pbCover
        // 
        pbCover.Dock     = System.Windows.Forms.DockStyle.Fill;
        pbCover.Location = new System.Drawing.Point(0, 0);
        pbCover.Name     = "pbCover";
        pbCover.Size     = new System.Drawing.Size(372, 156);
        pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pbCover.TabIndex = 0;
        pbCover.TabStop  = false;
        // 
        // BooksForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize          = new System.Drawing.Size(800, 450);
        Controls.Add(splitBottom);
        Controls.Add(dgvBooks);
        Controls.Add(btnDownloadBooks);
        ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
        splitBottom.Panel1.ResumeLayout(false);
        splitBottom.Panel1.PerformLayout();
        splitBottom.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitBottom).EndInit();
        splitBottom.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pbCover).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button                    btnDownloadBooks;
    private System.Windows.Forms.DataGridView              dgvBooks;
    private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalTitle;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPages;
    private System.Windows.Forms.DataGridViewTextBoxColumn colReleaseDate;
    private System.Windows.Forms.SplitContainer            splitBottom;
    private System.Windows.Forms.TextBox                   lbDescription;
    private System.Windows.Forms.PictureBox                pbCover;

    #endregion
}