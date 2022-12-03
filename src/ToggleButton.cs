using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

public partial class ToggleButton : CheckBox
{
	private static readonly object s_sliderColorChanged = new();
	private static readonly object s_toggleColorChanged = new();
	private static readonly object s_solidStyleChanged = new();

	private Color _onSliderColor = Color.RoyalBlue;
	private Color _offSliderColor = Color.Gray;

	private Color _onToggleColor = Color.WhiteSmoke;
	private Color _offToggleColor = Color.Gainsboro;

	private bool _solidStyle = true;


	/// <summary>
	/// creates a new instance of the <see cref="ToggleButton"/> class
	/// </summary>
	public ToggleButton()
	{
		SetStyle(ControlStyles.UserPaint, true);
		SetStyle(ControlStyles.ResizeRedraw, true);

		SetStyle(ControlStyles.ContainerControl, false);
		SetStyle(ControlStyles.Opaque, false);

		MinimumSize = new Size(90, 45);
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

	/// <summary>
	/// gets the left arc of the toggle
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	private Rectangle LeftArc
	{
		get
		{
			int height = Height;
			int arcSize = height - 1;

			Rectangle leftArc = new(0, 0, arcSize, arcSize);
			return leftArc;
		}
	}

	/// <summary>
	/// gets the right arc of the toggle
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	private Rectangle RightArc
	{
		get
		{
			int width = Width;
			int height = Height;
			int arcSize = height - 1;

			Rectangle rightArc = new(width - arcSize - 2, 0, arcSize, arcSize);
			return rightArc;
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
	}

	/// <summary>
	/// draws the slider
	/// </summary>
	/// <param name="graphics"></param>
	/// <param name="isChecked"></param>
	private void DrawSlider(Graphics graphics, bool isChecked)
	{
		GraphicsPath path = GetFigurePath();
		Color backColor = GetSlideColor(isChecked);
		Brush backColorBrush = new SolidBrush(backColor);

		if (isChecked)
		{
			if (_solidStyle)
			{
				graphics.FillPath(backColorBrush, path);
			}
			else
			{
				graphics.DrawPath(new Pen(_onSliderColor), path);
			}
		}
		else
		{
			if (_solidStyle)
			{
				graphics.FillPath(backColorBrush, path);
			}
			else
			{
				graphics.DrawPath(new Pen(_offSliderColor), path);
			}
		}

		path.Dispose();
		backColorBrush.Dispose();
	}

	/// <summary>
	/// draws the toggle
	/// </summary>
	/// <param name="graphics"></param>
	/// <param name="width"></param>
	/// <param name="height"></param>
	/// <param name="isChecked"></param>
	private void DrawToggle(Graphics graphics, int width, int height, bool isChecked)
	{
		Color toggleColor = GetToggleColor(isChecked);
		Brush toggleColorBrush = new SolidBrush(toggleColor);

		int toggleSize = height - 5;
		Rectangle rectangle;

		if (isChecked)
		{
			rectangle = new Rectangle(width - height + 1, 2, toggleSize, toggleSize);
		}
		else
		{
			rectangle = new Rectangle(2, 2, toggleSize, toggleSize);
		}

		graphics.FillEllipse(toggleColorBrush, rectangle);
		toggleColorBrush.Dispose();
	}

	/// <summary>
	/// gets the path of the toggle button
	/// </summary>
	/// <returns></returns>
	private GraphicsPath GetFigurePath()
	{
		Rectangle leftArc = LeftArc;
		Rectangle rightArc = RightArc;

		GraphicsPath path = new();

		path.StartFigure();
		path.AddArc(leftArc, 90, 180);
		path.AddArc(rightArc, 270, 180);
		path.CloseFigure();

		return path;
	}

	/// <summary>
	/// gets the color of the slide giving its status
	/// </summary>
	/// <param name="isChecked"></param>
	/// <returns></returns>
	private Color GetSlideColor(bool isChecked)
	{
		return isChecked ?
			_onSliderColor :
			_offSliderColor;
	}

	/// <summary>
	/// gets the color of the toggle giving its status
	/// </summary>
	/// <param name="isChecked"></param>
	/// <returns></returns>
	private Color GetToggleColor(bool isChecked)
	{
		return isChecked ?
			_onToggleColor :
			_offToggleColor;
	}
}