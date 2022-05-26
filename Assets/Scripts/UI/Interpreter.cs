using System.Data;
using UnityEngine;

namespace GBAsteroids
{
    public static class Interpreter
    {
        private const string KILO = "k";
        private const string MEGA = "M";

        public static string ScoreInterpreter(float score)
        {
            int count = (int)Mathf.Abs(score / 1000000);
            string numberMarker = MEGA;

            if (count <= 0)
            {
                count = (int)Mathf.Abs(score / 1000);
                numberMarker = KILO;

                if (count <= 0)
                {
                    count = (int)score;
                    numberMarker = null;
                }
            }

            return $"{count}{numberMarker}";
        }

        public static string FormulaInterpreter(string formula)
        {
            return new DataTable().Compute(formula, null).ToString();
        }
    }
}