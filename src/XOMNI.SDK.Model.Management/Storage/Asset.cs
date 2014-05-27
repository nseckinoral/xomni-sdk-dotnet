using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Management.Storage
{
    public class Asset
    {
        /// <summary>
        /// Unique id of the asset
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// File name of the asset
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Mime type of the asset
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// File body of the asset
        /// </summary>
        public byte[] FileBody { get; set; }
    }
}
