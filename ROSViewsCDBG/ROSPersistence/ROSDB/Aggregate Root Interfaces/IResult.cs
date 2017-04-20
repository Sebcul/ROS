namespace ROSPersistence.ROSDB
{
    public interface IResult
    {
        bool Active { get; set; }
        string Description { get; set; }
        DistanceResult DistanceResult { get; set; }
        string Flag { get; set; }
        int Id { get; set; }
        int No { get; set; }
        string Penalty { get; set; }
        int? Points { get; set; }
        int? Rank { get; set; }
        Team Team { get; set; }
        int TeamId { get; set; }
        TimeResult TimeResult { get; set; }
    }
}