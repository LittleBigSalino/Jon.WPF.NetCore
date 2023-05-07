using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls
{
    public static class WriteableBitmapExtensions
    {
        public static void SetPixel(this WriteableBitmap bitmap, int x, int y, Color color)
        {
            if (bitmap == null || x < 0 || y < 0 || x >= bitmap.PixelWidth || y >= bitmap.PixelHeight) return;

            int index = y * bitmap.BackBufferStride + x * (bitmap.Format.BitsPerPixel / 8);
            int pixel = (color.A << 24) | (color.R << 16) | (color.G << 8) | color.B;

            bitmap.Lock();
            unsafe
            {
                byte* buffer = (byte*)bitmap.BackBuffer;
                buffer[index] = color.B;
                buffer[index + 1] = color.G;
                buffer[index + 2] = color.R;
                buffer[index + 3] = color.A;
            }
            bitmap.AddDirtyRect(new Int32Rect(x, y, 1, 1));
            bitmap.Unlock();
        }

        public static Color GetPixel(this WriteableBitmap bitmap, int x, int y)
        {
            if (bitmap == null || x < 0 || y < 0 || x >= bitmap.PixelWidth || y >= bitmap.PixelHeight) return Colors.Transparent;

            bitmap.Lock();
            int index = y * bitmap.BackBufferStride + x * (bitmap.Format.BitsPerPixel / 8);

            byte b, g, r, a;
            unsafe
            {
                byte* buffer = (byte*)bitmap.BackBuffer;
                b = buffer[index];
                g = buffer[index + 1];
                r = buffer[index + 2];
                a = buffer[index + 3];
            }

            bitmap.Unlock();
            return Color.FromArgb(a, r, g, b);
        }
    }
}

