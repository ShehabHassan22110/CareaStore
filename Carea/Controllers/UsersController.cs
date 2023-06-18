using Carea.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Controllers
{
    public class UsersController : Controller
    {
        #region ctor
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        #endregion


        #region Index
        public IActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(string id)
        {
            var data = await userManager.FindByIdAsync(id);
           // var result = userManager.GetUserAsync(data);
            return View(data);
        }
        #endregion


        #region Edit User
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {

            try
            {


                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByIdAsync(model.Id);

                    user.UserName = model.Email;
                    user.FullName = model.FullName;
                    user.Nickname = model.Nickname;
                    user.Email = model.Email;
                    user.BirthDate = model.BirthDate;
                    user.Gender = model.Gender;
                    user.PIN = model.PIN;

                    var result = await userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }


                }

                return View(model);

            }
            catch (Exception)
            {
                return View(model);
            }
        }
        #endregion

        #region Delete User
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUser model)
        {

            try
            {

                //if (ModelState.IsValid)
                //{

                    var user = await userManager.FindByIdAsync(model.Id);

                    //user.Id=model.Id;
                    //user.PhoneNumber=model.PhoneNumber;
                    //user.UserName=model.UserName;
                    //user.Email=model.Email;

                    var result = await userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }


                //}

                return View(model);

            }
            catch (Exception)
            {
                return View(model);
            }
        }
        #endregion




    }
}
