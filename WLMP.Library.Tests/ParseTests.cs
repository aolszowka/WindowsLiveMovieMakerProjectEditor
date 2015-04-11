
namespace WLMP.Library.Tests
{
    using NUnit.Framework;
    using System.Diagnostics;

    [TestFixture]
    public class ParseTests
    {
        [Test]
        public void ParseForMediaItems_ValidInput()
        {
            var mediaItems = Parse.ForMediaItemFilePaths(@"R:\My Movie.wlmp");

            foreach (string mediaItem in mediaItems)
            {
                Trace.WriteLine(mediaItem);
            }
        }
    }
}
