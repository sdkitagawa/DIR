namespace DiscordIconReplacer;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.Label_DiscordFolder = new System.Windows.Forms.Label();
        this.Label_DiscordIcon = new System.Windows.Forms.Label();
        this.Label_DiscordPTBFolder = new System.Windows.Forms.Label();
        this.Label_DiscordPTBIcon = new System.Windows.Forms.Label();
        this.Label_DiscordCanaryFolder = new System.Windows.Forms.Label();
        this.Label_DiscordCanaryIcon = new System.Windows.Forms.Label();
        this.TextBox_DiscordShortcut = new System.Windows.Forms.TextBox();
        this.TextBox_DiscordIcon = new System.Windows.Forms.TextBox();
        this.TextBox_DiscordPTBShortcut = new System.Windows.Forms.TextBox();
        this.TextBox_DiscordPTBIcon = new System.Windows.Forms.TextBox();
        this.TextBox_DiscordCanaryShortcut = new System.Windows.Forms.TextBox();
        this.TextBox_DiscordCanaryIcon = new System.Windows.Forms.TextBox();
        this.Label_StartMenuCache = new System.Windows.Forms.Label();
        this.CheckBox_RestartExplorer = new System.Windows.Forms.CheckBox();
        this.Button_Browse_DiscordShortcut = new System.Windows.Forms.Button();
        this.Button_Browse_DiscordIcon = new System.Windows.Forms.Button();
        this.Button_Browse_DiscordPTBShortcut = new System.Windows.Forms.Button();
        this.Button_Browse_DiscordPTBIcon = new System.Windows.Forms.Button();
        this.Button_Browse_DiscordCanaryShortcut = new System.Windows.Forms.Button();
        this.Button_Browse_DiscordCanaryIcon = new System.Windows.Forms.Button();
        this.Button_ApplyIcons = new System.Windows.Forms.Button();
        this.Button_SaveSettings = new System.Windows.Forms.Button();
        this.Button_Close = new System.Windows.Forms.Button();
        this.tableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.AutoSize = true;
        this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.tableLayoutPanel1.ColumnCount = 2;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel1.Controls.Add(this.Label_DiscordFolder, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.Label_DiscordIcon, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.Label_DiscordPTBFolder, 0, 2);
        this.tableLayoutPanel1.Controls.Add(this.Label_DiscordPTBIcon, 0, 3);
        this.tableLayoutPanel1.Controls.Add(this.Label_DiscordCanaryFolder, 0, 4);
        this.tableLayoutPanel1.Controls.Add(this.Label_DiscordCanaryIcon, 0, 5);
        this.tableLayoutPanel1.Controls.Add(this.TextBox_DiscordShortcut, 1, 0);
        this.tableLayoutPanel1.Controls.Add(this.TextBox_DiscordIcon, 1, 1);
        this.tableLayoutPanel1.Controls.Add(this.TextBox_DiscordPTBShortcut, 1, 2);
        this.tableLayoutPanel1.Controls.Add(this.TextBox_DiscordPTBIcon, 1, 3);
        this.tableLayoutPanel1.Controls.Add(this.TextBox_DiscordCanaryShortcut, 1, 4);
        this.tableLayoutPanel1.Controls.Add(this.TextBox_DiscordCanaryIcon, 1, 5);
        this.tableLayoutPanel1.Controls.Add(this.Label_StartMenuCache, 0, 6);
        this.tableLayoutPanel1.Controls.Add(this.CheckBox_RestartExplorer, 1, 6);
        this.tableLayoutPanel1.Font = new System.Drawing.Font("gg sans Medium", 8F);
        this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 7;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(726, 189);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // Label_DiscordFolder
        // 
        this.Label_DiscordFolder.AutoSize = true;
        this.Label_DiscordFolder.ForeColor = System.Drawing.Color.White;
        this.Label_DiscordFolder.Location = new System.Drawing.Point(3, 0);
        this.Label_DiscordFolder.Name = "Label_DiscordFolder";
        this.Label_DiscordFolder.Size = new System.Drawing.Size(80, 15);
        this.Label_DiscordFolder.TabIndex = 0;
        this.Label_DiscordFolder.Text = "Discord Folder:";
        // 
        // Label_DiscordIcon
        // 
        this.Label_DiscordIcon.AutoSize = true;
        this.Label_DiscordIcon.ForeColor = System.Drawing.Color.White;
        this.Label_DiscordIcon.Location = new System.Drawing.Point(3, 26);
        this.Label_DiscordIcon.Name = "Label_DiscordIcon";
        this.Label_DiscordIcon.Size = new System.Drawing.Size(70, 15);
        this.Label_DiscordIcon.TabIndex = 0;
        this.Label_DiscordIcon.Text = "Discord Icon:";
        // 
        // Label_DiscordPTBFolder
        // 
        this.Label_DiscordPTBFolder.AutoSize = true;
        this.Label_DiscordPTBFolder.ForeColor = System.Drawing.Color.White;
        this.Label_DiscordPTBFolder.Location = new System.Drawing.Point(3, 52);
        this.Label_DiscordPTBFolder.Name = "Label_DiscordPTBFolder";
        this.Label_DiscordPTBFolder.Size = new System.Drawing.Size(102, 15);
        this.Label_DiscordPTBFolder.TabIndex = 0;
        this.Label_DiscordPTBFolder.Text = "Discord PTB Folder:";
        // 
        // Label_DiscordPTBIcon
        // 
        this.Label_DiscordPTBIcon.AutoSize = true;
        this.Label_DiscordPTBIcon.ForeColor = System.Drawing.Color.White;
        this.Label_DiscordPTBIcon.Location = new System.Drawing.Point(3, 78);
        this.Label_DiscordPTBIcon.Name = "Label_DiscordPTBIcon";
        this.Label_DiscordPTBIcon.Size = new System.Drawing.Size(92, 15);
        this.Label_DiscordPTBIcon.TabIndex = 0;
        this.Label_DiscordPTBIcon.Text = "Discord PTB Icon:";
        // 
        // Label_DiscordCanaryFolder
        // 
        this.Label_DiscordCanaryFolder.AutoSize = true;
        this.Label_DiscordCanaryFolder.ForeColor = System.Drawing.Color.White;
        this.Label_DiscordCanaryFolder.Location = new System.Drawing.Point(3, 104);
        this.Label_DiscordCanaryFolder.Name = "Label_DiscordCanaryFolder";
        this.Label_DiscordCanaryFolder.Size = new System.Drawing.Size(116, 15);
        this.Label_DiscordCanaryFolder.TabIndex = 0;
        this.Label_DiscordCanaryFolder.Text = "Discord Canary Folder:";
        // 
        // Label_DiscordCanaryIcon
        // 
        this.Label_DiscordCanaryIcon.AutoSize = true;
        this.Label_DiscordCanaryIcon.ForeColor = System.Drawing.Color.White;
        this.Label_DiscordCanaryIcon.Location = new System.Drawing.Point(3, 130);
        this.Label_DiscordCanaryIcon.Name = "Label_DiscordCanaryIcon";
        this.Label_DiscordCanaryIcon.Size = new System.Drawing.Size(106, 15);
        this.Label_DiscordCanaryIcon.TabIndex = 0;
        this.Label_DiscordCanaryIcon.Text = "Discord Canary Icon:";
        // 
        // TextBox_DiscordShortcut
        // 
        this.TextBox_DiscordShortcut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.TextBox_DiscordShortcut.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TextBox_DiscordShortcut.ForeColor = System.Drawing.Color.White;
        this.TextBox_DiscordShortcut.Location = new System.Drawing.Point(125, 3);
        this.TextBox_DiscordShortcut.Name = "TextBox_DiscordShortcut";
        this.TextBox_DiscordShortcut.Size = new System.Drawing.Size(598, 21);
        this.TextBox_DiscordShortcut.TabIndex = 1;
        // 
        // TextBox_DiscordIcon
        // 
        this.TextBox_DiscordIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.TextBox_DiscordIcon.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TextBox_DiscordIcon.ForeColor = System.Drawing.Color.White;
        this.TextBox_DiscordIcon.Location = new System.Drawing.Point(125, 29);
        this.TextBox_DiscordIcon.Name = "TextBox_DiscordIcon";
        this.TextBox_DiscordIcon.Size = new System.Drawing.Size(598, 21);
        this.TextBox_DiscordIcon.TabIndex = 1;
        // 
        // TextBox_DiscordPTBShortcut
        // 
        this.TextBox_DiscordPTBShortcut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.TextBox_DiscordPTBShortcut.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TextBox_DiscordPTBShortcut.ForeColor = System.Drawing.Color.White;
        this.TextBox_DiscordPTBShortcut.Location = new System.Drawing.Point(125, 55);
        this.TextBox_DiscordPTBShortcut.Name = "TextBox_DiscordPTBShortcut";
        this.TextBox_DiscordPTBShortcut.Size = new System.Drawing.Size(598, 21);
        this.TextBox_DiscordPTBShortcut.TabIndex = 1;
        // 
        // TextBox_DiscordPTBIcon
        // 
        this.TextBox_DiscordPTBIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.TextBox_DiscordPTBIcon.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TextBox_DiscordPTBIcon.ForeColor = System.Drawing.Color.White;
        this.TextBox_DiscordPTBIcon.Location = new System.Drawing.Point(125, 81);
        this.TextBox_DiscordPTBIcon.Name = "TextBox_DiscordPTBIcon";
        this.TextBox_DiscordPTBIcon.Size = new System.Drawing.Size(598, 21);
        this.TextBox_DiscordPTBIcon.TabIndex = 1;
        // 
        // TextBox_DiscordCanaryShortcut
        // 
        this.TextBox_DiscordCanaryShortcut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.TextBox_DiscordCanaryShortcut.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TextBox_DiscordCanaryShortcut.ForeColor = System.Drawing.Color.White;
        this.TextBox_DiscordCanaryShortcut.Location = new System.Drawing.Point(125, 107);
        this.TextBox_DiscordCanaryShortcut.Name = "TextBox_DiscordCanaryShortcut";
        this.TextBox_DiscordCanaryShortcut.Size = new System.Drawing.Size(598, 21);
        this.TextBox_DiscordCanaryShortcut.TabIndex = 1;
        // 
        // TextBox_DiscordCanaryIcon
        // 
        this.TextBox_DiscordCanaryIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.TextBox_DiscordCanaryIcon.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TextBox_DiscordCanaryIcon.ForeColor = System.Drawing.Color.White;
        this.TextBox_DiscordCanaryIcon.Location = new System.Drawing.Point(125, 133);
        this.TextBox_DiscordCanaryIcon.Name = "TextBox_DiscordCanaryIcon";
        this.TextBox_DiscordCanaryIcon.Size = new System.Drawing.Size(598, 21);
        this.TextBox_DiscordCanaryIcon.TabIndex = 1;
        // 
        // Label_StartMenuCache
        // 
        this.Label_StartMenuCache.AutoSize = true;
        this.Label_StartMenuCache.ForeColor = System.Drawing.Color.White;
        this.Label_StartMenuCache.Location = new System.Drawing.Point(3, 156);
        this.Label_StartMenuCache.Name = "Label_StartMenuCache";
        this.Label_StartMenuCache.Size = new System.Drawing.Size(93, 15);
        this.Label_StartMenuCache.TabIndex = 2;
        this.Label_StartMenuCache.Text = "Start Menu Cache";
        // 
        // CheckBox_RestartExplorer
        // 
        this.CheckBox_RestartExplorer.AutoSize = true;
        this.CheckBox_RestartExplorer.ForeColor = System.Drawing.Color.White;
        this.CheckBox_RestartExplorer.Location = new System.Drawing.Point(125, 159);
        this.CheckBox_RestartExplorer.Name = "CheckBox_RestartExplorer";
        this.CheckBox_RestartExplorer.Size = new System.Drawing.Size(201, 19);
        this.CheckBox_RestartExplorer.TabIndex = 3;
        this.CheckBox_RestartExplorer.Text = "Restart Explorer after applying icons";
        this.CheckBox_RestartExplorer.UseVisualStyleBackColor = true;
        // 
        // Button_Browse_DiscordShortcut
        // 
        this.Button_Browse_DiscordShortcut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.Button_Browse_DiscordShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.Button_Browse_DiscordShortcut.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Button_Browse_DiscordShortcut.FlatAppearance.BorderSize = 0;
        this.Button_Browse_DiscordShortcut.Font = new System.Drawing.Font("gg sans Medium", 8F, System.Drawing.FontStyle.Bold);
        this.Button_Browse_DiscordShortcut.ForeColor = System.Drawing.Color.White;
        this.Button_Browse_DiscordShortcut.Location = new System.Drawing.Point(744, 12);
        this.Button_Browse_DiscordShortcut.Name = "Button_Browse_DiscordShortcut";
        this.Button_Browse_DiscordShortcut.Size = new System.Drawing.Size(75, 25);
        this.Button_Browse_DiscordShortcut.TabIndex = 1;
        this.Button_Browse_DiscordShortcut.Text = "...";
        this.Button_Browse_DiscordShortcut.UseVisualStyleBackColor = false;
        this.Button_Browse_DiscordShortcut.Click += new System.EventHandler(this.Button_Browse_DiscordShortcut_Click);
        // 
        // Button_Browse_DiscordIcon
        // 
        this.Button_Browse_DiscordIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.Button_Browse_DiscordIcon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Button_Browse_DiscordIcon.Font = new System.Drawing.Font("gg sans Medium", 8F, System.Drawing.FontStyle.Bold);
        this.Button_Browse_DiscordIcon.ForeColor = System.Drawing.Color.White;
        this.Button_Browse_DiscordIcon.Location = new System.Drawing.Point(744, 40);
        this.Button_Browse_DiscordIcon.Name = "Button_Browse_DiscordIcon";
        this.Button_Browse_DiscordIcon.Size = new System.Drawing.Size(75, 25);
        this.Button_Browse_DiscordIcon.TabIndex = 1;
        this.Button_Browse_DiscordIcon.Text = "...";
        this.Button_Browse_DiscordIcon.UseVisualStyleBackColor = false;
        this.Button_Browse_DiscordIcon.Click += new System.EventHandler(this.Button_Browse_DiscordIcon_Click);
        // 
        // Button_Browse_DiscordPTBShortcut
        // 
        this.Button_Browse_DiscordPTBShortcut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.Button_Browse_DiscordPTBShortcut.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Button_Browse_DiscordPTBShortcut.Font = new System.Drawing.Font("gg sans Medium", 8F, System.Drawing.FontStyle.Bold);
        this.Button_Browse_DiscordPTBShortcut.ForeColor = System.Drawing.Color.White;
        this.Button_Browse_DiscordPTBShortcut.Location = new System.Drawing.Point(744, 66);
        this.Button_Browse_DiscordPTBShortcut.Name = "Button_Browse_DiscordPTBShortcut";
        this.Button_Browse_DiscordPTBShortcut.Size = new System.Drawing.Size(75, 25);
        this.Button_Browse_DiscordPTBShortcut.TabIndex = 1;
        this.Button_Browse_DiscordPTBShortcut.Text = "...";
        this.Button_Browse_DiscordPTBShortcut.UseVisualStyleBackColor = false;
        this.Button_Browse_DiscordPTBShortcut.Click += new System.EventHandler(this.Button_Browse_DiscordPTBShortcut_Click);
        // 
        // Button_Browse_DiscordPTBIcon
        // 
        this.Button_Browse_DiscordPTBIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.Button_Browse_DiscordPTBIcon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Button_Browse_DiscordPTBIcon.Font = new System.Drawing.Font("gg sans Medium", 8F, System.Drawing.FontStyle.Bold);
        this.Button_Browse_DiscordPTBIcon.ForeColor = System.Drawing.Color.White;
        this.Button_Browse_DiscordPTBIcon.Location = new System.Drawing.Point(744, 93);
        this.Button_Browse_DiscordPTBIcon.Name = "Button_Browse_DiscordPTBIcon";
        this.Button_Browse_DiscordPTBIcon.Size = new System.Drawing.Size(75, 25);
        this.Button_Browse_DiscordPTBIcon.TabIndex = 1;
        this.Button_Browse_DiscordPTBIcon.Text = "...";
        this.Button_Browse_DiscordPTBIcon.UseVisualStyleBackColor = false;
        this.Button_Browse_DiscordPTBIcon.Click += new System.EventHandler(this.Button_Browse_DiscordPTBIcon_Click);
        // 
        // Button_Browse_DiscordCanaryShortcut
        // 
        this.Button_Browse_DiscordCanaryShortcut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.Button_Browse_DiscordCanaryShortcut.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Button_Browse_DiscordCanaryShortcut.Font = new System.Drawing.Font("gg sans Medium", 8F, System.Drawing.FontStyle.Bold);
        this.Button_Browse_DiscordCanaryShortcut.ForeColor = System.Drawing.Color.White;
        this.Button_Browse_DiscordCanaryShortcut.Location = new System.Drawing.Point(744, 120);
        this.Button_Browse_DiscordCanaryShortcut.Name = "Button_Browse_DiscordCanaryShortcut";
        this.Button_Browse_DiscordCanaryShortcut.Size = new System.Drawing.Size(75, 25);
        this.Button_Browse_DiscordCanaryShortcut.TabIndex = 1;
        this.Button_Browse_DiscordCanaryShortcut.Text = "...";
        this.Button_Browse_DiscordCanaryShortcut.UseVisualStyleBackColor = false;
        this.Button_Browse_DiscordCanaryShortcut.Click += new System.EventHandler(this.Button_Browse_DiscordCanaryShortcut_Click);
        // 
        // Button_Browse_DiscordCanaryIcon
        // 
        this.Button_Browse_DiscordCanaryIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.Button_Browse_DiscordCanaryIcon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Button_Browse_DiscordCanaryIcon.Font = new System.Drawing.Font("gg sans Medium", 8F, System.Drawing.FontStyle.Bold);
        this.Button_Browse_DiscordCanaryIcon.ForeColor = System.Drawing.Color.White;
        this.Button_Browse_DiscordCanaryIcon.Location = new System.Drawing.Point(744, 148);
        this.Button_Browse_DiscordCanaryIcon.Name = "Button_Browse_DiscordCanaryIcon";
        this.Button_Browse_DiscordCanaryIcon.Size = new System.Drawing.Size(75, 25);
        this.Button_Browse_DiscordCanaryIcon.TabIndex = 1;
        this.Button_Browse_DiscordCanaryIcon.Text = "...";
        this.Button_Browse_DiscordCanaryIcon.UseVisualStyleBackColor = false;
        this.Button_Browse_DiscordCanaryIcon.Click += new System.EventHandler(this.Button_Browse_DiscordCanaryIcon_Click);
        // 
        // Button_ApplyIcons
        // 
        this.Button_ApplyIcons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.Button_ApplyIcons.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Button_ApplyIcons.Font = new System.Drawing.Font("gg sans Medium", 8F, System.Drawing.FontStyle.Bold);
        this.Button_ApplyIcons.ForeColor = System.Drawing.Color.White;
        this.Button_ApplyIcons.Location = new System.Drawing.Point(11, 207);
        this.Button_ApplyIcons.Name = "Button_ApplyIcons";
        this.Button_ApplyIcons.Size = new System.Drawing.Size(372, 35);
        this.Button_ApplyIcons.TabIndex = 1;
        this.Button_ApplyIcons.Text = "Apply Icons";
        this.Button_ApplyIcons.UseVisualStyleBackColor = false;
        this.Button_ApplyIcons.Click += new System.EventHandler(this.Button_ApplyIcons_Click);
        // 
        // Button_SaveSettings
        // 
        this.Button_SaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.Button_SaveSettings.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Button_SaveSettings.Font = new System.Drawing.Font("gg sans Medium", 8F, System.Drawing.FontStyle.Bold);
        this.Button_SaveSettings.ForeColor = System.Drawing.Color.White;
        this.Button_SaveSettings.Location = new System.Drawing.Point(389, 207);
        this.Button_SaveSettings.Name = "Button_SaveSettings";
        this.Button_SaveSettings.Size = new System.Drawing.Size(430, 35);
        this.Button_SaveSettings.TabIndex = 1;
        this.Button_SaveSettings.Text = "Save Discord Directories";
        this.Button_SaveSettings.UseVisualStyleBackColor = false;
        this.Button_SaveSettings.Click += new System.EventHandler(this.Button_SaveSettings_Click);
        // 
        // Button_Close
        // 
        this.Button_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
        this.Button_Close.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Button_Close.Font = new System.Drawing.Font("gg sans Medium", 8F, System.Drawing.FontStyle.Bold);
        this.Button_Close.ForeColor = System.Drawing.Color.White;
        this.Button_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Button_Close.Location = new System.Drawing.Point(12, 248);
        this.Button_Close.Name = "Button_Close";
        this.Button_Close.Size = new System.Drawing.Size(807, 35);
        this.Button_Close.TabIndex = 1;
        this.Button_Close.Text = "Close";
        this.Button_Close.UseVisualStyleBackColor = false;
        this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
        this.ClientSize = new System.Drawing.Size(824, 295);
        this.Controls.Add(this.Button_SaveSettings);
        this.Controls.Add(this.Button_Close);
        this.Controls.Add(this.Button_ApplyIcons);
        this.Controls.Add(this.Button_Browse_DiscordCanaryIcon);
        this.Controls.Add(this.Button_Browse_DiscordCanaryShortcut);
        this.Controls.Add(this.Button_Browse_DiscordPTBIcon);
        this.Controls.Add(this.Button_Browse_DiscordPTBShortcut);
        this.Controls.Add(this.Button_Browse_DiscordIcon);
        this.Controls.Add(this.Button_Browse_DiscordShortcut);
        this.Controls.Add(this.tableLayoutPanel1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Discord Icon Replacer";
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.CheckBox CheckBox_RestartExplorer;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label Label_DiscordFolder;
    private System.Windows.Forms.Label Label_DiscordIcon;
    private System.Windows.Forms.Label Label_DiscordPTBFolder;
    private System.Windows.Forms.Label Label_DiscordPTBIcon;
    private System.Windows.Forms.Label Label_DiscordCanaryFolder;
    private System.Windows.Forms.Label Label_DiscordCanaryIcon;
    private System.Windows.Forms.TextBox TextBox_DiscordShortcut;
    private System.Windows.Forms.TextBox TextBox_DiscordIcon;
    private System.Windows.Forms.TextBox TextBox_DiscordPTBShortcut;
    private System.Windows.Forms.TextBox TextBox_DiscordPTBIcon;
    private System.Windows.Forms.TextBox TextBox_DiscordCanaryShortcut;
    private System.Windows.Forms.TextBox TextBox_DiscordCanaryIcon;
    private System.Windows.Forms.Button Button_Browse_DiscordShortcut;
    private System.Windows.Forms.Button Button_Browse_DiscordIcon;
    private System.Windows.Forms.Button Button_Browse_DiscordPTBShortcut;
    private System.Windows.Forms.Button Button_Browse_DiscordPTBIcon;
    private System.Windows.Forms.Button Button_Browse_DiscordCanaryShortcut;
    private System.Windows.Forms.Button Button_Browse_DiscordCanaryIcon;
    private System.Windows.Forms.Button Button_ApplyIcons;
    private System.Windows.Forms.Button Button_SaveSettings;
    private System.Windows.Forms.Button Button_Close;
    private System.Windows.Forms.Label Label_StartMenuCache;
}
