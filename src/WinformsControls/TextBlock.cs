using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

/// <summary>
/// 
/// </summary>
[DefaultEvent(nameof(TextChanged))]
public partial class TextBlock : UserControl
{
    private Color _borderColor = Color.RoyalBlue;
    private Color _borderFocusColor = Color.HotPink;

    private int _borderSize = 2;

    private string _placeholderText = null;
    private Color _placeholderColor = Color.Gray;

    private bool _underlinedStyle = false;
    private bool _focused = false;

    private bool _isPlaceholder = false;

    /// <summary>
    /// creates a new instance of the <see cref="TextBlock"/> class
    /// </summary>
    public TextBlock()
    {
        SetStyle(ControlStyles.ResizeRedraw, false); //the control can't be resized by the user
        SetStyle(ControlStyles.ContainerControl, false); //the control is not a container control

        SetStyle(ControlStyles.UserPaint, true); //the user can define the appearance of the control

        InitializeComponent();
    }

    /// <summary>
    /// gets or sets the color of the border
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
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
                throw new ArgumentException("invalid color", nameof(value));
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
    /// gets or sets the color of the border when the control is focused
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color BorderFocusColor
    {
        get
        {
            return _borderFocusColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(value));
            }

            if (value == BorderFocusColor)
            {
                return;
            }

