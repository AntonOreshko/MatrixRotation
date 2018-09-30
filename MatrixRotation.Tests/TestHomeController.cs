using MatrixRotation.Controllers;
using MatrixRotation.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MatrixRotation.Tests
{
    public class TestHomeController
    {
        [Fact]
        public void TestIndexViewResultNotNull()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void TestRotate()
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

            HomeController controller = new HomeController();

            ViewResult result = controller.Rotate(matrixSource.ToString()) as ViewResult;

            Assert.True(matrixTarget.EqualMatrix((MatrixViewModel)result.Model));
        }

        [Fact]
        public void TestSave()
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

            HomeController controller = new HomeController();

            FileResult result = controller.Save(matrixSource.ToString());

            Assert.True(!string.IsNullOrEmpty(result.FileDownloadName));
        }

        [Fact]
        public void TestChangeSize()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.ChangeSize(5) as ViewResult;

            Assert.True(((MatrixViewModel)result.Model).Size == 5);
        }
    }
}
