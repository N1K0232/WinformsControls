using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

/// <summary>
/// defines a <see cref="Button"/> control with rounded corners
/// </summary>
[DefaultEvent(nameof(Click))]
public partial class RoundButton : Button
{
    //this control doesn't extends ButtonBase class otherwise I will get
    //a runtime error because the default painter doesn't know anything about this control
    //so to avoid this kind of error I will extend the Button class

    private static readonly object s_borderSizeChanged = new();
    private static readonly object s_borderRadiusChanged = new();
    private static readonly object s_borderColorChanged = new();
    private static readonly object s_borderFocusColorChanged = new();

    private int _borderSize = 0;
    private int _borderRadius = 40;

    private Color _borderColor = Color.PaleVioletRed;
    private Color _borderFocusColor = Color.Red;

    internal bool _focused = false;

    /// <summary>
    /// creates a new instance of the <see cref="RoundButton"/> control
    /// </summary>
    public RoundButton()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.Selectable, true);

        SetStyle(ControlStyles.ContainerControl, false);
        SetStyle(ControlStyles.Opaque, false);

        Initialize();
    }


    /// <summary>
    /// gets or sets the size of the border
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("button appearance")]
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
    /// gets or sets the radius of the border
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("button appearance")]
    public virtual int BorderRadius
    {
        get
        {
            return _borderRadius;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("invalid value", nameof(BorderRadius));
            }

            if (value == BorderRadius)
            {
                return;
            }

            _borderRadius = value;

            Invalidate();
            OnBorderRadiusChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the radius of the border
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("button appearance")]
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
                throw new ArgumentException("Invalid color", nameof(BorderColor));
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
    /// gets or sets the color of the border when the control receives focus
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("button appearance")]
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
                throw new ArgumentException("Invalid color", nameof(BorderFocusColor));
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
    /// occurs when the <see cref="BorderSize"/> property changes
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("button events")]
    public event EventHandler BorderSizeChanged
    {
        add => Events.AddHandler(s_borderSizeChanged, value);
        remove => Events.RemoveHandler(s_borderSizeChanged, value);
    }


    /// <summary>
    /// occurs when the <see cref="BorderRadius"/> property changes
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("button events")]
    public event EventHandler BorderRadiusChanged
    {
        add => Events.AddHandler(s_borderRadiusChanged, value);
        remove => Events.RemoveHandler(s_borderRadiusChanged, value);
    }


    /// <summary>
    /// occurs when the <see cref="BorderColor"/> property changes
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("button events")]
    public event EventHandler BorderColorChanged
    {
        add => Events.AddHandler(s_borderColorChanged, value);
        remove => Events.RemoveHandler(s_borderColorChanged, value);
    }


    /// <summary>
    /// occurs when the <see cref="BorderFocusColor"/> property changes
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Category("button events")]
    public event EventHandler BorderFocusColorChanged
    {
        add => Events.AddHandler(s_borderFocusColorChanged, value);
        remove => Events.RemoveHandler(s_borderFocusColorChanged, value);
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
    /// raises the <see cref="BorderRadiusChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBorderRadiusChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_borderRadiusChanged];
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
    /// creates the instance of the <see cref="RoundButtonAccessibleObject"/> class
    /// </summary>
    /// <returns>the instance of the <see cref="RoundButtonAccessibleObject"/> class</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new RoundButtonAccessibleObject(this);
    }

    /// <summary>
    /// raises the <see cref="RoundButton.OnPaint(PaintEventArgs)" /> event
    /// </summary>
    /// <param name="pevent"></param>
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Graphics graphics = pevent.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        int width = Width;
        int height = Height;

        DrawBorder(graphics, width, height);
        DrawSurface(graphics, width, height);
    }

    /// <summary>
    /// draws the border of the control
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void DrawBorder(Graphics graphics, int width, int height)
    {
        Color borderColor = _focused ? BorderFocusColor : BorderColor;

        int borderSize = BorderSize;
        int borderRadius = BorderRadius;

        float borderWidth = width - 0.8F;
        float borderHeight = height - 1F;

        var borderRectangle = new RectangleF(1, 1, borderWidth, borderHeight);

        GraphicsPath borderPath = GetFigurePath(borderRectangle, 1F);
        Pen borderPen = null;

        if (borderRadius > 2)
        {
            borderPen = new Pen(borderColor, 2);
            borderPen.Alignment = PenAlignment.Inset;

            if (borderSize >= 1)
            {
                graphics.DrawPath(borderPen, borderPath);
            }
        }
        else
        {
            if (borderSize >= 1)
            {
                borderPen = new Pen(borderColor, borderSize);
                borderPen.Alignment = PenAlignment.Inset;
                graphics.DrawRectangle(borderPen, 0, 0, width - 1, height - 1);
            }
        }

        borderPen.Dispose();
        borderPath.Dispose();
    }

    /// <summary>
    /// draws the surface of the control
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void DrawSurface(Graphics graphics, int width, int height)
    {
        var surfaceRectangle = new RectangleF(0, 0, width, height);
        int borderRadius = BorderRadius;

        Control parent = Parent;

        GraphicsPath surfacePath = GetFigurePath(surfaceRectangle);
        Pen penSurface = new(parent.BackColor, 2);

        if (borderRadius > 2)
        {
            Region = new Region(surfacePath);
            graphics.DrawPath(penSurface, surfacePath);
        }
        else
        {
            Region = new Region(surfaceRectangle);
        }

        penSurface.Dispose();
        surfacePath.Dispose();
    }

    /// <summary>
    /// Raises the <see cref="Control.HandleCreated"/> event.
    /// </summary>
    /// <param name="e"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        Control container = Parent;
        container.BackColorChanged += new EventHandler(Container_BackColorChanged);
    }

    /// <summary>
    /// Raises the <see cref="Control.HandleDestroyed"/> event
    /// </summary>
    /// <param name="e"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override void OnHandleDestroyed(EventArgs e)
    {
        base.OnHandleDestroyed(e);

        Control container = Parent;
        container.BackColorChanged -= new EventHandler(Container_BackColorChanged);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        Cursor = Cursors.Hand;
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        Cursor = Cursors.Default;
        base.OnMouseLeave(e);
    }

    /// <summary>
    /// if this control is in DesignMode then redraw the control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void Container_BackColorChanged(object sender, EventArgs e)
    {
        InvalidateIfDesignMode();
    }

    /// <summary>
    /// redraws the control if <see cref="Component.DesignMode"/> value is true
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void InvalidateIfDesignMode()
    {
        if (DesignMode)
        {
            Invalidate();
        }
    }

    /// <summary>
    /// initializes the base properties of the control
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected internal virtual void Initialize()
    {
        Size = new Size(150, 40);
        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;

        BackColor = Color.RoyalBlue;
        ForeColor = Color.White;

        Enter += new EventHandler(OnEnter);
        Leave += new EventHandler(OnLeave);
    }

    /// <summary>
    /// called when the control is entered
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnEnter(object sender, EventArgs e)
    {
        _focused = true;
        Invalidate();
    }

    /// <summary>
    /// called when the input focus leaves the control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnLeave(object sender, EventArgs e)
    {
        _focused = false;
        Invalidate();
    }

    /// <summary>
    /// gets the path of the control
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private GraphicsPath GetFigurePath(RectangleF rectangle, float offset = 0)
    {
        float borderRadius = Convert.ToSingle(BorderRadius);
        float radius = offset != 0 ? borderRadius - offset : borderRadius;

        float x = rectangle.X;
        float y = rectangle.Y;
        float width = rectangle.Width;
        float height = rectangle.Height;

        var path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(x, y, radius, radius, 180, 90);
        path.AddArc(width - radius, y, radius, radius, 270, 90);
        path.AddArc(width - radius, height - radius, radius, radius, 0, 90);
        path.AddArc(x, height - radius, radius, radius, 90, 90);
        path.CloseFigure();
        return path;
    }
}