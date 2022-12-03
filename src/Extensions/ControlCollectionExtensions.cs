using ControlCollection = System.Windows.Forms.Control.ControlCollection;

namespace WinformsControls.Extensions;

public static class ControlCollectionExtensions
{
    public static void RemoveRange(this ControlCollection controls, IEnumerable<Control> items)
    {
        foreach (Control item in controls)
        {
            controls.Remove(item);
            if (!item.IsDisposed)
            {
                item.Dispose();
            }
        }
    }
}