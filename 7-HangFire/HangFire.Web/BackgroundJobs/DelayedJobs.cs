using System.Drawing;

namespace HangFire.Web.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string AddWaterMarkJob(string fileName, string waterMarkText)
        {
            return Hangfire.BackgroundJob.Schedule(() => ApplyWatermark(fileName, waterMarkText), TimeSpan.FromSeconds(20));
        }

        public static void ApplyWatermark(string fileName, string waterMarkText)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", fileName);
            using Image bitmap = Bitmap.FromFile(path);
            using Bitmap tempBitmap = new(bitmap.Width, bitmap.Height);
            using Graphics grp = Graphics.FromImage(tempBitmap);
            grp.DrawImage(bitmap, 0, 0);
            Font font = new(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
            Color color = Color.FromArgb(255, 0, 0);
            Brush brush = new SolidBrush(color);
            Point point = new(20, bitmap.Height - 50);

            grp.DrawString(waterMarkText, font, brush, point);

            tempBitmap.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures/Watermarks", fileName));
        }
    }
}
