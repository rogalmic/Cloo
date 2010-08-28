﻿#region License

/*

Copyright (c) 2009 - 2010 Fatjon Sakiqi

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

namespace Cloo
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public partial class ComputeCommandQueue
    {
        #region CopyBuffer

        /// <summary>
        /// Copies data from a source buffer to a destination buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffers. </typeparam>
        /// <param name="source"> The buffer to copy from. </param>
        /// <param name="destination"> The buffer to copy to. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyBuffer<T>(ComputeBufferBase<T> source, ComputeBufferBase<T> destination, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, 0, 0, source.Count, events);
        }

        /// <summary>
        /// Copies data from a source buffer to a destination buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffers. </typeparam>
        /// <param name="source"> The buffer to copy from. </param>
        /// <param name="destination"> The buffer to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to copy. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyBuffer<T>(ComputeBufferBase<T> source, ComputeBufferBase<T> destination, long sourceOffset, long destinationOffset, long region, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, sourceOffset, destinationOffset, region, events);
        }

        /// <summary>
        /// Copies data from a source buffer to a destination buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffers. </typeparam>
        /// <param name="source"> The buffer to copy from. </param>
        /// <param name="destination"> The buffer to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to copy. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyBuffer<T>(ComputeBufferBase<T> source, ComputeBufferBase<T> destination, SysIntX2 sourceOffset, SysIntX2 destinationOffset, SysIntX2 region, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, new SysIntX3(sourceOffset, 0), new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), 0, 0, 0, 0, events);
        }

        /// <summary>
        /// Copies data from a source buffer to a destination buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffers. </typeparam>
        /// <param name="source"> The buffer to copy from. </param>
        /// <param name="destination"> The buffer to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to copy. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyBuffer<T>(ComputeBufferBase<T> source, ComputeBufferBase<T> destination, SysIntX3 sourceOffset, SysIntX3 destinationOffset, SysIntX3 region, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, sourceOffset, destinationOffset, region, 0, 0, 0, 0, events);
        }

        /// <summary>
        /// Copies data from a source buffer to a destination buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffers. </typeparam>
        /// <param name="source"> The buffer to copy from. </param>
        /// <param name="destination"> The buffer to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to copy. </param>
        /// <param name="sourceRowPitch"> The size of a row of elements of <paramref name="source"/> in bytes. </param>
        /// <param name="destinationRowPitch"> The size of a row of elements of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyBuffer<T>(ComputeBufferBase<T> source, ComputeBufferBase<T> destination, SysIntX2 sourceOffset, SysIntX2 destinationOffset, SysIntX2 region, long sourceRowPitch, long destinationRowPitch, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, new SysIntX3(sourceOffset, 0), new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), sourceRowPitch, 0, destinationRowPitch, 0, events);
        }

        /// <summary>
        /// Copies data from a source buffer to a destination buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffers. </typeparam>
        /// <param name="source"> The buffer to copy from. </param>
        /// <param name="destination"> The buffer to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to copy. </param>
        /// <param name="sourceRowPitch"> The size of a row of elements of <paramref name="source"/> in bytes. </param>
        /// <param name="destinationRowPitch"> The size of a row of elements of <paramref name="destination"/> in bytes. </param>
        /// <param name="sourceSlicePitch"> The size of a 2D slice of elements of <paramref name="source"/> in bytes. </param>
        /// <param name="destinationSlicePitch"> The size of a 2D slice of elements of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyBuffer<T>(ComputeBufferBase<T> source, ComputeBufferBase<T> destination, SysIntX3 sourceOffset, SysIntX3 destinationOffset, SysIntX3 region, long sourceRowPitch, long destinationRowPitch, long sourceSlicePitch, long destinationSlicePitch, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, sourceOffset, destinationOffset, region, sourceRowPitch, sourceSlicePitch, destinationRowPitch, destinationSlicePitch, events);
        }

        #endregion

        #region CopyBufferToImage

        /// <summary>
        /// Copies data from a buffer to an image.
        /// </summary>
        /// <typeparam name="T"> The type of data in <paramref name="source"/>. </typeparam>
        /// <param name="source"> The buffer to copy from. </param>
        /// <param name="destination"> The image to copy to. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyBufferToImage<T>(ComputeBufferBase<T> source, ComputeImage destination, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, 0, new SysIntX3(), new SysIntX3(destination.Width, destination.Height, destination.Depth), events);
        }

        /// <summary>
        /// Copies data from a buffer to an image.
        /// </summary>
        /// <typeparam name="T"> The type of data in <paramref name="source"/>. </typeparam>
        /// <param name="source"> The buffer to copy from. </param>
        /// <param name="destination"> The image to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to copy expressed as image pixels. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyBufferToImage<T>(ComputeBufferBase<T> source, ComputeImage2D destination, long sourceOffset, SysIntX2 destinationOffset, SysIntX2 region, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, sourceOffset, new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), events);
        }

        /// <summary>
        /// Copies data from a buffer to an image.
        /// </summary>
        /// <typeparam name="T"> The type of data in <paramref name="source"/>. </typeparam>
        /// <param name="source"> The buffer to copy from. </param>
        /// <param name="destination"> The image to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to copy expressed as image pixels. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyBufferToImage<T>(ComputeBufferBase<T> source, ComputeImage3D destination, long sourceOffset, SysIntX3 destinationOffset, SysIntX3 region, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, sourceOffset, destinationOffset, region, events);
        }

        #endregion

        #region CopyImage

        /// <summary>
        /// Copies data from a source image to a destination image.
        /// </summary>
        /// <param name="source"> The image to copy from. </param>
        /// <param name="destination"> The image to copy to. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyImage(ComputeImage source, ComputeImage destination, ICollection<ComputeEventBase> events)
        {
            Copy(source, destination, new SysIntX3(), new SysIntX3(), new SysIntX3(source.Width, source.Height, (source.Depth == 0 || destination.Depth == 0) ? 1 : source.Depth), events);
        }

        /// <summary>
        /// Copies data from a source image to a destination image.
        /// </summary>
        /// <param name="source"> The image to copy from. </param>
        /// <param name="destination"> The image to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of pixels to copy. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyImage(ComputeImage2D source, ComputeImage2D destination, SysIntX2 sourceOffset, SysIntX2 destinationOffset, SysIntX2 region, ICollection<ComputeEventBase> events)
        {
            Copy(source, destination, new SysIntX3(sourceOffset, 0), new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), events);
        }

        /// <summary>
        /// Copies data from a source image to a destination image.
        /// </summary>
        /// <param name="source"> The image to copy from. </param>
        /// <param name="destination"> The image to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of pixels to copy. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyImage(ComputeImage2D source, ComputeImage3D destination, SysIntX2 sourceOffset, SysIntX3 destinationOffset, SysIntX2 region, ICollection<ComputeEventBase> events)
        {
            Copy(source, destination, new SysIntX3(sourceOffset, 0), destinationOffset, new SysIntX3(region, 1), events);
        }

        /// <summary>
        /// Copies data from a source image to a destination image.
        /// </summary>
        /// <param name="source"> The image to copy from. </param>
        /// <param name="destination"> The image to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of pixels to copy. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyImage(ComputeImage3D source, ComputeImage2D destination, SysIntX3 sourceOffset, SysIntX2 destinationOffset, SysIntX2 region, ICollection<ComputeEventBase> events)
        {
            Copy(source, destination, sourceOffset, new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), null);
        }

        /// <summary>
        /// Copies data from a source image to a destination image.
        /// </summary>
        /// <param name="source"> The image to copy from. </param>
        /// <param name="destination"> The image to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of pixels to copy. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyImage(ComputeImage3D source, ComputeImage3D destination, SysIntX3 sourceOffset, SysIntX3 destinationOffset, SysIntX3 region, ICollection<ComputeEventBase> events)
        {
            Copy(source, destination, sourceOffset, destinationOffset, region, events);
        }

        #endregion

        #region CopyImageToBuffer

        /// <summary>
        /// Copies data from an image to a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in <paramref name="destination"/>. </typeparam>
        /// <param name="source"> The image to copy from. </param>
        /// <param name="destination"> The buffer to copy to. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyImageToBuffer<T>(ComputeImage source, ComputeBufferBase<T> destination, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, new SysIntX3(), 0, new SysIntX3(source.Width, source.Height, (source.Depth == 0) ? 1 : source.Depth), events);
        }

        /// <summary>
        /// Copies data from an image to a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in <paramref name="destination"/>. </typeparam>
        /// <param name="source"> The image to copy from. </param>
        /// <param name="destination"> The buffer to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to copy expressed as image pixels. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyImageToBuffer<T>(ComputeImage2D source, ComputeBufferBase<T> destination, SysIntX2 sourceOffset, long destinationOffset, SysIntX2 region, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, new SysIntX3(sourceOffset, 0), destinationOffset, new SysIntX3(region, 1), events);
        }

        /// <summary>
        /// Copies data from a 3D image to a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in <paramref name="destination"/>. </typeparam>
        /// <param name="source"> The image to copy from. </param>
        /// <param name="destination"> The buffer to copy to. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to copy expressed as image pixels. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void CopyImageToBuffer<T>(ComputeImage3D source, ComputeBufferBase<T> destination, SysIntX3 sourceOffset, long destinationOffset, SysIntX3 region, ICollection<ComputeEventBase> events) where T : struct
        {
            Copy(source, destination, sourceOffset, destinationOffset, region, events);
        }

        #endregion

        #region ReadFromBuffer

        /// <summary>
        /// Reads data from a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The buffer to read from. </param>
        /// <param name="destination"> The array to write to. If <c>null</c> a new array of appriopriate size is allocated. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromBuffer<T>(ComputeBufferBase<T> source, ref T[] destination, bool blocking, ICollection<ComputeEventBase> events) where T : struct
        {
            ReadFromBuffer(source, ref destination, blocking, 0, 0, source.Count, events);
        }

        /// <summary>
        /// Reads data from a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The buffer to read from. </param>
        /// <param name="destination"> The array to write to. If <c>null</c> a new array of appriopriate size is allocated. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to read. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromBuffer<T>(ComputeBufferBase<T> source, ref T[] destination, bool blocking, long sourceOffset, long destinationOffset, long region, ICollection<ComputeEventBase> events) where T : struct
        {
            if (destination == null) destination = new T[destinationOffset + region];
            GCHandle destinationGCHandle = GCHandle.Alloc(destination, GCHandleType.Pinned);
            IntPtr destinationOffsetPtr = Marshal.UnsafeAddrOfPinnedArrayElement(destination, (int)destinationOffset);
            
            if (blocking)
            {
                Read(source, blocking, sourceOffset, region, destinationOffsetPtr, events);
                destinationGCHandle.Free();
            }
            else
            {
                IList<ComputeEventBase> evlist = (events != null) ? (List<ComputeEventBase>)events : new List<ComputeEventBase>();
                Read(source, blocking, sourceOffset, region, destinationOffsetPtr, evlist);
                ((ComputeEvent)evlist[evlist.Count - 1]).Track(destinationGCHandle);
                this.events.Add((ComputeEvent)evlist[evlist.Count - 1]);
            }
        }

        /// <summary>
        /// Reads data from a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The buffer to read from. </param>
        /// <param name="destination"> The array to write to. If <c>null</c> a new array of appriopriate size is allocated. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to read. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromBuffer<T>(ComputeBufferBase<T> source, ref T[,] destination, bool blocking, SysIntX2 sourceOffset, SysIntX2 destinationOffset, SysIntX2 region, ICollection<ComputeEventBase> events) where T : struct
        {
            ReadFromBuffer(source, ref destination, blocking, sourceOffset, destinationOffset, region, 0, 0, events);
        }

        /// <summary>
        /// Reads data from a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The buffer to read from. </param>
        /// <param name="destination"> The array to write to. If <c>null</c> a new array of appriopriate size is allocated. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to read. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromBuffer<T>(ComputeBufferBase<T> source, ref T[, ,] destination, bool blocking, SysIntX3 sourceOffset, SysIntX3 destinationOffset, SysIntX3 region, ICollection<ComputeEventBase> events) where T : struct
        {
            ReadFromBuffer(source, ref destination, blocking, sourceOffset, destinationOffset, region, 0, 0, 0, 0, events);
        }

        /// <summary>
        /// Reads data from a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The buffer to read from. </param>
        /// <param name="destination"> The array to write to. If <c>null</c> a new array of appriopriate size is allocated. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to read. </param>
        /// <param name="sourceRowPitch"> The size of a row of elements of <paramref name="source"/> in bytes. </param>
        /// <param name="destinationRowPitch"> The size of a row of elements of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromBuffer<T>(ComputeBufferBase<T> source, ref T[,] destination, bool blocking, SysIntX2 sourceOffset, SysIntX2 destinationOffset, SysIntX2 region, long sourceRowPitch, long destinationRowPitch, ICollection<ComputeEventBase> events) where T : struct
        {
            if (destination == null) destination = new T[destinationOffset.Y.ToInt64() + region.Y.ToInt64(), destinationOffset.X.ToInt64() + region.X.ToInt64()];
            GCHandle destinationGCHandle = GCHandle.Alloc(destination, GCHandleType.Pinned);

            if (blocking)
            {
                Read(source, blocking, new SysIntX3(sourceOffset, 0), new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), sourceRowPitch, 0, destinationRowPitch, 0, destinationGCHandle.AddrOfPinnedObject(), events);
                destinationGCHandle.Free();
            }
            else
            {
                IList<ComputeEventBase> evlist = (events != null) ? (List<ComputeEventBase>)events : new List<ComputeEventBase>();
                Read(source, blocking, new SysIntX3(sourceOffset, 0), new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), sourceRowPitch, 0, destinationRowPitch, 0, destinationGCHandle.AddrOfPinnedObject(), evlist);
                ((ComputeEvent)evlist[evlist.Count - 1]).Track(destinationGCHandle);
                this.events.Add((ComputeEvent)evlist[evlist.Count - 1]);
            }
        }

        /// <summary>
        /// Reads data from a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The buffer to read from. </param>
        /// <param name="destination"> The array to write to. If <c>null</c> a new array of appriopriate size is allocated. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to read. </param>
        /// <param name="sourceRowPitch"> The size of a row of elements of <paramref name="source"/> in bytes. </param>
        /// <param name="destinationRowPitch"> The size of a row of elements of <paramref name="destination"/> in bytes. </param>
        /// <param name="sourceSlicePitch"> The size of a 2D slice of elements of <paramref name="source"/> in bytes. </param>
        /// <param name="destinationSlicePitch"> The size of a 2D slice of elements of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromBuffer<T>(ComputeBufferBase<T> source, ref T[, ,] destination, bool blocking, SysIntX3 sourceOffset, SysIntX3 destinationOffset, SysIntX3 region, long sourceRowPitch, long destinationRowPitch, long sourceSlicePitch, long destinationSlicePitch, ICollection<ComputeEventBase> events) where T : struct
        {
            if (destination == null) destination = new T[destinationOffset.Z.ToInt64() + region.Z.ToInt64(), destinationOffset.Y.ToInt64() + region.Y.ToInt64(), destinationOffset.X.ToInt64() + region.X.ToInt64()];
            GCHandle destinationGCHandle = GCHandle.Alloc(destination, GCHandleType.Pinned);

            if (blocking)
            {
                Read(source, blocking, sourceOffset, destinationOffset, region, sourceRowPitch, sourceSlicePitch, destinationRowPitch, destinationSlicePitch, destinationGCHandle.AddrOfPinnedObject(), events);
                destinationGCHandle.Free();
            }
            else
            {
                IList<ComputeEventBase> evlist = (events != null) ? (List<ComputeEventBase>)events : new List<ComputeEventBase>();
                Read(source, blocking, sourceOffset, destinationOffset, region, sourceRowPitch, sourceSlicePitch, destinationRowPitch, destinationSlicePitch, destinationGCHandle.AddrOfPinnedObject(), evlist);
                ((ComputeEvent)evlist[evlist.Count - 1]).Track(destinationGCHandle);
                this.events.Add((ComputeEvent)evlist[evlist.Count - 1]);
            }
        }

        #endregion

        #region ReadFromImage

        /// <summary>
        /// Reads data from an image.
        /// </summary>
        /// <param name="source"> The image to read from. </param>
        /// <param name="destination"> A valid pointer to a preallocated memory area to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromImage(ComputeImage source, IntPtr destination, bool blocking, ICollection<ComputeEventBase> events)
        {
            Read(source, blocking, new SysIntX3(), new SysIntX3(source.Width, source.Height, source.Depth), 0, 0, destination, events);
        }

        /// <summary>
        /// Reads data from an image.
        /// </summary>
        /// <param name="source"> The image to read from. </param>
        /// <param name="destination"> A valid pointer to a preallocated memory area to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="region"> The number of elements to read. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromImage(ComputeImage2D source, IntPtr destination, bool blocking, SysIntX2 sourceOffset, SysIntX2 region, ICollection<ComputeEventBase> events)
        {
            Read(source, blocking, new SysIntX3(sourceOffset, 0), new SysIntX3(region, 1), 0, 0, destination, events);
        }

        /// <summary>
        /// Reads data from an image.
        /// </summary>
        /// <param name="source"> The image to read from. </param>
        /// <param name="destination"> A valid pointer to a preallocated memory area to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="region"> The number of pixels to read. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromImage(ComputeImage3D source, IntPtr destination, bool blocking, SysIntX3 sourceOffset, SysIntX3 region, ICollection<ComputeEventBase> events)
        {
            Read(source, blocking, sourceOffset, region, 0, 0, destination, events);
        }

        /// <summary>
        /// Reads data from an image.
        /// </summary>
        /// <param name="source"> The image to read from. </param>
        /// <param name="destination"> A valid pointer to a preallocated memory area to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="region"> The number of pixels to read. </param>
        /// <param name="sourceRowPitch"> The size of a row of pixels of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromImage(ComputeImage2D source, IntPtr destination, bool blocking, SysIntX2 sourceOffset, SysIntX2 region, long sourceRowPitch, ICollection<ComputeEventBase> events)
        {
            Read(source, blocking, new SysIntX3(sourceOffset, 0), new SysIntX3(region, 1), sourceRowPitch, 0, destination, events);
        }

        /// <summary>
        /// Reads data from an image.
        /// </summary>
        /// <param name="source"> The image to read from. </param>
        /// <param name="destination"> A valid pointer to a preallocated memory area to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="region"> The number of pixels to read. </param>
        /// <param name="sourceRowPitch"> The size of a row of pixels of <paramref name="destination"/> in bytes. </param>
        /// <param name="sourceSlicePitch"> The size of a 2D slice of pixels of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void ReadFromImage(ComputeImage3D source, IntPtr destination, bool blocking, SysIntX3 sourceOffset, SysIntX3 region, long sourceRowPitch, long sourceSlicePitch, ICollection<ComputeEventBase> events)
        {
            Read(source, blocking, sourceOffset, region, sourceRowPitch, sourceSlicePitch, destination, events);
        }

        #endregion

        #region WriteToBuffer

        /// <summary>
        /// Writes data to a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The array to read from. </param>
        /// <param name="destination"> The buffer to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToBuffer<T>(T[] source, ComputeBufferBase<T> destination, bool blocking, ICollection<ComputeEventBase> events) where T : struct
        {
            WriteToBuffer(source, destination, blocking, 0, 0, destination.Count, events);
        }

        /// <summary>
        /// Writes data to a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The array to read from. </param>
        /// <param name="destination"> The buffer to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to write. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToBuffer<T>(T[] source, ComputeBufferBase<T> destination, bool blocking, long sourceOffset, long destinationOffset, long region, ICollection<ComputeEventBase> events) where T : struct
        {
            GCHandle sourceGCHandle = GCHandle.Alloc(source, GCHandleType.Pinned);
            IntPtr sourceOffsetPtr = Marshal.UnsafeAddrOfPinnedArrayElement(source, (int)sourceOffset);

            if (blocking)
            {
                Write(destination, blocking, destinationOffset, region, sourceOffsetPtr, events);
                sourceGCHandle.Free();
            }
            else
            {
                IList<ComputeEventBase> evlist = (events != null) ? (List<ComputeEventBase>)events : new List<ComputeEventBase>();
                Write(destination, blocking, destinationOffset, region, sourceOffsetPtr, evlist);
                ((ComputeEvent)evlist[evlist.Count - 1]).Track(sourceGCHandle);
                ((ComputeEvent)evlist[evlist.Count - 1]).Track(source);
                this.events.Add((ComputeEvent)evlist[evlist.Count - 1]);
            }
        }

        /// <summary>
        /// Writes data to a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The array to read from. </param>
        /// <param name="destination"> The buffer to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to write. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToBuffer<T>(T[,] source, ComputeBufferBase<T> destination, bool blocking, SysIntX2 sourceOffset, SysIntX2 destinationOffset, SysIntX2 region, ICollection<ComputeEventBase> events) where T : struct
        {
            WriteToBuffer(source, destination, blocking, sourceOffset, destinationOffset, region, 0, 0, events);
        }

        /// <summary>
        /// Writes data to a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The array to read from. </param>
        /// <param name="destination"> The buffer to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to write. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToBuffer<T>(T[, ,] source, ComputeBufferBase<T> destination, bool blocking, SysIntX3 sourceOffset, SysIntX3 destinationOffset, SysIntX3 region, ICollection<ComputeEventBase> events) where T : struct
        {
            WriteToBuffer(source, destination, blocking, sourceOffset, destinationOffset, region, 0, 0, 0, 0, events);
        }

        /// <summary>
        /// Writes data to a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The array to read from. </param>
        /// <param name="destination"> The buffer to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to write. </param>
        /// <param name="sourceRowPitch"> The size of a row of elements of <paramref name="source"/> in bytes. </param>
        /// <param name="destinationRowPitch"> The size of a row of elements of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToBuffer<T>(T[,] source, ComputeBufferBase<T> destination, bool blocking, SysIntX2 sourceOffset, SysIntX2 destinationOffset, SysIntX2 region, long sourceRowPitch, long destinationRowPitch, ICollection<ComputeEventBase> events) where T : struct
        {
            GCHandle sourceGCHandle = GCHandle.Alloc(source, GCHandleType.Pinned);

            if (blocking)
            {
                Write(destination, blocking, new SysIntX3(sourceOffset, 0), new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), sourceRowPitch, 0, destinationRowPitch, 0, sourceGCHandle.AddrOfPinnedObject(), events);
                sourceGCHandle.Free();
            }
            else
            {
                IList<ComputeEventBase> evlist = (events != null) ? (List<ComputeEventBase>)events : new List<ComputeEventBase>();
                Write(destination, blocking, new SysIntX3(sourceOffset, 0), new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), sourceRowPitch, 0, destinationRowPitch, 0, sourceGCHandle.AddrOfPinnedObject(), evlist);
                ((ComputeEvent)evlist[evlist.Count - 1]).Track(sourceGCHandle);
                ((ComputeEvent)evlist[evlist.Count - 1]).Track(source);
                this.events.Add((ComputeEvent)evlist[evlist.Count - 1]);
            }
        }

        /// <summary>
        /// Writes data to a buffer.
        /// </summary>
        /// <typeparam name="T"> The type of data in the buffer. </typeparam>
        /// <param name="source"> The array to read from. </param>
        /// <param name="destination"> The buffer to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="sourceOffset"> The <paramref name="source"/> position where reading starts. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of elements to write. </param>
        /// <param name="sourceRowPitch"> The size of a row of elements of <paramref name="source"/> in bytes. </param>
        /// <param name="destinationRowPitch"> The size of a row of elements of <paramref name="destination"/> in bytes. </param>
        /// <param name="sourceSlicePitch"> The size of a 2D slice of elements of <paramref name="source"/> in bytes. </param>
        /// <param name="destinationSlicePitch"> The size of a 2D slice of elements of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToBuffer<T>(T[, ,] source, ComputeBufferBase<T> destination, bool blocking, SysIntX3 sourceOffset, SysIntX3 destinationOffset, SysIntX3 region, long sourceRowPitch, long destinationRowPitch, long sourceSlicePitch, long destinationSlicePitch, ICollection<ComputeEventBase> events) where T : struct
        {
            GCHandle sourceGCHandle = GCHandle.Alloc(source, GCHandleType.Pinned);

            if (blocking)
            {
                Write(destination, blocking, sourceOffset, destinationOffset, region, sourceRowPitch, sourceSlicePitch, destinationRowPitch, destinationSlicePitch, sourceGCHandle.AddrOfPinnedObject(), events);
                sourceGCHandle.Free();
            }
            else
            {
                IList<ComputeEventBase> evlist = (events != null) ? (List<ComputeEventBase>)events : new List<ComputeEventBase>();
                Write(destination, blocking, sourceOffset, destinationOffset, region, sourceRowPitch, sourceSlicePitch, destinationRowPitch, destinationSlicePitch, sourceGCHandle.AddrOfPinnedObject(), evlist);
                ((ComputeEvent)evlist[evlist.Count - 1]).Track(sourceGCHandle);
                ((ComputeEvent)evlist[evlist.Count - 1]).Track(source);
                this.events.Add((ComputeEvent)evlist[evlist.Count - 1]);
            }
        }

        #endregion

        #region WriteToImage

        /// <summary>
        /// Writes data to an image.
        /// </summary>
        /// <param name="source"> A pointer to a memory area to read from. </param>
        /// <param name="destination"> The image to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToImage(IntPtr source, ComputeImage destination, bool blocking, ICollection<ComputeEventBase> events)
        {
            Write(destination, blocking, new SysIntX3(), new SysIntX3(destination.Width, destination.Height, destination.Depth), 0, 0, source, events);
        }

        /// <summary>
        /// Writes data to an image.
        /// </summary>
        /// <param name="source"> A pointer to a memory area to read from. </param>
        /// <param name="destination"> The image to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of pixels to write. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToImage(IntPtr source, ComputeImage2D destination, bool blocking, SysIntX2 destinationOffset, SysIntX2 region, ICollection<ComputeEventBase> events)
        {
            Write(destination, blocking, new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), 0, 0, source, events);
        }

        /// <summary>
        /// Writes data to an image.
        /// </summary>
        /// <param name="source"> A pointer to a memory area to read from. </param>
        /// <param name="destination"> The image to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of pixels to write. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToImage(IntPtr source, ComputeImage3D destination, bool blocking, SysIntX3 destinationOffset, SysIntX3 region, ICollection<ComputeEventBase> events)
        {
            Write(destination, blocking, destinationOffset, region, 0, 0, source, events);
        }

        /// <summary>
        /// Writes data to an image.
        /// </summary>
        /// <param name="source"> A pointer to a memory area to read from. </param>
        /// <param name="destination"> The image to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of pixels to write. </param>
        /// <param name="destinationRowPitch"> The size of a row of pixels of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToImage(IntPtr source, ComputeImage2D destination, bool blocking, SysIntX2 destinationOffset, SysIntX2 region, long destinationRowPitch, ICollection<ComputeEventBase> events)
        {
            Write(destination, blocking, new SysIntX3(destinationOffset, 0), new SysIntX3(region, 1), destinationRowPitch, 0, source, events);
        }

        /// <summary>
        /// Writes data to an image.
        /// </summary>
        /// <param name="source"> A pointer to a memory area to read from. </param>
        /// <param name="destination"> The image to write to. </param>
        /// <param name="blocking"> The mode of operation of this command. If <c>true</c> this call will not return until the command has finished execution. </param>
        /// <param name="destinationOffset"> The <paramref name="destination"/> position where writing starts. </param>
        /// <param name="region"> The number of pixels to write. </param>
        /// <param name="destinationRowPitch"> The size of a row of pixels of <paramref name="destination"/> in bytes. </param>
        /// <param name="destinationSlicePitch"> The size of a 2D slice of pixels of <paramref name="destination"/> in bytes. </param>
        /// <param name="events"> A collection of events that need to complete before this particular command can be executed. If <paramref name="events"/> is not <c>null</c> a new event identifying this command is attached to the end of the collection. </param>
        public void WriteToImage(IntPtr source, ComputeImage3D destination, bool blocking, SysIntX3 destinationOffset, SysIntX3 region, long destinationRowPitch, long destinationSlicePitch, ICollection<ComputeEventBase> events)
        {
            Write(destination, blocking, destinationOffset, region, destinationRowPitch, destinationSlicePitch, source, events);
        }

        #endregion
    }
}