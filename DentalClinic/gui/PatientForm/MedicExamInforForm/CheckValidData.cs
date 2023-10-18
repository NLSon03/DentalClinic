using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace gui.PatientForm.MedicExamInforForm
{
    public static class CheckValidData
    {
        public static bool IsBloodPressureFormat(string input)
        {
            // Định dạng huyết áp thường là "120/80"
            Regex regex = new Regex(@"^\d{2,3}/\d{2,3}$");
            return regex.IsMatch(input);
        }

        public static bool IsPulseRateFormat(string input)
        {
            // Mạch thường là một số nguyên dương
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(input);
        }

        public static bool IsBloodSugarFormat(string input)
        {
            // Đường huyết thường là một số nguyên dương
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(input);
        }

        public static void ValidInput(string BP, string PR, string BS)
        {
            if (!IsBloodPressureFormat(BP) && BP != "")
                throw new Exception("Định dạng huyết áp không hợp lệ.");
            if (!IsBloodSugarFormat(BS) && BS != "")
                throw new Exception("Định dạng đường huyết không hợp lệ");
            if (!IsPulseRateFormat(PR) && PR != "")
                throw new Exception("Định dạng mạch không hợp lệ.");
        }
    }
}
