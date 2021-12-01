using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ShopBridgeDemo.Models;
using DAL;
using System.Collections;
using System.Data;

namespace ShopBridgeDemo.Controllers
{
    [RoutePrefix("api/Inventories")]
    public class InventoryController : ApiController
    {
        [HttpPost]
        [Route("Save")]
        public async Task<IHttpActionResult> SaveInventories(InventoryModel inventoryModel)
        {
            int res = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@Id", inventoryModel.Id.ToString());
                ht.Add("@Name", inventoryModel.Name.ToString());
                ht.Add("@Description", inventoryModel.Description.ToString());
                ht.Add("@Price", inventoryModel.Price.ToString());

                res = ExecuteNonQuery.InsertUpdateDelete("SP_SAVE_INVENTORIES", ht);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            if (res == 1)
            {
                return Ok("Success");
            }
            else
            {
                return Ok("Unable to save");
            }

        }
        [HttpGet]
        [Route("Get")]
        public async Task<DataTable> GetInventories()
        {
            try
            {
                Hashtable ht = new Hashtable();
                return ExecuteDataSet.Fetch("SP_GET_INVENTORIES", ht).Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<int> DeleteInventories(int id)
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@Id", id.ToString());
                return ExecuteNonQuery.InsertUpdateDelete("SP_DELETE_BY_ID", ht);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
