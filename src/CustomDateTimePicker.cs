using System.ComponentModel;
using WinformsControls.Properties;

namespace WinformsControls;

/// <summary>
/// represents a custom <see cref="DateTimePicker"/> control
/// </summary>
public partial class CustomDateTimePicker : DateTimePicker
{
    private static readonly object s_skinColorChanged = new();
    private static readonly object s_textColorChanged = new();
    private static readonly object s_borderColorChanged = new();
    private static readonly object s_borderSizeChanged = new();

    private const int CalendarIconWidth = 34;
    private const int ArrowIconWidth = 17;

    private Color _skinColor = Color.MediumSlateBlue;
    private Color _textColor = Color.White;
    private Color _borderColor = Color.PaleVioletRed;

    private int _borderSize = 0;
    private bool _droppedDown = false;

    private RectangleF _iconButtonArea;
    private Image _calendarIcon = Resources.CalendarWhite;


    /// <summary>
    /// creates a new instance of the <see cref="CustomDateTimePicker"/> class
    /// </summary>
    public CustomDateTimePicker()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.ResizeRedraw, true);

        SetStyle(ControlStyles.Opaque, false);
        SetStyle(ControlStyles.ContainerControl, false);

        MinimumSize = new Size(0, 35);
        Font = new Font("Segoe UI", 9.5F);
    }


    /// <summary>
    /// gets or sets the fill color
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public virtual Color SkinColor
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

            SetCalendarIcon(value);
            Invalidate();
            OnSkinColorChanged(EventArgs.Empty);
        }
    }


    /// <summary>
    /// gets or sets the color of the text
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public virtual Color TextColor
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
            OnTextColorChanged(EventArgs.Empty);
        }
    }


    /// <summary>
    /// gets or sets the border color
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public virtual Color BorderColor
    {
        get
        {
            return _borderColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(BorderColor));
            }

            if (value == BorderColor)
            {
                return;
            }

            _borderColor = value;

            Invalidate();
            OnBorderColorChanged(EventArgs.Empty);
        }
    }


    /// <summary>
    /// gets or sets the size of the border
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public virtual int BorderSize
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
            OnBorderSizeChanged(EventArgs.Empty);
        }
    }


    /// <summary>
    /// gets or sets the icon for this control appearance
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private Image CalendarIcon
    {
        get
        {
            return _calendarIcon;
        }
        set
        {
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
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private RectangleF IconButtonArea
    {
        get
        {
            return _iconButtonArea;
        }
        set
        {
            if (value == IconButtonArea)
            {
                return;
            }

            _iconButtonArea = value;
        }
    }

    /// <summary>
    /// gets the width of the icon button
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private int IconButtonWidth
    {
        get
        {
            string text = Text;
            Font font = Font;

            Size textSize = TextRenderer.MeasureText(text, font);
            int textWidth = textSize.Width;

            if (textWidth <= Width - (CalendarIconWidth + 20))
            {
                return CalendarIconWidth;
            }
            else
            {
                return ArrowIconWidth;
            }
        }
    }


    /// <summary>
    /// occurs when the <see cref="SkinColor"/> changes its value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("control events")]
    public event EventHandler SkinColorChanged
    {
        add => Events.AddHandler(s_skinColorChanged, value);
        remove => Events.RemoveHandler(s_skinColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="TextColor"/> changes its value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("control events")]
    public event EventHandler TextColorChanged
    {
        add => Events.AddHandler(s_textColorChanged, value);
        remove => Events.RemoveHandler(s_textColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="BorderColor"/> changes its value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("control events")]
    public event EventHandler BorderColorChanged
    {
        add => Events.AddHandler(s_borderColorChanged, value);
        remove => Events.RemoveHandler(s_borderColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="BorderSize"/> changes its value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("control events")]
    public event EventHandler BorderSizeChanged
    {
        add => Events.AddHandler(s_borderSizeChanged, value);
        remove => Events.RemoveHandler(s_borderSizeChanged, value);
    }


    /// <summary>
    /// raises the <see cref="SkinColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnSkinColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_skinColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="TextColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnTextColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_textColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="BorderColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBorderColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_borderColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="BorderSizeChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBorderSizeChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_borderSizeChanged];
        handler?.Invoke(this, e);
    }

    protected override void OnDropDown(EventArgs eventargs)
    {
        base.OnDropDown(eventargs);
        _droppedDown = true;
    }

    protected override void OnCloseUp(EventArgs eventargs)
    {
        base.OnCloseUp(eventargs);
        _droppedDown = false;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        e.Handled = true;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        int iconWidth = IconButtonWidth;
        int width = Width - iconWidth;
        int height = Height;

        IconButtonArea = new RectangleF(width, 0, iconWidth, height);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        Point mouseLocation = e.Location;
        ChangeCursor(mouseLocation);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new CustomDateTimePickerAccessibleObject(this);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics graphics = CreateGraphics();
        float width = Width - 0.5F;
        float height = Height - 0.5F;
        var clientArea = new RectangleF(0, 0, width, height);

        DrawBorder(graphics, clientArea);
        DrawRectangle(graphics, clientArea);
        DrawText(graphics, clientArea);
        DrawImage(graphics);
    }

    /// <summary>
    /// draws the control border
    /// </summary>
    /// <param name="graphics">the control graphics</param>
    /// <param name="clientArea">the control client area</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void DrawBorder(Graphics graphics, RectangleF clientArea)
    {
        int borderSize = BorderSize;
        Color borderColor = BorderColor;
        using var borderPen = new Pen(borderColor, borderSize);

        if (borderSize >= 1)
        {
            graphics.DrawRectangle(borderPen, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
        }
    }

    /// <summary>
    /// fills the rectangle of the control
    /// </summary>
    /// <param name="graphics">the control graphics</param>
    /// <param name="clientArea">the control client area</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void DrawRectangle(Graphics graphics, RectangleF clientArea)
    {
        bool droppedDown = _droppedDown;

        float iconWidth = CalendarIconWidth;
        var iconArea = new RectangleF(clientArea.Width - iconWidth, 0, iconWidth, clientArea.Height);

        Color skinColor = SkinColor;
        Color iconColor = Color.FromArgb(50, 64, 64, 64);

        Brush skinBrush = new SolidBrush(skinColor);
        Brush openIconBrush = new SolidBrush(iconColor);

        graphics.FillRectangle(skinBrush, clientArea);

        if (droppedDown)
        {
            graphics.FillRectangle(openIconBrush, iconArea);
        }

        skinBrush.Dispose();
        openIconBrush.Dispose();
    }

    /// <summary>
    /// draws the calendar icon in the control
    /// </summary>
    /// <param name="graphics"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void DrawImage(Graphics graphics)
    {
        Image calendarIcon = CalendarIcon;

        int width = Width;
        int height = Height;

        int iconWidth = calendarIcon.Width;
        int iconHeight = calendarIcon.Height;

        int x = width - iconWidth;
        int y = height - iconHeight;

        graphics.DrawImage(calendarIcon, x - 10, y / 2);
    }

    /// <summary>
    /// draws the text
    /// </summary>
    /// <param name="graphics">the control graphics</param>
    /// <param name="clientArea">the control client area</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void DrawText(Graphics graphics, RectangleF clientArea)
    {
        string text = "   " + Text;
        Font font = Font;
        Color textColor = TextColor;

        StringFormat textFormat = new();
        Brush textBrush = new SolidBrush(textColor);

        textFormat.LineAlignment = StringAlignment.Center;
        textFormat.Alignment = StringAlignment.Center;
        graphics.DrawString(text, font, textBrush, clientArea, textFormat);

        textBrush.Dispose();
        textFormat.Dispose();
    }

    /// <summary>
    /// when the <see cref="SkinColor"/> changes value
    /// this method updates the icon between
    /// <see cref="Resources.CalendarDark"/> and <see cref="Resources.CalendarWhite"/>
    /// depending on the color brightness
    /// </summary>
    /// <param name="skinColor">the current skin color</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void SetCalendarIcon(Color skinColor)
    {
        float brightness = skinColor.GetBrightness();

        if (brightness > 0.8F)
        {
            CalendarIcon = Resources.CalendarDark;
        }
        else
        {
            CalendarIcon = Resources.CalendarWhite;
        }
    }

    /// <summary>
    /// changes the cursor when the mouse enters the icon area
    /// </summary>
    /// <param name="location"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void ChangeCursor(Point location)
    {
        RectangleF area = IconButtonArea;

        if (area.Contains(location))
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.Default;
        }
    }
}