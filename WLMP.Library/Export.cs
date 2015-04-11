//-----------------------------------------------------------------------
// <copyright file="Export.cs" company="Ace Olszowka">
//   Copyright (c) Ace Olszowka 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WLMP.Library
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    ///     Utility class that encapsulates all of the logic concerning the
    /// Export of items in a Windows Live Movie Maker Project (*.wlmp).
    /// </summary>
    public static class Export
    {
        /// <summary>
        ///     Given a Windows Live Movie Maker Project (*.wlmp) export all of
        /// the assets required by this project to the specified output directory.
        /// </summary>
        /// <param name="projectFile">The Windows Live Movie Maker Project (*.wlmp) to export.</param>
        /// <param name="exportDirectory">The directory to export this project to.</param>
        /// <remarks>
        /// Currently we do not support the ability to export to a directory
        /// that already exists, this is because in order to do so we'd need
        /// to have some additional logic to perform the appropriate merging
        /// of files.
        /// </remarks>
        public static void Project(string projectFile, string exportDirectory)
        {
            // We need to load up all the files, and to save time we're
            // only going to parse the file once.
            var mediaItemsFilePaths = Parse.ForMediaItemFilePaths(projectFile).ToArray();

            if (Validate.MediaItemsFilePaths(mediaItemsFilePaths).Any())
            {
                throw new InvalidOperationException("At least one MediaItem file is missing");
            }
            else if (Directory.Exists(exportDirectory))
            {
                // If the directory is not empty (exists) we cannot export to this
                // location currently (future functionality), throw an exception.
                // TODO: When we support a merge like ability we'll need to remove this check.
                throw new InvalidOperationException("The export directory cannot exist, as we do not support merging");
            }
            else
            {
                // First create all of our export directories
                WLMPExportDirectories exportDirectories = CreateDirectoryStructure(exportDirectory);

                // Now perform our internal export
                ProjectInternal(projectFile, mediaItemsFilePaths, exportDirectories);
            }
        }

        /// <summary>
        /// Exports the specified project, along with its assets, to the specified directories.
        /// </summary>
        /// <param name="projectFile">The Windows Live Movie Maker Project (*.wlmp) that is being exported.</param>
        /// <param name="assets">The assets referenced by the given project that should be moved.</param>
        /// <param name="exportDirectories">A <see cref="WLMPExportDirectories"/> that indicates where elements should be placed.</param>
        /// <remarks>
        ///     This function is optimized to avoid having to reparse the given
        /// projectFile again and assumes that the given export directories
        /// have already been created.
        /// </remarks>
        internal static void ProjectInternal(string projectFile, IEnumerable<string> assets, WLMPExportDirectories exportDirectories)
        {
            // Next copy our project file into the root of that directory
            string exportedProjectFilePath = FileOperations.ChangeDirectoryOfFile(projectFile, exportDirectories.Root);
            File.Copy(projectFile, exportedProjectFilePath);

            // Rebase and copy all of our assets
            IDictionary<string, string> rebasedAssets = FileOperations.RebaseFiles(assets, exportDirectories.Assets);
            foreach (KeyValuePair<string, string> asset in rebasedAssets)
            {
                File.Copy(asset.Key, asset.Value);
            }

            // We need to update the exported project to reference these new paths
            Modify.MediaItemsFilePath(exportedProjectFilePath, rebasedAssets);
        }

        internal static WLMPExportDirectories CreateDirectoryStructure(string outputDirectory)
        {
            WLMPExportDirectories exportDirectories = new WLMPExportDirectories(outputDirectory);
            CreateDirectoryStructure(exportDirectories);
            return exportDirectories;
        }

        private static void CreateDirectoryStructure(WLMPExportDirectories createTheseDirectories)
        {
            Directory.CreateDirectory(createTheseDirectories.Root);
            Directory.CreateDirectory(createTheseDirectories.Assets);
        }
    }
}
