using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

/// <summary>
/// defines a round button
/// </summary>
public partial class ButtonWoc : Button
{
    private static readonly object s_borderColorChanged = new();
    private static readonly object s_buttonColorChanged = new();
    private static readonly object s_textColorChanged = new();

    private static readonly object s_hoverBorderColorChanged = new();
    private static readonly object s_hoverButtonColorChanged = new();
    private static readonly object s_hoverTextColorChanged = new();

    private const int BorderThickness = 6;
    private const int BorderThicknessByTwo = 3;

    private Color _borderColor = Color.Red;
    private Color _buttonColor = Color.Blue;
    private Color _textColor = Color.White;

    private Color _hoverBorderColor = Color.Black;
    private Color _hoverButtonColor = Color.Yellow;
    private Color _hoverTextColor = Color.Red;

    private bool _hovering = false;
    private bool _focused = false;

    private Brush _borderBrush;
    private Brush _buttonBrush;
    private Brush _textBrush;

    /// <summary>
    /// creates a new instance of the <see cref="ButtonWoc"/> control
    /// </summary>
    public ButtonWoc() : base()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.Selectable, true);

        SetStyle(ControlStyles.ContainerControl, false);
        SetStyle(ControlStyles.Opaque, false);

        Initialize();
    }


    /// <summary>
    /// gets or sets the color of the border
    /// </summary>
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
            Color oldBorderColor = BorderColor;
            Color borderColor = value;

            if (borderColor.IsEmpty)
            {
                throw new ArgumentException("Invalid color", nameof(BorderColor));
            }

            if (borderColor != oldBorderColor)
            {
                _borderColor = borderColor;

                Invalidate();
                OnBorderColorChanged(EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// gets or sets the color of the button
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("button appearance")]
    public virtual Color ButtonColor
    {
        get
        {
            return _buttonColor;
        }
        set
        {
            Color oldButtonColor = ButtonColor;
            Color buttonColor = value;

            if (buttonColor.IsEmpty)
            {
                throw new ArgumentException("Invalid color", nameof(ButtonColor));
            }

            if (buttonColor != oldButtonColor)
            {
                _buttonColor = buttonColor;

                Invalidate();
                OnButtonColorChanged(EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// gets or sets the color of the text
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("button appearance")]
    public virtual Color TextColor
    {
        get
        {
            return _textColor;
        }
        set
        {
            Color oldTextColor = TextColor;
            Color textColor = value;

            if (textColor.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(TextColor));
            }

            if (textColor != oldTextColor)
            {
                _textColor = textColor;

                Invalidate();
                OnTextColorChanged(EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// gets or sets the color of the border when the mouse hoverings the control
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("button appearance")]
    public virtual Color HoverBorderColor
    {
        get
        {
            return _hoverBorderColor;
        }
        set
        {
            Color oldHoverBorderColor = HoverBorderColor;
            Color hoverBorderColor = value;

            if (hoverBorderColor.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(HoverBorderColor));
            }

            if (hoverBorderColor != oldHoverBorderColor)
            {
                _hoverBorderColor = hoverBorderColor;

                Invalidate();
                OnHoverBorderColorChanged(EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// gets or sets the color of the button when the mouse hoverings the control
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("button appearance")]
    public virtual Color HoverButtonColor
    {
        get
        {
            return _hoverButtonColor;
        }
        set
        {
            Color oldHoverButtonColor = HoverButtonColor;
            Color hoverButtonColor = value;

            if (hoverButtonColor.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(HoverButtonColor));
            }

            if (hoverButtonColor != oldHoverButtonColor)
            {
                _hoverButtonColor = value;

                Invalidate();
                OnHoverButtonColorChanged(EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// gets or sets the color of the text when the mouse hoverings the control
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("button appearance")]
    public virtual Color HoverTextColor
    {
        get
        {
            return _hoverTextColor;
        }
        set
        {
            Color oldHoverTextColor = HoverTextColor;
            Color hoverTextColor = value;

            if (hoverTextColor.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(HoverTextColor));
            }

            if (hoverTextColor != oldHoverTextColor)
            {
                _hoverTextColor = hoverTextColor;

                Invalidate();
                OnHoverTextColorChanged(EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// gets the state of the control
    /// </summary>
    public bool MouseHovering => Hovering;

    /// <summary>
    /// gets or sets the value of the hovering property when the mouse enters the control area
    /// </summary>
    private bool Hovering
    {
        get
        {
            return _hovering;
        }
        set
        {
            bool oldHovering = Hovering;
            bool hovering = value;

            if (hovering != oldHovering)
            {
                _hovering = hovering;
                Invalidate();
            }
        }
    }

    public override bool Focused
    {
        get
        {
            bool focused = base.Focused;
            bool currentFocused = FocusedInternal;

            return focused && currentFocused;
        }
    }

    private bool FocusedInternal
    {
        get
        {
            return _focused;
        }
        set
        {
            bool oldFocused = FocusedInternal;
            bool focused = value;

            if (focused != oldFocused)
            {
                _focused = focused;
                //Invalidate();
            }
        }
    }

    /// <summary>
    /// occurs when the <see cref="BorderColor"/> property changes its value
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler BorderColorChanged
    {
        add => Events.AddHandler(s_borderColorChanged, value);
        remove => Events.RemoveHandler(s_borderColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="ButtonColor"/> property changes its value
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler ButtonColorChanged
    {
        add => Events.AddHandler(s_buttonColorChanged, value);
        remove => Events.RemoveHandler(s_buttonColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="TextColor"/> property changes its value
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler TextColorChanged
    {
        add => Events.AddHandler(s_textColorChanged, value);
        remove => Events.RemoveHandler(s_textColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="HoverBorderColor"/> property changes its value
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler HoverBorderColorChanged
    {
        add => Events.AddHandler(s_hoverBorderColorChanged, value);
        remove => Events.RemoveHandler(s_hoverBorderColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="HoverButtonColor"/> property changes its value
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler HoverButtonColorChanged
    {
        add => Events.AddHandler(s_hoverButtonColorChanged, value);
        remove => Events.RemoveHandler(s_hoverButtonColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="HoverTextColor"/> property changes its value
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler HoverTextColorChanged
    {
        add => Events.AddHandler(s_hoverTextColorChanged, value);
        remove => Events.RemoveHandler(s_hoverTextColorChanged, value);
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
    /// raises the <see cref="ButtonColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnButtonColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_buttonColorChanged];
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
    /// raises the <see cref="HoverBorderColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnHoverBorderColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_hoverBorderColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="HoverButtonColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnHoverButtonColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_hoverButtonColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="HoverTextColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnHoverTextColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_hoverTextColorChanged];
        handler?.Invoke(this, e);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Graphics g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        int width = Width;
        int height = Height;

        int borderThickness = BorderThickness;
        int borderThicknessByTwo = BorderThicknessByTwo;

        Color borderColor = _hovering ? HoverBorderColor : BorderColor;
        _borderBrush = new SolidBrush(borderColor);

        g.FillEllipse(_borderBrush, 0, 0, height, height);
        g.FillEllipse(_borderBrush, width - height, 0, height, height);
        g.FillRectangle(_borderBrush, height / 2, 0, width - height, height);

        Color buttonColor = _hovering ? HoverButtonColor : ButtonColor;
        _buttonBrush = new SolidBrush(buttonColor);

        g.FillEllipse(_buttonBrush, borderThicknessByTwo, borderThicknessByTwo, height - borderThickness,
                height - borderThickness);
        g.FillEllipse(_buttonBrush, (width - height) + borderThicknessByTwo, borderThicknessByTwo,
            height - borderThickness, height - borderThickness);
        g.FillRectangle(_buttonBrush, height / 2 + borderThicknessByTwo, borderThicknessByTwo,
            width - height - borderThickness, height - borderThickness);

        Color textColor = _hovering ? HoverTextColor : TextColor;
        _textBrush = new SolidBrush(textColor);

        string text = Text;
        Font font = Font;

        SizeF textSize = g.MeasureString(text, font);
        float textWidth = (width - textSize.Width) / 2;
        float textHeight = (height - textSize.Height) / 2;

        g.DrawString(text, font, _textBrush, textWidth, textHeight);
    }


    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new ButtonWocAccessibleObject(this);
    }

    /// <summary>
    /// called when the mouse enters the control area
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnMouseEnter(object sender, EventArgs e)
    {
        Hovering = true;
    }

    /// <summary>
    /// called when the mouse leaves the control area
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnMouseLeave(object sender, EventArgs e)
    {
        Hovering = false;
    }

    private void OnEnterFocus(object sender, EventArgs e)
    {
        if (CanFocus)
        {
            FocusedInternal = true;
        }
    }

    private void OnLeaveFocus(object sender, EventArgs e)
    {
        FocusedInternal = false;
    }

    protected internal virtual void Initialize()
    {
        FlatAppearance.BorderColor = Color.White;
        FlatAppearance.BorderSize = 0;
        FlatAppearance.MouseOverBackColor = Color.White;
        FlatAppearance.MouseDownBackColor = Color.White;
        FlatStyle = FlatStyle.Flat;

        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

        MinimumSize = new Size(150, 50);

        MouseEnter += new EventHandler(OnMouseEnter);
        MouseLeave += new EventHandler(OnMouseLeave);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_borderBrush != null)
            {
                _borderBrush.Dispose();
                _borderBrush = null;
            }

            if (_buttonBrush != null)
            {
                _buttonBrush.Dispose();
                _buttonBrush = null;
            }

            if (_textBrush != null)
            {
                _textBrush.Dispose();
                _textBrush = null;
            }
        }

        base.Dispose(disposing);
    }
}