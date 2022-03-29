using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.DateTime
{
    public class DateTimePeriod
    {
        public System.DateTime Begin { get; set; }
        public System.DateTime End { get; set; }
        public int Days => (End.Date - Begin.Date).Days + 1;

        public DateTimePeriod()
        {
        }

        public DateTimePeriod(System.DateTime begin, System.DateTime end)
        {
            Begin = begin;
            End = end.GuardIsLaterOrEqualThan(begin, nameof(Begin));
        }
    }
}
