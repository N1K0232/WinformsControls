using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace WinformsControls;

public partial class Clock : UserControl
{
    private Label lblClock;
    private Timer timerClock;

    private IContainer components = null;

    /// <summary>
    /// releases unmanaged resources
    /// </summary>
    /// <param name="disposing"></param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if(components != null)
            {
                components.Dispose();
            }

            if(lblClock != null)
            {
                lblClock.Dispose();
            }

            if(timerClock != null)
            {
                timerClock.Dispose();
            }
        }
        
        base.Dispose(disposing);
    }

    /// <summary>
    /// creates the graphic for this control
    /// </summary>
    private void InitializeComponent()
    {
        components = new Container();
        lblClock = new Label();
        timerClock = new Timer(components);
        
        SuspendLayout();

        lblClock.AutoSize = true;
        lblClock.BorderStyle = BorderStyle.FixedSingle;
        lblClock.FlatStyle = FlatStyle.Flat;
        lblClock.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
        lblClock.Location = new Point(50, 100);
        lblClock.Name = "lblClock";
        lblClock.Size = new Size(2, 48);
        lblClock.TabIndex = 0;
        lblClock.TextAlign = ContentAlignment.MiddleCenter;

        timerClock.Interval = 1000;
        timerClock.Tick += new EventHandler(Timer_OnTick);

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(lblClock);
        ForeColor = Color.Black;
        Name = "Clock";
        Size = new Size(200, 200);
        
        ResumeLayout(false);
        PerformLayout();
    }
}