using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace WindsoulDataFile.Test
{
    public class OpenWindsoulDataFileTest
    {
        private const string ValidTestFile = "valid-file.wdf";

        [Fact(DisplayName = "Open by file path")]
        public void OpenByFilePath()
        {
            WindsoulFile windsould = null;

            try
            {
                windsould = new WindsoulFile(ValidTestFile);
            }
            catch
            {
                windsould = null;
            }
            finally
            {
                windsould?.Dispose();
                Assert.NotNull(windsould);
            }
        }

        [Fact(DisplayName = "Open by file buffer")]
        public void OpenByFileBuffer()
        {
            WindsoulFile windsould = null;
            byte[] fileBuffer = File.ReadAllBytes(ValidTestFile);

            try
            {
                windsould = new WindsoulFile(fileBuffer);
            }
            catch
            {
                windsould = null;
            }
            finally
            {
                windsould?.Dispose();
                Assert.NotNull(windsould);
            }
        }

        [Fact(DisplayName = "Open by file stream")]
        public void OpenByFileStream()
        {
            WindsoulFile windsould = null;
            FileStream fileStream = File.OpenRead(ValidTestFile);

            try
            {
                windsould = new WindsoulFile(fileStream);
            }
            catch
            {
                windsould = null;
            }
            finally
            {
                windsould?.Dispose();
                Assert.NotNull(windsould);
            }
        }
    }
}
