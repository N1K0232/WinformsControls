﻿using WinformsControls;
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
            if(components != null)
            {
                components.Dispose();
            }

            Controls.RemoveRange();
        }
        
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.firstButton = new WinformsControls.RoundButton();
            this.toggleButton = new WinformsControls.ToggleButton();
            this.cuteButton1 = new WinformsControls.CuteButton();
            this.customDateTimePicker1 = new WinformsControls.CustomDateTimePicker();
            this.buttonWoc1 = new WinformsControls.ButtonWoc();
            this.clock1 = new WinformsControls.Clock();
            this.circularPictureBox1 = new WinformsControls.CircularPictureBox();
            this.comboBlock1 = new WinformsControls.ComboBlock();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
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
            this.cuteButton1.BorderSize = 0;
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
            // buttonWoc1
            // 
            this.buttonWoc1.BackColor = System.Drawing.Color.Transparent;
            this.buttonWoc1.BorderColor = System.Drawing.Color.Red;
            this.buttonWoc1.ButtonColor = System.Drawing.Color.Blue;
            this.buttonWoc1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonWoc1.FlatAppearance.BorderSize = 0;
            this.buttonWoc1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonWoc1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonWoc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWoc1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonWoc1.HoverBorderColor = System.Drawing.Color.Black;
            this.buttonWoc1.HoverButtonColor = System.Drawing.Color.Yellow;
            this.buttonWoc1.HoverTextColor = System.Drawing.Color.Red;
            this.buttonWoc1.Location = new System.Drawing.Point(677, 412);
            this.buttonWoc1.MinimumSize = new System.Drawing.Size(150, 50);
            this.buttonWoc1.Name = "buttonWoc1";
            this.buttonWoc1.Size = new System.Drawing.Size(188, 62);
            this.buttonWoc1.TabIndex = 6;
            this.buttonWoc1.Text = "buttonWoc1";
            this.buttonWoc1.TextColor = System.Drawing.Color.White;
            this.buttonWoc1.UseVisualStyleBackColor = false;
            // 
            // clock1
            // 
            this.clock1.BackColor = System.Drawing.Color.White;
            this.clock1.ForeColor = System.Drawing.Color.Black;
            this.clock1.Location = new System.Drawing.Point(200, 311);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(250, 250);
            this.clock1.TabIndex = 7;
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Round;
            this.circularPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.circularPictureBox1.BorderSize = 5;
            this.circularPictureBox1.GradientAngle = 50F;
            this.circularPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("circularPictureBox1.Image")));
            this.circularPictureBox1.Location = new System.Drawing.Point(725, 135);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.PrimaryBorderColor = System.Drawing.Color.RoyalBlue;
            this.circularPictureBox1.SecondaryBorderColor = System.Drawing.Color.HotPink;
            this.circularPictureBox1.Size = new System.Drawing.Size(125, 125);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circularPictureBox1.TabIndex = 8;
            this.circularPictureBox1.TabStop = false;
            // 
            // comboBlock1
            // 
            this.comboBlock1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.comboBlock1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.comboBlock1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBlock1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.comboBlock1.BorderSize = 3;
            this.comboBlock1.DataSource = null;
            this.comboBlock1.DisplayMember = "";
            this.comboBlock1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.comboBlock1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBlock1.ForeColor = System.Drawing.Color.DimGray;
            this.comboBlock1.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.comboBlock1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.comboBlock1.ListTextColor = System.Drawing.Color.DimGray;
            this.comboBlock1.Location = new System.Drawing.Point(28, 51);
            this.comboBlock1.MinimumSize = new System.Drawing.Size(200, 30);
            this.comboBlock1.Name = "comboBlock1";
            this.comboBlock1.Padding = new System.Windows.Forms.Padding(1);
            this.comboBlock1.SelectedIndex = -1;
            this.comboBlock1.SelectedItem = null;
            this.comboBlock1.Size = new System.Drawing.Size(262, 38);
            this.comboBlock1.TabIndex = 9;
            this.comboBlock1.ValueMember = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(993, 620);
            this.Controls.Add(this.comboBlock1);
            this.Controls.Add(this.circularPictureBox1);
            this.Controls.Add(this.clock1);
            this.Controls.Add(this.buttonWoc1);
            this.Controls.Add(this.customDateTimePicker1);
            this.Controls.Add(this.cuteButton1);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.toggleButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MainForm";
            this.Text = "Control test";
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);

    }

    private RoundButton firstButton;
    private ToggleButton toggleButton;
    private CuteButton cuteButton1;
    private CustomDateTimePicker customDateTimePicker1;
    private ButtonWoc buttonWoc1;
    private Clock clock1;
    private CircularPictureBox circularPictureBox1;
    private ComboBlock comboBlock1;
}