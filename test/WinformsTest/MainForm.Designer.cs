using WinformsControls;
using System.ComponentModel;

namespace WinformsTest;

public partial class MainForm : Form
{
    private IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.firstButton = new WinformsControls.RoundButton();
            this.toggleButton = new WinformsControls.ToggleButton();
            this.textBlock1 = new WinformsControls.TextBlock();
            this.cuteButton1 = new WinformsControls.CuteButton();
            this.SuspendLayout();
            // 
            // firstButton
            // 
            this.firstButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.firstButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.firstButton.BorderFocusColor = System.Drawing.Color.Red;
            this.firstButton.BorderRadius = 40;
            this.firstButton.BorderSize = 2;
            this.firstButton.FlatAppearance.BorderSize = 0;
            this.firstButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.firstButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstButton.ForeColor = System.Drawing.Color.White;
            this.firstButton.Location = new System.Drawing.Point(310, 196);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(188, 74);
            this.firstButton.TabIndex = 0;
            this.firstButton.Text = "First button";
            this.firstButton.UseVisualStyleBackColor = false;
            // 
            // toggleButton
            // 
            this.toggleButton.Location = new System.Drawing.Point(200, 200);
            this.toggleButton.MinimumSize = new System.Drawing.Size(90, 45);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.OffSliderColor = System.Drawing.Color.Gray;
            this.toggleButton.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton.OnSliderColor = System.Drawing.Color.RoyalBlue;
            this.toggleButton.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton.Size = new System.Drawing.Size(90, 45);
            this.toggleButton.SolidStyle = true;
            this.toggleButton.TabIndex = 1;
            this.toggleButton.UseVisualStyleBackColor = false;
            // 
            // textBlock1
            // 
            this.textBlock1.BackColor = System.Drawing.Color.White;
            this.textBlock1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.textBlock1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBlock1.BorderSize = 2;
            this.textBlock1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBlock1.ForeColor = System.Drawing.Color.Gray;
            this.textBlock1.Location = new System.Drawing.Point(283, 52);
            this.textBlock1.Margin = new System.Windows.Forms.Padding(4);
            this.textBlock1.Multiline = false;
            this.textBlock1.Name = "textBlock1";
            this.textBlock1.Padding = new System.Windows.Forms.Padding(7);
            this.textBlock1.PasswordChar = '\0';
            this.textBlock1.PlaceholderColor = System.Drawing.Color.Gray;
            this.textBlock1.PlaceholderText = "";
            this.textBlock1.Size = new System.Drawing.Size(312, 36);
            this.textBlock1.TabIndex = 2;
            this.textBlock1.UnderlinedStyle = false;
            this.textBlock1.UseSystemPasswordChar = false;
            // 
            // cuteButton1
            // 
            this.cuteButton1.Angle = 10F;
            this.cuteButton1.BorderColor = System.Drawing.Color.Magenta;
            this.cuteButton1.BorderFocusColor = System.Drawing.Color.DarkMagenta;
            this.cuteButton1.FirstColor = System.Drawing.Color.Yellow;
            this.cuteButton1.FirstColorTransparency = 80;
            this.cuteButton1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cuteButton1.FlatAppearance.BorderSize = 0;
            this.cuteButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuteButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cuteButton1.ForeColor = System.Drawing.Color.Black;
            this.cuteButton1.Location = new System.Drawing.Point(542, 223);
            this.cuteButton1.Name = "cuteButton1";
            this.cuteButton1.SecondColor = System.Drawing.Color.RoyalBlue;
            this.cuteButton1.SecondColorTransparency = 80;
            this.cuteButton1.Size = new System.Drawing.Size(150, 62);
            this.cuteButton1.TabIndex = 3;
            this.cuteButton1.Text = "cuteButton1";
            this.cuteButton1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cuteButton1);
            this.Controls.Add(this.textBlock1);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.toggleButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MainForm";
            this.Text = "Control test";
            this.ResumeLayout(false);

    }

    private RoundButton firstButton;
    private ToggleButton toggleButton;
    private TextBlock textBlock1;
    private CuteButton cuteButton1;
}