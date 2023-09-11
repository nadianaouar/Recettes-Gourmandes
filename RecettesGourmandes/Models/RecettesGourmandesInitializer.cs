using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Web;
using System.Web.Routing;
using System.Web.Services.Description;
using System.Web.Caching;
using Antlr.Runtime;
using Microsoft.SqlServer.Server;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;

namespace RecettesGourmandes.Models
{
    public class RecettesGourmandesInitializer : DropCreateDatabaseIfModelChanges<RecettesGourmandesContext>
    {
        protected override void Seed(RecettesGourmandesContext context)
        {
            base.Seed(context);
            var recettes = new List<Recette>
            {
                new Recette
                {
                    NomRecette= "Gateau roulé aux fraises",
                    Description= "Par portion: calories 369; protéines 7 g; M.G. 16 g; glucides 59 g; fibres 2 g; fer 2 mg; calcium 71 mg; sodium 129 mg",
                    RecetteImage= GetFileByte("\\Images\\gateau-roule-a-la-confiture-de-fraises.jpg"),
                    RecetteImageType="image/jpg"

                    
                },
                new Recette
                {
                    NomRecette= "Gateau au chocolat",
                    Description= "Par portion: calories 598; protéines 8 g; matières grasses 35 g; glucides 65 g; fibres 4 g; fer 4 mg; calcium 66 mg; sodium 82 mg",
                    RecetteImage= GetFileByte("\\Images\\gateau-au-chocolat.jpg"),
                    RecetteImageType="image/jpg"
                }
            };
            recettes.ForEach(recette => context.Recettes.Add(recette));
            context.SaveChanges();
        }

        private byte[] GetFileByte(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}