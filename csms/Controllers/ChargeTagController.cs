﻿using csms.Models;
using Microsoft.AspNetCore.Mvc;

namespace csms.Controllers
{
    public class ChargeTagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetChargeTagTable()
        {
            string draw = Request.Form["draw"][0];
            string order = Request.Form["order[0][column]"][0];
            string orderDir = Request.Form["order[0][dir]"][0];
            int startRec = Convert.ToInt32(Request.Form["start"][0]);
            int pageSize = Convert.ToInt32(Request.Form["length"][0]);

            var model = ChargeTagModel.GetChargeTagDatas();
            switch (order)
            {
                case "0":
                    model = orderDir == "asc" ? model.OrderBy(x => x.TagId).ToList() : model.OrderByDescending(x => x.TagId).ToList();
                    break;
                case "1":
                    model = orderDir == "asc" ? model.OrderBy(x => x.PlateNo).ToList() : model.OrderByDescending(x => x.PlateNo).ToList();
                    break;
                case "2":
                    model = orderDir == "asc" ? model.OrderBy(x => x.CustomerName).ToList() : model.OrderByDescending(x => x.CustomerName).ToList();
                    break;
                case "3":
                    model = orderDir == "asc" ? model.OrderBy(x => x.AgencyName).ToList() : model.OrderByDescending(x => x.AgencyName).ToList();
                    break;
                case "4":
                    model = orderDir == "asc" ? model.OrderBy(x => x.ExpiryDate).ToList() : model.OrderByDescending(x => x.ExpiryDate).ToList();
                    break;
                case "5":
                    model = orderDir == "asc" ? model.OrderBy(x => x.BlockedStatus).ToList() : model.OrderByDescending(x => x.BlockedStatus).ToList();
                    break;
            }

            int totalRecords = model.Count;
            if (pageSize > -1)
            {
                model = model.Skip(startRec).Take(pageSize).ToList();
            }
            else
            {
                model = model.Skip(startRec).ToList();
            }

            return new JsonResult(new { draw = draw, iTotalRecords = totalRecords, iTotalDisplayRecords = totalRecords, data = model });
        }
        public IActionResult CreateChargeTag()
        {
            string id = Request.Form["id"];
            string platenumber = Request.Form["platenumber"];
            string name = Request.Form["name"];
            string owner = Request.Form["owner"];
            string expireday = Request.Form["expireday"];

            if (string.IsNullOrEmpty(id))
            {
                return Json("รหัส RFID เป็นค่าว่าง กรุณาสแกนบัตร");
            }
            var tag = new Entities.TblChargingTag();
            tag.FCode = id;
            tag.FAgencyId = owner;
            tag.FBlocked = 'N';
            tag.FName = name;
            if (!string.IsNullOrEmpty(expireday))
                tag.FExpiryDate = DateTime.ParseExact(expireday, "dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            tag.FPlateNo = platenumber;

            ChargeTagModel.CreateChargeTag(tag);

            return Json("success");
        }
        public IActionResult UpadateChargeTag()
        {
            string id = Request.Form["id"];
            string platenumber = Request.Form["platenumber"];
            string name = Request.Form["name"];
            string owner = Request.Form["owner"];
            string expireday = Request.Form["expireday"];
            string blocked = Request.Form["blocked"];

            var model = ChargeTagModel.GetChargeTag(Guid.Parse(id));
            model.FAgencyId = owner;
            model.FBlocked = Convert.ToBoolean(blocked) ? 'Y' : 'N';
            model.FName = name;
            if (!string.IsNullOrEmpty(expireday))
                model.FExpiryDate = DateTime.ParseExact(expireday, "dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            model.FPlateNo = platenumber;

            ChargeTagModel.UpdateChargeTag(model);

            return Json("success");
        }
        public IActionResult DeleteChargeTag(string id)
        {
            var model = ChargeTagModel.GetChargeTag(Guid.Parse(id));
            ChargeTagModel.DeleteChargeTag(model);
            return Json("success");
        }
    }
}
