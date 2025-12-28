namespace FF7Scarlet.SceneEditor
{
    partial class SceneImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneImportForm));
            labelResults = new Label();
            buttonImport = new Button();
            panelSceneList = new Panel();
            SuspendLayout();
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.Location = new Point(12, 9);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(183, 15);
            labelResults.TabIndex = 0;
            labelResults.Text = "The following scenes were found:";
            // 
            // buttonImport
            // 
            buttonImport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonImport.Location = new Point(377, 226);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(75, 23);
            buttonImport.TabIndex = 2;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // panelSceneList
            // 
            panelSceneList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelSceneList.AutoScroll = true;
            panelSceneList.BackColor = SystemColors.ControlLightLight;
            panelSceneList.BorderStyle = BorderStyle.FixedSingle;
            panelSceneList.Location = new Point(12, 27);
            panelSceneList.Name = "panelSceneList";
            panelSceneList.Size = new Size(440, 193);
            panelSceneList.TabIndex = 3;
            // 
            // SceneImportForm
            // 
            AcceptButton = buttonImport;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 261);
            Controls.Add(panelSceneList);
            Controls.Add(buttonImport);
            Controls.Add(labelResults);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SceneImportForm";
            Text = "Scene chunk import";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelResults;
        private Button buttonImport;
        private Panel panelSceneList;
    }
}