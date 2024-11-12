﻿using System;

namespace Arithmetics.Algorithms.Crypto.Digests
{
    /// <summary>
    /// MD2 is a cryptographic hash function that takes an input message and produces a 128-bit output, also called a message
    /// digest or a hash.
    /// <para>
    /// A hash function has two main properties: it is easy to compute the hash from the input, but it is hard to find the
    /// input from the hash or to find two different inputs that produce the same hash.
    /// </para>
    /// <para>
    /// MD2 works by first padding the input message to a multiple of 16 bytes and adding a 16-byte checksum to it. Then, it
    /// uses a 48-byte auxiliary block and a 256-byte S-table (a fixed permutation of the numbers 0 to 255) to process the
    /// message in 16-byte blocks.
    /// </para>
    /// <para>
    /// For each block, it updates the auxiliary block by XORing it with the message block and then applying the S-table 18
    /// times. After all blocks are processed, the first 16 bytes of the auxiliary block become the hash value.
    /// </para>
    /// </summary>
    public class Md2Digest
    {
        // The S-table is a set of constants generated by shuffling the integers 0 through 255 using a variant of
        // Durstenfeld's algorithm with a pseudorandom number generator based on decimal digits of pi.
        private static readonly byte[] STable =
        {
        41, 46, 67, 201, 162, 216, 124, 1, 61, 54, 84, 161, 236, 240, 6, 19,
        98, 167, 5, 243, 192, 199, 115, 140, 152, 147, 43, 217, 188, 76, 130, 202,
        30, 155, 87, 60, 253, 212, 224, 22, 103, 66, 111, 24, 138, 23, 229, 18,
        190, 78, 196, 214, 218, 158, 222, 73, 160, 251, 245, 142, 187, 47, 238, 122,
        169, 104, 121, 145, 21, 178, 7, 63, 148, 194, 16, 137, 11, 34, 95, 33,
        128, 127, 93, 154, 90, 144, 50, 39, 53, 62, 204, 231, 191, 247, 151, 3,
        255, 25, 48, 179, 72, 165, 181, 209, 215, 94, 146, 42, 172, 86, 170, 198,
        79, 184, 56, 210, 150, 164, 125, 182, 118, 252, 107, 226, 156, 116, 4, 241,
        69, 157, 112, 89, 100, 113, 135, 32, 134, 91, 207, 101, 230, 45, 168, 2,
        27, 96, 37, 173, 174, 176, 185, 246, 28, 70, 97, 105, 52, 64, 126, 15,
        85, 71, 163, 35, 221, 81, 175, 58, 195, 92, 249, 206, 186, 197, 234, 38,
        44, 83, 13, 110, 133, 40, 132, 9, 211, 223, 205, 244, 65, 129, 77, 82,
        106, 220, 55, 200, 108, 193, 171, 250, 36, 225, 123, 8, 12, 189, 177, 74,
        120, 136, 149, 139, 227, 99, 232, 109, 233, 203, 213, 254, 59, 0, 29, 57,
        242, 239, 183, 14, 102, 88, 208, 228, 166, 119, 114, 248, 235, 117, 75, 10,
        49, 68, 80, 180, 143, 237, 31, 26, 219, 153, 141, 51, 159, 17, 131, 20,
    };

        // The X buffer is a 48-byte auxiliary block used to compute the message digest.
        private readonly byte[] xBuffer = new byte[48];

        // The M buffer is a 16-byte auxiliary block that keeps 16 byte blocks from the input data.
        private readonly byte[] mBuffer = new byte[16];

        // The checksum buffer
        private readonly byte[] checkSum = new byte[16];

        private int xBufferOffset;
        private int mBufferOffset;

        /// <summary>
        /// Computes the MD2 hash of the input byte array.
        /// </summary>
        /// <param name="input">The input byte array to be hashed.</param>
        /// <returns>The MD2 hash as a byte array.</returns>
        public byte[] Digest(byte[] input)
        {
            Update(input, 0, input.Length);

            // Pad the input to a multiple of 16 bytes.
            var paddingByte = (byte)(mBuffer.Length - mBufferOffset);

            for (var i = mBufferOffset; i < mBuffer.Length; i++)
            {
                mBuffer[i] = paddingByte;
            }

            // Process the checksum of the padded input.
            ProcessCheckSum(mBuffer);

            // Process the first block of the padded input.
            ProcessBlock(mBuffer);

            // Process the second block of the padded input, which is the checksum.
            ProcessBlock(checkSum);

            // Copy the first 16 bytes of the auxiliary block to the output.
            var digest = new byte[16];

            xBuffer.AsSpan(xBufferOffset, 16).CopyTo(digest);

            // Reset the internal state for reuse.
            Reset();
            return digest;
        }

