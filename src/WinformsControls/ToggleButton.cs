using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

/// <summary>
/// represents a toggle control
/// </summary>
public partial class ToggleButton : CheckBox
{
    private static readonly object s_sliderColorChanged = new();
    private static readonly object s_toggleColorChanged = new();
    private static readonly object s_solidStyleChanged = new();

    private Color _onSliderColor = Color.RoyalBlue;
    private Color _offSliderColor = Color.Gray;

    private Color _onToggleColor = Color.WhiteSmoke;
    private Color _offToggleColor = Color.Gainsboro;

    private string _onText;
    private string _offText;

    private bool _solidStyle = true;

    private Pen _sliderPen;

    private Brush _sliderBrush;
    private Brush _toggleBrush;
    private Brush _textBrush;


    /// <summary>
    /// creates a new instance of the <see cref="ToggleButton"/> class
    /// </summary>
    public ToggleButton()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.ResizeRedraw, true);

        SetStyle(ControlStyles.ContainerControl, false);
        SetStyle(ControlStyles.Opaque, false);

        Initialize();
    }


    /// <summary>
    /// gets or sets the color of the slide when the <see cref="ToggleButton"/> is checked
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("toggle appearance")]
    public virtual Color OnSliderColor
    {
        get
        {
            return _onSliderColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(OnSliderColor));
            }

            if (value == OnSliderColor)
            {
                return;
            }

            _onSliderColor = value;

            Invalidate();
            OnSlideColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the color of the slide when the <see cref="ToggleButton"/> is unchecked
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("toggle appearance")]
    public virtual Color OffSliderColor
    {
        get
        {
            return _offSliderColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(OffSliderColor));
            }

            if (value == OffSliderColor)
            {
                return;
            }

            _offSliderColor = value;

            Invalidate();
            OnSlideColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the color of the toggle when the <see cref="ToggleButton"/> is checked
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("toggle appearance")]
    public virtual Color OnToggleColor
    {
        get
        {
            return _onToggleColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(OnToggleColor));
            }

            if (value == OnToggleColor)
            {
                return;
            }

            _onToggleColor = value;

            Invalidate();
            OnToggleColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the color of the toggle when the <see cref="ToggleButton"/> is unchecked
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("toggle appearance")]
    public virtual Color OffToggleColor
    {
        get
        {
            return _offToggleColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(OffToggleColor));
            }

            if (value == OffToggleColor)
            {
                return;
            }

            _offToggleColor = value;

            Invalidate();
            OnToggleColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the style of the toggle
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("toggle appearance")]
    public bool SolidStyle
    {
        get
        {
            return _solidStyle;
        }
        set
        {
            if (value == SolidStyle)
            {
                return;
            }

            _solidStyle = value;

            Invalidate();
            OnSolidStyleChanged(EventArgs.Empty);
        }
    }

    public string OnText
    {
        get
        {
            return _onText;
        }
        set
        {
            string oldOnText = OnText;
            string onText = value;

            if (onText != oldOnText)
            {
                _onText = onText;
                Invalidate();
            }
        }
    }

    public string OffText
    {
        get
        {
            return _offText;
        }
        set
        {
            string oldOffText = OffText;
            string offText = value;

            if (offText != oldOffText)
            {
                _offText = offText;
                Invalidate();
            }
        }
    }

    /// <summary>
    /// occurs when the <see cref="OnSliderColor"/> or <see cref="OffSliderColor"/> changes its value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("toggle events")]
    public event EventHandler SlideColorChanged
    {
        add => Events.AddHandler(s_sliderColorChanged, value);
        remove => Events.RemoveHandler(s_sliderColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="OnToggleColor"/> or <see cref="OffToggleColor"/> changes its value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("toggle events")]
    public event EventHandler ToggleColorChanged
    {
        add => Events.AddHandler(s_toggleColorChanged, value);
        remove => Events.RemoveHandler(s_toggleColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="SolidStyle"/> property changes value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("toggle events")]
    public event EventHandler SolidStyleChanged
    {
        add => Events.AddHandler(s_solidStyleChanged, value);
        remove => Events.RemoveHandler(s_solidStyleChanged, value);
    }


    /// <summary>
    /// raises the <see cref="SlideColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnSlideColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_sliderColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="ToggleColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnToggleColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_toggleColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="SolidStyleChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnSolidStyleChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_solidStyleChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// creates the <see cref="ToggleButtonAccessibleObject"/> instance
    /// </summary>
    /// <returns>the <see cref="ToggleButtonAccessibleObject"/> instance</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new ToggleButtonAccessibleObject(this);
    }

    /// <summary>
    /// raises the <see cref="ToggleButton.OnPaint(PaintEventArgs)"/> event
    /// </summary>
    /// <param name="pevent"></param>
    protected override void OnPaint(PaintEventArgs pevent)
    {
        Control parent = Parent;
        Graphics graphics = pevent.Graphics;

        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.Clear(parent.BackColor);

        int width = Width;
        int height = Height;
        bool isChecked = Checked;

        DrawSlider(graphics, isChecked);
        DrawToggle(graphics, width, height, isChecked);
        DrawText(graphics, isChecked, width, height);
    }

    /// <summary>
    /// draws the slider
    /// </summary>
    /// <param name="graphics">the control graphics</param>
    /// <param name="isChecked">the control status</param>
    private void DrawSlider(Graphics graphics, bool isChecked)
    {
        bool solidStyle = SolidStyle;
        GraphicsPath path = GetFigurePath();

        Color onSliderColor = OnSliderColor;
        Color offSliderColor = OffSliderColor;

        Color sliderColor = isChecked ? onSliderColor : offSliderColor;
        _sliderBrush = new SolidBrush(sliderColor);

        if (isChecked)
        {
            if (solidStyle)
            {
                graphics.FillPath(_sliderBrush, path);
            }
            else
            {
                _sliderPen = new Pen(onSliderColor);
                graphics.DrawPath(_sliderPen, path);
            }
        }
        else
        {
            if (solidStyle)
            {
                graphics.FillPath(_sliderBrush, path);
            }
            else
            {
                _sliderPen = new Pen(offSliderColor);
                graphics.DrawPath(_sliderPen, path);
            }
        }

        path.Dispose();
    }

    /// <summary>
    /// draws the toggle
    /// </summary>
    /// <param name="graphics">the control graphic</param>
    /// <param name="width">the control width</param>
    /// <param name="height">the control height</param>
    /// <param name="isChecked">the control status</param>
    private void DrawToggle(Graphics graphics, int width, int height, bool isChecked)
    {
        int toggleSize = height - 5;
        var toggleRectangle = isChecked ? new Rectangle(width - height + 1, 2, toggleSize, toggleSize) : new Rectangle(2, 2, toggleSize, toggleSize);

        Color toggleColor = isChecked ? OnToggleColor : OffToggleColor;
        _toggleBrush = new SolidBrush(toggleColor);

        graphics.FillEllipse(_toggleBrush, toggleRectangle);
    }

    private void DrawText(Graphics graphics, bool isChecked, int width, int height)
    {
        string text = isChecked ? OnText : OffText;
        Font font = Font;

        if (!string.IsNullOrWhiteSpace(text))
        {
            SizeF textSize = graphics.MeasureString(text, font);

            float textWidth = (width - textSize.Width) / 2;
            float textHeight = (height - textSize.Height) / 2;

            _textBrush = new SolidBrush(Color.White);
            graphics.DrawString(text, font, _textBrush, textWidth, textHeight);
        }
    }

    /// <summary>
    /// gets the path of the toggle button
    /// </summary>
    /// <returns></returns>
    private GraphicsPath GetFigurePath()
    {
        var path = new GraphicsPath();
        path.StartFigure();

        int width = Width;
        int height = Height;
        int arcSize = height - 1;

        var leftArc = new Rectangle(0, 0, arcSize, arcSize);
        var rightArc = new Rectangle(width - arcSize - 2, 0, arcSize, arcSize);

        path.AddArc(leftArc, 90, 180);
        path.AddArc(rightArc, 270, 180);

        path.CloseFigure();
        return path;
    }

    private void Initialize()
    {
        MinimumSize = new Size(90, 45);
    }
}