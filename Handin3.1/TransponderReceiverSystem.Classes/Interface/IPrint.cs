namespace TransponderReceiverSystem.Classes
{
    public interface IPrint
    {
        void PrintTrack(TransponderObserverSoftware tr);
        void PrintTrackTrue(TrackOjects td);
    }
}