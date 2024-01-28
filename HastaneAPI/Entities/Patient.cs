namespace HastaneAPI.Entities
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Klinik { get; set; }
        public DateTime ControlDate { get; set; }
        public int HastaneID { get; set; }
        public Hospital Hastane { get; set; }
    }
}