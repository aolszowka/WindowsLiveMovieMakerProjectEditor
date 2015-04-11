//-----------------------------------------------------------------------
// <copyright file="Modify.cs" company="Ace Olszowka">
//   Copyright (c) Ace Olszowka 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WLMP.Library
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    ///     Utility class that encapsulates all of the operations that modify a
    /// Windows Live Movie Maker Project (*.wlmp).
    /// </summary>
    public static class Modify
    {
        /// <summary>
        ///     Given a Windows Live Movie Maker Project File (*.wlmp) and a
        /// cross reference of file locations, update all MediaItem tags that
        /// contain a filePath reference to the Keys of the given dictionary
        /// with the Value of that KeyValuePair.
        /// </summary>
        /// <param name="projectFile">The Windows Live Movie Maker Project (*.wlmp) to modify.</param>
        /// <param name="fileLocations">A Dictionary Cross reference in which the Key is the old file name, and the value is the new file name.</param>
        public static void MediaItemsFilePath(string projectFile, IDictionary<string, string> fileLocations)
        {
            XDocument wlmp = XDocument.Load(projectFile);
            var mediaItems = wlmp.Descendants(WLMPTagConstants.MEDIA_ITEM).ToArray();

            foreach (XElement mediaItem in mediaItems)
            {
                string filePath = mediaItem.Attribute(WLMPTagConstants.MEDIA_ITEM_FILE_PATH_ATTRIBUTE).Value;

                if (fileLocations.ContainsKey(filePath))
                {
                    mediaItem.Attribute(WLMPTagConstants.MEDIA_ITEM_FILE_PATH_ATTRIBUTE).SetValue(fileLocations[filePath]);
                }
            }

            wlmp.Save(projectFile);
        }
    }
}
