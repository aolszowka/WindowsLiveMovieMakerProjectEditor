using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLMP.Library.Tests
{
    [TestFixture]
    public class ExportTests
    {
        [Test]
        [TestCase(@"R:\My Movie.wlmp", @"R:\TestExport")]
        public void Project_ValidInputs(string projectFile, string exportDirectory)
        {
            Export.Project(projectFile, exportDirectory);
        }
    }
}
