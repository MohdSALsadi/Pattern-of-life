using Microsoft.AspNetCore.Mvc;
using Pattern_of_life.Models;
using Pattern_of_life.Repository.Interface;
using System.Linq.Expressions;

namespace Pattern_of_life.Controllers
{
    public class ShipActivityController : Controller
    {
        private readonly IRepository<ShipActivity> _repository;
        private readonly IRepository<VesselType> _vesselTypeRepository;
        private readonly IRepository<FlagState> _flagStateRepository;
        private readonly IRepository<ActivityName> _activityNameRepository;

        public ShipActivityController(
            IRepository<ShipActivity> repository,
            IRepository<VesselType> vesselTypeRepository,
            IRepository<FlagState> flagStateRepository,
            IRepository<ActivityName> activityNameRepository)
        {
            _repository = repository;
            _vesselTypeRepository = vesselTypeRepository;
            _flagStateRepository = flagStateRepository;
            _activityNameRepository = activityNameRepository;
        }
        public async Task<IActionResult> Index()
        {
            var shipActivities = await _repository.GetAllIncludingAsync(
                sa => sa.VesselType,
                sa => sa.FlagState,
                sa => sa.ActivityName
            );

            return View(shipActivities);
        }

        public async Task<IActionResult> Details(int id)
        {
            var shipActivity = await _repository.GetById(id);
            if (shipActivity == null)
            {
                return NotFound();
            }
            return PartialView("_shipActivitiesDetails", shipActivity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new ShipActivityViewModel
            {
                DTG=DateTime.Now,
                VesselTypes = await _vesselTypeRepository.GetAll(),
                FlagStates = await _flagStateRepository.GetAll(),
                ActivityNames = await _activityNameRepository.GetAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShipActivityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var shipActivity = new ShipActivity
                {
                    // Map properties from viewModel to shipActivity
                    DTG = viewModel.DTG,
                    Longitude = viewModel.Longitude,
                    Latitude = viewModel.Latitude,
                    Course = viewModel.Course,
                    IMO = viewModel.IMO,
                    POB = viewModel.POB,
                    Remarks = viewModel.Remarks,
                    Speed = viewModel.Speed,
                    Name = viewModel.Name,
                    VesselTypeID = viewModel.VesselTypeID,
                    FlagStateID = viewModel.FlagStateID,
                    ActivityNameID = viewModel.ActivityNameID
                };
                await _repository.Add(shipActivity);
                return RedirectToAction(nameof(Index));
            }

            viewModel.VesselTypes = await _vesselTypeRepository.GetAll();
            viewModel.FlagStates = await _flagStateRepository.GetAll();
            viewModel.ActivityNames = await _activityNameRepository.GetAll();
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var shipActivity = await _repository.GetById(id);
            if (shipActivity == null)
            {
                return NotFound();
            }

            var viewModel = new ShipActivityViewModel
            {
                ID = shipActivity.ID,
                // Map other properties from shipActivity to viewModel
                DTG = shipActivity.DTG,
                Longitude = shipActivity.Longitude,
                Latitude = shipActivity.Latitude,
                Course = shipActivity.Course,
                IMO = shipActivity.IMO,
                POB = shipActivity.POB,
                Remarks = shipActivity.Remarks,
                Speed = shipActivity.Speed,
                Name = shipActivity.Name,
                VesselTypeID = shipActivity.VesselTypeID,
                FlagStateID = shipActivity.FlagStateID,
                ActivityNameID = shipActivity.ActivityNameID,
                VesselTypes = await _vesselTypeRepository.GetAll(),
                FlagStates = await _flagStateRepository.GetAll(),
                ActivityNames = await _activityNameRepository.GetAll()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ShipActivityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var shipActivity = await _repository.GetById(viewModel.ID);
                if (shipActivity == null)
                {
                    return NotFound();
                }

                // Update shipActivity properties from viewModel
                shipActivity.DTG = viewModel.DTG;
                shipActivity.Longitude = viewModel.Longitude;
                shipActivity.Latitude = viewModel.Latitude;
                shipActivity.Course = viewModel.Course;
                shipActivity.IMO = viewModel.IMO;
                shipActivity.POB = viewModel.POB;
                shipActivity.Remarks = viewModel.Remarks;
                shipActivity.Speed = viewModel.Speed;
                shipActivity.Name = viewModel.Name;
                shipActivity.VesselTypeID = viewModel.VesselTypeID;
                shipActivity.FlagStateID = viewModel.FlagStateID;
                shipActivity.ActivityNameID = viewModel.ActivityNameID;
                await _repository.Update(shipActivity);
                return RedirectToAction(nameof(Index));
            }

            viewModel.VesselTypes = await _vesselTypeRepository.GetAll();
            viewModel.FlagStates = await _flagStateRepository.GetAll();
            viewModel.ActivityNames = await _activityNameRepository.GetAll();
            return View(viewModel);
        }

    }
}
