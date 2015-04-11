//-----------------------------------------------------------------------
// <copyright file="WLMPTagConstants.cs" company="Ace Olszowka">
//   Copyright (c) Ace Olszowka 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WLMP.Library
{
    /// <summary>
    /// Class to hold well known XML Tag constants for Windows Live Movie Maker Projects (*.wlmp).
    /// </summary>
    public class WLMPTagConstants
    {
        /// <summary>
        /// The tag for a MediaItem
        /// </summary>
        public const string MEDIA_ITEM = "MediaItem";

        /// <summary>
        /// The attribute off of the <see cref="MediaItem"/> tag that contains the File Path.
        /// </summary>
        public const string MEDIA_ITEM_FILE_PATH_ATTRIBUTE = "filePath";
    }
}
