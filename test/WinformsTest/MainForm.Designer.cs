using WinformsControls;
using System.ComponentModel;
using WinformsControls.Extensions;

namespace WinformsTest;

public partial class MainForm : Form
{
    private IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }

            Controls.RemoveRange();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
        firstButton = new RoundButton();
        toggleButton = new ToggleButton();
        cuteButton1 = new CuteButton();
        customDateTimePicker1 = new CustomDateTimePicker();
        buttonWoc1 = new ButtonWoc();
        clock1 = new Clock();
        circularPictureBox1 = new CircularPictureBox();
        textBlock1 = new TextBlock();
        ((ISupportInitialize)circularPictureBox1).BeginInit();
        SuspendLayout();
        // 
        // firstButton
        // 
        firstButton.BackColor = Color.RoyalBlue;
        firstButton.BorderColor = Color.PaleVioletRed;
        firstButton.BorderFocusColor = Color.Red;
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
        // 
        // toggleButton
        // 
        toggleButton.Location = new Point(200, 200);
        toggleButton.MinimumSize = new Size(90, 45);
        toggleButton.Name = "toggleButton";
        toggleButton.OffSliderColor = Color.Gray;
        toggleButton.OffToggleColor = Color.Gainsboro;
        toggleButton.OnSliderColor = Color.RoyalBlue;
        toggleButton.OnToggleColor = Color.WhiteSmoke;
        toggleButton.Size = new Size(90, 45);
        toggleButton.SolidStyle = true;
        toggleButton.TabIndex = 1;
        toggleButton.UseVisualStyleBackColor = false;
        // 
        // cuteButton1
        // 
        cuteButton1.Angle = 10F;
        cuteButton1.BorderColor = Color.Magenta;
        cuteButton1.BorderFocusColor = Color.DarkMagenta;
        cuteButton1.BorderSize = 0;
        cuteButton1.FirstColor = Color.Yellow;
        cuteButton1.FirstColorTransparency = 80;
        cuteButton1.FlatAppearance.BorderColor = Color.White;
        cuteButton1.FlatAppearance.BorderSize = 0;
        cuteButton1.FlatStyle = FlatStyle.Flat;
        cuteButton1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        cuteButton1.ForeColor = Color.Black;
        cuteButton1.Location = new Point(542, 223);
        cuteButton1.Name = "cuteButton1";
        cuteButton1.SecondColor = Color.RoyalBlue;
        cuteButton1.SecondColorTransparency = 80;
        cuteButton1.Size = new Size(150, 62);
        cuteButton1.TabIndex = 3;
        cuteButton1.Text = "cuteButton1";
        cuteButton1.UseVisualStyleBackColor = true;
        // 
        // customDateTimePicker1
        // 
        customDateTimePicker1.BorderColor = Color.PaleVioletRed;
        customDateTimePicker1.BorderSize = 0;
        customDateTimePicker1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        customDateTimePicker1.Location = new Point(340, 85);
        customDateTimePicker1.MinimumSize = new Size(0, 35);
        customDateTimePicker1.Name = "customDateTimePicker1";
        customDateTimePicker1.Size = new Size(250, 35);
        customDateTimePicker1.SkinColor = Color.MediumSlateBlue;
        customDateTimePicker1.TabIndex = 5;
        customDateTimePicker1.TextColor = Color.White;
        // 
        // buttonWoc1
        // 
        buttonWoc1.BackColor = Color.Transparent;
        buttonWoc1.BorderColor = Color.Red;
        buttonWoc1.ButtonColor = Color.Blue;
        buttonWoc1.FlatAppearance.BorderColor = Color.White;
        buttonWoc1.FlatAppearance.BorderSize = 0;
        buttonWoc1.FlatAppearance.MouseDownBackColor = Color.White;
        buttonWoc1.FlatAppearance.MouseOverBackColor = Color.White;
        buttonWoc1.FlatStyle = FlatStyle.Flat;
        buttonWoc1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        buttonWoc1.HoverBorderColor = Color.Black;
        buttonWoc1.HoverButtonColor = Color.Yellow;
        buttonWoc1.HoverTextColor = Color.Red;
        buttonWoc1.Location = new Point(677, 412);
        buttonWoc1.MinimumSize = new Size(150, 50);
        buttonWoc1.Name = "buttonWoc1";
        buttonWoc1.Size = new Size(188, 62);
        buttonWoc1.TabIndex = 6;
        buttonWoc1.Text = "buttonWoc1";
        buttonWoc1.TextColor = Color.White;
        buttonWoc1.UseVisualStyleBackColor = false;
        // 
        // clock1
        // 
        clock1.BackColor = Color.White;
        clock1.ForeColor = Color.Black;
        clock1.Location = new Point(200, 311);
        clock1.Name = "clock1";
        clock1.Size = new Size(250, 250);
        clock1.TabIndex = 7;
        // 
        // circularPictureBox1
        // 
        circularPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Round;
        circularPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
        circularPictureBox1.BorderSize = 5;
        circularPictureBox1.GradientAngle = 50F;
        circularPictureBox1.Image = (Image)resources.GetObject("circularPictureBox1.Image");
        circularPictureBox1.Location = new Point(725, 135);
        circularPictureBox1.Name = "circularPictureBox1";
        circularPictureBox1.PrimaryBorderColor = Color.RoyalBlue;
        circularPictureBox1.SecondaryBorderColor = Color.HotPink;
        circularPictureBox1.Size = new Size(125, 125);
        circularPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        circularPictureBox1.TabIndex = 8;
        circularPictureBox1.TabStop = false;
        // 
        // textBlock1
        // 
        textBlock1.BorderColor = Color.Blue;
        textBlock1.Location = new Point(41, 58);
        textBlock1.Name = "textBlock1";
        textBlock1.Size = new Size(194, 27);
        textBlock1.TabIndex = 9;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(993, 620);
        Controls.Add(textBlock1);
        Controls.Add(circularPictureBox1);
        Controls.Add(clock1);
        Controls.Add(buttonWoc1);
        Controls.Add(customDateTimePicker1);
        Controls.Add(cuteButton1);
        Controls.Add(firstButton);
        Controls.Add(toggleButton);
        ForeColor = Color.Black;
        Name = "MainForm";
        Text = "Control test";
        ((ISupportInitialize)circularPictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private RoundButton firstButton;
    private ToggleButton toggleButton;
    private CuteButton cuteButton1;
    private CustomDateTimePicker customDateTimePicker1;
    private ButtonWoc buttonWoc1;
    private Clock clock1;
    private CircularPictureBox circularPictureBox1;
    private TextBlock textBlock1;
}