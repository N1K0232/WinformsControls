using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

/// <summary>
/// defines a <see cref="PictureBox"/> with a rounded shape
/// </summary>
public partial class CircularPictureBox : PictureBox
{
    private static readonly object s_primaryBorderColorChanged = new();
    private static readonly object s_secondaryBorderColorChanged = new();
    private static readonly object s_borderLineStyleChanged = new();
    private static readonly object s_borderCapStyleChanged = new();
    private static readonly object s_borderSizeChanged = new();
    private static readonly object s_gradientAngleChanged = new();

    private Color _primaryBorderColor = Color.RoyalBlue;
    private Color _secondaryBorderColor = Color.HotPink;

    private DashStyle _borderLineStyle = DashStyle.Solid;
    private DashCap _borderCapStyle = DashCap.Flat;

    private int _borderSize = 2;
    private float _gradientAngle = 50F;


    /// <summary>
    /// creates a new instance of <see cref="CircularPictureBox"/> class
    /// </summary>
    public CircularPictureBox() : base()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.Opaque, true);

        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.Selectable, true);

        SetStyle(ControlStyles.CacheText, false);

        Size = new Size(100, 100);
        SizeMode = PictureBoxSizeMode.StretchImage;
    }


    /// <summary>
    /// gets or sets the first border color
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public virtual Color PrimaryBorderColor
    {
        get
        {
            return _primaryBorderColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("Invalid color", nameof(PrimaryBorderColor));
            }

            if (value == PrimaryBorderColor)
            {
                return;
            }

            _primaryBorderColor = value;

            Invalidate();
            OnPrimaryBorderColorChanged(EventArgs.Empty);
        }
    }


    /// <summary>
    /// gets or sets the second border color
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public virtual Color SecondaryBorderColor
    {
        get
        {
            return _secondaryBorderColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("Invalid color", nameof(SecondaryBorderColor));
            }

            if (value == SecondaryBorderColor)
            {
                return;
            }

            _secondaryBorderColor = value;

            Invalidate();
            OnSecondaryBorderColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the border line style
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public virtual DashStyle BorderLineStyle
    {
        get
        {
            return _borderLineStyle;
        }
        set
        {
            if (value == BorderLineStyle)
            {
                return;
            }

            _borderLineStyle = value;

            Invalidate();
            OnBorderLineStyleChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the border cap style
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public virtual DashCap BorderCapStyle
    {
        get
        {
            return _borderCapStyle;
        }
        set
        {
            if (value == BorderCapStyle)
            {
                return;
            }

            _borderCapStyle = value;

            Invalidate();
            OnBorderCapStyleChanged(EventArgs.Empty);
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
                throw new ArgumentException("invalid value", nameof(BorderSize));
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
    /// gets or sets the angle of the gradient of the control
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("control appearance")]
    public float GradientAngle
    {
        get
        {
            return _gradientAngle;
        }
        set
        {
            if (value < 0F)
            {
                throw new ArgumentException("Invalid value", nameof(GradientAngle));
            }

            if (value == GradientAngle)
            {
                return;
            }

            _gradientAngle = value;

            Invalidate();
            OnGradientAngleChanged(EventArgs.Empty);
        }
    }


    /// <summary>
    /// occurs when <see cref="PrimaryBorderColor"/> changes value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("control events")]
    public event EventHandler PrimaryBorderColorChanged
    {
        add => Events.AddHandler(s_primaryBorderColorChanged, value);
        remove => Events.RemoveHandler(s_primaryBorderColorChanged, value);
    }

    /// <summary>
    /// occurs when <see cref="SecondaryBorderColor"/> changes value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("control events")]
    public event EventHandler SecondaryBorderColorChanged
    {
        add => Events.AddHandler(s_secondaryBorderColorChanged, value);
        remove => Events.RemoveHandler(s_secondaryBorderColorChanged, value);
    }

    /// <summary>
    /// occurs when <see cref="BorderLineStyle"/> changes value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("control events")]
    public event EventHandler BorderLineStyleChanged
    {
        add => Events.AddHandler(s_borderLineStyleChanged, value);
        remove => Events.RemoveHandler(s_borderLineStyleChanged, value);
    }

    /// <summary>
    /// occurs when <see cref="BorderCapStyle"/> changes value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("control events")]
    public event EventHandler BorderCapStyleChanged
    {
        add => Events.AddHandler(s_borderCapStyleChanged, value);
        remove => Events.RemoveHandler(s_borderCapStyleChanged, value);
    }

    /// <summary>
    /// occurs when <see cref="BorderSize"/> changes value
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
    /// occurs when <see cref="GradientAngle"/> changes value
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("control events")]
    public event EventHandler GradientAngleChanged
    {
        add => Events.AddHandler(s_gradientAngleChanged, value);
        remove => Events.RemoveHandler(s_gradientAngleChanged, value);
    }


    /// <summary>
    /// raises the <see cref="PrimaryBorderColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnPrimaryBorderColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_primaryBorderColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="SecondaryBorderColor"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnSecondaryBorderColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_secondaryBorderColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="BorderLineStyleChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBorderLineStyleChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_borderLineStyleChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="BorderCapStyle"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBorderCapStyleChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_borderCapStyleChanged];
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
    /// raises the <see cref="GradientAngleChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnGradientAngleChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_gradientAngleChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// creates the instance of <see cref="CircularPictureBoxAccessibleObject"/>
    /// </summary>
    /// <returns>the instance of <see cref="CircularPictureBoxAccessibleObject"/></returns>
    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new CircularPictureBoxAccessibleObject(this);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        int width = Width;
        Size = new Size(width, width);
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        Control parent = Parent;

        Color primaryBorderColor = PrimaryBorderColor;
        Color secondaryBorderColor = SecondaryBorderColor;

        int borderSize = BorderSize;
        int smoothSize = borderSize > 0 ? borderSize * 3 : 1;

        float gradientAngle = GradientAngle;

        DashStyle borderLineStyle = BorderLineStyle;
        DashCap borderCapStyle = BorderCapStyle;

        Graphics graphics = pe.Graphics;
        Rectangle rectContourSmooth = Rectangle.Inflate(ClientRectangle, -1, -1);
        Rectangle rectBorder = Rectangle.Inflate(rectContourSmooth, -borderSize, -borderSize);

        using var borderBrush = new LinearGradientBrush(rectBorder, primaryBorderColor, secondaryBorderColor, gradientAngle);
        using var regionPath = new GraphicsPath();
        using var smoothPen = new Pen(parent.BackColor, smoothSize);
        using var borderPen = new Pen(borderBrush, borderSize);

        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        borderPen.DashStyle = borderLineStyle;
        borderPen.DashCap = borderCapStyle;

        regionPath.AddEllipse(rectContourSmooth);
        Region = new Region(regionPath);

        graphics.DrawEllipse(smoothPen, rectContourSmooth);

        if (borderSize > 0)
        {
            graphics.DrawEllipse(borderPen, rectBorder);
        }
    }
}