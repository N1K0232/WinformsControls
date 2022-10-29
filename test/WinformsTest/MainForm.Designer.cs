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
        firstButton = new RoundButton();
        toggleButton = new ToggleButton();
        SuspendLayout();

        firstButton.BackColor = Color.RoyalBlue;
        firstButton.BorderColor = Color.PaleVioletRed;
        firstButton.BorderRadius = 40;
        firstButton.BorderSize = 2;
        firstButton.FlatAppearance.BorderSize = 0;
        firstButton.FlatStyle = FlatStyle.Flat;
        firstButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        firstButton.ForeColor = Color.White;
        firstButton.Location = new Point(310, 196);
        firstButton.Name = "firstButton";
        firstButton.Size = new Size(188, 74);
        firstButton.TabIndex = 0;
        firstButton.Text = "First button";
        firstButton.UseVisualStyleBackColor = false;

        toggleButton.Location = new Point(200, 200);
        toggleButton.UseVisualStyleBackColor = false;
        toggleButton.TabIndex = 1;
        toggleButton.MinimumSize = new Size(90, 45);
        toggleButton.Size = new Size(90, 45);
        toggleButton.OnSliderColor = Color.RoyalBlue;
        toggleButton.OffSliderColor = Color.Gray;
        toggleButton.OnToggleColor = Color.WhiteSmoke;
        toggleButton.OffToggleColor = Color.Gainsboro;
        toggleButton.Name = "toggleButton";

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(800, 450);
        Controls.Add(firstButton);
        Controls.Add(toggleButton);
        ForeColor = Color.Black;
        Name = "MainForm";
        Text = "Control test";
        ResumeLayout(false);
    }

    private RoundButton firstButton;
    private ToggleButton toggleButton;
}