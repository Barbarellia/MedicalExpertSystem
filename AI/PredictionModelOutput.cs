using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.AI
{
    public class PredictionModelOutput
    {
        [ColumnName("Prediction")]
        public bool Prediction { get; set; }
        [ColumnName("Score")]
        public float Score { get; set; }
    }
}
