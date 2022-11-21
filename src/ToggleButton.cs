using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

public partial class ToggleButton : CheckBox
{
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

			OnSlideColorChanged(EventArgs.Empty);
			Invalidate();
		}
	}

	/// <summary>
	/// gets or sets the color of the slide when the <see cref="ToggleButton"/> is unchecked
	/// </summary>
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

			OnSlideColorChanged(EventArgs.Empty);
			Invalidate();
		}
	}

	/// <summary>
	/// gets or sets the color of the toggle when the <see cref="ToggleButton"/> is checked
	/// </summary>
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

			OnToggleColorChanged(EventArgs.Empty);
			Invalidate();
		}
	}

	/// <summary>
	/// gets or sets the color of the toggle when the <see cref="ToggleButton"/> is unchecked
	/// </summary>
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

			OnToggleColorChanged(EventArgs.Empty);
			Invalidate();
		}
	}

	/// <summary>
	/// gets or sets the style of the toggle
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Category("toggle appearance")]
	public bool SolidStyle
	{
		get { return _solidStyle; }
		set
		{
			if (value == SolidStyle)
			{
				return;
			}

			_solidStyle = value;

			OnSolidStyleChanged(EventArgs.Empty);
			Invalidate();
		}
	}

	/// <summary>
	/// gets the left arc of the toggle
	/// </summary>
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


	public event EventHandler SlideColorChanged;
	public event EventHandler ToggleColorChanged;
	public event EventHandler SolidStyleChanged;

	/// <summary>
	/// raises the <see cref="ToggleButton.SlideColorChanged"/> event
	/// </summary>
	/// <param name="e"></param>
	protected virtual void OnSlideColorChanged(EventArgs e)
	{
		EventHandler handler = SlideColorChanged;
		handler?.Invoke(this, e);
	}

	/// <summary>
	/// raises the <see cref="ToggleButton.ToggleColorChanged"/> event
	/// </summary>
	/// <param name="e"></param>
	protected virtual void OnToggleColorChanged(EventArgs e)
	{
		EventHandler handler = ToggleColorChanged;
		handler?.Invoke(this, e);
	}

	/// <summary>
	/// raises the <see cref="ToggleButton.SolidStyleChanged"/> event
	/// </summary>
	/// <param name="e"></param>
	protected virtual void OnSolidStyleChanged(EventArgs e)
	{
		EventHandler handler = SolidStyleChanged;
		handler?.Invoke(this, e);
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
		SolidBrush brush = new(backColor);

		if (isChecked)
		{
			if (_solidStyle)
			{
				graphics.FillPath(brush, path);
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
				graphics.FillPath(brush, path);
			}
			else
			{
				graphics.DrawPath(new Pen(_offSliderColor), path);
			}
		}

		path.Dispose();
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
		SolidBrush brush = new(toggleColor);

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

		graphics.FillEllipse(brush, rectangle);
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