namespace WinformsControls;

public partial class TextBlock
{
    public class TextBlockAccessibleObject : ControlAccessibleObject
    {
        public TextBlockAccessibleObject(Control ownerControl)
            : base(ownerControl is TextBlock textBlock ?
                   textBlock : throw new ArgumentException("invalid control", nameof(ownerControl)))
        {
        }
    }
}