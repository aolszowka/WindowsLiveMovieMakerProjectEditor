//-----------------------------------------------------------------------
// <copyright file="WLMPExportDirectories.cs" company="Ace Olszowka">
//   Copyright (c) Ace Olszowka 2015. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WLMP.Library
{
    using System.IO;

    /// <summary>
    /// DTO for storing information related to the Export Directories
    /// </summary>
    public class WLMPExportDirectories
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WLMPExportDirectories"/> class.
        /// </summary>
        /// <param name="rootDirectory">The root directory for this export.</param>
        public WLMPExportDirectories(string rootDirectory)
        {
            this.Root = rootDirectory;
            this.Assets = Path.Combine(this.Root, "Assets");
        }

        /// <summary>
        /// Gets the folder that Assets should be exported. This is relative to <see cref="Root"/>.
        /// </summary>
        public string Assets
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Root Export Folder. All other folders are relative to this one.
        /// </summary>
        public string Root
        {
            get;
            private set;
        }
    }
}
