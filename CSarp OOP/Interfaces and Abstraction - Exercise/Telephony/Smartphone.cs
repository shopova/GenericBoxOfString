using System.Linq;

namespace Telephony
{
    public class Smartphone : IFunctioallities, ISmartPhone
    {
        public string Model { get; set; }

        public string Call(string number)
        {
            if (number.Any(x => (!char.IsDigit(x))))
            {
                return "Invalid number!";
            }
            return $"Calling... {number}";
        }

        public string Browse(string site)
        {
            if (site.Any(x => (char.IsDigit(x))))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {site}!";
        }
    }
}
