namespace Power
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BTN_Actualizar = new Button();
            Group_Config = new GroupBox();
            CK_Inactividad = new CheckBox();
            CK_00Hs = new CheckBox();
            DGV_Estado = new DataGridView();
            BTN_Desactivar = new Button();
            TXT_INACTIVIDAD = new TextBox();
            label1 = new Label();
            Group_Config.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Estado).BeginInit();
            SuspendLayout();
            // 
            // BTN_Actualizar
            // 
            BTN_Actualizar.Location = new Point(83, 118);
            BTN_Actualizar.Name = "BTN_Actualizar";
            BTN_Actualizar.Size = new Size(114, 23);
            BTN_Actualizar.TabIndex = 0;
            BTN_Actualizar.Text = "Actualizar";
            BTN_Actualizar.UseVisualStyleBackColor = true;
            BTN_Actualizar.Click += BTN_Actualizar_Click;
            // 
            // Group_Config
            // 
            Group_Config.Controls.Add(CK_Inactividad);
            Group_Config.Controls.Add(CK_00Hs);
            Group_Config.Location = new Point(30, 12);
            Group_Config.Name = "Group_Config";
            Group_Config.Size = new Size(224, 100);
            Group_Config.TabIndex = 5;
            Group_Config.TabStop = false;
            Group_Config.Text = "Configuracion";
            // 
            // CK_Inactividad
            // 
            CK_Inactividad.AutoSize = true;
            CK_Inactividad.Location = new Point(53, 47);
            CK_Inactividad.Name = "CK_Inactividad";
            CK_Inactividad.Size = new Size(148, 19);
            CK_Inactividad.TabIndex = 1;
            CK_Inactividad.Text = "Apagar con Inactividad";
            CK_Inactividad.UseVisualStyleBackColor = true;
            CK_Inactividad.CheckedChanged += CK_Inactividad_CheckedChanged;
            // 
            // CK_00Hs
            // 
            CK_00Hs.AutoSize = true;
            CK_00Hs.Location = new Point(53, 22);
            CK_00Hs.Name = "CK_00Hs";
            CK_00Hs.Size = new Size(93, 19);
            CK_00Hs.TabIndex = 0;
            CK_00Hs.Text = "Apagar 00Hs";
            CK_00Hs.UseVisualStyleBackColor = true;
            CK_00Hs.CheckedChanged += CK_00Hs_CheckedChanged;
            // 
            // DGV_Estado
            // 
            DGV_Estado.AllowUserToAddRows = false;
            DGV_Estado.AllowUserToDeleteRows = false;
            DGV_Estado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Estado.Location = new Point(260, 44);
            DGV_Estado.Name = "DGV_Estado";
            DGV_Estado.ReadOnly = true;
            DGV_Estado.Size = new Size(351, 44);
            DGV_Estado.TabIndex = 6;
            // 
            // BTN_Desactivar
            // 
            BTN_Desactivar.Location = new Point(83, 147);
            BTN_Desactivar.Name = "BTN_Desactivar";
            BTN_Desactivar.Size = new Size(114, 23);
            BTN_Desactivar.TabIndex = 7;
            BTN_Desactivar.Text = "Desactivar";
            BTN_Desactivar.UseVisualStyleBackColor = true;
            BTN_Desactivar.Click += BTN_Desactivar_Click;
            // 
            // TXT_INACTIVIDAD
            // 
            TXT_INACTIVIDAD.Location = new Point(403, 94);
            TXT_INACTIVIDAD.Name = "TXT_INACTIVIDAD";
            TXT_INACTIVIDAD.Size = new Size(61, 23);
            TXT_INACTIVIDAD.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(273, 97);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 9;
            label1.Text = "Tiempo de inactividad";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 189);
            Controls.Add(label1);
            Controls.Add(TXT_INACTIVIDAD);
            Controls.Add(BTN_Desactivar);
            Controls.Add(DGV_Estado);
            Controls.Add(Group_Config);
            Controls.Add(BTN_Actualizar);
            Name = "Form1";
            Text = "X";
            FormClosing += Form1_FormClosing;
            Group_Config.ResumeLayout(false);
            Group_Config.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Estado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_Actualizar;
        private GroupBox Group_Config;
        private CheckBox CK_Inactividad;
        private CheckBox CK_00Hs;
        private DataGridView DGV_Estado;
        private Button BTN_Desactivar;
        private TextBox TXT_INACTIVIDAD;
        private Label label1;
    }
}
