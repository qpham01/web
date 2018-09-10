using BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivalServer.ViewModels
{
    public class CharacterViewModel
    {
        #region Constructor 
        public CharacterViewModel()
        {

        }
        #endregion

        #region Properties 
        public int Id { get; set; }
        public string Name { get; set; }
        public Sex Sex{ get; set; }
        public int Health { get; set; }
        public int HealthMax { get; set; }
        public int Stamina { get; set; }
        public int StaminaMax { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        #endregion
    }
}
