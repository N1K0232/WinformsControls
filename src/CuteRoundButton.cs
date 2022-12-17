using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

/// <summary>
/// 
/// </summary>
public partial class CuteRoundButton : RoundButton
{
    private static readonly object s_firstColorChanged = new();
    private static readonly object s_secondColorChanged = new();

    private static readonly object s_firstColorTransparencyChanged = new();
    private static readonly object s_secondColorTransparencyChanged = new();

    private static readonly object s_angleChanged = new();


    private Color _firstColor = Color.Red;
    private Color _secondColor = Color.RoyalBlue;

    private int _firstColorTransparency = 80;
    private int _secondColorTransparency = 80;

    private float _angle = 10F;

    /// <summary>
    /// creates a new instance of <see cref="CuteRoundButton"/> class
    /// </summary>
    public CuteRoundButton() : base()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.Selectable, true);

        SetStyle(ControlStyles.ContainerControl, false);
        SetStyle(ControlStyles.Opaque, false);
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
    /// raises the <see cref="AngleChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnAngleChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_angleChanged];
        handler?.Invoke(this, e);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override void OnBorderSizeChanged(EventArgs e)
    {
        base.OnBorderSizeChanged(e);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override void OnBorderRadiusChanged(EventArgs e)
    {
        base.OnBorderRadiusChanged(e);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override void OnBorderColorChanged(EventArgs e)
    {
        base.OnBorderColorChanged(e);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override void OnBorderFocusColorChanged(EventArgs e)
    {
        base.OnBorderFocusColorChanged(e);
    }

    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new CuteRoundButtonAccessibleObject(this);
    }

    /// <summary>
    /// called when the mouse enters the button area
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected override void OnEnter(object sender, EventArgs e)
    {
        base.OnEnter(sender, e);
    }

    /// <summary>
    /// called when the mouse leaves the button area
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected override void OnLeave(object sender, EventArgs e)
    {
        base.OnLeave(sender, e);
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

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        Control container = Parent;
        container.BackColorChanged += new EventHandler(Container_BackColorChanged);
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        base.OnHandleDestroyed(e);

        Control container = Parent;
        container.BackColorChanged -= new EventHandler(Container_BackColorChanged);
    }

    /// <summary>
    /// called when the parent control changes the background color
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Container_BackColorChanged(object sender, EventArgs e)
    {
        if (DesignMode)
        {
            Invalidate();
        }
    }

    /// <summary>
    /// when the <see cref="FirstColor"/> property or the <see cref="SecondColor"/> property value
    /// changes this method updates the <see cref="Control.ForeColor"/> property
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
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

    protected internal override void Initialize()
    {
        base.Initialize();

        BorderColor = Color.White;
        BackColor = Color.White;
        ForeColor = Color.Black;

        Enter += new EventHandler(OnEnter);
        Leave += new EventHandler(OnLeave);
    }
}