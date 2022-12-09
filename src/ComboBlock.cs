using System.ComponentModel;
using ObjectCollection = System.Windows.Forms.ComboBox.ObjectCollection;

namespace WinformsControls;

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
	/// 
	/// </summary>
	public ComboBlock()
	{
		SetStyle(ControlStyles.UserPaint, true);
		SetStyle(ControlStyles.ContainerControl, true);
		Initialize();
	}


	public override Color BackColor
	{
		get
		{
			return _backColor;
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


	public Color IconColor
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


	public Color ListBackColor
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


	public Color ListTextColor
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

	public object DataSource
	{
		get
		{
			return cmbList.DataSource;
		}
		set
		{
			if (value is null)
			{
				throw new ArgumentException("you must add at least one member", nameof(DataSource));
			}

			if (value == DataSource)
			{
				return;
			}

			cmbList.DataSource = value;
		}
	}

	public ObjectCollection Items => cmbList.Items;

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

	public object SelectedItem
	{
		get
		{
			return cmbList.SelectedItem;
		}
		set
		{
			if (value is null)
			{
				throw new ArgumentException("value can't be null", nameof(SelectedItem));
			}

			if (value == SelectedItem)
			{
				return;
			}

			cmbList.SelectedItem = value;
		}
	}

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

	public string DisplayMember
	{
		get
		{
			return cmbList.DisplayMember;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Invalid value", nameof(DisplayMember));
			}

			if (value == DisplayMember)
			{
				return;
			}

			cmbList.DisplayMember = value;
		}
	}

	public string ValueMember
	{
		get
		{
			return cmbList.ValueMember;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Invalid value", nameof(ValueMember));
			}

			if (value == ValueMember)
			{
				return;
			}

			cmbList.ValueMember = value;
		}
	}


	public event EventHandler IconColorChanged
	{
		add => Events.AddHandler(s_iconColorChanged, value);
		remove => Events.RemoveHandler(s_iconColorChanged, value);
	}

	public event EventHandler ListBackColorChanged
	{
		add => Events.AddHandler(s_listBackColorChanged, value);
		remove => Events.RemoveHandler(s_listBackColorChanged, value);
	}

	public event EventHandler ListTextColorChanged
	{
		add => Events.AddHandler(s_listTextColorChanged, value);
		remove => Events.RemoveHandler(s_listTextColorChanged, value);
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

	public event EventHandler SelectedIndexChanged
	{
		add => Events.AddHandler(s_selectedIndexChanged, value);
		remove => Events.RemoveHandler(s_selectedIndexChanged, value);
	}


	protected virtual void OnIconColorChanged(EventArgs e)
	{
		EventHandler handler = (EventHandler)Events[s_iconColorChanged];
		handler?.Invoke(this, e);
	}

	protected virtual void OnListBackColorChanged(EventArgs e)
	{
		EventHandler handler = (EventHandler)Events[s_listBackColorChanged];
		handler?.Invoke(this, e);
	}

	protected virtual void OnListTextColorChanged(EventArgs e)
	{
		EventHandler handler = (EventHandler)Events[s_listTextColorChanged];
		handler?.Invoke(this, e);
	}

	protected virtual void OnBorderColorChanged(EventArgs e)
	{
		EventHandler handler = (EventHandler)Events[s_borderColorChanged];
		handler?.Invoke(this, e);
	}

	protected virtual void OnBorderSizeChanged(EventArgs e)
	{
		EventHandler handler = (EventHandler)Events[s_borderColorChanged];
		handler?.Invoke(this, e);
	}

	protected virtual void OnSelectedIndexChanged(object sender, EventArgs e)
	{
		if (sender is not null && sender is ComboBox comboBox && comboBox.Name.Equals(cmbList.Name))
		{
			EventHandler handler = (EventHandler)Events[s_selectedIndexChanged];
			handler?.Invoke(comboBox, e);
			RefreshText();
		}
	}

	protected void OnIconClick(object sender, EventArgs e)
	{
		if (sender is not null && sender is Button button && button.Name.Equals(btnIcon.Name))
		{
			cmbList.Select();
			cmbList.DroppedDown = true;
		}
	}

	protected void OnSurfaceClick(object sender, EventArgs e)
	{
		if (sender is not null && sender is Label label && label.Name.Equals(lblText.Name))
		{
			OnClick(e);

			cmbList.Select();
			if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
			{
				cmbList.DroppedDown = true;
			}
		}
	}

	protected void OnSurfaceEnter(object sender, EventArgs e)
	{
		if (sender is not null && sender is Label label && label.Name.Equals(lblText.Name))
		{
			OnMouseEnter(e);
		}
	}

	protected void OnSurfaceLeave(object sender, EventArgs e)
	{
		if (sender is not null && sender is Label label && label.Name.Equals(lblText.Name))
		{
			OnMouseLeave(e);
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

	protected void OnTextChanged(object sender, EventArgs e)
	{
		RefreshText();
	}

	private void RefreshText()
	{
		lblText.Text = cmbList.Text;
	}
}