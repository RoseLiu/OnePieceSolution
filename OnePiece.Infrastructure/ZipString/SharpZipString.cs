using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Infrastructure.ZipString
{
    public class SharpZipString : IZipString
    {

        public string StringCompress(string toCompressString)
        {
            if (String.IsNullOrEmpty(toCompressString) == true) return "";

            return "";
        }

        public string StringDeCompress(string toDeCompressString)
        {
            if (String.IsNullOrEmpty(toDeCompressString) == true) return "";

            return "";
        }











    }
}
