namespace WinformsControls;

public partial class ToggleButton
{
    public class ToggleButtonAccessibleObject : CheckBoxAccessibleObject
    {
        public ToggleButtonAccessibleObject(Control owner)
            : base(owner is ToggleButton toggleButton ? toggleButton
            : throw new ArgumentException("invalid control", nameof(owner)))
        {
        }
    }
}