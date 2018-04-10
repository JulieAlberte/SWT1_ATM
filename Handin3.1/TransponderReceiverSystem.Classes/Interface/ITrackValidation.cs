namespace TransponderReceiverSystem.Classes
{
    public interface ITrackValidation
    {
        bool ValidateTrack(string xcoordinate, string ycoordinate, string altitude);
    }
}