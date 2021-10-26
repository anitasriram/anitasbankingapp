using System;

namespace BankingDomain
{
    public class StandardClock : IProvideTheBusinessClock
    {
        private readonly ISystemTime _systemTime;

        public StandardClock(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }
        public bool OutsideBusinessHours()
        {
            if (_systemTime.GetCurrent().Hour >= 9 && _systemTime.GetCurrent().Hour < 17)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}