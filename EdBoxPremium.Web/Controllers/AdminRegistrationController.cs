using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using EdBoxPremium.Core;
using EdBoxPremium.Data;
using EdBoxPremium.Data.InterchangeModels;
using EdBoxPremium.Library;
using EdBoxPremium.Library.Dictionary;
using EdBoxPremium.Web.Models.RegistrationModels;

namespace EdBoxPremium.Web.Controllers
{
    public class AdminRegistrationController : _BaseController
    {
        // GET: AdminRegistration

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(int registrationManifestId = 0)
        {
            try
            {
                if (registrationManifestId == 0)
                    return RedirectToAction("Index", "AdminRegistration");

                using (var entities = new Entities())
                {
                    ViewBag.RegistrationManifestId = registrationManifestId;
                    var manifest =
                        entities.Administration_RegistrationSessionManifest.FirstOrDefault(x =>
                            !x.IsDeleted && x.Id == registrationManifestId);

                    return View(manifest);
                }
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return RedirectToAction("Index", "AdminRegistration");
            }
        }

        public ActionResult DataExportIdCard(int registrationManifestId = 0)
        {
            try
            {
                using (var entities = new Entities())
                {
                    var manifest =
                        entities.Administration_RegistrationSessionManifest.FirstOrDefault(x =>
                            !x.IsDeleted && x.Id == registrationManifestId);

                    if (manifest == null)
                        return null;

                    var manifestItems = entities.Administration_RegistrationSessionManifestItems.Where(x =>
                        !x.IsDeleted && x.RegistrationSessionManifestId == registrationManifestId).ToList();

                    var exportdata = manifestItems.Select(x =>
                        Newtonsoft.Json.JsonConvert.DeserializeObject<RegModelIdCard>(x.DataPayLoad)).ToList();

                    var fileName = ExcelWriter.GetFilePatientRecords(
                        $"{((RegistrationReason) manifest.RegistrationReaason).DisplayName().Replace(' ', '_').ToUpper()}_{DateTime.Now:yyyyMMddHHmm}",
                        exportdata.Select(x => new ExcelWriter.RegistrationExcelRecords()
                        {
                            MatricNumber = x.MatricNumber,
                            School = x.School,
                            Program = x.Program,
                            Sex = x.Sex,
                            FullName = x.FullName, 
                            BloodGroup = x.BloodGroup,
                            Phone = x.PhoneNumber, 
                            Email = x.Email
                        }).OrderBy(x => x.MatricNumber).ToList());

                    var filedata = System.IO.File.ReadAllBytes(fileName);
                    var contentType = MimeMapping.GetMimeMapping(fileName);
                    var fileInfo = new FileInfo(fileName);

                    var contentDisposition = new ContentDisposition
                    {
                        FileName = fileInfo.Name,
                        Inline = true,
                    };

                    Response.AppendHeader("Content-Disposition", contentDisposition.ToString());

                    return File(filedata, contentType);
                }
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return null;
            }
        }

