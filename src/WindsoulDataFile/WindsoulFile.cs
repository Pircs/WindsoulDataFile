using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WindsoulDataFile.Exceptions;

namespace WindsoulDataFile
{
    public sealed class WindsoulFile : IDisposable
    {
        public static readonly uint Header = 0x57444650;

        private bool _disposed;
        private Stream _stream;
        private BinaryReader _reader;
        private List<WindsoulFileEntry> _files;


        public int Count => this._files.Count;

        public IReadOnlyCollection<WindsoulFileEntry> Files => this._files;

        public WindsoulFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Cannot find file : '{filePath}'", filePath);
            
            this.Open(File.OpenRead(filePath));
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
            this._files = new List<WindsoulFileEntry>();
            uint fileHeader = this._reader.ReadUInt32();

            if (fileHeader != Header)
                throw new WindsoulFileBadHeaderException(fileHeader);

            int fileCount = this._reader.ReadInt32();
            uint fileListOffset = this._reader.ReadUInt32();

            this._reader.BaseStream.Seek(fileListOffset, SeekOrigin.Begin);

            for (int i = 0; i < fileCount; i++)
            {
                uint id = this._reader.ReadUInt32();
                uint offset = this._reader.ReadUInt32();
                int size = this._reader.ReadInt32();
                uint reserved = this._reader.ReadUInt32();

                this._files.Add(new WindsoulFileEntry(id, offset, size, reserved));
            }
        }

        public byte[] GetFileContent(uint id)
        {
            WindsoulFileEntry file = this._files.FirstOrDefault(x => x.Id == id);

            if (file == null)
                return null;

            return this.ReadContent(file.Offset, file.Size);
        }

        public WindsoulFileEntry GetFile(uint id)
        {
            WindsoulFileEntry file = this._files.FirstOrDefault(x => x.Id == id);

            if (file == null)
                return null;

            if (file.Content.Length != file.Size)
                file.Content = this.ReadContent(file.Offset, file.Size);

            return file;
        }

        public WindsoulFileEntry GetFile(string name)
        {
            uint fileId = Hash(name);

            return this.GetFile(fileId);
        }

        public void Remove(uint id)
        {
            var file = this.GetFile(id);

            if (file != null)
                this._files.Remove(file);
        }

        public void Remove(string name)
        {
            uint fileId = Hash(name);

            this.Remove(fileId);
        }

        public void AddFile(WindsoulFileEntry newFile)
        {
            var file = this.GetFile(newFile.Id);

            if (file != null)
                throw new WindsoulFileEntryAlreadyExists(newFile.Id.ToString());

            this._files.Add(newFile);
        }

        public void AddFile(string name, byte[] content)
        {
            var newFile = new WindsoulFileEntry(Hash(name), 0, content.Length, 0, content);

            this.AddFile(newFile);
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

        private byte[] ReadContent(uint offset, int size)
        {
            this._reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            return this._reader.ReadBytes(size);
        }

        private static uint Hash(string inputText)
        {
            //x86 - 32 bits - Registers
            uint eax, ebx, ecx, edx, edi, esi;
            ulong num = 0;

            uint v;
            int i;
            uint[] m = new uint[0x46];
            byte[] buffer = new byte[0x100];

            var input = inputText.ToLowerInvariant();

            for (i = 0; i < input.Length; i++)
                buffer[i] = (byte)input[i];

            int Length = (input.Length % 4 == 0 ? input.Length / 4 : input.Length / 4 + 1);
            for (i = 0; i < Length; i++)
                m[i] = BitConverter.ToUInt32(buffer, i * 4);

            m[i++] = 0x9BE74448; //
            m[i++] = 0x66F42C48; //

            v = 0xF4FA8928; //

            edi = 0x7758B42B;
            esi = 0x37A8470E; //

            for (ecx = 0; ecx < i; ecx++)
            {
                ebx = 0x267B0B11; //
                v = (v << 1) | (v >> 0x1F);
                ebx ^= v;
                eax = m[ecx];
                esi ^= eax;
                edi ^= eax;
                edx = ebx;
                edx += edi;
                edx |= 0x02040801; // 
                edx &= 0xBFEF7FDF;//
                num = edx;
                num *= esi;
                eax = (uint)num;
                edx = (uint)(num >> 0x20);
                if (edx != 0)
                    eax++;
                num = eax;
                num += edx;
                eax = (uint)num;
                if (((uint)(num >> 0x20)) != 0)
                    eax++;
                edx = ebx;
                edx += esi;
                edx |= 0x00804021; //
                edx &= 0x7DFEFBFF; //
                esi = eax;
                num = edi;
                num *= edx;
                eax = (uint)num;
                edx = (uint)(num >> 0x20);
                num = edx;
                num += edx;
                edx = (uint)num;
                if (((uint)(num >> 0x20)) != 0)
                    eax++;
                num = eax;
                num += edx;
                eax = (uint)num;
                if (((uint)(num >> 0x20)) != 0)
                    eax += 2;
                edi = eax;
            }
            esi ^= edi;
            v = esi;

            return v;
        }
    }
}
