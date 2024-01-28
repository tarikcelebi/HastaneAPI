namespace HastaneAPI.Entities
{
    public class Hospital : BaseEntity
    {
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public List<Patient> Hastalar { get; set; }
    }
}
