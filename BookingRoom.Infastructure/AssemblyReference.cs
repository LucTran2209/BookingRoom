using System.Reflection;

namespace BookingRoom.Infastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assemply = typeof(AssemblyReference).Assembly;
    }
}