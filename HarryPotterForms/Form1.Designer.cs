namespace HarryPotterForms;

partial class Form1 {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        pbCharacterImage = new System.Windows.Forms.PictureBox();
        lbKnownSpells    = new System.Windows.Forms.ListBox();
        lbChildren       = new System.Windows.Forms.ListBox();
        btnLoadBooks     = new System.Windows.Forms.Button();
        btnRefresh       = new System.Windows.Forms.Button();
        columnHeader1    = new System.Windows.Forms.ColumnHeader();
        columnHeader2    = new System.Windows.Forms.ColumnHeader();
        columnHeader3    = new System.Windows.Forms.ColumnHeader();
        columnHeader4    = new System.Windows.Forms.ColumnHeader();
        columnHeader5    = new System.Windows.Forms.ColumnHeader();
        lvCharacters     = new System.Windows.Forms.ListView();
        ((System.ComponentModel.ISupportInitialize)pbCharacterImage).BeginInit();
        SuspendLayout();
        // 
        // pbCharacterImage
        // 
        pbCharacterImage.Location = new System.Drawing.Point(950, 41);
        pbCharacterImage.Name     = "pbCharacterImage";
        pbCharacterImage.Size     = new System.Drawing.Size(270, 327);
        pbCharacterImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pbCharacterImage.TabIndex = 1;
        pbCharacterImage.TabStop  = false;
        // 
        // lbKnownSpells
        // 
        lbKnownSpells.FormattingEnabled = true;
        lbKnownSpells.ItemHeight        = 15;
        lbKnownSpells.Location          = new System.Drawing.Point(661, 14);
        lbKnownSpells.Name              = "lbKnownSpells";
        lbKnownSpells.Size              = new System.Drawing.Size(283, 679);
        lbKnownSpells.TabIndex          = 2;
        // 
        // lbChildren
        // 
        lbChildren.FormattingEnabled = true;
        lbChildren.ItemHeight        = 15;
        lbChildren.Location          = new System.Drawing.Point(950, 374);
        lbChildren.Name              = "lbChildren";
        lbChildren.Size              = new System.Drawing.Size(270, 319);
        lbChildren.TabIndex          = 3;
        // 
        // btnLoadBooks
        // 
        btnLoadBooks.Location                =  new System.Drawing.Point(950, 12);
        btnLoadBooks.Name                    =  "btnLoadBooks";
        btnLoadBooks.Size                    =  new System.Drawing.Size(137, 23);
        btnLoadBooks.TabIndex                =  4;
        btnLoadBooks.Text                    =  "Load Books";
        btnLoadBooks.UseVisualStyleBackColor =  true;
        btnLoadBooks.Click                   += btnLoadBooks_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.Location                =  new System.Drawing.Point(1093, 12);
        btnRefresh.Name                    =  "btnRefresh";
        btnRefresh.Size                    =  new System.Drawing.Size(127, 23);
        btnRefresh.TabIndex                =  5;
        btnRefresh.Text                    =  "Refresh";
        btnRefresh.UseVisualStyleBackColor =  true;
        btnRefresh.Click                   += btnRefresh_Click;
        // 
        // columnHeader1
        // 
        columnHeader1.Name  = "columnHeader1";
        columnHeader1.Text  = "Index";
        columnHeader1.Width = 44;
        // 
        // columnHeader2
        // 
        columnHeader2.Name  = "columnHeader2";
        columnHeader2.Text  = "FullName";
        columnHeader2.Width = 193;
        // 
        // columnHeader3
        // 
        columnHeader3.Name  = "columnHeader3";
        columnHeader3.Text  = "Nickname";
        columnHeader3.Width = 128;
        // 
        // columnHeader4
        // 
        columnHeader4.Name  = "columnHeader4";
        columnHeader4.Text  = "House";
        columnHeader4.Width = 145;
        // 
        // columnHeader5
        // 
        columnHeader5.Name  = "columnHeader5";
        columnHeader5.Text  = "Birthdate";
        columnHeader5.Width = 126;
        // 
        // lvCharacters
        // 
        lvCharacters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
        lvCharacters.Location                        =  new System.Drawing.Point(12, 14);
        lvCharacters.Name                            =  "lvCharacters";
        lvCharacters.Size                            =  new System.Drawing.Size(643, 679);
        lvCharacters.TabIndex                        =  0;
        lvCharacters.UseCompatibleStateImageBehavior =  false;
        lvCharacters.View                            =  System.Windows.Forms.View.Details;
        lvCharacters.ItemSelectionChanged            += lvCharacters_ItemSelectionChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
        AutoScroll          = true;
        BackColor           = System.Drawing.SystemColors.Control;
        ClientSize          = new System.Drawing.Size(1232, 705);
        Controls.Add(lbChildren);
        Controls.Add(lbKnownSpells);
        Controls.Add(btnRefresh);
        Controls.Add(btnLoadBooks);
        Controls.Add(pbCharacterImage);
        Controls.Add(lvCharacters);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Location        = new System.Drawing.Point(15, 15);
        MaximizeBox     = false;
        StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
        ((System.ComponentModel.ISupportInitialize)pbCharacterImage).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.ListView     lvCharacters;

    private System.Windows.Forms.ColumnHeader Index;

    private System.Windows.Forms.Button btnLoadBooks;

    private System.Windows.Forms.Button btnRefresh;

    private System.Windows.Forms.ListBox lbChildren;

    private System.Windows.Forms.ListBox lbKnownSpells;

    private System.Windows.Forms.PictureBox pbCharacterImage;

    #endregion
}