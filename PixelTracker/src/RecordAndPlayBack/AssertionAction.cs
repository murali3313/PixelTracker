using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace RecordAndPlayBack
{
    public class AssertionAction:List<AssertionData>,IAssertionAction
    {
        public void Add(Bitmap clonedImage, int startXPoint, int startYPoint, int width, int height)
        {
            var data = new AssertionData()
                           {IsSuccess = false,
                               ExpectedImage = clonedImage,
                               CropInfo =
                                   new CropInfo() {X = startXPoint, Y = startYPoint, Width = width, Height = height},
                               AssertionIndex = Count + 1
            };
            Add(data);
        }

        public void Execute()
        {
            var playBack = new PlayBack();
            playBack.Assert(this);
        }

        public void Save(int order, int scenarioID)
        {
            var pkactionID = Repository.Instance.ExecuteScalar<int>(string.Format("INSERT INTO T_ActionAssertion (FK_ScenarioID,TestType,ActionOrder) VALUES ({0},{1},{2})   SELECT @@Identity", scenarioID,(int)TestType.Assertion, order));
            ForEach(data => data.Save(pkactionID));
        }

        public void Load()
        {

            var assertionData = Repository.Instance.LoadDataTableWithQuery("Select * from T_AssertionData Where FK_AssertionID=" + ID);
            foreach (DataRow assertionDatum in assertionData.Rows)
            {
                var pk_ID = Convert.ToInt32(assertionDatum["PK_ID"]);
                var assertionOrder = Convert.ToInt32(assertionDatum["AssertionOrder"]);
                var X = Convert.ToInt32(assertionDatum["X"]);
                var Y = Convert.ToInt32(assertionDatum["Y"]);
                var height = Convert.ToInt32(assertionDatum["Height"]);
                var width = Convert.ToInt32(assertionDatum["Width"]);
                var expectedImageByteArray = (Byte[]) (assertionDatum["ExpectedImage"]);
                var failureReason = Convert.ToString(assertionDatum["FailureReason"]);

                var ic=new ImageConverter();
                var img = (Image)ic.ConvertFrom(expectedImageByteArray);
                var expectedImage= new Bitmap(img);
                var assertionImageData = new AssertionData()
                                             {
                                                 ID=pk_ID,
                                                 AssertionIndex = assertionOrder,
                                                 CropInfo = new CropInfo()
                                                 {
                                                     X = X,
                                                     Y = Y,
                                                     Height = height,
                                                     Width = width
                                                 },
                                                 FailureReason = failureReason,
                                                 ExpectedImage = expectedImage
                                             };
                
                this.Add(assertionImageData);
            }
        }

        public int ID { get; set; }
    }

    public class AssertionData
    {
        public Bitmap ExpectedImage { get; set; }
        public CropInfo CropInfo { get; set; }
        public int AssertionIndex { get; set; }

        public string FailureReason { get; set; }

        public bool IsSuccess { get; set; }

        public Bitmap ActualImage { get; set; }

        public int ID { get; set; }

        public void Save(int pkassertionID)
        {
            var memoryStream = new MemoryStream();
            ExpectedImage.Save(memoryStream,ImageFormat.Bmp);
            var imageDetails = memoryStream.GetBuffer();
            var assertionIDParam = new SqlParameter("@fkAssertionID", SqlDbType.Int) {Value = pkassertionID};
            var assertionOrderParam = new SqlParameter("@assertionOrder", SqlDbType.Int) {Value = AssertionIndex};
            var expectedImageParam = new SqlParameter("@expectedImage", SqlDbType.Image) {Value = imageDetails};
            var xParam = new SqlParameter("@x", SqlDbType.Int) {Value = CropInfo.X};
            var yparam = new SqlParameter("@y", SqlDbType.Int) {Value = CropInfo.Y};
            var heightParam = new SqlParameter("@height", SqlDbType.Int) {Value = CropInfo.Height};
            var widthParam = new SqlParameter("@width", SqlDbType.Int) {Value = CropInfo.Width};
            var failureReasonParam = new SqlParameter("@failureReasonParam", SqlDbType.NVarChar) { Value = FailureReason};
            Repository.Instance.ExecuteStoredProcedure("sp_AssertionSaveImage", 
                assertionIDParam, 
                assertionOrderParam,
                expectedImageParam,
                xParam,
                yparam,
                heightParam,
                widthParam);

        }
    }

    public class CropInfo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}