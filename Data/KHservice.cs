namespace BlazorThucTap.Data
{
    public class KHservice
    {
        public readonly GetDataKH objGetDataKH;

        public KHservice(GetDataKH CusData)
        {
            objGetDataKH = CusData;
        }

        public string Create(CustomerInfo objCus)
        {
            objGetDataKH.AddCustomer(objCus);
            return "Thêm thành công";
        }

        public List<CustomerInfo> GetCustomer()
        {
            List<CustomerInfo> customers = objGetDataKH.GetAllKH().ToList();
            return customers;
        }

        public CustomerInfo GetKHByID(int id)
        {
            CustomerInfo customer = objGetDataKH.GetCusData(id);
            return customer;
        }

        public string UpdateKH(CustomerInfo objCus)
        {
            objGetDataKH.UpdateCus(objCus);
            return "Cập nhật thành công";
        }

        public string DeleteCus(CustomerInfo objcus)
        {
            objGetDataKH.DeleteCus(objcus.ID);
            return "Xóa thành công";
        }
    }
}