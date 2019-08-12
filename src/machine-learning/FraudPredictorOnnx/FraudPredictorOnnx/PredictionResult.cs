using Microsoft.ML.Data;
using System;

namespace OnnxDemo
{
    class PredictionResult
    {
        [ColumnName("output_label")]
        public Int64[] IsFraud { get; set; }
    }
}
