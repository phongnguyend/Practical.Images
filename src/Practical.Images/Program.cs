using ImageMagick;
using OpenCvSharp;
using SkiaSharp;
using System.Drawing;


var fileName = "C:\\Users\\Phong.NguyenDoan\\Downloads\\0CA60F60-1091-456B-9F91-28DF9D65D428.jpg";

using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
{
    Bitmap imagePath = (Bitmap)Image.FromStream(stream, true);
    Console.WriteLine($"Width: {imagePath.Width} Height: {imagePath.Height}");
}

using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(stream))
{
    Console.WriteLine($"Width: {image.Width} Height: {image.Height}");
}

using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
{
    var skBitmap = SKBitmap.Decode(stream);
    Console.WriteLine($"Width: {skBitmap.Width} Height: {skBitmap.Height}");
}

using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
using (var image = new MagickImage(stream))
{
    Console.WriteLine($"Width: {image.Width} Height: {image.Height}");
}

using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
using (var ms = new MemoryStream())
{
    stream.CopyTo(ms);
    using Mat image = Cv2.ImDecode(ms.ToArray(), ImreadModes.Color);
    Console.WriteLine($"Width: {image.Width} Height: {image.Height}");
}