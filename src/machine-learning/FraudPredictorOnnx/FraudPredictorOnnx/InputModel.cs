using Microsoft.ML.Data;

namespace OnnxDemo
{
    class InputModel
    {
        [VectorType(11)]
        [ColumnName("float_input")]
        public float[] Data { get; set; }
    }
}
