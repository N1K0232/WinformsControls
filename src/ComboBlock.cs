using System.ComponentModel;
using ObjectCollection = System.Windows.Forms.ComboBox.ObjectCollection;

namespace WinformsControls;

/// <summary>
/// represents a <see cref="ComboBox"/> control with custom design
/// </summary>
[DefaultEvent(nameof(SelectedIndexChanged))]
public partial class ComboBlock : UserControl
{
    private static readonly object s_selectedIndexChanged = new();
    private static readonly object s_iconColorChanged = new();

    private static readonly object s_listBackColorChanged = new();
    private static readonly object s_listTextColorChanged = new();

    private static readonly object s_borderColorChanged = new();
    private static readonly object s_borderSizeChanged = new();


    private Color _backColor = Color.WhiteSmoke;
    private Color _iconColor = Color.MediumSlateBlue;

    private Color _listBackColor = Color.FromArgb(230, 228, 245);
    private Color _listTextColor = Color.DimGray;

    private Color _borderColor = Color.MediumSlateBlue;

    private int _borderSize = 1;


    /// <summary>
    /// creates a new instance of <see cref="ComboBlock"/> class
    /// </summary>
    public ComboBlock()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.ContainerControl, true);

        SetStyle(ControlStyles.Selectable, true);
        SetStyle(ControlStyles.ResizeRedraw, true);

        SetStyle(ControlStyles.Opaque, false);

        Initialize();
    }


    public override Color BackColor
    {
        get
        {
            Color c = _backColor;
            if (c.IsEmpty)
            {
                c = base.BackColor;
            }

            return c;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("Invalid color", nameof(BackColor));
            }

            if (value == BackColor)
            {
                return;
            }

            _backColor = value;

            lblText.BackColor = value;
            btnIcon.BackColor = value;
        }
    }

    public override Color ForeColor
    {
        get
        {
            return base.ForeColor;
        }
        set
        {
            base.ForeColor = value;
            lblText.ForeColor = value;
        }
    }

    public override Font Font
    {
        get
        {
            return base.Font;
        }
        set
        {
            base.Font = value;

            lblText.Font = value;
            cmbList.Font = value;
        }
    }

    /// <summary>
    /// gets or sets the color of the icon
    /// </summary>
    [Category("control appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual Color IconColor
    {
        get
        {
            return _iconColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(IconColor));
            }

            if (value == IconColor)
            {
                return;
            }

            _iconColor = value;

            Invalidate();
            OnIconColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the color of the background when the combo box is in list mode
    /// </summary>
    [Category("control appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual Color ListBackColor
    {
        get
        {
            return _listBackColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(ListBackColor));
            }

            if (value == ListBackColor)
            {
                return;
            }

            _listBackColor = value;

            Invalidate();
            OnListBackColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the color of the text when the combo box is in list mode
    /// </summary>
    [Category("control appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual Color ListTextColor
    {
        get
        {
            return _listTextColor;
        }
        set
        {
            if (value.IsEmpty)
            {
                throw new ArgumentException("invalid color", nameof(ListTextColor));
            }

            if (value == ListTextColor)
            {
                return;
            }

            _listTextColor = value;

            Invalidate();
            OnListTextColorChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// gets or sets the color of the border
    /// </summary>
    [Category("control appearance")]
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
    /// gets or sets the size of the border
    /// </summary>
    [Category("control appearance")]
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
    /// gets or sets the <see cref="ComboBox"/> <see cref="DropDownStyle"/> property
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public ComboBoxStyle DropDownStyle
    {
        get
        {
            return cmbList.DropDownStyle;
        }
        set
        {
            if (value == DropDownStyle)
            {
                return;
            }

            if (cmbList.DropDownStyle != ComboBoxStyle.Simple)
            {
                cmbList.DropDownStyle = value;
            }
        }
    }

    /// <summary>
    /// gets or sets the <see cref="ComboBox"/> <see cref="DataSource"/> property
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public object DataSource
    {
        get
        {
            return cmbList.DataSource;
        }
        set
        {
            if (value == DataSource)
            {
                return;
            }

            cmbList.DataSource = value;
        }
    }

    /// <summary>
    /// gets the <see cref="ComboBox"/> items list
    /// </summary>
    [Category("Data")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public ObjectCollection Items => cmbList.Items;

    /// <summary>
    /// gets or sets the <see cref="ComboBox"/> <see cref="AutoCompleteSource"/> property
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public AutoCompleteSource AutoCompleteSource
    {
        get
        {
            return cmbList.AutoCompleteSource;
        }
        set
        {
            if (value == AutoCompleteSource)
            {
                return;
            }

            cmbList.AutoCompleteSource = value;
        }
    }

    /// <summary>
    /// gets or sets the <see cref="ComboBox"/> <see cref="AutoCompleteMode"/> property
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public AutoCompleteMode AutoCompleteMode
    {
        get
        {
            return cmbList.AutoCompleteMode;
        }
        set
        {
            if (value == AutoCompleteMode)
            {
                return;
            }

            cmbList.AutoCompleteMode = value;
        }
    }

    /// <summary>
    /// gets or sets the <see cref="ComboBox"/> <see cref="SelectedItem"/> property
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public object SelectedItem
    {
        get
        {
            return cmbList.SelectedItem;
        }
        set
        {
            if (value == SelectedItem)
            {
                return;
            }

            cmbList.SelectedItem = value;
        }
    }

    /// <summary>
    /// gets or sets the <see cref="ComboBox"/> <see cref="SelectedIndex"/> property
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public int SelectedIndex
    {
        get
        {
            return cmbList.SelectedIndex;
        }
        set
        {
            if (value == SelectedIndex)
            {
                return;
            }

            cmbList.SelectedIndex = value;
        }
    }

    /// <summary>
    /// gets or sets the <see cref="ComboBox"/> <see cref="DisplayMember"/> property
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public string DisplayMember
    {
        get
        {
            return cmbList.DisplayMember;
        }
        set
        {
            if (value == DisplayMember)
            {
                return;
            }

            cmbList.DisplayMember = value;
        }
    }

    /// <summary>
    /// gets or sets the <see cref="ComboBox"/> <see cref="ValueMember"/> property
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public string ValueMember
    {
        get
        {
            return cmbList.ValueMember;
        }
        set
        {
            if (value == ValueMember)
            {
                return;
            }

            cmbList.ValueMember = value;
        }
    }


    /// <summary>
    /// occurs when the <see cref="IconColor"/> changes value
    /// </summary>
    [Category("control events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler IconColorChanged
    {
        add => Events.AddHandler(s_iconColorChanged, value);
        remove => Events.RemoveHandler(s_iconColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="ListBackColor"/> changes value
    /// </summary>
    [Category("control events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler ListBackColorChanged
    {
        add => Events.AddHandler(s_listBackColorChanged, value);
        remove => Events.RemoveHandler(s_listBackColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="ListTextColor"/> changes value
    /// </summary>
    [Category("control events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler ListTextColorChanged
    {
        add => Events.AddHandler(s_listTextColorChanged, value);
        remove => Events.RemoveHandler(s_listTextColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="BorderColor"/> changes value
    /// </summary>
    [Category("control events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler BorderColorChanged
    {
        add => Events.AddHandler(s_borderColorChanged, value);
        remove => Events.RemoveHandler(s_borderColorChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="BorderSize"/> changes value
    /// </summary>
    [Category("control events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler BorderSizeChanged
    {
        add => Events.AddHandler(s_borderSizeChanged, value);
        remove => Events.RemoveHandler(s_borderSizeChanged, value);
    }

    /// <summary>
    /// occurs when the <see cref="SelectedIndex"/> changes value
    /// </summary>
    [Category("control events")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler SelectedIndexChanged
    {
        add => Events.AddHandler(s_selectedIndexChanged, value);
        remove => Events.RemoveHandler(s_selectedIndexChanged, value);
    }

    /// <summary>
    /// raises the <see cref="IconColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnIconColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_iconColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="ListBackColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnListBackColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_listBackColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="ListTextColorChanged"/> event
    /// </summary>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnListTextColorChanged(EventArgs e)
    {
        EventHandler handler = (EventHandler)Events[s_listTextColorChanged];
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// raises the <see cref="BorderSizeChanged"/> event
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

    /// <summary>
    /// occurs when the index is changed
    /// </summary>
    /// <param name="sender">the control that invoked the event</param>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (sender is not null && sender is ComboBox comboBox && comboBox.Name.Equals(cmbList.Name))
        {
            EventHandler handler = (EventHandler)Events[s_selectedIndexChanged];
            handler?.Invoke(comboBox, e);

            RefreshText();
        }
    }

    /// <summary>
    /// occurs when the icon button is pressend
    /// </summary>
    /// <param name="sender">the control that invoked the event</param>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void OnIconClick(object sender, EventArgs e)
    {
        if (sender is not null && sender is Button button && button.Name.Equals(btnIcon.Name))
        {
            RefreshStyle();
        }
    }

    /// <summary>
    /// occurs when the label text is clicked
    /// </summary>
    /// <param name="sender">the control that invoked the event</param>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void OnSurfaceClick(object sender, EventArgs e)
    {
        if (sender is not null && sender is Label label && label.Name.Equals(lblText.Name))
        {
            OnClick(e);
            RefreshStyle();
        }
    }

    /// <summary>
    /// occurs when the mouse enters the surface area
    /// </summary>
    /// <param name="sender">the control that invoked the event</param>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void OnSurfaceEnter(object sender, EventArgs e)
    {
        if (sender is not null && sender is Label label && label.Name.Equals(lblText.Name))
        {
            OnMouseEnter(e);
        }
    }

    /// <summary>
    /// occurs when the mouse leaves the surface area
    /// </summary>
    /// <param name="sender">the control that invoked the event</param>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void OnSurfaceLeave(object sender, EventArgs e)
    {
        if (sender is not null && sender is Label label && label.Name.Equals(lblText.Name))
        {
            OnMouseLeave(e);
        }
    }

    /// <summary>
    /// occurs when the text changes
    /// </summary>
    /// <param name="sender">the control that invoked the event</param>
    /// <param name="e">the event data</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void OnTextChanged(object sender, EventArgs e)
    {
        if (sender is not null && sender is ComboBox comboBox && comboBox.Name.Equals(cmbList.Name))
        {
            RefreshText();
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        AdjustComboBoxDimensions();
    }

    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new ComboBlockAccessibleObject(this);
    }

    /// <summary>
    /// sets the <see cref="ComboBox"/> style to DroppedDown
    /// </summary>
    private void RefreshStyle()
    {
        cmbList.Select();
        cmbList.DroppedDown = true;
    }

    /// <summary>
    /// updates the text
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void RefreshText()
    {
        lblText.Text = cmbList.Text;
    }
}