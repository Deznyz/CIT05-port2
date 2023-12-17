namespace DataLayer.PostgresModels
{
    public class WeightedAverage
    {
        public double WeightedAverageForNameId {  get; set; }

        public override string ToString()
        {
            return $"{WeightedAverageForNameId}";
        }
    }
}
