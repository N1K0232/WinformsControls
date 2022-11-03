using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Globalization;
using WinformsControls.Properties;

namespace WinformsControls;

/// <summary>
/// defines a custom <see cref="DateTimePicker"/> control
/// </summary>
public partial class CustomDateTimePicker : DateTimePicker
{
    private const int CalendarIconWidth = 34;
    private const int ArrowIconWidth = 17;

    private readonly Resources resources = new() { ResourceCulture = CultureInfo.CurrentCulture };

    private Color _skinColor = Color.MediumSlateBlue;
    private Color _textColor = Color.White;
    private Color _borderColor = Color.PaleVioletRed;

    private int _borderSize = 0;

    private Image _calendarIcon;

    private bool _droppedDown = false;

    private RectangleF _iconButtonArea;


    /// <summary>
    /// creates a new instance of the <see cref="CustomDateTimePicker"/> control
    /// </summary>
    public CustomDateTimePicker()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.ResizeRedraw, true);

        SetStyle(ControlStyles.Opaque, false);

        SetStyle(ControlStyles.ContainerControl, false);

        MinimumSize = new Size(0, 35);
        Size = new Size(150, 40);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        CalendarIcon = resources.CalendarWhite;
    }

    /// <summary>
    /// gets or sets the skin color of the control and changes the icon
    /// based on the brightness of the color
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public Color SkinColor
    {
        get
        {
            return _skinColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(SkinColor));
            }

            if (value == SkinColor)
            {
                return;
            }

            _skinColor = value;

            Image calendarIcon;
            float colorBrightness = value.GetBrightness();

            if (colorBrightness > 0.6F)
            {
                calendarIcon = resources.CalendarDark;
            }
            else
            {
                calendarIcon = resources.CalendarWhite;
            }

            CalendarIcon = calendarIcon;
            Invalidate();
        }
    }

    /// <summary>
    /// gets or sets the text color of the control
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public Color TextColor
    {
        get
        {
            return _textColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(TextColor));
            }

            if (value == TextColor)
            {
                return;
            }

            _textColor = value;
            Invalidate();
        }
    }

    /// <summary>
    /// gets or sets the border color of the control
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public Color BorderColor
    {
        get
        {
            return _borderColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("Invalid color", nameof(BorderColor));
            }

            if (value == BorderColor)
            {
                return;
            }

            _borderColor = value;
            Invalidate();
        }
    }

    /// <summary>
    /// gets or sets the border size of the control
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public int BorderSize
    {
        get
        {
            return _borderSize;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid value", nameof(BorderSize));
            }

            if (value == BorderSize)
            {
                return;
            }

            _borderSize = value;
            Invalidate();
        }
    }

    /// <summary>
    /// gets or sets the <see cref="Text"/> of the control
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public override string Text
    {
        get
        {
            return base.Text;
        }
        set
        {
            if (value == Text)
            {
                return;
            }

            base.Text = value;
        }
    }

    /// <summary>
    /// gets or sets the icon of the control
    /// </summary>
    protected virtual Image CalendarIcon
    {
        get => _calendarIcon;
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid image", nameof(CalendarIcon));
            }

            if (value == CalendarIcon)
            {
                return;
            }

            _calendarIcon = value;
        }
    }

    /// <summary>
    /// gets or sets the area of the icon
    /// </summary>
    protected virtual RectangleF IconButtonArea
    {
        get => _iconButtonArea;
        set
        {
            if (value == IconButtonArea)
            {
                return;
            }

            _iconButtonArea = value;
        }
    }

    private bool DroppedDown => _droppedDown;

    /// <summary>
    /// raises the <see cref="DateTimePicker.DropDown"/> event
    /// </summary>
    /// <param name="eventargs"></param>
    protected override void OnDropDown(EventArgs eventargs)
    {
        base.OnDropDown(eventargs);

        _droppedDown = true;
    }

    /// <summary>
    /// raises the <see cref="DateTimePicker.CloseUp"/> event
    /// </summary>
    /// <param name="eventargs"></param>
    protected override void OnCloseUp(EventArgs eventargs)
    {
        base.OnCloseUp(eventargs);

        _droppedDown = false;
    }

    /// <summary>
    /// updates the area of the icon
    /// </summary>
    /// <param name="e"></param>
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        int currentWidth = Width;
        int currentHeight = Height;
        int iconWidth = GetIconButtonWidth();

        int width = currentWidth - iconWidth;

        IconButtonArea = new RectangleF(width, 0, iconWidth, currentHeight);
    }

    /// <summary>
    /// raises the <see cref="Control.MouseMove"/> event and changes the <see cref="Control.Cursor"/>
    /// property when the mouse enters the icon area
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        Point currentLocation = e.Location;
        RectangleF iconArea = IconButtonArea;

        if (iconArea.Contains(currentLocation))
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.Default;
        }
    }

    /// <summary>
    /// Raises the <see cref="Control.KeyPress"/> event 
    /// </summary>
    /// <param name="e"></param>
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        e.Handled = true;
    }

    /// <summary>
    /// redraws the control
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPaint(PaintEventArgs e)
    {
        Control parent = Parent;
        Graphics graphics = CreateGraphics();

        graphics.Clear(parent.BackColor);
        graphics.SmoothingMode = SmoothingMode.Default;

        int width = Width;
        int height = Height;

        RectangleF clientArea = new(0, 0, width - 0.5F, height - 0.5F);

        DrawControl(graphics, width, height, clientArea);
        DrawString(graphics, clientArea);
    }

    /// <summary>
    /// draws the border, fills the control and draws the icon of the control
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="clientArea"></param>
    private void DrawControl(Graphics graphics, int width, int height, RectangleF clientArea)
    {
        bool droppedDown = DroppedDown;

        int iconWidth = CalendarIconWidth;

        Color borderColor = BorderColor;
        int borderSize = BorderSize;
        Pen borderPen = new(borderColor, borderSize);

        Color skinColor = SkinColor;
        Brush skinBrush = new SolidBrush(skinColor);

        Color iconColor = Color.FromArgb(50, 64, 64, 64);
        Brush iconBrush = new SolidBrush(iconColor);
        Image calendarIcon = CalendarIcon;

        borderPen.Alignment = PenAlignment.Inset;

        RectangleF iconArea = new(clientArea.Width - iconWidth, 0, iconWidth, clientArea.Height);

        graphics.FillRectangle(skinBrush, clientArea);

        if (droppedDown)
        {
            graphics.FillRectangle(iconBrush, iconArea);
        }

        if (borderSize >= 1)
        {
            graphics.DrawRectangle(borderPen, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
        }

        graphics.DrawImage(calendarIcon, width - calendarIcon.Width - 9, (height - calendarIcon.Height) / 2);
    }

    /// <summary>
    /// draws the text of the control
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="clientArea"></param>
    private void DrawString(Graphics graphics, RectangleF clientArea)
    {
        Color textColor = TextColor;
        Brush textBrush = new SolidBrush(textColor);
        StringFormat textFormat = new();
        StringAlignment dateAlignment = StringAlignment.Center;

        string text = Text;
        Font font = Font;

        textFormat.LineAlignment = dateAlignment;
        textFormat.Alignment = dateAlignment;
        textFormat.Trimming = StringTrimming.Character;

        graphics.DrawString(text, font, textBrush, clientArea, textFormat);
    }

    /// <summary>
    /// gets the width of the icon button
    /// </summary>
    /// <returns></returns>
    private int GetIconButtonWidth()
    {
        int currentWidth = Width;

        string text = Text;
        Font font = Font;

        Size textSize = TextRenderer.MeasureText(text, font);
        int textWidth = textSize.Width;

        if (textWidth <= currentWidth - (CalendarIconWidth + 20))
        {
            return CalendarIconWidth;
        }

        return ArrowIconWidth;
    }
}