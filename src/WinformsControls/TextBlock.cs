namespace WinformsControls;

public partial class TextBlock : TextBox
{
    private static readonly object s_borderColorChanged = new();

    private Color _borderColor = Color.Blue;

    public TextBlock()
    {
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
                throw new ArgumentException("you must specify the color", nameof(BorderColor));
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

    public event EventHandler BorderColorChanged
    {
        add => Events.AddHandler(s_borderColorChanged, value);
        remove => Events.RemoveHandler(s_borderColorChanged, value);
    }

    protected virtual void OnBorderColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_borderColorChanged];
        handler?.Invoke(this, e);

        RedrawWindow();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        RedrawWindow();
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        Color borderColor = BorderColor;
        BorderStyle borderStyle = BorderStyle;

        if (m.Msg == WM_NCPAINT && borderColor != Color.Transparent &&
            borderStyle == BorderStyle.Fixed3D)
        {
            nint handle = Handle;
            nint hdc = GetWindowDC(handle);

            Graphics graphics = Graphics.FromHdcInternal(hdc);

            int borderWidth = Width - 1;
            int borderHeight = Height - 1;

            var borderRectangle = new Rectangle(0, 0, borderWidth, borderHeight);
            var borderPen = new Pen(borderColor);

            graphics.DrawRectangle(borderPen, borderRectangle);
            ReleaseDC(handle, hdc);
        }
    }

    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new TextBlockAccessibleObject(this);
    }

    private void RedrawWindow()
    {
        nint handle = Handle;
        uint frame = RDW_FRAME;
        uint updateNow = RDW_IUPDATENOW;
        uint invalidate = RDW_INVALIDATE;

        nint lprc = nint.Zero;
        nint hrgn = nint.Zero;

        RedrawWindow(handle, lprc, hrgn, frame | updateNow | invalidate);
    }
}