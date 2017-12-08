namespace ProgHausaufgaben
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDatenbankOeffnen = new System.Windows.Forms.Button();
            this.buttonUebersicht = new System.Windows.Forms.Button();
            this.buttonAlleFaecher = new System.Windows.Forms.Button();
            this.buttonAlleFachnamen = new System.Windows.Forms.Button();
            this.buttonAlleSchulhalbjahre = new System.Windows.Forms.Button();
            this.buttonAlleSchueler = new System.Windows.Forms.Button();
            this.buttonZeugnis = new System.Windows.Forms.Button();
            this.buttonEntwicklung = new System.Windows.Forms.Button();
            this.buttonEntwicklungSchueler = new System.Windows.Forms.Button();
            this.buttonDurchschnittsNoten = new System.Windows.Forms.Button();
            this.buttonEnde = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonDatenbankOeffnen
            // 
            this.buttonDatenbankOeffnen.Location = new System.Drawing.Point(620, 14);
            this.buttonDatenbankOeffnen.Name = "buttonDatenbankOeffnen";
            this.buttonDatenbankOeffnen.Size = new System.Drawing.Size(173, 23);
            this.buttonDatenbankOeffnen.TabIndex = 0;
            this.buttonDatenbankOeffnen.Text = "Datenbank öffnen";
            this.buttonDatenbankOeffnen.UseVisualStyleBackColor = true;
            this.buttonDatenbankOeffnen.Click += new System.EventHandler(this.buttonDatenbankOeffnen_Click);
            // 
            // buttonUebersicht
            // 
            this.buttonUebersicht.Location = new System.Drawing.Point(620, 54);
            this.buttonUebersicht.Name = "buttonUebersicht";
            this.buttonUebersicht.Size = new System.Drawing.Size(173, 23);
            this.buttonUebersicht.TabIndex = 1;
            this.buttonUebersicht.Text = "Übersicht";
            this.buttonUebersicht.UseVisualStyleBackColor = true;
            // 
            // buttonAlleFaecher
            // 
            this.buttonAlleFaecher.Location = new System.Drawing.Point(620, 94);
            this.buttonAlleFaecher.Name = "buttonAlleFaecher";
            this.buttonAlleFaecher.Size = new System.Drawing.Size(173, 23);
            this.buttonAlleFaecher.TabIndex = 2;
            this.buttonAlleFaecher.Text = "alle Fächer";
            this.buttonAlleFaecher.UseVisualStyleBackColor = true;
            // 
            // buttonAlleFachnamen
            // 
            this.buttonAlleFachnamen.Location = new System.Drawing.Point(620, 135);
            this.buttonAlleFachnamen.Name = "buttonAlleFachnamen";
            this.buttonAlleFachnamen.Size = new System.Drawing.Size(173, 23);
            this.buttonAlleFachnamen.TabIndex = 3;
            this.buttonAlleFachnamen.Text = "alle Fachnamen";
            this.buttonAlleFachnamen.UseVisualStyleBackColor = true;
            // 
            // buttonAlleSchulhalbjahre
            // 
            this.buttonAlleSchulhalbjahre.Location = new System.Drawing.Point(620, 174);
            this.buttonAlleSchulhalbjahre.Name = "buttonAlleSchulhalbjahre";
            this.buttonAlleSchulhalbjahre.Size = new System.Drawing.Size(173, 23);
            this.buttonAlleSchulhalbjahre.TabIndex = 4;
            this.buttonAlleSchulhalbjahre.Text = "alle Schulhalbjahre";
            this.buttonAlleSchulhalbjahre.UseVisualStyleBackColor = true;
            // 
            // buttonAlleSchueler
            // 
            this.buttonAlleSchueler.Location = new System.Drawing.Point(620, 215);
            this.buttonAlleSchueler.Name = "buttonAlleSchueler";
            this.buttonAlleSchueler.Size = new System.Drawing.Size(173, 23);
            this.buttonAlleSchueler.TabIndex = 5;
            this.buttonAlleSchueler.Text = "alle Schüler";
            this.buttonAlleSchueler.UseVisualStyleBackColor = true;
            // 
            // buttonZeugnis
            // 
            this.buttonZeugnis.Location = new System.Drawing.Point(620, 256);
            this.buttonZeugnis.Name = "buttonZeugnis";
            this.buttonZeugnis.Size = new System.Drawing.Size(173, 23);
            this.buttonZeugnis.TabIndex = 6;
            this.buttonZeugnis.Text = "Zeugnis für einen Schüler";
            this.buttonZeugnis.UseVisualStyleBackColor = true;
            // 
            // buttonEntwicklung
            // 
            this.buttonEntwicklung.Location = new System.Drawing.Point(620, 294);
            this.buttonEntwicklung.Name = "buttonEntwicklung";
            this.buttonEntwicklung.Size = new System.Drawing.Size(173, 23);
            this.buttonEntwicklung.TabIndex = 7;
            this.buttonEntwicklung.Text = "Entwicklung eines Schülers";
            this.buttonEntwicklung.UseVisualStyleBackColor = true;
            // 
            // buttonEntwicklungSchueler
            // 
            this.buttonEntwicklungSchueler.Location = new System.Drawing.Point(620, 332);
            this.buttonEntwicklungSchueler.Name = "buttonEntwicklungSchueler";
            this.buttonEntwicklungSchueler.Size = new System.Drawing.Size(173, 23);
            this.buttonEntwicklungSchueler.TabIndex = 8;
            this.buttonEntwicklungSchueler.Text = "Entwicklung eines Schülers";
            this.buttonEntwicklungSchueler.UseVisualStyleBackColor = true;
            // 
            // buttonDurchschnittsNoten
            // 
            this.buttonDurchschnittsNoten.Location = new System.Drawing.Point(620, 371);
            this.buttonDurchschnittsNoten.Name = "buttonDurchschnittsNoten";
            this.buttonDurchschnittsNoten.Size = new System.Drawing.Size(173, 23);
            this.buttonDurchschnittsNoten.TabIndex = 9;
            this.buttonDurchschnittsNoten.Text = "Durchschnittsnoten aller Fächer";
            this.buttonDurchschnittsNoten.UseVisualStyleBackColor = true;
            // 
            // buttonEnde
            // 
            this.buttonEnde.Location = new System.Drawing.Point(620, 409);
            this.buttonEnde.Name = "buttonEnde";
            this.buttonEnde.Size = new System.Drawing.Size(173, 23);
            this.buttonEnde.TabIndex = 10;
            this.buttonEnde.Text = "Ende";
            this.buttonEnde.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox1.Location = new System.Drawing.Point(6, 14);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(602, 418);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 441);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonEnde);
            this.Controls.Add(this.buttonDurchschnittsNoten);
            this.Controls.Add(this.buttonEntwicklungSchueler);
            this.Controls.Add(this.buttonEntwicklung);
            this.Controls.Add(this.buttonZeugnis);
            this.Controls.Add(this.buttonAlleSchueler);
            this.Controls.Add(this.buttonAlleSchulhalbjahre);
            this.Controls.Add(this.buttonAlleFachnamen);
            this.Controls.Add(this.buttonAlleFaecher);
            this.Controls.Add(this.buttonUebersicht);
            this.Controls.Add(this.buttonDatenbankOeffnen);
            this.Name = "Form1";
            this.Text = "Hello";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDatenbankOeffnen;
        private System.Windows.Forms.Button buttonUebersicht;
        private System.Windows.Forms.Button buttonAlleFaecher;
        private System.Windows.Forms.Button buttonAlleFachnamen;
        private System.Windows.Forms.Button buttonAlleSchulhalbjahre;
        private System.Windows.Forms.Button buttonAlleSchueler;
        private System.Windows.Forms.Button buttonZeugnis;
        private System.Windows.Forms.Button buttonEntwicklung;
        private System.Windows.Forms.Button buttonEntwicklungSchueler;
        private System.Windows.Forms.Button buttonDurchschnittsNoten;
        private System.Windows.Forms.Button buttonEnde;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

