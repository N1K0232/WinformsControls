namespace WinformsControls;

public partial class ColorPicker
{
    public class ColorPickerAccessibleObject : ControlAccessibleObject
    {
        private readonly ColorPicker _owner;

        public ColorPickerAccessibleObject(Control owner)
            : base(owner is ColorPicker colorPicker ? colorPicker
            : throw new ArgumentException("invalid control", nameof(owner)))
        {
            _owner = colorPicker;
        }
    }
}