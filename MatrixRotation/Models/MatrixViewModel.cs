using System;
using System.Collections.Generic;

namespace MatrixRotation.Models
{
    public class MatrixViewModel
    {
        public List<List<int>> Matrix;

        public int Size { get; set; } = 5;

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

        }
    }
}
