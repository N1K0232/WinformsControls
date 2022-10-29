using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinformsControls;

public partial class RoundButton : Button
{
	private int _borderSize = 0;
	private int _borderRadius = 40;
	private Color _borderColor = Color.PaleVioletRed;

	/// <summary>
	/// creates a new instance of the <see cref="RoundButton"/> control
	/// </summary>
	public RoundButton()
	{
		SetStyle(ControlStyles.UserPaint, true);
		Initialize();
	}

	/// <summary>
	/// gets or sets the size of the border
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Category("button appearance")]
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
				throw new ArgumentException("invalid value", nameof(BorderSize));
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
	/// gets or sets the radius of the border
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Category("button appearance")]
	public int BorderRadius
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
		}
	}

	/// <summary>
	/// gets or sets the radius of the border
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Category("button appearance")]
	public Color BorderColor
	{
		get
		{
			return _borderColor;
		}
		set
		{
			Color c = value;

			if (c.IsEmpty)
			{
				throw new ArgumentException("Invalid color", nameof(BorderColor));
			}

			if (c == BorderColor)
			{
				return;
			}

			_borderColor = c;
		}
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

	private void DrawBorder(Graphics graphics, int width, int height)
	{
		Color borderColor = BorderColor;
		int borderSize = BorderSize;
		int borderRadius = BorderRadius;

		RectangleF borderRectangle = new(1, 1, Width - 0.8F, Height - 1);
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

	private void DrawSurface(Graphics graphics, int width, int height)
	{
		RectangleF surfaceRectangle = new(0, 0, width, height);
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
	protected override void OnHandleDestroyed(EventArgs e)
	{
		base.OnHandleDestroyed(e);

		Control container = Parent;
		container.BackColorChanged -= new EventHandler(Container_BackColorChanged);
	}

	/// <summary>
	/// if this control is in DesignMode then redraw the control
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
	/// initializes the base properties of the control
	/// </summary>
	private void Initialize()
	{
		Size = new Size(150, 40);
		Font = new Font("Segoe UI", 12F);

		FlatStyle = FlatStyle.Flat;
		FlatAppearance.BorderSize = 0;

		BackColor = Color.RoyalBlue;
		ForeColor = Color.White;
	}

	private GraphicsPath GetFigurePath(RectangleF rectangle, float offset = 0)
	{
		float borderRadius = Convert.ToSingle(BorderRadius);
		float radius = offset != 0 ? borderRadius - offset : borderRadius;

		float x = rectangle.X;
		float y = rectangle.Y;
		float width = rectangle.Width;
		float height = rectangle.Height;

		GraphicsPath path = new();
		path.StartFigure();
		path.AddArc(x, y, radius, radius, 180, 90);
		path.AddArc(width - radius, y, radius, radius, 270, 90);
		path.AddArc(width - radius, height - radius, radius, radius, 0, 90);
		path.AddArc(x, height - radius, radius, radius, 90, 90);
		path.CloseFigure();
		return path;
	}
}