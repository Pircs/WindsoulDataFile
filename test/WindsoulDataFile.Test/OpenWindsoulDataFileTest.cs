using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WindsoulDataFile.Test
{
    public class OpenWindsoulDataFileTest
    {
        [Fact(DisplayName = "Open by file path (with using)")]
        public void OpenByFilePathWithUsing()
        {
            using (var windsoul = new WindsoulFile("test.wdf"))
            {
            }
        }

        [Fact(DisplayName = "Open by file buffer (with using)")]
        public void OpenByFileBufferWithUsing()
        {
        }

        [Fact(DisplayName = "Open by file stream (with using)")]
        public void OpenByFileStreamWithUsing()
        {
        }

        [Fact(DisplayName = "Open by file path (without using)")]
        public void OpenByFilePathWithoutUsing()
        {
        }

        [Fact(DisplayName = "Open by file buffer (without using)")]
        public void OpenByFileBufferWithoutUsing()
        {
        }

        [Fact (DisplayName = "Open by file stream (without using)")]
        public void OpenByFileStreamWithoutUsing()
        {
        }
    }
}
