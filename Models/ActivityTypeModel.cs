namespace GAC.Models
{
    public class ActivityTypeModel
    {
        public string Name { get; set; }
        public int MaxHoursPerInstance { get; set; } // Horas máximas por realização
        public int MaxHoursTotal { get; set; } // Horas máximas em conjunto
    }
}
