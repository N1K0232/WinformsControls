using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

/// <summary>
/// defines a <see cref="Button"/> control with a double background color
/// </summary>
[DefaultEvent(nameof(Click))]
[ToolboxItemFilter("WinformsControls")]
public partial class CuteButton : Button
{
    private static readonly object s_firstColorChanged = new();
    private static readonly object s_secondColorChanged = new();
    private static readonly object s_borderColorChanged = new();
    private static readonly object s_borderFocusColorChanged = new();
    private static readonly object s_firstColorTransparencyChanged = new();
    private static readonly object s_secondColorTransparencyChanged = new();
    private static readonly object s_borderSizeChanged = new();
    private static readonly object s_angleChanged = new();


    private Color _firstColor = Color.Red;
    private Color _secondColor = Color.RoyalBlue;

    private Color _borderColor = Color.Magenta;
    private Color _borderFocusColor = Color.DarkMagenta;

    private int _firstColorTransparency = 80;
    private int _secondColorTransparency = 80;

    private int _borderSize = 0;

    private float _angle = 10F;

    private bool _focused = false;


    /// <summary>
    /// creates a new instance of the <see cref="CuteButton"/> class
    /// </summary>
    public CuteButton()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.ResizeRedraw, true);

        SetStyle(ControlStyles.ContainerControl, false);
        SetStyle(ControlStyles.Opaque, false);

        Initialize();
    }


    /// <summary>
    /// gets or sets the first color of the control
    /// </summary>
    [Category("button appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual Color FirstColor
    {
        get
        {
            return _firstColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(FirstColor));
            }

            if (value == FirstColor)
            {
                return;
            }

            _firstColor = value;

            Invalidate();
            ChangeTextColor();
            OnFirstColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the second color of the control
    /// </summary>
    [Category("button appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual Color SecondColor
    {
        get
        {
            return _secondColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(SecondColor));
            }

            if (value == SecondColor)
            {
                return;
            }

            _secondColor = value;

            Invalidate();
            ChangeTextColor();
            OnSecondColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the color of the border
    /// </summary>
    [Category("button appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
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
    /// gets or sets the color of the border when the control is focused
    /// </summary>
    [Category("button appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual Color BorderFocusColor
    {
        get
        {
            return _borderFocusColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(BorderFocusColor));
            }

            if (value == BorderFocusColor)
            {
                return;
            }

            _borderFocusColor = value;
            OnBorderFocusColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the transparency of the first color
    /// </summary>
    [Category("button appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual int FirstColorTransparency
    {
        get
        {
            return _firstColorTransparency;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid value", nameof(FirstColorTransparency));
            }

            if (value == FirstColorTransparency)
            {
                return;
            }

            _firstColorTransparency = value;

            Invalidate();
            OnFirstColorTransparencyChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the transparency of the second color
    /// </summary>
    [Category("button appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual int SecondColorTransparency
    {
        get
        {
            return _secondColorTransparency;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid value", nameof(SecondColorTransparency));
            }

            if (value == SecondColorTransparency)
            {
                return;
            }

            _secondColorTransparency = value;

            Invalidate();
            OnSecondColorTransparencyChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the angle of the control
    /// </summary>
    [Category("button appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
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
    /// gets or sets the angle of the control
    /// </summary>
    [Category("button appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public float Angle
    {
        get
        {
            return _angle;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("invalid value", nameof(Angle));
            }

            if (value == Angle)
            {
                return;
            }

            _angle = value;

            Invalidate();
            OnAngleChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the dialog result for this control
    /// </summary>
    public override DialogResult DialogResult
    {
        get
        {
            return base.DialogResult;
        }
        set
        {
            if (value == DialogResult)
            {
                return;
            }

            base.DialogResult = value;
        }
    }

    protected override CreateParams CreateParams => base.CreateParams;


    /// <summary>
    /// occurs when the <see cref="FirstColor"/> property value changes
    /// </summary>
    [Category("button events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler FirstColorChanged
    {
        add => Events.AddHandler(s_firstColorChanged, value);
        remove => Events.RemoveHandler(s_firstColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="SecondColor"/> property value changes
    /// </summary>
    [Category("button events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler SecondColorChanged
    {
        add => Events.AddHandler(s_secondColorChanged, value);
        remove => Events.RemoveHandler(s_secondColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="BorderColor"/> property value changes
    /// </summary>
    [Category("button events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler BorderColorChanged
    {
        add => Events.AddHandler(s_borderColorChanged, value);
        remove => Events.RemoveHandler(s_borderColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="BorderFocusColor"/> property value changes
    /// </summary>
    [Category("button events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler BorderFocusColorChanged
    {
        add => Events.AddHandler(s_borderFocusColorChanged, value);
        remove => Events.RemoveHandler(s_borderFocusColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="FirstColorTransparency"/> property value changes
    /// </summary>
    [Category("button events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler FirstColorTransparencyChanged
    {
        add => Events.AddHandler(s_firstColorTransparencyChanged, value);
        remove => Events.RemoveHandler(s_firstColorTransparencyChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="SecondColorTransparency"/> property value changes
    /// </summary>
    [Category("button events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler SecondColorTransparencyChanged
    {
        add => Events.AddHandler(s_secondColorTransparencyChanged, value);
        remove => Events.RemoveHandler(s_secondColorTransparencyChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="BorderSize"/> property value changes
    /// </summary>
    [Category("button events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler BorderSizeChanged
    {
        add => Events.AddHandler(s_borderSizeChanged, value);
        remove => Events.RemoveHandler(s_borderSizeChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="Angle"/> property value changes
    /// </summary>
    [Category("button events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler AngleChanged
    {
        add => Events.AddHandler(s_angleChanged, value);
        remove => Events.RemoveHandler(s_angleChanged, value);
    }


    /// <summary>
    /// raises the <see cref="FirstColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnFirstColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_firstColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="SecondColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnSecondColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_secondColorChanged];
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
    /// raises the <see cref="BorderFocusColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBorderFocusColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_borderFocusColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="FirstColorTransparencyChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnFirstColorTransparencyChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_firstColorTransparencyChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="SecondColorTransparencyChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnSecondColorTransparencyChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_secondColorTransparencyChanged];
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

    /// <summary>
    /// raises the <see cref="AngleChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnAngleChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_angleChanged];
        handler?.Invoke(this, e);
    }


    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
    }


    protected override void OnDoubleClick(EventArgs e)
    {
        base.OnDoubleClick(e);
    }

    /// <summary>
    /// redraws the background of the control
    /// </summary>
    /// <param name="pevent"></param>
    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        base.OnPaintBackground(pevent);
    }

    /// <summary>
    /// redraws the control
    /// </summary>
    /// <param name="pevent"></param>
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Control container = Parent;
        Graphics graphics = pevent.Graphics;

        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.Clear(container.BackColor);

        int firstColorTransparency = FirstColorTransparency;
        int secondColorTransparency = SecondColorTransparency;

        int borderSize = BorderSize;

        int width = Width;
        int height = Height;

        float angle = Angle;

        string text = Text;
        Font font = Font;
        SizeF textSize = graphics.MeasureString(text, font);

        float textWidth = (width - textSize.Width) / 2;
        float textHeight = (height - textSize.Height) / 2;

        Color firstColor = Color.FromArgb(firstColorTransparency, FirstColor);
        Color secondColor = Color.FromArgb(secondColorTransparency, SecondColor);

        Color borderColor = _focused ? BorderFocusColor : BorderColor;
        Color textColor = ForeColor;

        Rectangle rectangle = ClientRectangle;

        Brush backgroundBrush = new LinearGradientBrush(rectangle, firstColor, secondColor, angle);
        Brush textBrush = new SolidBrush(textColor);

        if (borderSize >= 1)
        {
            using var borderPen = new Pen(borderColor, borderSize);
            graphics.DrawRectangle(borderPen, rectangle);
        }

        graphics.FillRectangle(backgroundBrush, rectangle);
        graphics.DrawString(text, font, textBrush, textWidth, textHeight);

        backgroundBrush.Dispose();
        textBrush.Dispose();
    }

    /// <summary>
    /// raises the <see cref="Control.HandleCreated"/> event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        Control container = Parent;
        container.BackColorChanged += new EventHandler(Container_BackColorChanged);
    }

    /// <summary>
    /// raises the <see cref="Control.HandleDestroyed"/>
    /// </summary>
    /// <param name="e"></param>
    protected override void OnHandleDestroyed(EventArgs e)
    {
        base.OnHandleDestroyed(e);

        Control container = Parent;
        container.BackColorChanged -= Container_BackColorChanged;
    }

    /// <summary>
    /// raises the <see cref="Control.MouseEnter"/> event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseEnter(EventArgs e)
    {
        Cursor = Cursors.Hand;
        base.OnMouseEnter(e);
    }

    /// <summary>
    /// raises the <see cref="Control.MouseLeave"/> event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseLeave(EventArgs e)
    {
        Cursor = Cursors.Default;
        base.OnMouseLeave(e);
    }

    /// <summary>
    /// initializes the base property of the <see cref="CuteButton"/> control
    /// </summary>
    protected internal virtual void Initialize()
    {
        ForeColor = Color.WhiteSmoke;
        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        Size = new Size(120, 50);
        FlatAppearance.BorderColor = Color.White;
        FlatAppearance.BorderSize = 0;
        FlatStyle = FlatStyle.Flat;

        Enter += new EventHandler(OnEnter);
        Leave += new EventHandler(OnLeave);
    }

    /// <summary>
    /// called when the mouse enters the button area
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnEnter(object sender, EventArgs e)
    {
        _focused = true;
        Invalidate();
    }

    /// <summary>
    /// called when the mouse leaves the button area
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnLeave(object sender, EventArgs e)
    {
        _focused = false;
        Invalidate();
    }

    /// <summary>
    /// called when the parent control changes the background color
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Container_BackColorChanged(object sender, EventArgs e)
    {
        bool designMode = DesignMode;
        if (designMode)
        {
            Invalidate();
        }
    }

    /// <summary>
    /// when the <see cref="FirstColor"/> property or the <see cref="SecondColor"/> property value
    /// changes this method updates the <see cref="Control.ForeColor"/> property
    /// </summary>
    private void ChangeTextColor()
    {
        float firstColorBrightness = FirstColor.GetBrightness();
        float secondColorBrightness = SecondColor.GetBrightness();

        Color textColor;

        if (firstColorBrightness > 0.8F && secondColorBrightness > 0.8F)
        {
            textColor = Color.White;
        }
        else
        {
            textColor = Color.Black;
        }

        ForeColor = textColor;
    }
}