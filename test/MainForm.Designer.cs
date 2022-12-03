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
            this.cuteButton1 = new WinformsControls.CuteButton();
            this.clock1 = new WinformsControls.Clock();
            this.customDateTimePicker1 = new WinformsControls.CustomDateTimePicker();
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
            // clock1
            // 
            this.clock1.BackColor = System.Drawing.Color.White;
            this.clock1.ForeColor = System.Drawing.Color.Black;
            this.clock1.Location = new System.Drawing.Point(327, 358);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(250, 250);
            this.clock1.TabIndex = 4;
            // 
            // customDateTimePicker1
            // 
            this.customDateTimePicker1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.customDateTimePicker1.BorderSize = 0;
            this.customDateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customDateTimePicker1.Location = new System.Drawing.Point(340, 85);
            this.customDateTimePicker1.MinimumSize = new System.Drawing.Size(0, 35);
            this.customDateTimePicker1.Name = "customDateTimePicker1";
            this.customDateTimePicker1.Size = new System.Drawing.Size(250, 35);
            this.customDateTimePicker1.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.customDateTimePicker1.TabIndex = 5;
            this.customDateTimePicker1.TextColor = System.Drawing.Color.White;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(993, 620);
            this.Controls.Add(this.customDateTimePicker1);
            this.Controls.Add(this.clock1);
            this.Controls.Add(this.cuteButton1);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.toggleButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MainForm";
            this.Text = "Control test";
            this.ResumeLayout(false);

    }

    private RoundButton firstButton;
    private ToggleButton toggleButton;
    private CuteButton cuteButton1;
    private Clock clock1;
    private CustomDateTimePicker customDateTimePicker1;
}