            _borderFocusColor = value;
        }
    }

    /// <summary>
    /// gets or sets the border size of the control
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
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
                throw new ArgumentException("invalid size", nameof(value));
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
    /// gets or sets a value that specifies whether the textbox is underlined or not
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool UnderlinedStyle
    {
        get
        {
            return _underlinedStyle;
        }
        set
        {
            if (value == UnderlinedStyle)
            {
                return;
            }

            _underlinedStyle = value;
            Invalidate();
        }
    }

    /// <summary>
    /// gets or sets the text of the control
    /// </summary>
    [Browsable(true)]
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override string Text
    {
        get
        {
            string text = IsPlaceholder ? string.Empty : InnerText;
            return text;
        }
        set
        {
            InnerText = value;
            SetPlaceholder();
        }
    }

    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual string PlaceholderText
    {
        get
        {
            return _placeholderText;
        }
        set
        {
            if (value == PlaceholderText)
            {
                return;
            }

            _placeholderText = value;
            InnerText = string.Empty;

            SetPlaceholder();
            OnPlaceholderTextChanged(EventArgs.Empty);
        }
    }

    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual Color PlaceholderColor
    {
        get
        {
            return _placeholderColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(value));
            }

            if (value == PlaceholderColor)
            {
                return;
            }

            _placeholderColor = value;

            if (IsPlaceholder)
            {
                ForeColor = value;
            }
        }
    }

    /// <summary>
    /// gets or sets the password character of the control
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public char PasswordChar
    {
        get => textBox.PasswordChar;
        set => textBox.PasswordChar = value;
    }

    /// <summary>
    /// gets or sets a value that specifies if the control should be a password text box or not
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool UseSystemPasswordChar
    {
        get => UseSystemPasswordCharInternal;
        set => UseSystemPasswordCharInternal = value;
    }

    /// <summary>
    /// gets or sets a boolean value to specify if the <see cref="TextBlock"/> can be multiline or not
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool Multiline
    {
        get => MultilineInternal;
        set => MultilineInternal = value;
    }

    /// <summary>
    /// gets or sets the back color of the control
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override Color BackColor
    {
        get
        {
            Color backColor = base.BackColor;
            if (backColor.IsEmpty)
            {
                backColor = textBox.BackColor;
            }

            return backColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("Invalid color", nameof(value));
            }

            if (value == BackColor && value == textBox.BackColor)
            {
                return;
            }

            base.BackColor = value;
            textBox.BackColor = value;
        }
    }

    /// <summary>
    /// gets or sets the color of the control text
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override Color ForeColor
    {
        get
        {
            Color foreColor = base.ForeColor;
            if (foreColor.IsEmpty)
            {
                foreColor = textBox.ForeColor;
            }

            return foreColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("Invalid color", nameof(value));
            }

            if (value == ForeColor && value == textBox.ForeColor)
            {
                return;
            }

            base.ForeColor = value;
            textBox.ForeColor = value;
        }
    }

    /// <summary>
    /// gets or sets the font of the control
    /// </summary>
    [Category("control appearance")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override Font Font
    {
        get
        {
            Font font = textBox.Font;

            if (font is null)
            {
                return base.Font;
            }

            return font;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("invalid font", nameof(value));
            }

            if (value == Font)
            {
                return;
            }

            base.Font = value;
            textBox.Font = value;

            UpdateHeight();
        }
    }

    /// <summary>
    /// used by the <see cref="TextBlock"/> private methods to update the <see cref="TextBox.UseSystemPasswordChar"/> 
    /// property of the control
    /// </summary>
    private bool UseSystemPasswordCharInternal
    {
        get => textBox.UseSystemPasswordChar;
        set
        {
            if (value == UseSystemPasswordCharInternal)
            {
                return;
            }

            textBox.UseSystemPasswordChar = value;
        }
    }

    /// <summary>
    /// used by the <see cref="TextBlock"/> private methods to update the <see cref="TextBox.Text"/> 
    /// property of the control
    /// </summary>
    private string InnerText
    {
        get => textBox.Text;
        set
        {
            if (value == InnerText)
            {
                return;
            }

            textBox.Text = value;
        }
    }

    /// <summary>
    /// used by the <see cref="TextBlock"/> private methods to update the <see cref="TextBox.Multiline"/>
    /// property of the control
    /// </summary>
    private bool MultilineInternal
    {
        get => textBox.Multiline;
        set
        {
            if (value == MultilineInternal)
            {
                return;
            }

            textBox.Multiline = value;
        }
    }

    /// <summary>
    /// gets or sets the <see cref="_isPlaceholder"/> field
    /// </summary>
    private bool IsPlaceholder
    {
        get => _isPlaceholder;
        set => _isPlaceholder = value;
    }


    public new event EventHandler TextChanged;
    public event EventHandler PlaceholderTextChanged;

    /// <summary>
    /// raises the <see cref="TextChanged"/> event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnTextChanged(object sender, EventArgs e)
    {
        EventHandler handler = TextChanged;

        if (sender is TextBox textBox && handler != null)
        {
            handler.Invoke(textBox, e);
        }
    }

    /// <summary>
    /// raises the <see cref="PlaceholderTextChanged"/> event
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnPlaceholderTextChanged(EventArgs e)
    {
        EventHandler handler = PlaceholderTextChanged;
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnMouseEnter(object sender, EventArgs e)
    {
        OnMouseEnter(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnMouseLeave(object sender, EventArgs e)
    {
        OnMouseLeave(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnClick(object sender, EventArgs e)
    {
        OnClick(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnKeyPress(object sender, KeyPressEventArgs e)
    {
        OnKeyPress(e);
    }

    /// <summary>
    /// raises the <see cref="Control.Resize"/> event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        UpdateHeight();
    }

    /// <summary>
    /// raises the <see cref="UserControl.Load"/> event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        UpdateHeightCore();
    }

    /// <summary>
    /// raises the <see cref="Control.Paint"/> event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics graphics = e.Graphics;
        Pen borderPen = new(_borderColor, _borderSize);

        int width = Width;
        int height = Height;

        bool focused = _focused;
        bool underlinedStyle = UnderlinedStyle;

        if (!focused)
        {
            borderPen.Alignment = PenAlignment.Inset;

            if (_underlinedStyle)
            {
                graphics.DrawLine(borderPen, 0, height - 1, width, height - 1);
            }
            else
            {
                graphics.DrawRectangle(borderPen, 0, 0, width - 0.5F, height - 0.5F);
            }
        }
        else
        {
            borderPen.Color = _borderFocusColor;

            if (underlinedStyle)
            {
                graphics.DrawLine(borderPen, 0, height - 1, width, height - 1);
            }
            else
            {
                graphics.DrawRectangle(borderPen, 0, 0, width - 0.5F, height - 0.5F);
            }
        }
    }

    /// <summary>
    /// called when the control is focused
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnEnter(object sender, EventArgs e)
    {
        _focused = true;

        Invalidate();
        RemovePlaceholder();
    }

    /// <summary>
    /// invoked when another control gets the focus
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnLeave(object sender, EventArgs e)
    {
        _focused = false;

        Invalidate();
        SetPlaceholder();
    }

    private void UpdateHeight()
    {
        bool designMode = DesignMode;
        if (designMode)
        {
            UpdateHeightCore();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void UpdateHeightCore()
    {
        bool multiline = MultilineInternal;
        if (!multiline)
        {
            string text = InnerText ?? "Text";
            Font font = Font;

            Size textSize = TextRenderer.MeasureText(text, font);
            int textHeight = textSize.Height + 1;
            MultilineInternal = true;
            textBox.MinimumSize = new Size(0, textHeight);
            MultilineInternal = false;

            Padding padding = Padding;
            Height = textBox.Height + padding.Top + padding.Bottom;
        }
    }

    /// <summary>
    /// sets the place holder text in the <see cref="TextBox.Text"/> property
    /// </summary>
    private void SetPlaceholder()
    {
        string placeholderText = PlaceholderText;
        Color placeholderColor = PlaceholderColor;

        if (string.IsNullOrWhiteSpace(textBox.Text) && placeholderText != "")
        {
            IsPlaceholder = true;
            InnerText = placeholderText;
            ForeColor = placeholderColor;
            if (!UseSystemPasswordChar)
            {
                UseSystemPasswordChar = false;
            }
        }
    }

    /// <summary>
    /// removes the place holder from the <see cref="TextBox.Text"/>
    /// </summary>
    private void RemovePlaceholder()
    {
        string placeholderText = PlaceholderText;

        if (IsPlaceholder && placeholderText != "")
        {
            IsPlaceholder = false;
            InnerText = null;
            ForeColor = textColor;
            if (UseSystemPasswordChar)
            {
                UseSystemPasswordChar = false;
            }
        }
    }
}