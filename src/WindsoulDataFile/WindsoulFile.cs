using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WindsoulDataFile.Exceptions;

namespace WindsoulDataFile
{
    public sealed class WindsoulFile : IDisposable
    {
        public const uint Header = 0x57444650;

        private bool _disposed;
        private string _filePath;
        private uint _fileCount;
        private Stream _stream;
        private BinaryReader _reader;

        public uint Count => this._fileCount;

        public WindsoulFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Cannot find file : '{filePath}'", filePath);
            
            this._filePath = filePath;
            this.Open(File.OpenRead(this._filePath));
        }

        public WindsoulFile(byte[] fileBuffer)
        {
            this.Open(new MemoryStream(fileBuffer));
        }

        public WindsoulFile(Stream input)
        {
            this.Open(input);
        }

        private void Open(Stream input)
        {
            this._stream = input;
            this._reader = new BinaryReader(this._stream);
            uint fileHeader = this._reader.ReadUInt32();

            if (fileHeader != Header)
                throw new WindsoulFileBadHeaderException();
        }

        public void Dispose()
        {
            // TODO: dispose unmanaged resources
            if (!this._disposed)
            {
                this._reader.Dispose();
                this._stream.Dispose();
                this._reader = null;
                this._stream = null;

                this._disposed = true;
            }
        }
    }
}