        public JsonResult GetAllRegistrationManifests()
        {
            try
            {
                using (var entities = new Entities())
                {
                    var regManifests = entities.Administration_RegistrationSessionManifest.Where(x => !x.IsDeleted)
                        .ToList();

                    return Json(
                        ResponseData.SendSuccessMsg(data: regManifests.Select(x =>
                            new
                            {
                                DateOfManifest = x.DateOfManifest.ToLongDateString(),
                                x.Id,
                                x.RegistrationDesc,
                                RegistrationReaasonDesc = ((RegistrationReason) x.RegistrationReaason).DisplayName(),
                                x.RegistrationReaason,
                                CurrentCount =
                                    entities.Administration_RegistrationSessionManifestItems.Count(y =>
                                        y.RegistrationSessionManifestId == x.Id && !y.IsDeleted)
                            }).ToList()), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllRegistrationManifestItem(int registrationSessionManifestId, long itemId)
        {
            try
            {
                using (var entities = new Entities())
                {
                    var regManifests =
                        entities.Administration_RegistrationSessionManifest.FirstOrDefault(x =>
                            !x.IsDeleted && x.Id == registrationSessionManifestId);

                    if (regManifests == null)
                        return Json(
                            ResponseData.SendFailMsg(), JsonRequestBehavior.AllowGet);

                    var regManifestItem = entities.Administration_RegistrationSessionManifestItems.FirstOrDefault(x =>
                        !x.IsDeleted && x.Id == itemId);

                    if (regManifestItem == null)
                        return Json(
                            ResponseData.SendFailMsg(), JsonRequestBehavior.AllowGet);

                    if (regManifests.RegistrationReaason == (int) RegistrationReason.IdCard)
                        return Json(
                            ResponseData.SendSuccessMsg(data: new
                            {
                                regManifests.RegistrationReaason,
                                DataSet =
                                    Newtonsoft.Json.JsonConvert.DeserializeObject<RegModelIdCard>(regManifestItem
                                        .DataPayLoad)
                            }), JsonRequestBehavior.AllowGet);

                    return Json(
                        ResponseData.SendFailMsg(), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteItem(long itemId)
        {
            try
            {
                using (var entities = new Entities())
                {
                    var regManifestItem = entities.Administration_RegistrationSessionManifestItems.FirstOrDefault(x =>
                        !x.IsDeleted && x.Id == itemId);

                    if (regManifestItem == null)
                        return Json(
                            ResponseData.SendFailMsg(), JsonRequestBehavior.AllowGet);

                    entities.Administration_RegistrationSessionManifestItems.Remove(regManifestItem);
                    entities.SaveChanges();

                    return Json(
                        ResponseData.SendSuccessMsg(), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllRegistrationManifestItems(int registrationSessionManifestId)
        {
            try
            {
                using (var entities = new Entities())
                {
                    var regManifests =
                        entities.Administration_RegistrationSessionManifest.FirstOrDefault(x =>
                            !x.IsDeleted && x.Id == registrationSessionManifestId);

                    if (regManifests == null)
                        return Json(
                            ResponseData.SendFailMsg(), JsonRequestBehavior.AllowGet);

                    var regManifestItems = entities.Administration_RegistrationSessionManifestItems.Where(x =>
                            !x.IsDeleted && x.RegistrationSessionManifestId == registrationSessionManifestId)
                        .OrderBy(x => x.DateOfEntry)
                        .ToList();

                    var returnData = new List<object>();

                    if (regManifests.RegistrationReaason == (int)RegistrationReason.IdCard)
                        returnData.AddRange(regManifestItems.Select(x => new
                        {
                            x.Id,
                            DateOfEntry = $"{x.DateOfEntry:yyyyMMdd}",
                            PayLoad = Newtonsoft.Json.JsonConvert.DeserializeObject<RegModelIdCard>(x.DataPayLoad)
                        }));

                    return Json(
                        ResponseData.SendSuccessMsg(data: new
                        {
                            regManifests.RegistrationReaason,
                            DataSet = returnData.ToList()
                        }), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SaveRegistrationManifests(int registrationModel, string desc)
        {
            try
            {
                using (var entities = new Entities())
                {
                    if (entities.Administration_RegistrationSessionManifest.FirstOrDefault(x =>
                            !x.IsDeleted && x.RegistrationReaason == registrationModel &&
                            x.RegistrationDesc == desc.ToUpper()) != null)
                        return Json(
                            ResponseData.SendFailMsg(
                                "A Data Manifest exists for this Registration Type with this same name. Please choose another name"),
                            JsonRequestBehavior.AllowGet);

                    var manifest = new Administration_RegistrationSessionManifest()
                    {
                        DateOfManifest = DateTime.Now, 
                        IsDeleted = false, 
                        RegistrationDesc = desc,
                        RegistrationReaason = registrationModel
                    };

                    entities.Administration_RegistrationSessionManifest.Add(manifest);
                    entities.SaveChanges();

                    return Json(
                        ResponseData.SendSuccessMsg(data: new
                        {
                            Manifest = manifest
                        }), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SaveRegistrationManifestItemIdCard(RegModelIdCard registrationModel, int registrationManifest,
            int itemId = 0)
        {
            try
            {
                using (var entity = new Entities())
                {
                    var existingData = entity.Administration_RegistrationSessionManifestItems.Where(x =>
                        !x.IsDeleted && x.RegistrationSessionManifestId == registrationManifest).ToList();

                    var list = new List<RegModelIdCard>();
                    foreach (var x in existingData)
                        list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<RegModelIdCard>(x.DataPayLoad));

                    if (list.Any(y => y.MatricNumber == registrationModel.MatricNumber))
                        return Json(ResponseData.SendFailMsg("This Matric Number has been Used"),
                            JsonRequestBehavior.AllowGet);
                }

                var location = System.Web.Hosting.HostingEnvironment.MapPath(
                                   $"~/PassportPictureFiles/Students/") ??
                               "";

                //var location = System.Web.Hosting.HostingEnvironment.MapPath(
                //                   $"~/PassportPictureFiles/{RegistrationReason.IdCard.DisplayName()}/{registrationManifest}") ??
                //               "";

                if (!Directory.Exists(location))
                    Directory.CreateDirectory(location);

                var base64String = registrationModel.Picture.Substring(23);
                var fileName = registrationModel.MatricNumber
                    .Replace("-", "0")
                    .Replace("_", "0")
                    .Replace("/", "0")
                    .Replace("\\", "0") + ".png";

                var filePath = Path.Combine(location, fileName);
                System.IO.File.WriteAllBytes(filePath, Convert.FromBase64String(base64String));

                registrationModel.PictureFileName = fileName;

                return Json(
                    SaveRegistrationModelItem(Newtonsoft.Json.JsonConvert.SerializeObject(registrationModel),
                        registrationManifest)
                        ? ResponseData.SendSuccessMsg()
                        : ResponseData.SendFailMsg(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        private bool SaveRegistrationModelItem(string modelItem, int registrationManifestId)
        {
            try
            {
                using (var entities = new Entities())
                {
                    entities.Administration_RegistrationSessionManifestItems.Add(
                        new Administration_RegistrationSessionManifestItems()
                        {
                            DataPayLoad = modelItem,
                            DateOfEntry = DateTime.Now,
                            IsDeleted = false,
                            RegistrationSessionManifestId = registrationManifestId
                        });

                    entities.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return false;
            }
        }
    }
}