namespace TransponderReceiverSystem
{
    public interface IPrint
    {
        void PrintTrack(TransponderObserverSoftware tr);
        void PrintTrackTrue(TrackOjects td);
    }
}