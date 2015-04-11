//-----------------------------------------------------------------------
// <copyright file="FileOperations.cs" company="Ace Olszowka">
//   Copyright (c) Ace Olszowka 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WLMP.Library
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Utility class to store all File Manipulation operations.
    /// </summary>
    public static class FileOperations
    {
        /// <summary>
        /// Given a file path (which can be a file name) and a new directory, return a string which represents the path if the file had been moved there.
        /// </summary>
        /// <param name="originalFilePath">The file path (or name) to generate the new path for.</param>
        /// <param name="newDirectory">The directory in which the file should reside.</param>
        /// <returns>A string that represents the path to the file based on the new directory.</returns>
        /// <remarks>This does not move files! This only will generate a path</remarks>
        public static string ChangeDirectoryOfFile(string originalFilePath, string newDirectory)
        {
            string originalFilename = Path.GetFileName(originalFilePath);

            return Path.Combine(newDirectory, originalFilename);
        }

        public static IDictionary<string, string> RebaseFiles(IEnumerable<string> files, string newExportDirectory)
        {
            Dictionary<string, string> rebasedFiles = new Dictionary<string, string>();

            foreach (string fileOldPath in files)
            {
                // Slight optimization, if we already knew about this asset,
                // don't bother rebasing it again
                if (!rebasedFiles.ContainsKey(fileOldPath))
                {
                    // Rebase to our new assets folder
                    string fileNewPath = FileOperations.ChangeDirectoryOfFile(fileOldPath, newExportDirectory);

                    rebasedFiles.Add(fileOldPath, fileNewPath);
                }
            }

            return rebasedFiles;
        }

        /// <summary>
        /// Given a list of file paths, return an Enumerable of the files that are missing.
        /// </summary>
        /// <param name="files">The files to check for existence.</param>
        /// <returns>An Enumerable which contains the missing files; or an empty enumerable if none of the files are missing.</returns>
        public static IEnumerable<string> GetMissingFiles(IEnumerable<string> files)
        {
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    yield return file;
                }
            }
        }
    }
}
