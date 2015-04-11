//-----------------------------------------------------------------------
// <copyright file="Validate.cs" company="Ace Olszowka">
//   Copyright (c) Ace Olszowka 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WLMP.Library
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    ///     Utility class that encapsulates all of the logic regarding
    /// validating Windows Live Movie Maker Project Files (*.wlmp).
    /// </summary>
    public static class Validate
    {
        /// <summary>
        ///     Given a Windows Live Movie Maker Project File (*.wlmp) validate
        /// that each of the MediaItems in the project are valid, returning an
        /// Enumerable of those that are missing.
        /// </summary>
        /// <param name="projectFile">The Windows Live Movie Maker Project File (*.wlmp) to parse.</param>
        /// <returns>An Enumerable which contains the missing files; or an empty enumerable if none of the files are missing.</returns>
        public static IEnumerable<string> MediaItemsFilePaths(string projectFile)
        {
            IEnumerable<string> mediaItemFilePaths = Parse.ForMediaItemFilePaths(projectFile);
            return MediaItemsFilePaths(mediaItemFilePaths);
        }

        /// <summary>
        ///     Given a list of paths to Media Items return an Enumerable of paths that were not found.
        /// </summary>
        /// <param name="mediaItemFilePaths">The Media Item File Paths to check.</param>
        /// <returns>An Enumerable which contains the missing files; or an empty enumerable if none of the files are missing.</returns>
        public static IEnumerable<string> MediaItemsFilePaths(IEnumerable<string> mediaItemFilePaths)
        {
            return FileOperations.GetMissingFiles(mediaItemFilePaths);
        }
    }
}
