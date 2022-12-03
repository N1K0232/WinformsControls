namespace WinformsControls;

public partial class ColorPicker : UserControl
{
    public ColorPicker()
    {
        SetStyle(ControlStyles.ContainerControl, true);
        SetStyle(ControlStyles.UserPaint, true);

        InitializeComponent();
    }


    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    protected override AccessibleObject CreateAccessibilityInstance()
    {
        return new ColorPickerAccessibleObject(this);
    }

    private void OnScroll(object sender, EventArgs e)
    {
    }
}