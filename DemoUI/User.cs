//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoUI
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string IDUser { get; set; }
        public string MaNV { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Quyen { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}