using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Calculator
{

    /// <summary>
    /// 会社情報
    /// </summary>
    [GenerateSerializer]
    public class CalculatorResult <Tresult> 
    {
        [Id(0)]
        // 会社コード
        public string Operation { get; set; } = String.Empty;
        [Id(1)]
        // 名前
        public Tresult? Result { get; set; }
        
    }
}
