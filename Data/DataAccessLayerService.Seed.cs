using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public partial class DataAccessLayerService : IDataAccessLayerService

    {
        #region Seed
        public void Seed()
        {

            ctx.Add(new Student
            {
                Name = "Marin Chitac",
                Age = 43,
                Address = new Address
                {
                    City = "Iasi",
                    Street = "Revolutiei",
                    Number = 32
                }
            });

            ctx.Add(new Student
            {
                Name = "Florin Dumitrescu",
                Age = 38,
                Address = new Address
                {
                    City = "Bucuresti",
                    Street = "Pietei",
                    Number = 13
                }
            });
            ctx.Add(new Student
            {
                Name = "Ionel Lupu",
                Age = 23,
                Address = new Address
                {
                    City = "Cluuuj",
                    Street = "Centrala",
                    Number = 14
                }

            });
            ctx.Add(new Student
            {
                Name = "Mihaela Popa",
                Age = 18,
                Address = new Address
                {
                    City = "Deva",
                    Street = "Principala",
                    Number = 4
                }

            });

            ctx.SaveChanges();

        }
        #endregion
    }
}
