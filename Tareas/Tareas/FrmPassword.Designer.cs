﻿
namespace Tareas
{
    partial class FrmPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPassword));
            this.txtPasswordNueva = new System.Windows.Forms.TextBox();
            this.txtConfirmarPasswordNueva = new System.Windows.Forms.TextBox();
            this.lblIngresePasswordNueva = new System.Windows.Forms.Label();
            this.lblReingresePasswordNueva = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRemoverPassword = new System.Windows.Forms.Button();
            this.lblIngresePasswordActual = new System.Windows.Forms.Label();
            this.txtPasswordActual = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPasswordNueva
            // 
            this.txtPasswordNueva.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPasswordNueva.Location = new System.Drawing.Point(325, 47);
            this.txtPasswordNueva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPasswordNueva.MaxLength = 12;
            this.txtPasswordNueva.Name = "txtPasswordNueva";
            this.txtPasswordNueva.PasswordChar = '*';
            this.txtPasswordNueva.Size = new System.Drawing.Size(261, 29);
            this.txtPasswordNueva.TabIndex = 1;
            // 
            // txtConfirmarPasswordNueva
            // 
            this.txtConfirmarPasswordNueva.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtConfirmarPasswordNueva.Location = new System.Drawing.Point(325, 91);
            this.txtConfirmarPasswordNueva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmarPasswordNueva.MaxLength = 12;
            this.txtConfirmarPasswordNueva.Name = "txtConfirmarPasswordNueva";
            this.txtConfirmarPasswordNueva.PasswordChar = '*';
            this.txtConfirmarPasswordNueva.Size = new System.Drawing.Size(261, 29);
            this.txtConfirmarPasswordNueva.TabIndex = 2;
            // 
            // lblIngresePasswordNueva
            // 
            this.lblIngresePasswordNueva.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIngresePasswordNueva.Location = new System.Drawing.Point(10, 50);
            this.lblIngresePasswordNueva.Name = "lblIngresePasswordNueva";
            this.lblIngresePasswordNueva.Size = new System.Drawing.Size(298, 26);
            this.lblIngresePasswordNueva.TabIndex = 3;
            this.lblIngresePasswordNueva.Text = "Ingrese nueva contraseña:";
            // 
            // lblReingresePasswordNueva
            // 
            this.lblReingresePasswordNueva.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReingresePasswordNueva.Location = new System.Drawing.Point(10, 93);
            this.lblReingresePasswordNueva.Name = "lblReingresePasswordNueva";
            this.lblReingresePasswordNueva.Size = new System.Drawing.Size(298, 26);
            this.lblReingresePasswordNueva.TabIndex = 4;
            this.lblReingresePasswordNueva.Text = "Confirme nueva contraseña:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAceptar.Location = new System.Drawing.Point(425, 141);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(160, 54);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(10, 141);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(160, 54);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRemoverPassword
            // 
            this.btnRemoverPassword.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemoverPassword.Location = new System.Drawing.Point(201, 141);
            this.btnRemoverPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoverPassword.Name = "btnRemoverPassword";
            this.btnRemoverPassword.Size = new System.Drawing.Size(189, 54);
            this.btnRemoverPassword.TabIndex = 7;
            this.btnRemoverPassword.Text = "Remover Contraseña";
            this.btnRemoverPassword.UseVisualStyleBackColor = true;
            this.btnRemoverPassword.Click += new System.EventHandler(this.btnRemoverPassword_Click);
            // 
            // lblIngresePasswordActual
            // 
            this.lblIngresePasswordActual.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIngresePasswordActual.Location = new System.Drawing.Point(10, 7);
            this.lblIngresePasswordActual.Name = "lblIngresePasswordActual";
            this.lblIngresePasswordActual.Size = new System.Drawing.Size(298, 26);
            this.lblIngresePasswordActual.TabIndex = 9;
            // 
            // txtPasswordActual
            // 
            this.txtPasswordActual.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPasswordActual.Location = new System.Drawing.Point(325, 4);
            this.txtPasswordActual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPasswordActual.MaxLength = 12;
            this.txtPasswordActual.Name = "txtPasswordActual";
            this.txtPasswordActual.PasswordChar = '*';
            this.txtPasswordActual.Size = new System.Drawing.Size(261, 29);
            this.txtPasswordActual.TabIndex = 8;
            // 
            // FrmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 209);
            this.Controls.Add(this.lblIngresePasswordActual);
            this.Controls.Add(this.txtPasswordActual);
            this.Controls.Add(this.btnRemoverPassword);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblReingresePasswordNueva);
            this.Controls.Add(this.lblIngresePasswordNueva);
            this.Controls.Add(this.txtConfirmarPasswordNueva);
            this.Controls.Add(this.txtPasswordNueva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FrmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPasswordNueva;
        private System.Windows.Forms.TextBox txtConfirmarPasswordNueva;
        private System.Windows.Forms.Label lblIngresePasswordNueva;
        private System.Windows.Forms.Label lblReingresePasswordNueva;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRemoverPassword;
        private System.Windows.Forms.Label lblIngresePasswordActual;
        private System.Windows.Forms.TextBox txtPasswordActual;
    }
}