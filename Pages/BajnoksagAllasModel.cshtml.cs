using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using focisokadik;
using focisokadik.Models;
using System.Linq;

namespace focisokadik.Pages
{
    public class BajnoksagAllasModelModel : PageModel
    {
        private readonly FociDbContext _context;

        public BajnoksagAllasModelModel(FociDbContext context)
        {
            _context = context;
        }

        public List<Meccs> meccsek;
        public List<CsapatEredmenyei> csapatokEredmenyei;


        public void OnGet()
        {
            meccsek = _context.Meccsek.ToList();
            csapatokEredmenyei = new List<CsapatEredmenyei>();
            foreach (var cs in meccsek.Select(x=>x.HazaiCsapat).Distinct())
            {
                CsapatEredmenyei ujcsapat = new CsapatEredmenyei();
                ujcsapat.CsapatNev = cs;
                csapatokEredmenyei.Add(ujcsapat);
            }

            foreach (var cs in csapatokEredmenyei)
            {
                cs.GyozelmekSzama = meccsek.Where(x => x.GyoztesCsapatNeve() == cs.CsapatNev).Count();
                cs.VeresegekSzama = meccsek.Where(x => (x.HazaiCsapat == cs.CsapatNev || x.VednegCsapat == cs.CsapatNev)
                && x.GyoztesCsapatNeve() != cs.CsapatNev && x.GyoztesCsapatNeve() != "").Count();
            }
        }
    }
}
