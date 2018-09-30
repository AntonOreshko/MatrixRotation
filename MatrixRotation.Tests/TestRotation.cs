using MatrixRotation.Models;
using Xunit;

namespace MatrixRotation.Tests
{
    public class TestRotation
    {
        [Fact]
        public void TestRotation2X2()
        {
            var matrixSource = new MatrixViewModel(2);
            matrixSource.Matrix[0][0] = 1;
            matrixSource.Matrix[0][1] = 2;
            matrixSource.Matrix[1][1] = 3;
            matrixSource.Matrix[1][0] = 4;

            var matrixTarget = new MatrixViewModel(2);
            matrixTarget.Matrix[0][0] = 4;
            matrixTarget.Matrix[0][1] = 1;
            matrixTarget.Matrix[1][1] = 2;
            matrixTarget.Matrix[1][0] = 3;

            matrixSource.Rotate();

            Assert.True(matrixSource.EqualMatrix(matrixTarget));
        }

        [Fact]
        public void TestRotation3X3()
        {
            var matrixSource = new MatrixViewModel(3);
            matrixSource.Matrix[0][0] = 1;
            matrixSource.Matrix[0][1] = 2;
            matrixSource.Matrix[0][2] = 3;
            matrixSource.Matrix[1][0] = 4;
            matrixSource.Matrix[1][1] = 5;
            matrixSource.Matrix[1][2] = 6;
            matrixSource.Matrix[2][0] = 7;
            matrixSource.Matrix[2][1] = 8;
            matrixSource.Matrix[2][2] = 9;

            var matrixTarget = new MatrixViewModel(3);
            matrixTarget.Matrix[0][0] = 7;
            matrixTarget.Matrix[0][1] = 4;
            matrixTarget.Matrix[0][2] = 1;
            matrixTarget.Matrix[1][0] = 8;
            matrixTarget.Matrix[1][1] = 5;
            matrixTarget.Matrix[1][2] = 2;
            matrixTarget.Matrix[2][0] = 9;
            matrixTarget.Matrix[2][1] = 6;
            matrixTarget.Matrix[2][2] = 3;

            matrixSource.Rotate();

            Assert.True(matrixSource.EqualMatrix(matrixTarget));
        }

        [Fact]
        public void TestRotation4X4()
        {
            var matrixSource = new MatrixViewModel(4);
            matrixSource.Matrix[0][0] = 1;
            matrixSource.Matrix[0][1] = 2;
            matrixSource.Matrix[0][2] = 3;
            matrixSource.Matrix[0][3] = 4;
            matrixSource.Matrix[1][0] = 5;
            matrixSource.Matrix[1][1] = 6;
            matrixSource.Matrix[1][2] = 7;
            matrixSource.Matrix[1][3] = 8;
            matrixSource.Matrix[2][0] = 9;
            matrixSource.Matrix[2][1] = 10;
            matrixSource.Matrix[2][2] = 11;
            matrixSource.Matrix[2][3] = 12;
            matrixSource.Matrix[3][0] = 13;
            matrixSource.Matrix[3][1] = 14;
            matrixSource.Matrix[3][2] = 15;
            matrixSource.Matrix[3][3] = 16;

            var matrixTarget = new MatrixViewModel(4);
            matrixTarget.Matrix[0][0] = 13;
            matrixTarget.Matrix[0][1] = 9;
            matrixTarget.Matrix[0][2] = 5;
            matrixTarget.Matrix[0][3] = 1;
            matrixTarget.Matrix[1][0] = 14;
            matrixTarget.Matrix[1][1] = 10;
            matrixTarget.Matrix[1][2] = 6;
            matrixTarget.Matrix[1][3] = 2;
            matrixTarget.Matrix[2][0] = 15;
            matrixTarget.Matrix[2][1] = 11;
            matrixTarget.Matrix[2][2] = 7;
            matrixTarget.Matrix[2][3] = 3;
            matrixTarget.Matrix[3][0] = 16;
            matrixTarget.Matrix[3][1] = 12;
            matrixTarget.Matrix[3][2] = 8;
            matrixTarget.Matrix[3][3] = 4;

            matrixSource.Rotate();

            Assert.True(matrixSource.EqualMatrix(matrixTarget));
        }

        [Fact]
        public void TestRotation5X5()
        {
            var matrixSource = new MatrixViewModel(5);
            matrixSource.Matrix[0][0] = 1;
            matrixSource.Matrix[0][1] = 2;
            matrixSource.Matrix[0][2] = 3;
            matrixSource.Matrix[0][3] = 4;
            matrixSource.Matrix[0][4] = 5;
            matrixSource.Matrix[1][0] = 6;
            matrixSource.Matrix[1][1] = 7;
            matrixSource.Matrix[1][2] = 8;
            matrixSource.Matrix[1][3] = 9;
            matrixSource.Matrix[1][4] = 10;
            matrixSource.Matrix[2][0] = 11;
            matrixSource.Matrix[2][1] = 12;
            matrixSource.Matrix[2][2] = 13;
            matrixSource.Matrix[2][3] = 14;
            matrixSource.Matrix[2][4] = 15;
            matrixSource.Matrix[3][0] = 16;
            matrixSource.Matrix[3][1] = 17;
            matrixSource.Matrix[3][2] = 18;
            matrixSource.Matrix[3][3] = 19;
            matrixSource.Matrix[3][4] = 20;
            matrixSource.Matrix[4][0] = 21;
            matrixSource.Matrix[4][1] = 22;
            matrixSource.Matrix[4][2] = 23;
            matrixSource.Matrix[4][3] = 24;
            matrixSource.Matrix[4][4] = 25;

            var matrixTarget = new MatrixViewModel(5);
            matrixTarget.Matrix[0][0] = 21;
            matrixTarget.Matrix[0][1] = 16;
            matrixTarget.Matrix[0][2] = 11;
            matrixTarget.Matrix[0][3] = 6;
            matrixTarget.Matrix[0][4] = 1;
            matrixTarget.Matrix[1][0] = 22;
            matrixTarget.Matrix[1][1] = 17;
            matrixTarget.Matrix[1][2] = 12;
            matrixTarget.Matrix[1][3] = 7;
            matrixTarget.Matrix[1][4] = 2;
            matrixTarget.Matrix[2][0] = 23;
            matrixTarget.Matrix[2][1] = 18;
            matrixTarget.Matrix[2][2] = 13;
            matrixTarget.Matrix[2][3] = 8;
            matrixTarget.Matrix[2][4] = 3;
            matrixTarget.Matrix[3][0] = 24;
            matrixTarget.Matrix[3][1] = 19;
            matrixTarget.Matrix[3][2] = 14;
            matrixTarget.Matrix[3][3] = 9;
            matrixTarget.Matrix[3][4] = 4;
            matrixTarget.Matrix[4][0] = 25;
            matrixTarget.Matrix[4][1] = 20;
            matrixTarget.Matrix[4][2] = 15;
            matrixTarget.Matrix[4][3] = 10;
            matrixTarget.Matrix[4][4] = 5;

            matrixSource.Rotate();

            Assert.True(matrixSource.EqualMatrix(matrixTarget));
        }
    }
}
