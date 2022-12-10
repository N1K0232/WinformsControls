using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

public partial class ComboBlock : UserControl
{
    private static readonly Size defaultSize = new Size(200, 30);
    private static readonly Font defaultFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

    private ComboBox cmbList;
    private Label lblText;
    private Button btnIcon;

    private IContainer components = null;


    protected override void Dispose(bool disposing)
    {
        if(disposing)
        {
            if(cmbList != null)
            {
                cmbList.Dispose();
            }

            if(lblText != null)
            {
                lblText.Dispose();
            }

            if(btnIcon != null)
            {
                btnIcon.Dispose();
            }

            if(components != null)
            {
                components.Dispose();
            }
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// initializes the graphics for this control
    /// </summary>
    protected internal virtual void Initialize()
    {
        components = new Container();

        cmbList = new ComboBox();
        lblText = new Label();
        btnIcon = new Button();

        SuspendLayout();

        Color listBackColor = ListBackColor;
        Color listTextColor = ListTextColor;

        Color backColor = BackColor;
        Color borderColor = BorderColor;

        int borderSize = BorderSize;

        cmbList.BackColor = listBackColor;
        cmbList.ForeColor = listTextColor;
        cmbList.Font = defaultFont;
        cmbList.TabIndex = 0;
        cmbList.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbList.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
        cmbList.TextChanged += new EventHandler(OnTextChanged);

        btnIcon.Dock = DockStyle.Right;
        btnIcon.FlatStyle = FlatStyle.Flat;
        btnIcon.FlatAppearance.BorderSize = 0;
        btnIcon.BackColor = backColor;
        btnIcon.Size = new Size(30, 30);
        btnIcon.Cursor = Cursors.Hand;
        btnIcon.TabIndex = 1;
        btnIcon.Click += new EventHandler(OnIconClick);
        btnIcon.Paint += new PaintEventHandler(OnIconPaint);

        lblText.Dock = DockStyle.Fill;
        lblText.AutoSize = false;
        lblText.BackColor = backColor;
        lblText.TextAlign = ContentAlignment.MiddleLeft;
        lblText.Padding = new Padding(8, 0, 0, 0);
        lblText.Font = defaultFont;
        lblText.TabIndex = 2;
        lblText.Click += new EventHandler(OnSurfaceClick);
        lblText.MouseEnter += new EventHandler(OnSurfaceEnter);
        lblText.MouseLeave += new EventHandler(OnSurfaceLeave);

        Controls.Add(lblText);
        Controls.Add(btnIcon);
        Controls.Add(cmbList);
        Font = defaultFont;
        ForeColor = Color.DimGray;
        MinimumSize = defaultSize;
        Size = defaultSize;
        Padding = new Padding(borderSize);

        base.BackColor = borderColor;

        ResumeLayout(false);
        PerformLayout();
        AdjustComboBoxDimensions();
    }

    /// <summary>
    /// paints the icon button
    /// </summary>
    /// <param name="sender">the object that invoked the event</param>
    /// <param name="e">the event data</param>
    private void OnIconPaint(object sender, PaintEventArgs e)
    {
        Color iconColor = IconColor;

        int iconWidth = 14;
        int iconHeight = 6;

        int x = (btnIcon.Width - iconWidth) / 2;
        int y = (btnIcon.Height - iconHeight) / 2;

        var rectIcon = new Rectangle(x, y, iconWidth, iconHeight);

        Graphics graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        using var path = new GraphicsPath();
        using var pen = new Pen(iconColor, 2);

        path.AddLine(x, y, x + (iconWidth / 2), rectIcon.Bottom);
        path.AddLine(x + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, y);
        
        graphics.DrawPath(pen, path);
    }

    /// <summary>
    /// updates the location of the combo box when the control is resized
    /// </summary>
    private void AdjustComboBoxDimensions()
    {
        int x = Width - Padding.Right - cmbList.Width;
        int y = lblText.Bottom - cmbList.Height;

        var updatedLocation = new Point(x, y);
        cmbList.Width = lblText.Width;
        cmbList.Location = updatedLocation;
    }
}