using System.Runtime.InteropServices;

namespace WinformsControls;

public partial class TextBlock
{
    private const int WM_NCPAINT = 0x85;
    private const uint RDW_INVALIDATE = 0x1;
    private const uint RDW_IUPDATENOW = 0x100;
    private const uint RDW_FRAME = 0x400;

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("user32.dll")]
    private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
}