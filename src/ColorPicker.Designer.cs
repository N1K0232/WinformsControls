using System.ComponentModel;

namespace WinformsControls;

public partial class ColorPicker : UserControl
{
    private IContainer components = null; //designer field

    private TrackBar redTrackbar;
    private TrackBar greenTrackbar;
    private TrackBar blueTrackbar;
    private TextBox txtRed;
    private TextBox txtGreen;
    private TextBox txtBlue;
    private Panel colorPanel;

    protected override void Dispose(bool disposing)
    {
        if(disposing && components != null)
        {
            components.Dispose();
        }

        DisposeCore(disposing);
        base.Dispose(disposing);
    }

    private void DisposeCore(bool disposing)
    {
        if(disposing)
        {
            redTrackbar.Dispose();
            greenTrackbar.Dispose();
            blueTrackbar.Dispose();
            txtRed.Dispose();
            txtGreen.Dispose();
            txtBlue.Dispose();
            colorPanel.Dispose();
        }
    }

    /// <summary>
    /// initializes the control
    /// </summary>
    private void InitializeComponent()
    {
        redTrackbar = new TrackBar();
        greenTrackbar = new TrackBar();
        blueTrackbar = new TrackBar();
        txtRed = new TextBox();
        txtGreen = new TextBox();
        txtBlue = new TextBox();
        colorPanel = new Panel();
        
        redTrackbar.BeginInit();
        greenTrackbar.BeginInit();
        blueTrackbar.BeginInit();
        
        SuspendLayout();

        redTrackbar.Location = new Point(8, 12);
        redTrackbar.Name = "redTrackbar";
        redTrackbar.Size = new Size(795, 56);
        redTrackbar.TabIndex = 0;
        redTrackbar.Scroll += new EventHandler(OnScroll);
 
        greenTrackbar.Location = new Point(8, 74);
        greenTrackbar.Maximum = 255;
        greenTrackbar.Name = "greenTrackbar";
        greenTrackbar.Size = new Size(795, 56);
        greenTrackbar.TabIndex = 1;
        greenTrackbar.Scroll += new EventHandler(OnScroll);
        
        blueTrackbar.Location = new Point(8, 136);
        blueTrackbar.Name = "blueTrackbar";
        blueTrackbar.Size = new Size(795, 56);
        blueTrackbar.TabIndex = 2;
        blueTrackbar.Scroll += new EventHandler(OnScroll);

        txtRed.BackColor = Color.White;
        txtRed.ForeColor = Color.Red;
        txtRed.Location = new Point(837, 12);
        txtRed.Name = "txtRed";
        txtRed.Size = new Size(125, 27);
        txtRed.TabIndex = 3;

        txtGreen.BackColor = Color.White;
        txtGreen.ForeColor = Color.Green;
        txtGreen.Location = new Point(837, 74);
        txtGreen.Name = "txtGreen";
        txtGreen.Size = new Size(125, 27);
        txtGreen.TabIndex = 4;

        txtBlue.BackColor = Color.White;
        txtBlue.ForeColor = Color.Blue;
        txtBlue.Location = new Point(837, 136);
        txtBlue.Name = "txtBlue";
        txtBlue.Size = new Size(125, 27);
        txtBlue.TabIndex = 5;

        colorPanel.Location = new Point(3, 198);
        colorPanel.Name = "colorPanel";
        colorPanel.Size = new Size(994, 399);
        colorPanel.TabIndex = 6;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(colorPanel);
        Controls.Add(txtBlue);
        Controls.Add(txtGreen);
        Controls.Add(txtRed);
        Controls.Add(blueTrackbar);
        Controls.Add(greenTrackbar);
        Controls.Add(redTrackbar);
        Name = "ColorPicker";
        Size = new Size(1000, 600);
        
        redTrackbar.EndInit();
        greenTrackbar.EndInit();
        blueTrackbar.EndInit();
        
        ResumeLayout(false);
        PerformLayout();
    }
}