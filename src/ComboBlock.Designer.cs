using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

public partial class ComboBlock
{
    private static readonly Size s_defaultSize = new Size(200, 30);
    private static readonly Font s_defaultFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

    
    private ComboBox _cmbList = null;
    private Label _lblText = null;
    private Button _btnIcon = null;

    private IContainer _components = null;


    protected override void Dispose(bool disposing)
    {
        if(disposing)
        {
            if(_cmbList != null)
            {
                _cmbList.Dispose();
            }

            if(_lblText != null)
            {
                _lblText.Dispose();
            }

            if(_btnIcon != null)
            {
                _btnIcon.Dispose();
            }

            if(_components != null)
            {
                _components.Dispose();
            }
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// initializes the graphics for this control
    /// </summary>
    protected internal virtual void Initialize()
    {
        _components = new Container();
        _cmbList = new ComboBox();
        _lblText = new Label();
        _btnIcon = new Button();

        SuspendLayout();

        Color listBackColor = ListBackColor;
        Color listTextColor = ListTextColor;

        Color backColor = BackColor;
        Color borderColor = BorderColor;

        int borderSize = BorderSize;

        _cmbList.BackColor = listBackColor;
        _cmbList.ForeColor = listTextColor;
        _cmbList.Font = s_defaultFont;
        _cmbList.DropDownStyle = ComboBoxStyle.DropDownList;
        _cmbList.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
        _cmbList.TextChanged += new EventHandler(OnTextChanged);

        _btnIcon.Dock = DockStyle.Right;
        _btnIcon.FlatStyle = FlatStyle.Flat;
        _btnIcon.FlatAppearance.BorderSize = 0;
        _btnIcon.BackColor = backColor;
        _btnIcon.Size = new Size(30, 30);
        _btnIcon.Cursor = Cursors.Hand;
        _btnIcon.Click += new EventHandler(OnIconClick);
        _btnIcon.Paint += new PaintEventHandler(OnIconPaint);

        _lblText.Dock = DockStyle.Fill;
        _lblText.AutoSize = false;
        _lblText.BackColor = backColor;
        _lblText.TextAlign = ContentAlignment.MiddleLeft;
        _lblText.Padding = new Padding(8, 0, 0, 0);
        _lblText.Font = s_defaultFont;
        _lblText.Click += new EventHandler(OnSurfaceClick);
        _lblText.MouseEnter += new EventHandler(OnSurfaceEnter);
        _lblText.MouseLeave += new EventHandler(OnSurfaceLeave);

        Controls.Add(_lblText);
        Controls.Add(_btnIcon);
        Controls.Add(_cmbList);
        Font = s_defaultFont;
        ForeColor = Color.DimGray;
        MinimumSize = s_defaultSize;
        Size = s_defaultSize;
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
        if (sender is not null && sender is Button button && button.Name.Equals(_btnIcon.Name))
        {
            Color iconColor = IconColor;

            int iconWidth = 14;
            int iconHeight = 6;

            int x = (_btnIcon.Width - iconWidth) / 2;
            int y = (_btnIcon.Height - iconHeight) / 2;

            var rectIcon = new Rectangle(x, y, iconWidth, iconHeight);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var path = new GraphicsPath();
            using var pen = new Pen(iconColor, 2);

            path.AddLine(x, y, x + (iconWidth / 2), rectIcon.Bottom);
            path.AddLine(x + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, y);

            graphics.DrawPath(pen, path);
        }
    }

    /// <summary>
    /// updates the location of the combo box when the control is resized
    /// </summary>
    private void AdjustComboBoxDimensions()
    {
        int x = Width - Padding.Right - _cmbList.Width;
        int y = _lblText.Bottom - _cmbList.Height;

        var updatedLocation = new Point(x, y);
        _cmbList.Width = _lblText.Width;
        _cmbList.Location = updatedLocation;
    }
}