        /// <summary>
        /// Resets the engine to its initial state.
        /// </summary>
        private void Reset()
        {
            xBufferOffset = 0;
            for (var i = 0; i != xBuffer.Length; i++)
            {
                xBuffer[i] = 0;
            }

            mBufferOffset = 0;
            for (var i = 0; i != mBuffer.Length; i++)
            {
                mBuffer[i] = 0;
            }

            for (var i = 0; i != checkSum.Length; i++)
            {
                checkSum[i] = 0;
            }
        }

        /// <summary>
        /// Performs the compression step of MD2 hash algorithm.
        /// </summary>
        /// <param name="block">The 16 bytes block to be compressed.</param>
        /// <remarks>
        /// the compression step is designed to achieve diffusion and confusion, two properties that make it hard to reverse
        /// or analyze the hash function. Diffusion means that changing one bit of the input affects many bits of the output,
        /// and confusion means that there is no apparent relation between the input and the output.
        /// </remarks>
        private void ProcessBlock(byte[] block)
        {
            // Copying and XORing: The input block is copied to the second and third parts of the internal state, while XORing
            // the input block with the first part of the internal state.
            // By copying the input block to the second and third parts of the internal state, the compression step ensures
            // that each input block contributes to the final output digest.
            // By XORing the input block with the first part of the internal state, the compression step introduces a non-linear
            // transformation that depends on both the input and the previous state. This makes it difficult to deduce the input
            // or the state from the output, or vice versa.
            for (var i = 0; i < 16; i++)
            {
                xBuffer[i + 16] = block[i];
                xBuffer[i + 32] = (byte)(block[i] ^ xBuffer[i]);
            }

            var tmp = 0;

            // Mixing: The internal state is mixed using the substitution table for 18 rounds. Each round consists of looping
            // over the 48 bytes of the internal state and updating each byte by XORing it with a value from the substitution table.
            // The mixing process ensures that each byte of the internal state is affected by every byte of the input block and
            // every byte of the substitution table. This creates a high degree of diffusion and confusion, which makes it hard
            // to find collisions or preimages for the hash function.
            for (var j = 0; j < 18; j++)
            {
                for (var k = 0; k < 48; k++)
                {
                    tmp = xBuffer[k] ^= STable[tmp];
                    tmp &= 0xff;
                }

                tmp = (tmp + j) % 256;
            }
        }

        /// <summary>
        /// Performs the checksum step of MD2 hash algorithm.
        /// </summary>
        /// <param name="block">The 16 bytes block to calculate the checksum.</param>
        /// <remarks>
        /// The checksum step ensures that changing any bit of the input message will change about half of the bits of the
        /// checksum, making it harder to find collisions or preimages.
        /// </remarks>
        private void ProcessCheckSum(byte[] block)
        {
            // Assign the last element of checksum to the variable last. This is the initial value of the checksum.
            var last = checkSum[15];
            for (var i = 0; i < 16; i++)
            {
                // Compute the XOR of the current element of the mBuffer array and the last value, and uses it as an index
                // to access an element of STable. This is a substitution operation that maps each byte to another byte using
                // the STable.
                var map = STable[(mBuffer[i] ^ last) & 0xff];

                // Compute the XOR of the current element of checkSum and the substituted byte, and stores it back to the
                // checksum. This is a mixing operation that updates the checksum value with the input data.
                checkSum[i] ^= map;

                // Assign the updated element of checksum to last. This is to keep track of the last checksum value for the
                // next iteration.
                last = checkSum[i];
            }
        }

        /// <summary>
        /// Update the message digest with a single byte.
        /// </summary>
        /// <param name="input">The input byte to digest.</param>
        private void Update(byte input)
        {
            mBuffer[mBufferOffset++] = input;
        }

        /// <summary>
        /// Update the message digest with a block of bytes.
        /// </summary>
        /// <param name="input">The byte array containing the data.</param>
        /// <param name="inputOffset">The offset into the byte array where the data starts.</param>
        /// <param name="length">The length of the data.</param>
        private void Update(byte[] input, int inputOffset, int length)
        {
            // process whole words
            while (length >= 16)
            {
                Array.Copy(input, inputOffset, mBuffer, 0, 16);
                ProcessCheckSum(mBuffer);
                ProcessBlock(mBuffer);

                length -= 16;
                inputOffset += 16;
            }

            while (length > 0)
            {
                Update(input[inputOffset]);
                inputOffset++;
                length--;
            }
        }
    }
}