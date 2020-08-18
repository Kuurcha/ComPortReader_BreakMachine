using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
namespace ComPortReader.Classes
{
    class ExperimentReading
    {
        internal string metalMarking;
        internal string type;
        internal double aDim;
        internal double bDim;
        internal double diameterBefore;
        internal double diameterAfter;
        internal double totalArea;
        internal double originalLength;
        internal double endLength;
        internal int maxForce;
        internal int?[] forceAtStressFlow;
        internal int forceAtStressFlow2;
        internal int?[] stressFlow;
        internal int stressFlow2;
        internal double relativeExpansion;
        internal double relativeNarrowing;
        internal double tempTearResistance;
        internal PointPair[] yieldPoints;
        internal ExperimentReading(string metalMarking, double aDim, double bDim, double totalArea, double originalLength, double endLength, int maxForce, int?[] forceAtStressFlow, int?[] stressFlow, double tempTearResistance, double relativeExpansion,  PointPair[] yieldPoints)
        {
            this.metalMarking = metalMarking;
            this.aDim = aDim;
            this.bDim = bDim;
            this.totalArea = totalArea;
            this.originalLength = originalLength;
            this.endLength = endLength;
            this.maxForce = maxForce;
            this.forceAtStressFlow = forceAtStressFlow;
            this.stressFlow = stressFlow;
            this.tempTearResistance = tempTearResistance;
            this.relativeExpansion = relativeExpansion;
            this.yieldPoints = yieldPoints;
            type = "Прямоугольная";
        }
        internal ExperimentReading(string metalMarking, double diameterBefore, double diameterAfter, double totalArea, double originalLength, double endLength, int maxForce, int?[] forceAtStressFlow, int?[] stressFlow, double tempTearResistance, double relativeExpansion, double relativeNarrowing, PointPair[] yieldPoints)
        {
            this.metalMarking = metalMarking;
            this.diameterAfter = diameterAfter;
            this.diameterBefore = diameterBefore;
            this.originalLength = originalLength;
            this.totalArea = totalArea;
            this.endLength = endLength;
            this.maxForce = maxForce;
            this.forceAtStressFlow = forceAtStressFlow;
            this.tempTearResistance = tempTearResistance;
            this.stressFlow = stressFlow;
            this.relativeExpansion = relativeExpansion;
            this.relativeNarrowing = relativeNarrowing;
            this.yieldPoints = yieldPoints;
            type = "Круглая";
        }
    }
  
}
