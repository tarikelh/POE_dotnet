using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _3_ClientMVC.Models
{
    public class MemoryPostedFile : HttpPostedFileBase
    {
        private readonly byte[] fileBytes;
        string contentType;
        public MemoryPostedFile(byte[] fileBytes, string contentType, string fileName)
        {
            this.fileBytes = fileBytes;
            this.contentType = contentType;
            this.FileName = fileName;
            this.InputStream = new MemoryStream(fileBytes);
        }

        public override int ContentLength => fileBytes.Length;
        public override string ContentType => contentType;
        public override Stream InputStream { get; }
        public override string FileName {get;}

    }
}