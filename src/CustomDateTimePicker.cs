using WinformsControls.Properties;

namespace WinformsControls;

/// <summary>
/// 
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


    public event EventHandler SkinColorChanged
    {
        add => Events.AddHandler(s_skinColorChanged, value);
        remove => Events.RemoveHandler(s_skinColorChanged, value);
    }

    public event EventHandler TextColorChanged
    {
        add => Events.AddHandler(s_textColorChanged, value);
        remove => Events.RemoveHandler(s_textColorChanged, value);
    }

    public event EventHandler BorderColorChanged
    {
        add => Events.AddHandler(s_borderColorChanged, value);
        remove => Events.RemoveHandler(s_borderColorChanged, value);
    }

    public event EventHandler BorderSizeChanged
    {
        add => Events.AddHandler(s_borderSizeChanged, value);
        remove => Events.RemoveHandler(s_borderSizeChanged, value);
    }


    protected virtual void OnSkinColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_skinColorChanged];
        handler?.Invoke(this, e);
    }

    protected virtual void OnTextColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_textColorChanged];
        handler?.Invoke(this, e);
    }

    protected virtual void OnBorderColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_borderColorChanged];
        handler?.Invoke(this, e);
    }

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

    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new CustomDateTimePickerAccessibleObject(this);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics graphics = CreateGraphics();
        float width = Width - 0.5F;
        float height = Height - 0.5F;
        RectangleF clientArea = new(0, 0, width, height);

        Color borderColor = BorderColor;
        int borderSize = BorderSize;
        Pen borderPen = new(borderColor, borderSize);

        if (borderSize >= 1)
        {
            graphics.DrawRectangle(borderPen, 0, 0, width, height);
        }

        float iconWidth = CalendarIconWidth;
        Color skinColor = SkinColor;
        Color iconColor = Color.FromArgb(50, 64, 64, 64);
        RectangleF iconArea = new(width - iconWidth, 0, iconWidth, height);

        Brush skinBrush = new SolidBrush(skinColor);
        Brush openIconBrush = new SolidBrush(iconColor);

        graphics.FillRectangle(skinBrush, clientArea);

        if (_droppedDown)
        {
            graphics.FillRectangle(openIconBrush, iconArea);
        }

        DrawImage(graphics);

        string text = "   " + Text;
        Font font = Font;
        Color textColor = TextColor;

        Brush textBrush = new SolidBrush(textColor);
        StringFormat format = new();
        format.LineAlignment = StringAlignment.Center;
        format.Alignment = StringAlignment.Center;
        graphics.DrawString(text, font, textBrush, clientArea, format);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="graphics"></param>
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
    /// 
    /// </summary>
    /// <param name="skinColor"></param>
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
    /// 
    /// </summary>
    /// <param name="location"></param>
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