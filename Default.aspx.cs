using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MFCChatClient;

namespace AellaData
{
    public partial class AellaData : System.Web.UI.Page
    {
        void Page_Load(object sender, EventArgs evt)
        {
            var processed = false;
            var client = new MFCClient();

            client.UsersProcessed += (s, e) =>
            {
                processed = true;
            };

            var now = DateTime.Now;
            var timeout = now.AddSeconds(30);
            while (!processed && DateTime.Now < timeout) { };

            if (!processed)
            {
                Response.Write("Timed out");
                Response.End();
            }

            var rawList = client.Users.ToList();

            Camscores.DataSource = rawList.Where(model => model.Value.ModelDetails.Camscore > 3000)
             .Select(user => new { Model = user.Value.Name, CamScore = user.Value.ModelDetails.Camscore })
             .OrderByDescending(x => x.CamScore);

            Camscores.DataBind();

            CamscoresGrouped.DataSource = 	rawList.Where(model => model.Value.ModelDetails.Camscore > 3000)
		        .Select(user => new {Model=user.Value.Name, Camscore = user.Value.ModelDetails.Camscore, Modded=(Math.Truncate((decimal)user.Value.ModelDetails.Camscore / 1000))*1000})
		        .GroupBy(k => k.Modded)
		        .Select(x => new {Camscore=x.Key, Count = x.Count()})
		        .OrderByDescending(y=> y.Camscore);

            CamscoresGrouped.DataBind();

        }
    }
}