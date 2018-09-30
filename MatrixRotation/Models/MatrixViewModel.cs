using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MatrixRotation.Models
{
    public class MatrixViewModel
    {
        public List<List<int>> Matrix;

        public int Size { get; set; } = 2;

        public MatrixViewModel()
        {

        }

        public MatrixViewModel(int size)
        {
            Size = size;
            var rnd = new Random();
            Matrix = new List<List<int>>();
            for (var i = 0; i < Size; i++)
            {
                var list = new List<int>();
                for (var j = 0; j < Size; j++)
                {
                    list.Add(rnd.Next(1, 100));
                }
                Matrix.Add(list);
            }
        }

        public void Rotate()
        {
            var counter = 0;
            for (var step = Size - 1; step > 0; step = step - 2)
            {
                for (var i = 0; i < step; i++)
                {
                    var leftTop = Matrix[counter][counter + i];
                    var rightTop = Matrix[counter + i][step + counter];
                    var rightBottom = Matrix[step + counter][step + counter - i];
                    var leftBottom = Matrix[step + counter - i][counter];

                    Matrix[counter][counter + i] = leftBottom;
                    Matrix[counter + i][step + counter] = leftTop;
                    Matrix[step + counter][step + counter - i] = rightTop;
                    Matrix[step + counter - i][counter] = rightBottom;
                }
                counter++;
            }
        }

        public static byte[] SaveToCsv(MatrixViewModel matrix)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    using (var csvWriter = new CsvWriter(streamWriter))
                    {
                        csvWriter.WriteField(matrix.Size);
                        csvWriter.NextRecord();
                        for (int i = 0; i < matrix.Size; i++)
                        {
                            for (int j = 0; j < matrix.Size; j++)
                            {
                                csvWriter.WriteField(matrix.Matrix[i][j]);
                            }
                            csvWriter.NextRecord();
                        }
                    }
                    return memoryStream.ToArray();
                }
            }
        }

        public static MatrixViewModel LoadFromFile(IFormFile uploadedFile)
        {
            using (var memoryStream = uploadedFile.OpenReadStream())
            {
                using (TextReader textReader = new StreamReader(memoryStream))
                {
                    using (var csvReader = new CsvReader(textReader))
                    {
                        csvReader.Read();
                        var size = csvReader.GetField<int>(0);
                        var matrix = new MatrixViewModel(size);
                        for (var i = 0; i < matrix.Size; i++)
                        {
                            csvReader.Read();
                            for (var j = 0; j < matrix.Size; j++)
                            {
                                matrix.Matrix[i][j] = csvReader.GetField<int>(j);
                            }
                        }
                        return matrix;
                    }
                }
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public bool EqualMatrix(MatrixViewModel matrix)
        {
            if (Size != matrix.Size) return false;

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (Matrix[i][j] != matrix.Matrix[i][j]) return false;
                }
            }

            return true;
        }
    }
}
