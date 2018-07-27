//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace cadastro_remedios
//{
//    public class Adress
//    {
//        public bool GetAdressByZipCode(string pZipCode)
//        {
//            string pStreet;
//            string pCity;
//            string pDistrict;
//            string pRegionState;
//            string pError;

//            try
//            {
//                if (pZipCode != string.Empty)
//                {
//                    using (var ws = new WSCorreios.AtendeClienteClient())
//                    {
//                        var result = ws.consultaCEP(pZipCode);
//                        pRegionState = result.uf;
//                        pCity = result.cidade;
//                        pDistrict = result.bairro;
//                        pStreet = result.end;
//                        Cadastro_Funcionario lEmployee = new Cadastro_Funcionario();
//                        lEmployee.VerifyFields(pStreet, pCity, pDistrict, pRegionState);
//                    }

//                }
//                else
//                {
//                    pError = Errors.lZipCodeInvalid;
//                    Cadastro_Funcionario lEmployee = new Cadastro_Funcionario();
//                    lEmployee.VerifyFields(pStreet = null, pCity = null, pDistrict = null, pRegionState = null, pError);

//                }
//            }
//            catch (Exception ex)
//            {
//                pError = ex.Message;
//                return false;
//            }
//            return true;
//        }
//    }
//}
