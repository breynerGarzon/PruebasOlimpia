using Olimpia.Business.Model;

namespace Olimpia.Business.Caculate
{
    public class CalculateMatch
    {
        private string Result { get; set; }
        public CalculateMatch(DataTest data)
        {
            if (data.FirstPawPrint.Length < data.AcceptanceParameter || data.FirstPawPrint.Length < data.AcceptanceParameter)
            {
                Result = "NO-HIT";
            }
            else
            {
                int counter = 0;
                Result = Iteration(data.FirstPawPrint, data.SecodPawPrint, data.AcceptanceParameter, counter);
            }
        }

        private string Iteration(string firstPawPrint, string secodPawPrint, int accepte, int counter)
        {
            string firstPaw = firstPawPrint.Substring(0, 1);
            string secondPaw = secodPawPrint.Substring(0, 1);
            if (firstPaw.Equals(secondPaw))
            {
                counter++;
                if (accepte == counter)
                {
                    return "HIT";
                }
                return NextIteration(firstPawPrint, secodPawPrint, accepte, counter);
            }
            else
            {
                return NextIteration(firstPawPrint, secodPawPrint, accepte, counter);
            }
        }

        private string NextIteration(string firstPawPrint, string secodPawPrint, int accepte, int counter)
        {
            string validSize = ValidatedSize(firstPawPrint, secodPawPrint);
            return validSize.Equals("") ? Iteration(firstPawPrint.Substring(1, firstPawPrint.Length - 1), secodPawPrint.Substring(1, secodPawPrint.Length - 1), accepte, counter) : validSize;
        }

        private string ValidatedSize(string first, string second)
        {
            if ((first.Length <= 1 || second.Length <= 1))
            {
                return "NO-HIT";
            }
            return "";
        }

        public string GetValidation()
        {
            return Result;
        }
    }
}