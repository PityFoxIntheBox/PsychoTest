//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PsychoTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users_Tests
    {
        public int Id { get; set; }
        public int Id_user { get; set; }
        public int Id_result { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Results Results { get; set; }
    }
}
