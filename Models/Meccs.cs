namespace focisokadik.Models
{
    public class Meccs
    {
        public int Id { get; set; }
        public int Fordulo { get; set; }
        public int HazaiVeg { get; set; }
        public int VendegVeg { get; set; }
        public int HazaiFelido { get; set; }
        public int VendegFelido { get; set; }
        public string? HazaiCsapat { get; set; }
        public string? VednegCsapat { get; set; }

        public string GyoztesCsapatNeve() {

            if (HazaiVeg > VendegVeg)
            {
                return HazaiCsapat;
            }
            else if (HazaiVeg < VendegVeg) { return VednegCsapat; }
            else return "";

        }
    }

    
}
