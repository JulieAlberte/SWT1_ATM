namespace TransponderReceiverSystem
{
    public interface ITrackValidation
    {
        bool ValidateTrack(string xcoordinate, string ycoordinate, string altitude);
    }
}