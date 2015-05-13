using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerArchitectureApp.DAL;
using LayerArchitectureApp.MODEL;

namespace LayerArchitectureApp.BLL
{
    
    public class PersonManager
    {
        PersonGateWay aPersonGateWay = new PersonGateWay();
        public string InsertIntoManager(PersonClass aPerson)
        {
            PersonClass isNameExits = aPersonGateWay.IsNameExists(aPerson.name);
            if (isNameExits!=null)
            {
                return "Name is already exits";
            }

            else
            {
                int isSaved = aPersonGateWay.InsertIntoGateWay(aPerson);

                if (isSaved > 0)
                {
                    return "Saved";
                }
                else
                {
                    return "Unsaved";
                }
            }
            
            }

        public List<PersonClass> GetAllPerson()
        {
            return aPersonGateWay.GetAllPerson();
        }

        public PersonClass GetPersonByID(int personID)
        {
            return aPersonGateWay.GetPersonByID(personID);
        }

        public string Update(PersonClass aPerson)
        {
            int isUpdate = aPersonGateWay.Update(aPerson);
            if (isUpdate>0)
            {
                return "Successfully Update";
            }
            else
            {
                return "Sorry. Update failed.\n";
            }
        }

        public string Delete(PersonClass aPerson)
        {
            int isDelete = aPersonGateWay.Delete(aPerson);
            if (isDelete > 0)
            {
                return "Successfully Delete";
            }
            else
            {
                return "Sorry. Delete failed.\n";
            }
        }
    }
}
