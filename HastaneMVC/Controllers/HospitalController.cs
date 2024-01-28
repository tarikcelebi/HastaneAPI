using HastaneMVC.Models.HospitalVMs;
using Microsoft.AspNetCore.Mvc;

namespace HastaneMVC.Controllers
{
    public class HospitalController : Controller
    {
        private readonly string apiAddress = "https://localhost:7056/api/Hastane";
        HttpClient client;


        public HospitalController()
        {
            client = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            List<HospitalVM> hospitals = await client.GetFromJsonAsync<List<HospitalVM>>(apiAddress + "GetAllHospitals");
            return View();
        }

        public async Task<IActionResult> GetByID(int id)
        {

            HospitalVM hospitalVM = await client.GetFromJsonAsync<HospitalVM>(apiAddress+"Get/"+id);
            return View();
        }


        public async Task<IActionResult> CreateHospital(HospitalCreateVM hospitalCreateVM)
        {
            hospitalCreateVM.HospitalName = "New Hospital";
            hospitalCreateVM.Address = "Kartal,IStanbul";

            var result = await client.PostAsJsonAsync(apiAddress+"Create",hospitalCreateVM);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError("hata", "Hata oluştu.");

            return View();
        }

        public async Task<IActionResult> UpdateHospital(int id,HospitalUpdateVM hospitalUpdateVM)
        {
            HospitalVM updatedhospitalVM = await client.GetFromJsonAsync<HospitalVM>(apiAddress + "Get/" + id);

            updatedhospitalVM.HospitalName = "YEnihastane";
            updatedhospitalVM.Address = "Istanbul";


            var result = await client.PutAsJsonAsync(apiAddress + "Update", updatedhospitalVM);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError("hata", "Hata oluştu.");

            return View();

        }

        public async Task<IActionResult> DeleteHospital(int id)
        {
            var result = await client.DeleteAsync(apiAddress + "Delete", id);
            return View();
        }

    }
}
