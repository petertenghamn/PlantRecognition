using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjDetectV01
{
    class ImagePrediction : ImageData
    {
        public float[] Score { get; set; }
        public string PredictedLabelValue { get; set; }
    }
}
