using System.ComponentModel;

namespace WinformsControls;

public partial class TextBlock : UserControl
{
    private static readonly Color textColor = Color.DimGray;

    private IContainer components = null; //required designer field
    private TextBox textBox; //this field is required since the control we are designing is a textbox


    protected override void Dispose(bool disposing)
    {
        DisposeCore(disposing);
        base.Dispose(disposing);
    }

    private void DisposeCore(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }

            if (textBox != null)
            {
                textBox.Dispose();
            }
        }
    }

    /// <summary>
    /// initializes the graphic for this control
    /// </summary>
    protected internal virtual void InitializeComponent()
    {
        //creates a new instances of the fields
        components = new Container();
        textBox = new TextBox();

        SuspendLayout();

        //initialize the TextBox property
        textBox.BorderStyle = BorderStyle.None;
        textBox.Dock = DockStyle.Fill;
        textBox.Font = null;
        textBox.Text = null;
        textBox.Location = new Point(7, 7);
        textBox.Name = "textBox";
        textBox.Size = new Size(236, 22);
        textBox.TabIndex = 0;

        //subscribes the TextBox events
        textBox.TextChanged += new EventHandler(OnTextChanged);
        textBox.Click += new EventHandler(OnClick);
        textBox.Enter += new EventHandler(OnEnter);
        textBox.KeyPress += new KeyPressEventHandler(OnKeyPress);
        textBox.Leave += new EventHandler(OnLeave);
        textBox.MouseEnter += new EventHandler(OnMouseEnter);
        textBox.MouseLeave += new EventHandler(OnMouseLeave);

        //initializes the UserControl properties
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        ForeColor = textColor;
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        Margin = new Padding(4, 4, 4, 4);
        Name = "TextBlock";
        Padding = new Padding(7, 7, 7, 7);
        Size = new Size(250, 30);
        Controls.Add(textBox);

        ResumeLayout(false);
        PerformLayout();
    }
}