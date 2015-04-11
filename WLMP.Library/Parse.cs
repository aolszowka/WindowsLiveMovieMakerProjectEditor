//-----------------------------------------------------------------------
// <copyright file="Parse.cs" company="Ace Olszowka">
//   Copyright (c) Ace Olszowka 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WLMP.Library
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    ///   Utility class that encapsulates all of the operations that Parse
    /// a Windows Live Movie Maker Project (*.wlmp).
    /// </summary>
    public static class Parse
    {
        /// <summary>
        ///   Parses a Windows Live Movie Maker Project (*.wlmp) and returns
        /// a list that contains all of the unique Media Item File Paths.
        /// </summary>
        /// <param name="projectFile">The Windows Live Movie Maker Project (*.wlmp) to parse.</param>
        /// <returns>An Enumerable that contains all of the unique Media Item File Paths.</returns>
        public static IEnumerable<string> ForMediaItemFilePaths(string projectFile)
        {
            XDocument wlmp = XDocument.Load(projectFile);

            return new HashSet<string>(
                wlmp
                .Descendants(WLMPTagConstants.MEDIA_ITEM)
                .Select(mediaItem => mediaItem.Attribute(WLMPTagConstants.MEDIA_ITEM_FILE_PATH_ATTRIBUTE).Value));
        }
    }
}
