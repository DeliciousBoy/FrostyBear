using System.ComponentModel.DataAnnotations;


namespace FrostyBear.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "กรุณาป้อนชื่อผู้ใช้")]
        public string EmployeeUsername { get; set; }

        [Required(ErrorMessage = "กรุณาป้อนรหัสผ่าน")]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
    }
}

